using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing
{
    public partial class FormGameCreate : Form
    {
        FormMenu parent;
        public P2_Network networkUnit;

        public FormGameCreate(FormMenu parent_form)
        {
            InitializeComponent();
            parent = parent_form;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Sound.play_menu_button();
            parent.Show();
            Close();
        }
 
        private void start_game(int mode)
        {
            FormGame game = new FormGame(mode, null, this);
            Hide();
            game.Show();
        }
        private void close_game()
        {
            DialogResult = DialogResult.Abort;
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            if (textBoxIP.Text != "")
            {
                Sound.play_menu_button();

                networkUnit = new P2_Network(P2_Network.ResType.Server, textBoxIP.Text, this);
                networkUnit.Start();
            }
            else
                MessageBox.Show("Введите IP");
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            Sound.play_menu_button();

            if (textBoxIP.Text != "")
            {
                networkUnit = new P2_Network(P2_Network.ResType.Client, textBoxIP.Text, this);
                networkUnit.Start();
            }
            else
                MessageBox.Show("Введите IP");
        }

        private void FormGameCreate_Load(object sender, EventArgs e)
        {

        }

        private void button_sologame_Click(object sender, EventArgs e)
        {
            Sound.play_menu_button();
            start_game(0);
        }
    }
}
