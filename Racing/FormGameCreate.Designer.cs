namespace Racing
{
    partial class FormGameCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameCreate));
            this.button_create = new System.Windows.Forms.Button();
            this.button_connect = new System.Windows.Forms.Button();
            this.labelIP = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.button_back = new System.Windows.Forms.Button();
            this.button_sologame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_create
            // 
            this.button_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_create.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_create.Location = new System.Drawing.Point(133, 159);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(174, 53);
            this.button_create.TabIndex = 3;
            this.button_create.Text = "Создать сервер";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_connect
            // 
            this.button_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_connect.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_connect.Location = new System.Drawing.Point(133, 218);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(174, 53);
            this.button_connect.TabIndex = 2;
            this.button_connect.Text = "Подключиться";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // labelIP
            // 
            this.labelIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelIP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIP.Location = new System.Drawing.Point(133, 36);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(174, 53);
            this.labelIP.TabIndex = 4;
            this.labelIP.Text = "Введите IP:";
            this.labelIP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIP.Location = new System.Drawing.Point(133, 60);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(174, 30);
            this.textBoxIP.TabIndex = 5;
            // 
            // button_back
            // 
            this.button_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Location = new System.Drawing.Point(133, 318);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(174, 53);
            this.button_back.TabIndex = 6;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_sologame
            // 
            this.button_sologame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sologame.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_sologame.Location = new System.Drawing.Point(133, 96);
            this.button_sologame.Name = "button_sologame";
            this.button_sologame.Size = new System.Drawing.Size(174, 57);
            this.button_sologame.TabIndex = 7;
            this.button_sologame.Text = "Одиночная игра";
            this.button_sologame.UseVisualStyleBackColor = true;
            this.button_sologame.Click += new System.EventHandler(this.button_sologame_Click);
            // 
            // FormGameCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Racing.Properties.Resources.background_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(441, 496);
            this.Controls.Add(this.button_sologame);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.button_connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGameCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGameCreate";
            this.Load += new System.EventHandler(this.FormGameCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_sologame;
    }
}