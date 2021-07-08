using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClub2.Objects;
using GameClub2.Forms;
namespace GameClub2.Forms
{
    public partial class AdminInfoForm : Form
    {
        Admin _admin;
        public AdminInfoForm(int adminId)
        {
            InitializeComponent();
            UserContext userContext = new UserContext();
            _admin = userContext.Admins.First(c => c.Id == adminId);
            userContext.Dispose();
        }

        private void AdminInfoForm_Load(object sender, EventArgs e)
        {
           
            RefreshAdminLabels();
            RefreshDataGridView();
        }
        private void RefreshAdmin()
        {
            UserContext uc = new UserContext();
            _admin = uc.Admins.First(a => a.Id == this._admin.Id);
            uc.Dispose();
        }
        private void RefreshAdminLabels()
        {
            IdLabel.Text = _admin.Id.ToString();
            nameLabel.Text = _admin.Name;
            adressLabel.Text = _admin.Adress;
            salaryLabel.Text = _admin.Salary.ToString();
        }
        private void RefreshDataGridView()
        {
            this.dataGridView1.Rows.Clear();
            DataContext dataContext = new DataContext();
            UserContext userContext = new UserContext();
            foreach (Data data in dataContext.Datas.Where(c => c.AdminId == _admin.Id))
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell[] cells = new DataGridViewTextBoxCell[] { new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell() };
                Player plr = userContext.Players.First(c => c.Id == data.PlayerId);
                cells[0].Value = data.CompId;
                cells[1].Value = plr.Name;
                cells[1].Tag = plr.Id.ToString();
                row.Cells.AddRange(cells);
                dataGridView1.Rows.Add(row);
            }
            dataContext.Dispose();
            userContext.Dispose();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            object value = dataGridView1.CurrentCell.Value,
               tag = dataGridView1.CurrentCell.Tag;
            switch (e.ColumnIndex)
            {
                case 0:
                    if (value != null)
                    {
                        ComputerInfoForm computerInfoForm = new ComputerInfoForm(Convert.ToInt32(value));
                        computerInfoForm.Show();
                    }
                    break;
                case 1:
                    if (tag != null)
                    {
                        PlayerInfoForm playerInfoForm = new PlayerInfoForm(Convert.ToInt32(tag));
                        playerInfoForm.Show();
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           AdminEditDialog aedf= new AdminEditDialog(_admin);
           aedf.ShowDialog();
            if (aedf.DialogResult == DialogResult.OK)
            {
                RefreshAdmin();
                AdminInfoForm_Load(null,null);
                //new AdminInfoForm(_admin.Id).Show();
               // this.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
