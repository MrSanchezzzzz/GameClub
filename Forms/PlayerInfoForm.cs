using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GameClub2.Objects;
namespace GameClub2.Forms
{
    public partial class PlayerInfoForm : Form
    {
        Player _player;
        Admin _admin;
        public PlayerInfoForm(int playerId)
        {
            InitializeComponent();
            UserContext userContext = new UserContext();
            _player = userContext.Players.First(c => c.Id == playerId);
            userContext.Dispose();
        }

        private void PlayerInfoForm_Load(object sender, EventArgs e)
        {
            RefreshLabels();
            RefreshDataGridView();
        }
        private void RefreshPlayer()
        {
            UserContext uc = new UserContext();
            _player = uc.Players.First(a => a.Id == this._player.Id);
            uc.Dispose();
        }
        private void RefreshLabels()
        {
            idLabel.Text = _player.Id.ToString();
            nameLabel.Text = _player.Name;
            adressLabel.Text = _player.Adress;
        }
        private void RefreshDataGridView()
        {
            this.dataGridView1.Rows.Clear();
            DataContext dataContext = new DataContext();
            Data data = dataContext.Datas.First(c => c.PlayerId == _player.Id);
            ComputerContext computerContext = new ComputerContext();
            Computer computer = computerContext.Computers.First(c => c.Id == data.CompId);
            computerContext.Dispose();
            UserContext uc = new UserContext();
            _admin = uc.Admins.First(s => s.Id == data.AdminId);
            uc.Dispose();
            foreach (Data d in dataContext.Datas.Where(c => c.PlayerId == this._player.Id))
            {

                DataGridViewTextBoxCell[] cells = new DataGridViewTextBoxCell[] { new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell() };
                cells[0].Value = computer.Id;
                cells[1].Value = _admin.Name;
                cells[1].Tag = _admin.Id;
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.AddRange(cells);
                this.dataGridView1.Rows.Add(row);
            }
            dataContext.Dispose();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            object value = this.dataGridView1.CurrentCell.Value,
                tag = this.dataGridView1.CurrentCell.Tag;
            switch (e.ColumnIndex)
            {
                case 0:
                    ComputerInfoForm cIF = new ComputerInfoForm(Convert.ToInt32(value));
                    cIF.Show();
                    break;
                case 1:
                    AdminInfoForm aIF = new AdminInfoForm(_admin.Id);
                    aIF.Show();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            PlayerEditDialog ped = new PlayerEditDialog(this._player);
            ped.ShowDialog();
            if (ped.DialogResult == DialogResult.OK)
            {
                this.RefreshPlayer();
                this.PlayerInfoForm_Load(null, null);
            }
        }
    }
}
