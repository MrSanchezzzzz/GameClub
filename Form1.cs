using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GameClub2.Objects;
using GameClub2.Forms;
namespace GameClub2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(ref dataGridView1);
        }
        private void LoadData(ref DataGridView DGV)
        {
            ClearDataGridView(ref DGV);
            DGV.Columns.Add("ID", "Номер");
            DGV.Columns.Add("RentDate", "Дата оренди");
            DGV.Columns.Add("RentEndDate", "Дата кінця оренди");
            DGV.Columns.Add("Admin", "Адміністратор");
            DGV.Columns.Add("Player", "Користувач");
            DGV.Columns.Add("CompId", "Номер комп'ютера");
            DataContext dataContext = new DataContext();
            UserContext userContext = new UserContext();
            ComputerContext computerContext = new ComputerContext();
            foreach (Data data in dataContext.Datas)
            {
                Admin admin = userContext.Admins.First(c => c.Id == data.AdminId);
                Player player = userContext.Players.First(c => c.Id == data.PlayerId);
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell[] cells = new DataGridViewTextBoxCell[] { new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(),new DataGridViewTextBoxCell() };
                cells[0].Value = data.Id;
                cells[1].Value = data.RentDate;
                cells[2].Value = data.RentEndDate;
                cells[3].Value = admin.Name;
                cells[3].Tag = data.AdminId;
                cells[4].Value = player.Name;
                cells[4].Tag = data.PlayerId;
                cells[5].Value = data.CompId;
                row.Cells.AddRange(cells);
                DGV.Rows.Add(row);

            }
            DGV.CellDoubleClick += dataGridViewData_CellDoubleClick;
            DGV.CellClick += dataGridView_CellClick;
            dataContext.Dispose();
            userContext.Dispose();
        }
        private void LoadPlayers(ref DataGridView DGV)
        {
            ClearDataGridView(ref DGV);
            DGV.Columns.Add("ID", "Номер");
            DGV.Columns.Add("Name", "Ім'я");
            DGV.Columns.Add("Adress", "Адреса");
            DGV.Columns.Add("CompId", "Номер комп'ютера");
            DGV.Columns.Add("Admin", "Адміністратор");
            using (UserContext userContext=new UserContext())
            {
                DataContext DC = new DataContext();
                foreach(Player plr in userContext.Players)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewCell[] cells = new DataGridViewCell[]{new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(),new DataGridViewTextBoxCell(),new DataGridViewTextBoxCell()};
                    cells[0].Value = plr.Id;
                    cells[1].Value = plr.Name;
                    cells[2].Value = plr.Adress;
                    Data dt = DC.Datas.First(d => d.PlayerId == plr.Id);
                    cells[3].Value = dt.CompId;
                    UserContext adminContext = new UserContext();                    
                    Admin adm =adminContext.Admins.First(a => a.Id == dt.AdminId);
                    adminContext.Dispose();
                    cells[4].Value = adm.Name;
                    cells[4].Tag = adm.Id;
                    row.Cells.AddRange(cells);
                    DGV.Rows.Add(row);
                }
                DC.Dispose();
                DGV.CellDoubleClick += dataGridViewPlayers_CellDoubleClick;
            }
        }
        private void LoadAdmins(ref DataGridView DGV)
        {
            ClearDataGridView(ref DGV);
            DGV.Columns.Add("ID", "Номер");
            DGV.Columns.Add("Name", "Ім'я");
            DGV.Columns.Add("Adress", "Адреса");
            DGV.Columns.Add("Salary", "Зарплатня");
            using (UserContext UC = new UserContext())
            {
                foreach(Admin admin in UC.Admins)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell[] cells = new DataGridViewTextBoxCell[] { new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell() };
                    cells[0].Value = admin.Id;
                    cells[1].Value = admin.Name;
                    cells[2].Value = admin.Adress;
                    cells[3].Value = admin.Salary.ToString();
                    row.Cells.AddRange(cells);
                    DGV.Rows.Add(row);
                }
                
            }
        }
        private void LoadComputers(ref DataGridView DGV)
        {
            ClearDataGridView(ref DGV);
            DGV.Columns.Add("ID","Номер");
            DGV.Columns.Add("Status","Статус");
            DGV.Columns.Add("Processor", "Процесор");
            DGV.Columns.Add("GPU", "Відеокарта");
            DGV.Columns.Add("HDD", "Накопичувач");
            DGV.Columns.Add("Monitor", "Монітор");
            using(ComputerContext computerContext=new ComputerContext())
            {
                DataContext dataContext = new DataContext();
                UserContext userContext = new UserContext();
                DeviceContext deviceContext = new DeviceContext();
                var compIDs = dataContext.Datas.Select(d => d.CompId).ToArray();
                foreach(Computer comp in computerContext.Computers)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewCell[] cells = new DataGridViewCell[] { new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(),new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell(), new DataGridViewTextBoxCell() };
                    cells[0].Value = comp.Id.ToString();
                    if (compIDs.Contains(comp.Id))
                    {
                        Data d = dataContext.Datas.First(dt => dt.CompId == comp.Id);
                        Player plr = userContext.Players.First(p => p.Id == d.PlayerId);
                        cells[1].Value = "Занятий(" + plr.Name + ")";
                        cells[1].Tag = plr.Id;
                    }
                    else
                    cells[1].Value = "Вільний";
                    Device[] devices = new Device[] {
                        deviceContext.Devices.First(d=>d.Id==comp.ProcessorId),
                        deviceContext.Devices.First(d=>d.Id==comp.GPUId),
                        deviceContext.Devices.First(d=>d.Id==comp.HDDId),
                        deviceContext.Devices.First(d=>d.Id==comp.MonitorId)
                    };
                    int i = 2;
                    foreach(Device dvc in devices)
                    {
                        cells[i].Value = dvc.Model;
                        cells[i].Tag = dvc.Id;
                        i++;
                    }
                    row.Cells.AddRange(cells);
                    DGV.Rows.Add(row);
                }
            }
            DGV.CellDoubleClick += dataGridViewComputers_CellDoubleClick;
        }
        private void ClearDataGridView(ref DataGridView DGV)
        {
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            DGV.CellDoubleClick -= dataGridViewData_CellDoubleClick;
            DGV.CellDoubleClick -= dataGridViewPlayers_CellDoubleClick;
            DGV.CellDoubleClick -= dataGridViewComputers_CellDoubleClick;
        }
        private void SelectRow(ref DataGridView DGV,bool enabled)
        {
            if (enabled)
                DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            else
                DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DGV.CurrentCell.Selected = true;

        }
        private int GetRowId(DataGridViewRow row)
        {
            return Convert.ToInt32(row.Cells[0].Value);
        }
        private void dataGridViewData_CellDoubleClick(object sender,DataGridViewCellEventArgs e)
        {
            object value =((DataGridView)sender).CurrentCell.Value;
            if (value == null)
                return;
            object tag = ((DataGridView)sender).CurrentCell.Tag;

            if (e.ColumnIndex == 5)
                new ComputerInfoForm(Convert.ToInt32(value)).ShowDialog();
                
            else if (tag != null)
            {
                if (e.ColumnIndex == 3)
                    new AdminInfoForm(Convert.ToInt32(tag)).ShowDialog();
                else if (e.ColumnIndex == 4)
                    new PlayerInfoForm(Convert.ToInt32(tag)).ShowDialog();
            }
        }
        private void dataGridViewPlayers_CellDoubleClick(object sender,DataGridViewCellEventArgs e)
        {
            object value = ((DataGridView)sender).CurrentCell.Value;
            object tag = ((DataGridView)sender).CurrentCell.Tag;
            if (value == null)
                return;
            if (e.ColumnIndex == 3)
                new ComputerInfoForm(Convert.ToInt32(value)).ShowDialog();
            else if (tag != null)
            {
                if (e.ColumnIndex == 4)
                    new AdminInfoForm(Convert.ToInt32(tag)).ShowDialog();
            }
        }
        private void dataGridViewComputers_CellDoubleClick(object sender,DataGridViewCellEventArgs e)
        {
            object value = ((DataGridView)sender).CurrentCell.Value;
            if (value == null)
                return;
            object tag =((DataGridView)sender).CurrentCell.Tag;
            if (tag == null)
                return;
            int id = Convert.ToInt32(tag);
            switch (e.ColumnIndex)
            {
                case 1:
                    new PlayerInfoForm(id).ShowDialog();
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                    new DeviceInfoForm(id).ShowDialog();
                    break;

            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.CurrentCell;
            button2.Enabled = !(cell.Value is null);
            
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = ((DataGridView)sender).CurrentCell;
            button8.Enabled = button6.Enabled = !(cell.Value is null);
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = ((DataGridView)sender).CurrentCell;
            button10.Enabled = !(cell.Value is null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (new CreateDataEntryDialog().ShowDialog() == DialogResult.OK)
                LoadData(ref dataGridView1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CurrentCell.Selected = true;
            DialogResult res= MessageBox.Show("Ви впевнені, що хочете видалити обраний запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                int id =GetRowId(dataGridView1.CurrentRow);
                DataContext dataContext = new DataContext();
                Data d = dataContext.Datas.Find(id);
                UserContext userContext = new UserContext();
                Player plr = userContext.Players.Find(d.PlayerId);
                userContext.Players.Remove(plr);
                userContext.SaveChanges();
                userContext.Dispose();
                dataContext.Datas.Remove(d);
                dataContext.SaveChanges();
                dataContext.Dispose();
                LoadData(ref dataGridView1);
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.CurrentCell.Selected = true;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadData(ref dataGridView1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LoadPlayers(ref dataGridView2);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LoadAdmins(ref dataGridView3);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SelectRow(ref dataGridView3, true);
            int id = GetRowId(dataGridView3.CurrentRow);
            DialogResult res=MessageBox.Show("Ви дійсно хочете видалити цього адміністратора", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                using(UserContext userContext=new UserContext())
                {
                    Admin adm = userContext.Admins.First(a => a.Id == id);
                    userContext.Admins.Remove(adm);
                    userContext.SaveChanges();
                }
                LoadAdmins(ref dataGridView3);
            }
            SelectRow(ref dataGridView3, false);

        }
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = new CreateAdminEntryDialog().ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Успішно додано");
                LoadAdmins(ref dataGridView3);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Admin admin;
            int id = GetRowId(dataGridView3.CurrentRow);
            using(UserContext userContext=new UserContext())
            {
                admin = userContext.Admins.Find(id);
            }
            DialogResult result= new AdminEditDialog(admin).ShowDialog();
            if (result == DialogResult.OK)
                LoadAdmins(ref dataGridView3);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            LoadComputers(ref dataGridView4);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            SelectRow(ref dataGridView4, true);
            DialogResult result = MessageBox.Show("Ви дійсно хочете видалити цей комп'ютер?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int id = GetRowId(dataGridView4.CurrentRow);
                using (ComputerContext computerContext = new ComputerContext())
                {
                    Computer computer = computerContext.Computers.First(c => c.Id == id);
                    DeviceContext deviceContext = new DeviceContext();
                    Device[] devices = new Device[]
                    {
                    deviceContext.Devices.First(d=>d.Id==computer.ProcessorId),
                    deviceContext.Devices.First(d=>d.Id==computer.GPUId),
                    deviceContext.Devices.First(d=>d.Id==computer.HDDId),
                    deviceContext.Devices.First(d=>d.Id==computer.MonitorId)
                    };
                    foreach (Device dvc in devices)
                        deviceContext.Devices.Remove(dvc);
                    deviceContext.SaveChanges();
                    deviceContext.Dispose();
                    computerContext.Computers.Remove(computer);
                    computerContext.SaveChanges();

                }
                LoadComputers(ref dataGridView4);
            }
            SelectRow(ref dataGridView4, false);

        }
        private void button11_Click(object sender, EventArgs e)
        {

            DialogResult result=new CreateComputerEntryDialog().ShowDialog();
            if (result == DialogResult.OK)
                LoadComputers(ref dataGridView4);
        }

        private void tabPage_Enter(object sender, EventArgs e)
        {
            TabPage page = ((TabPage)sender);
            string[] args = page.Tag.ToString().Split('|');
            if (Convert.ToInt32(args[1]) == 1)
                return;
            switch (args[0][0])
            {
                case 'A':
                    LoadAdmins(ref dataGridView3);
                    break;
                case 'C':
                    LoadComputers(ref dataGridView4);
                    break;
                case 'D':
                    LoadData(ref dataGridView1);
                    break;
                case 'P':
                    LoadPlayers(ref dataGridView2);
                    break;
            }
            args[1] = 1.ToString();
            string tag = String.Join("|",args);
            page.Tag = tag;
        }

      
    }
}
