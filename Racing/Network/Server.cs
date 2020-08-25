using Racing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing
{
    public class Server
    {
        private TcpListener connectionListener { get; set; }
        private TcpClient client { get; set; }
        private P2_Network network { get; set; }
        private NetworkStream serverStream { get; set; }
        private bool IsConnected { get; set; } = false;

        public Server(P2_Network network)
        {
            this.network = network;
        }

        public void SendData(byte[] data, int offset, int size)
        {
            serverStream.Write(data, offset, size);
        }

        public void Disconnect()
        {
            IsConnected = false;

            connectionListener.Stop();
            serverStream.Close();
            client.Close();
        }

        public async Task<bool> Start()
        {
            // Создание сервера для прослушивания входящих соединений на указанный IP-адрес и номер порта
            IPAddress localAddr = IPAddress.Parse(ConnectionData.IPAddr);
            connectionListener = new TcpListener(localAddr, ConnectionData.Port);

            // Начало прослушки запросов клиентов на подключение
            connectionListener.Start();

            MessageBox.Show("Ожидание клиента.");

            // Ожидание запроса клиента на подключение
            client = await connectionListener.AcceptTcpClientAsync();

            // Получение потока для чтения и записи данных
            serverStream = client.GetStream();

            // Подключение установлено
            IsConnected = true;

            return true;
        }

        public async void Work()
        {
            // Буфер для чтения данных
            byte[] bytes = new byte[ConnectionData.BufSize];
            string data;
            int CountOfReadBytes;

            try
            {
                // Получение данных от клиента
                while (((CountOfReadBytes = await serverStream.ReadAsync(bytes, 0, bytes.Length)) != 0) && IsConnected)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, CountOfReadBytes); // Перевод из массива байт в string

                    if (network.DataProcessing(bytes, network.game, data))
                    {
                        bytes[0] = 0xF;
                        SendData(bytes, 0, bytes.Length);
                        break;
                    }

                }
                // Разрыв соединения
                Disconnect();

                MessageBox.Show("Соединение с клиентом потеряно. ");
                network.game.finishGame();
                network.game.Close();
                return;
            }
            catch (ObjectDisposedException) // Если произошло закрытие потока со стороны сервера
            {
                return;
            }
            catch (System.IO.IOException) // Если клиент разорвал соединение
            {
                MessageBox.Show("Клиент закрыл программу." + network.game.contenderPoints.ToString());

                // Разрыв соединения со стороны сервера
                Disconnect();
                network.game.Close();
                return;
            }
        }

    }
}
