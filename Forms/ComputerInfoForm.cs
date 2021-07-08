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
namespace GameClub2.Forms
{
    public partial class ComputerInfoForm : Form
    {
        Computer _computer;
        public ComputerInfoForm(int CompId)
        {
            InitializeComponent();
            ComputerContext cc = new ComputerContext();
            _computer =cc.Computers.First(c => c.Id == CompId);
            cc.Dispose();
        }

        private void ComputerInfoForm_Load(object sender, EventArgs e)
        {
            idLabel.Text = _computer.Id.ToString();
            Device[] devices = new Device[4];
            using (DeviceContext dc = new DeviceContext())
            {
                devices[0] = dc.Devices.First(cpu => cpu.Id == this._computer.ProcessorId);
                devices[1] = dc.Devices.First(gpu => gpu.Id == this._computer.GPUId);
                devices[2] = dc.Devices.First(hdd => hdd.Id == this._computer.HDDId);
                devices[3] = dc.Devices.First(mon => mon.Id == this._computer.MonitorId);
            }
            foreach(Device dvc in devices)
            {
                TreeNode tn = new TreeNode(dvc.Creator+" "+dvc.Model);
                tn.Nodes.Add("Продавець: "+dvc.Vendor);
                tn.Nodes.Add("Ціна: " + dvc.Price.ToString());
                treeView1.Nodes.Add(tn);
            }

            UserContext uc = new UserContext();
            DataContext dataContext = new DataContext();
            Data d = dataContext.Datas.First(c => c.CompId == this._computer.Id);
            Admin admin = uc.Admins.First(a => a.Id == d.AdminId);
            Player player = uc.Players.First(a => a.Id == d.PlayerId);
            uc.Dispose();
            dataContext.Dispose();

            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell[] cells = new DataGridViewTextBoxCell[] { new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell() };
            cells[0].Value = player.Name;
            cells[0].Tag = player.Id;
            cells[1].Value = admin.Name;
            cells[1].Tag = admin.Id;
            row.Cells.AddRange(cells);
            dataGridView1.Rows.Add(row);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            object value = dataGridView1.CurrentCell.Value;
            object tag = dataGridView1.CurrentCell.Tag;
            if (tag != null)
            {
                if (e.ColumnIndex == 0)
                    new PlayerInfoForm(Convert.ToInt32(tag)).Show();
                if (e.ColumnIndex == 1)
                    new AdminInfoForm(Convert.ToInt32(tag)).Show();

            }
        }
    }
}
