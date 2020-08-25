using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Reflection;

namespace Racing
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            using (FileStream bestScoreFile = new FileStream("BestScore.txt", FileMode.OpenOrCreate))
            { 
                StreamReader reader = new StreamReader(bestScoreFile);
                if (!reader.EndOfStream)
                {
                    string result = reader.ReadToEnd();
                    label_best_score.Text = label_best_score.Text + " " + result;
                }
                else
                    label_best_score.Text += " 0";
                reader.Close();
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Sound.play_menu_button();
            open_game_menu();         
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_start_Enter(object sender, EventArgs e)
        {
            
        }

        private void button_exit_Enter(object sender, EventArgs e)
        {
            
        }

        private void box_sound_CheckedChanged(object sender, EventArgs e)
        {
            if (box_sound.Checked)
            {
                Sound.sound_on();
                box_sound.Text = "Звук есть";
                Sound.play_menu_button();
            }
            else
            {
                Sound.sound_off();
                box_sound.Text = "Звука нет";
            }
        }

        private void open_game_menu()
        { 
            FormGameCreate game_menu = new FormGameCreate(this);
            game_menu.Show();
            this.Hide();
        }

        private void close_game_menu()
        { 
            DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        private void FormMemu_Load(object sender, EventArgs e)
        {

        }
    }
}
