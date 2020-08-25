namespace Racing
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.button_back_from_game = new System.Windows.Forms.Button();
            this.label_t_score_self = new System.Windows.Forms.Label();
            this.label_text_speed = new System.Windows.Forms.Label();
            this.label_n_score_self = new System.Windows.Forms.Label();
            this.label_num_speed = new System.Windows.Forms.Label();
            this.label_n_score_contender = new System.Windows.Forms.Label();
            this.label_t_score_contender = new System.Windows.Forms.Label();
            this.FieldPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_back_from_game
            // 
            this.button_back_from_game.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back_from_game.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back_from_game.Location = new System.Drawing.Point(370, 442);
            this.button_back_from_game.Name = "button_back_from_game";
            this.button_back_from_game.Size = new System.Drawing.Size(88, 42);
            this.button_back_from_game.TabIndex = 7;
            this.button_back_from_game.Text = "Выйти в меню";
            this.button_back_from_game.UseVisualStyleBackColor = true;
            this.button_back_from_game.Click += new System.EventHandler(this.button_back_from_game_Click);
            // 
            // label_t_score_self
            // 
            this.label_t_score_self.BackColor = System.Drawing.Color.Transparent;
            this.label_t_score_self.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_t_score_self.ForeColor = System.Drawing.Color.Black;
            this.label_t_score_self.Location = new System.Drawing.Point(362, 21);
            this.label_t_score_self.Name = "label_t_score_self";
            this.label_t_score_self.Size = new System.Drawing.Size(100, 34);
            this.label_t_score_self.TabIndex = 8;
            this.label_t_score_self.Text = "Ваши очки:";
            this.label_t_score_self.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_text_speed
            // 
            this.label_text_speed.BackColor = System.Drawing.Color.Transparent;
            this.label_text_speed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_text_speed.ForeColor = System.Drawing.Color.Black;
            this.label_text_speed.Location = new System.Drawing.Point(362, 189);
            this.label_text_speed.Name = "label_text_speed";
            this.label_text_speed.Size = new System.Drawing.Size(100, 23);
            this.label_text_speed.TabIndex = 9;
            this.label_text_speed.Text = "Скорость:";
            this.label_text_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_n_score_self
            // 
            this.label_n_score_self.BackColor = System.Drawing.Color.Transparent;
            this.label_n_score_self.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_n_score_self.ForeColor = System.Drawing.Color.Black;
            this.label_n_score_self.Location = new System.Drawing.Point(362, 55);
            this.label_n_score_self.Name = "label_n_score_self";
            this.label_n_score_self.Size = new System.Drawing.Size(100, 23);
            this.label_n_score_self.TabIndex = 10;
            this.label_n_score_self.Text = "0";
            this.label_n_score_self.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_num_speed
            // 
            this.label_num_speed.BackColor = System.Drawing.Color.Transparent;
            this.label_num_speed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_num_speed.ForeColor = System.Drawing.Color.Black;
            this.label_num_speed.Location = new System.Drawing.Point(362, 212);
            this.label_num_speed.Name = "label_num_speed";
            this.label_num_speed.Size = new System.Drawing.Size(100, 23);
            this.label_num_speed.TabIndex = 11;
            this.label_num_speed.Text = "0";
            this.label_num_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_n_score_contender
            // 
            this.label_n_score_contender.BackColor = System.Drawing.Color.Transparent;
            this.label_n_score_contender.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_n_score_contender.ForeColor = System.Drawing.Color.Black;
            this.label_n_score_contender.Location = new System.Drawing.Point(362, 124);
            this.label_n_score_contender.Name = "label_n_score_contender";
            this.label_n_score_contender.Size = new System.Drawing.Size(100, 23);
            this.label_n_score_contender.TabIndex = 13;
            this.label_n_score_contender.Text = "0";
            this.label_n_score_contender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_t_score_contender
            // 
            this.label_t_score_contender.BackColor = System.Drawing.Color.Transparent;
            this.label_t_score_contender.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_t_score_contender.ForeColor = System.Drawing.Color.Black;
            this.label_t_score_contender.Location = new System.Drawing.Point(362, 78);
            this.label_t_score_contender.Name = "label_t_score_contender";
            this.label_t_score_contender.Size = new System.Drawing.Size(96, 46);
            this.label_t_score_contender.TabIndex = 12;
            this.label_t_score_contender.Text = "Очки соперника:";
            this.label_t_score_contender.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FieldPictureBox
            // 
            this.FieldPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.FieldPictureBox.Location = new System.Drawing.Point(3, 2);
            this.FieldPictureBox.Name = "FieldPictureBox";
            this.FieldPictureBox.Size = new System.Drawing.Size(356, 491);
            this.FieldPictureBox.TabIndex = 14;
            this.FieldPictureBox.TabStop = false;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(470, 496);
            this.Controls.Add(this.FieldPictureBox);
            this.Controls.Add(this.label_n_score_contender);
            this.Controls.Add(this.label_t_score_contender);
            this.Controls.Add(this.label_num_speed);
            this.Controls.Add(this.label_n_score_self);
            this.Controls.Add(this.label_text_speed);
            this.Controls.Add(this.label_t_score_self);
            this.Controls.Add(this.button_back_from_game);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGame_FormClosing);
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FieldPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_back_from_game;
        public System.Windows.Forms.Label label_t_score_self;
        public System.Windows.Forms.Label label_text_speed;
        public System.Windows.Forms.Label label_n_score_self;
        public System.Windows.Forms.Label label_num_speed;
        public System.Windows.Forms.Label label_n_score_contender;
        public System.Windows.Forms.Label label_t_score_contender;
        public System.Windows.Forms.PictureBox FieldPictureBox;
    }
}