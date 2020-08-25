using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing
{
    public class Client
    {
        private P2_Network network { get; set; }
        private TcpClient clientConnection { get; set; }
        private NetworkStream clientStream { get; set; }
        private bool isConnected { get; set; } = false;

        public Client(P2_Network network)
        {
            this.network = network;
        }
        public void SendData(byte[] data, int offset, int size)
        {
            clientStream.Write(data, offset, size);
        }

        public void Disconnect()
        {
            isConnected = false;

            clientStream.Close();
            clientConnection.Close();
        }

        public bool Start()
        {
            try
            {
                // Создание клиента и подключение его к указанному порту заданного узла
                clientConnection = new TcpClient(ConnectionData.IPAddr, ConnectionData.Port);

                // Получение потока для чтения и записи данных
                clientStream = clientConnection.GetStream();

                // Подключение установлено
                isConnected = true;

                return true;
            }
            catch (SocketException)
            {
                MessageBox.Show("Конечный компьютер по адресу: " + ConnectionData.IPAddr + " отверг запрос на подключение.");
                return false;
            }
        }

        public async void Work()
        {
            // Буфер для чтения данных
            byte[] bytes = new byte[ConnectionData.BufSize];
            string data;

            // Число прочитанных байт
            int countOfReadBytes;

            try
            {
                // Получение данных от сервера
                while (((countOfReadBytes = await clientStream.ReadAsync(bytes, 0, bytes.Length)) != 0) && isConnected)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, countOfReadBytes); // Перевод из массива байт в string

                    if (network.DataProcessing(bytes, network.game, data))
                    {
                        bytes[0] = 0xF;
                        SendData(bytes, 0, bytes.Length);
                        break;
                    }
                }

                // Разрыв соединения
                Disconnect();

                MessageBox.Show("Соединение с сервером потеряно.");
                network.game.finishGame();
                network.game.Close();
            }
            catch (System.IO.IOException) // Если сервер разорвал соединение
            {
                MessageBox.Show("Сервер закрыл программу." + network.game.contenderPoints.ToString());
                network.game.Close();

                // Разрыв соединения со стороны клиента
                Disconnect();
            }
        }
    }
}
