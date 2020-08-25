using Racing;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;


public class P2_Network
{
    // Тип сетевого ресурса (Клиент/Сервер)
    public enum ResType
    {
        Server, Client
    }

    private bool IsServer { get; set; } = false;

    private Racing.FormGameCreate parent;

    public Server server = null;
    public Client client = null;

    // Конструктор сервера и клиента
    public P2_Network(ResType type, string IP, Racing.FormGameCreate parent_form)
    {
        parent = parent_form;
        if (type == ResType.Server)
        {
            IsServer = true;
            server = new Server(this);
        }
        else
        {
            client = new Client(this);
        }

        ConnectionData.IPAddr = IP;
    }

    delegate void Del(string text);
    public bool dialog_show = false;
    public Racing.FormGame game;

    public void Disconnect()
    {
        if (IsServer)
            server.Disconnect();
        else
            client.Disconnect();
    }

    public void SendData(byte[] data, int offset, int size)
    {
        if (IsServer)
            server.SendData(data, offset, size);
        else
            client.SendData(data, offset, size);
    }
	
    public bool DataProcessing(byte[] bytes, Racing.FormGame game, string data)
    {
        if (bytes[0] == 0xF)
            return true;

        byte alive = bytes[0];
        byte replay = bytes[1];
        byte pointsLength = bytes[2];

        string points_contender = data.Substring(3, pointsLength);

        game.contenderPoints = Int32.Parse(points_contender);

        if (game.label_n_score_contender.InvokeRequired)
            game.label_n_score_contender.Invoke(new Del((s) => game.label_n_score_contender.Text = s), points_contender.ToString());
        else
            game.label_n_score_contender.Text = game.contenderPoints.ToString();

        if (alive == 1 && replay == 0)
        {
            game.contenderAlive = 1;

            if (game.selfAlive == 1 && game.contenderAlive == 1 && !dialog_show)
            {
                string result;

                if (game.selfPoints > game.contenderPoints)
                    result = "Победа!\n" + "Ваш результат - " + game.selfPoints +
                        "\nРезультат соперника - " + game.contenderPoints;
                else if (game.selfPoints < game.contenderPoints)
                    result = "Поражение!\n" + "Ваш результат - " + game.selfPoints +
                        "\nРезультат соперника - " + game.contenderPoints;
                else
                    result = "Ничья!\n" + "Ваш результат - " + game.selfPoints +
                        "\nРезультат соперника - " + game.contenderPoints;

                result = result + "\nПереиграть?";
                dialog_show = true;
                if (game.replayDialog(result) == false)
                    return true;
            }
        }

        if (alive == 0 && replay == 1)
        {
            game.contenderReplay = 1;
            if (game.selfReplay == 1 && game.contenderReplay == 1)
            {
                game.startGame(game.gameMode);
            }
        }

        if (alive == 1 && replay == 1)
            return true;

        return false;
    }

    public async void Start()
    {
        bool isConnected;
        if (IsServer)
            isConnected = await server.Start();
        else
            isConnected = client.Start();

        if (isConnected)
        {
            game = new FormGame(1, this, parent);
            game.Show();
            parent.Hide();

            if (IsServer)
                server.Work();
            else
                client.Work();
        }
    }
}