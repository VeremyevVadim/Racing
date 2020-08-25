namespace Racing
{
    partial class FormMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.button_start = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.box_sound = new System.Windows.Forms.CheckBox();
            this.label_best_score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(133, 35);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(174, 53);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Начать игру";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            this.button_start.Enter += new System.EventHandler(this.button_start_Enter);
            // 
            // button_exit
            // 
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(133, 176);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(174, 53);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "Выйти";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            this.button_exit.Enter += new System.EventHandler(this.button_exit_Enter);
            // 
            // box_sound
            // 
            this.box_sound.AutoSize = true;
            this.box_sound.BackColor = System.Drawing.Color.Transparent;
            this.box_sound.Checked = true;
            this.box_sound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box_sound.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.box_sound.ForeColor = System.Drawing.Color.White;
            this.box_sound.Location = new System.Drawing.Point(133, 250);
            this.box_sound.Name = "box_sound";
            this.box_sound.Size = new System.Drawing.Size(123, 27);
            this.box_sound.TabIndex = 2;
            this.box_sound.Text = "Звук есть";
            this.box_sound.UseVisualStyleBackColor = false;
            this.box_sound.CheckedChanged += new System.EventHandler(this.box_sound_CheckedChanged);
            // 
            // label_best_score
            // 
            this.label_best_score.BackColor = System.Drawing.Color.Transparent;
            this.label_best_score.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_best_score.ForeColor = System.Drawing.Color.Black;
            this.label_best_score.Location = new System.Drawing.Point(139, 91);
            this.label_best_score.Name = "label_best_score";
            this.label_best_score.Size = new System.Drawing.Size(157, 34);
            this.label_best_score.TabIndex = 9;
            this.label_best_score.Text = "Лучший результат:";
            this.label_best_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Racing.Properties.Resources.background_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(442, 496);
            this.Controls.Add(this.label_best_score);
            this.Controls.Add(this.box_sound);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Racing";
            this.Load += new System.EventHandler(this.FormMemu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.CheckBox box_sound;
        public System.Windows.Forms.Label label_best_score;
    }
}

