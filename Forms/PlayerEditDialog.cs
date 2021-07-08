using GameClub2.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClub2.Forms
{
    public partial class PlayerEditDialog : Form
    {
        Player _player;
        public PlayerEditDialog(Player player)
        {
            InitializeComponent();
            this._player = player;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserWriter.EditPlayerWithValidation(nameTextBox.Text,
               adressTextBox.Text,
               _player);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayerEditDialog_Load(object sender, EventArgs e)
        {
            this.idTextBox.Text= this._player.Id.ToString();
            this.nameTextBox.Text = this._player.Name;
            this.adressTextBox.Text = this._player.Adress;
        }
    }
}
