using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Racing
{

    public partial class FormGame : Form
    {
        public enum GameType
        {
            Solo, Multiplayer
        }

        FormGameCreate parent;

        //Cостояние игры
        public int carPosition;
        public int tickCount;
        public static int carsAvoid;
        private int speed;
        private int downcarsCount;

        public int bestScore;

        // Частота появления машин
        public int ticks;

        //Состояние игроков
        public int contenderAlive;
        public int contenderReplay;
        public int contenderPoints;

        public int selfAlive;
        public int selfPoints;
        public int selfReplay;

        //Таймеры игры и анимации
        public System.Timers.Timer aTimer_game;
        public System.Timers.Timer aTimer_animation;
        public System.Timers.Timer aTimer_start;

        int[,] downCars = new int[3, 3];

        // Игровая зона
        public int leftBorder = 2;
        public int rightBorder = 8;

        // Поле
        public const int width = 10, height = 18, k = 35;
        public int[,] field = new int[width, height];

        public int blackLine;
        public int[] road;   // Боковые полосы

        // Машины
        readonly int[,] UpCar =  {
							{ 0, 1, 0 },
							{ 1, 1, 1 },
							{ 0, 1, 0 },
							{ 1, 0, 1 } 
						};

        readonly int[,] DownCar = { 
							{ 1, 0, 1 },
							{ 0, 1, 0 }, 
							{ 1, 1, 1 }, 
							{ 0, 1, 0 } 
						};

        public Bitmap bitfield;
        public Graphics gr;
        public int gameMode;

        private P2_Network networkUnit;

        public FormGame(int mode, P2_Network link, FormGameCreate parent_form)
        {
            InitializeComponent();
            parent = parent_form;
            networkUnit = link;
            gameMode = mode;

            using (FileStream file1 = new FileStream("BestScore.txt", FileMode.OpenOrCreate))
            {
                StreamReader reader = new StreamReader(file1);
                if (!reader.EndOfStream)
                {
                    string result = reader.ReadToEnd();
                    bestScore = Convert.ToInt32(result);
                }
                else
                    bestScore = 0;

                reader.Close();
            }
                  
            startGame(gameMode);
        }

        private void button_back_from_game_Click(object sender, EventArgs e)
        {
            Sound.play_menu_button();
            aTimer_game.Dispose();
            aTimer_animation.Dispose();
            aTimer_start.Dispose();

            if (gameMode == 1)
            {
                sendMessage(1, 1);
                networkUnit.Disconnect();
            }

            this.Close();
        }

        delegate void Del(string text);
        delegate void Close_Form(FormGame game);

        public void createCar(int[,] car, int x, int y)
        {
            for (int i = y; i < y + 4; i++) // Car
                for (int j = x; j < x + 3; j++)
                { 
                    if(x>=0 && y>=0)
                        field[j, i] = car[i - y, j - x];
                }
        }

        private int startAnimationDigit = 5;

        public void startAnimation(object sender, System.EventArgs e)
        {
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    field[i, j] = 0;

            // Цифры
            switch (startAnimationDigit)
            {
                case 5:
                    for (int i = 2; i <= 7; i++)  // Width
                        for (int j = 5; j <= 6; j++) // Height
                        {
                            field[i, j] = 1;
                            field[i, j + 5] = 1;
                            field[i, j + 10] = 1;
                        }
                    for (int i = 2; i <= 3; i++)  // Width
                        for (int j = 7; j <= 9; j++) // Height
                            field[i, j] = 1;
                    for (int i = 6; i <= 7; i++)  // Width
                        for (int j = 12; j <= 14; j++) // Height
                            field[i, j] = 1;
                    break;
                case 4:
                    for (int i = 2; i <= 3; i++)  // Width
                        for (int j = 5; j <= 11; j++) // Height
                            field[i, j] = 1;
                    for (int i = 6; i <= 7; i++)  // Width
                        for (int j = 5; j <= 16; j++) // Height
                            field[i, j] = 1;
                    for (int i = 4; i <= 5; i++)  // Width
                        for (int j = 10; j <= 11; j++) // Height
                            field[i, j] = 1;
                    break;
                case 3:
                    for (int i = 2; i <= 7; i++)  // Width
                        for (int j = 5; j <= 6; j++) // Height
                        {
                            field[i, j] = 1;
                            field[i, j + 5] = 1;
                            field[i, j + 10] = 1;
                        }
                    for (int i = 6; i <= 7; i++)  // Width
                        for (int j = 5; j <= 16; j++) // Height
                            field[i, j] = 1;
                    break;
                case 2:
                    for (int i = 2; i <= 7; i++)  // Width
                        for (int j = 5; j <= 6; j++) // Height
                        {
                            field[i, j] = 1;
                            field[i, j + 5] = 1;
                            field[i, j + 10] = 1;
                        }
                    for (int i = 6; i <= 7; i++)  // Width
                        for (int j = 7; j <= 9; j++) // Height
                            field[i, j] = 1;

                    for (int i = 2; i <= 3; i++)  // Width
                        for (int j = 12; j <= 14; j++) // Height
                            field[i, j] = 1;
                    break;
                case 1:
                    for (int i = 4; i <= 5; i++)  // Width
                        for (int j = 5; j <= 16; j++) // Height
                            field[i, j] = 1;           
                    break;
            }
            startAnimationDigit--;

            if (startAnimationDigit < 0)
            {
                aTimer_start.Enabled = false;

                createCar(UpCar, 2, 14);

                for (int i = 0; i < height; i++)
                {
                    field[0, i] = road[i];
                    field[width - 1, i] = road[i];
                }

                fillField();
                aTimer_game.Enabled = true;
            }
            Sound.play_game_count(); 
            
            fillField();
        }

        public void startGame(int mode)
        {
            bitfield = new Bitmap(k * width + 1, k * height - 4);
            gr = Graphics.FromImage(bitfield);
            
            if(gameMode == 1)
                networkUnit.dialog_show = false;

            if (aTimer_animation != null)
                aTimer_animation.Enabled = false;

            aTimer_game = new System.Timers.Timer(180);
            aTimer_game.Elapsed += TickTimer_Tick;

            aTimer_animation = new System.Timers.Timer(50);
            aTimer_animation.Elapsed += deathAnimation;

            aTimer_start = new System.Timers.Timer(1000);
            aTimer_start.Elapsed += startAnimation;

            selfPoints = 0;
            selfReplay = 0;
            selfAlive = 0;

            contenderReplay = 0;
            contenderPoints = 0;
            contenderAlive = 0;

            carsAvoid = 0;
            speed = 1;

            // Вывод скорости игры
            if (label_num_speed.InvokeRequired)
                label_num_speed.Invoke(new Del((s) => label_num_speed.Text = s), speed.ToString());
            else
                label_num_speed.Text = speed.ToString();

            if (label_n_score_self.InvokeRequired)
                label_n_score_self.Invoke(new Del((s) => label_n_score_self.Text = s), selfPoints.ToString());
            else
                label_n_score_self.Text = selfPoints.ToString();

            if (label_n_score_contender.InvokeRequired)
                label_n_score_contender.Invoke(new Del((s) => label_n_score_contender.Text = s), contenderPoints.ToString());
            else
                label_n_score_contender.Text = contenderPoints.ToString();


            road = new int[] { 1,1,0,0,0,1,1,0,0,0,1,1,0,0,0,1,1,0,0,0};

            ticks = 0;
            carPosition = 0;
            downcarsCount = 0;

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    field[i, j] = 0;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    downCars[i, j] = 0;

            int x = 2, y = 14;


            if (mode == 1)
            {
                aTimer_start.Enabled = true;
            }

            if (mode == 0)
            {
                createCar(UpCar, x, y);

                for (int i = 0; i < height; i++)
                {
                    field[0, i] = road[i];
                    field[width - 1, i] = road[i];
                }

                fillField();
                aTimer_game.Enabled = true;
            }

        }

        // Диалог - ПЕРЕИГРАТЬ ИЛИ ВЫЙТИ
        public bool replayDialog(string result)
        {
            string text;

            if (gameMode == 0)
                text = "Ваш результат - " + selfPoints + ".\n" +
                "Лучший результат: " + bestScore + ".\n" + "Переиграть?";
            else
                text = result;


            DialogResult dr = MessageBox.Show(text, "Сообщение",
                MessageBoxButtons.YesNo);

            
            if (dr == System.Windows.Forms.DialogResult.Yes) // Переиграть
            {
                selfReplay = 1;
                if (gameMode == 1)
                {
                    sendMessage(0, 1);
                }
                else
                {
                    startGame(gameMode);
                }
                return true;
            }
            else  // Выйти
            {
                if (gameMode == 1)
                {
                    sendMessage(1, 0);
                }
                else
                {
                    if (this.InvokeRequired)
                        this.Invoke(new Close_Form((s) => s.Close()), this);
                    else
                        this.Close();
                }
                return false;
            }

        }

        public void finishGame()
        {
            Sound.play_game_crash();


            // Анимация взрыва
            blackLine = height;

            aTimer_animation.Enabled = true;

            // Запись рекорда в файл
            if (bestScore < selfPoints)
            {
                bestScore = selfPoints;
                using (FileStream bestScoreFile = new FileStream("BestScore.txt", FileMode.Create))
                {
                    StreamWriter reader = new StreamWriter(bestScoreFile);
                    reader.WriteLine(selfPoints.ToString());
                    reader.Close();
                }
            }

            selfAlive = 1;

            if (gameMode == 1)
            {
                sendMessage(1, 0);
                
                if (selfAlive == 1 && contenderAlive == 1)
                {
                    string result;

                    if (selfPoints > contenderPoints)
                        result = "Победа!\n" + "Ваш результат - " + selfPoints +
                            "\nРезультат соперника - " + contenderPoints;
                    else if (selfPoints < contenderPoints)
                        result = "Поражение!\n" + "Ваш результат - " + selfPoints +
                            "\nРезультат соперника - " + contenderPoints;
                    else
                        result = "Ничья!\n" + "Ваш результат - " + selfPoints +
                            "\nРезультат соперника - " + contenderPoints;
                    result = result + "\nПереиграть?";
                    
                    replayDialog(result);
                   
                    if (selfReplay == 1)
                    {
                        if (contenderReplay == 1)
                            startGame(1);
                    }
                    else
                    {
                        networkUnit.Disconnect();
                        this.Close();
                    }
                        
                }
            }
            else
                replayDialog("");
        }

        public void fillField()
        {
            try
            {
                gr.Clear(Color.Transparent);
                Color newColor = Color.FromArgb(255, 178, 190, 186);

                for (int i = 0; i < width; i++)
                    for (int j = 4; j < height; j++)
                        if (field[i, j] == 1)
                        {
                            gr.FillRectangle(Brushes.Black, i * k, (j - 4) * k, k, k);
                            gr.FillRectangle(new SolidBrush(newColor), i * k + 5, (j - 4) * k + 5, k - 10, k - 10);
                            gr.FillRectangle(Brushes.Black, i * k + 10, (j - 4) * k + 10, k - 20, k - 20);
                            gr.DrawRectangle(Pens.Black, i * k, (j - 4) * k, k, k);
                        }

                FieldPictureBox.Image = bitfield;
            }
            catch
            { 
            
            }
        }

        public void moveRoad()
        {
            tickCount = (tickCount + 1) % 4;
            int last = road[20-1];

            // Сдвиг массива полос
            if (tickCount == 0)
            {
                for (int i = 20 - 1; i > 0; i--) 
                {
                    road[i] = road[i - 1];
                }
                road[0] = last;
            }

            // Сдвиг дороги
            if (carPosition == 0) // Сдвиг около машины
            {
                for (int i = height - 1; i > height - 5; i--)
                    for (int j = 5; j < width - 2; j++)
                    {
                        field[j, i] = field[j, i - 1];
                    }
            }
            else
            {
                for (int i = height - 1; i > height - 5; i--)
                    for (int j = 2; j < width - 5; j++)
                    {
                        field[j, i] = field[j, i - 1];
                    }

            }

            for (int i = 0; i < height; i++) 
            {
                field[0, i] = road[i];
                field[width - 1, i] = road[i];
            }
            for (int i = height - 5; i > 0; i--) 
                for (int j = 1; j < width - 2; j++)
                {
                    field[j, i] = field[j, i - 1];
                }
            for (int j = 1; j < width - 2; j++)
            {
                field[j, 0] = 0;
            }
        }

        public bool checkEnd()
        {
            bool result;
            if (carPosition == downCars[0,0] && downCars[0, 2] >= 13)
                result = true;
            else
                result = false;

            return result;
        }

        public void moveLeft()
        {
            if (carPosition != 0)
            {
                for (int i = height - 4; i < height; i++)
                    for (int j = 5; j < 8; j++)
                    {
                        field[j - 3, i] = field[j, i];
                        field[j, i] = 0;
                    }
                carPosition = 0;
            }
        }
        public void moveRight()
        {
            if (carPosition != 1)
            {
                for (int i = height - 4; i < height; i++)
                    for (int j = 2; j < 5; j++)
                    {
                        field[j + 3, i] = field[j, i];
                        field[j, i] = 0;
                    }
                carPosition = 1;
            }
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (selfAlive != 1)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        Sound.play_game_move();
                        moveLeft();
                        fillField();
                        if (checkEnd() == true)
                        {
                            aTimer_game.Enabled = false;
                            finishGame();
                        }
                        break;
                    case Keys.D:
                        Sound.play_game_move();
                        moveRight();
                        fillField();
                        if (checkEnd() == true)
                        {
                            aTimer_game.Enabled = false;
                            finishGame();
                        }
                        break;
                    case Keys.W:
                        Tick();
                        break;
                }
            }
        }
        
        public void deathAnimation(object sender, System.EventArgs e)
        {
            for (int i = 0; i < width; i++)
            {
                field[i, blackLine - 1] = 1;
            }
            blackLine--;
            if (blackLine == 0)
                aTimer_animation.Enabled = false;
            fillField();
        }

        // Функция отправки сообщения
        public void sendMessage(byte lparam, byte pparam)
        {
            byte[] data = new byte[512];
            byte[] data_buf;
            data[0] = lparam;
            data[1] = pparam;
            data[2] = (byte)selfPoints.ToString().Length;

            data_buf = Encoding.ASCII.GetBytes(selfPoints.ToString());

            for (int i = 0; i < data[2]; i++)
            {
                data[3 + i] = data_buf[i];
            }

            networkUnit.SendData(data, 0, data.Length);
        }

        // Функция, срабатывающая по таймеру
        public void Tick()
        {
            if (downCars[0, 2] >= 20)
            {
                for (int i = 0; i < downcarsCount - 1; i++)
                {
                    downCars[i, 0] = downCars[i + 1, 0];
                    downCars[i, 1] = downCars[i + 1, 1];
                    downCars[i, 2] = downCars[i + 1, 2];
                }

                if (carsAvoid == 0 || downCars[0, 2] >= 20)
                {
                    carsAvoid = carsAvoid + 1;
                    
                    //Каждые 10 машин увеличивается скорость игры 
                    if (carsAvoid % 10 == 0)
                    {
                        aTimer_game.Interval = aTimer_game.Interval * 0.8;
                        speed++;
                        if (label_num_speed.InvokeRequired)
                            label_num_speed.Invoke(new Del((s) => label_num_speed.Text = s), speed.ToString());
                        else
                            label_num_speed.Text = speed.ToString();
                    }

                    //100 очков за 1 машину
                    selfPoints = carsAvoid * 100;

                    if (label_n_score_self.InvokeRequired)
                        label_n_score_self.Invoke(new Del((s) => label_n_score_self.Text = s), selfPoints.ToString());
                    else
                        label_n_score_self.Text = selfPoints.ToString();

                    if(gameMode == 1)
                        sendMessage(0, 0);
                }
            }

            if (ticks == 0)
            {
                Random rand = new Random();
                int position = rand.Next() % 2;
                if (position == 0)
                {
                    createCar(DownCar, 2, 0);
                }
                else
                {
                    createCar(DownCar, 5, 0); 
                }

                if (downcarsCount < 3)
                {
                    downCars[downcarsCount, 0] = position;
                    downCars[downcarsCount, 1] = 0;
                    downCars[downcarsCount, 2] = 3;
                    downcarsCount++;
                }
                else
                {
                    downCars[downcarsCount - 1, 0] = position;
                    downCars[downcarsCount - 1, 1] = 0;
                    downCars[downcarsCount - 1, 2] = 3;
                }
            }

            ticks = (ticks + 1) % 10;
            moveRoad();
            fillField();

            if (checkEnd() == true)
            {
                aTimer_game.Enabled = false;
                finishGame();
            }

            for (int i = 0; i < downcarsCount; i++)
                downCars[i, 2]++;

        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        public void TickTimer_Tick(object sender, System.EventArgs e)
        {
            Tick();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
         
        }
    }
}


