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
    public partial class CreateComputerEntryDialog : Form
    {
        public CreateComputerEntryDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Device cpu = new Device()
            {
                Model = cpuModelTextBox.Text,
                Creator = cpuCreatorTextBox.Text,
                Vendor = cpuVendorTextBox.Text,
                Price = Convert.ToInt32(cpuPriceNumericUpDown.Value)
            };
            Device gpu = new Device()
            {
                Model = gpuModelTextBox.Text,
                Creator = gpuCreatorTextBox.Text,
                Vendor = gpuVendorTextBox.Text,
                Price = Convert.ToInt32(cpuPriceNumericUpDown.Value)
            };
            Device hdd = new Device()
            {
                Model = hddModelTextBox.Text,
                Creator = hddCreatorTextBox.Text,
                Vendor = hddVendorTextBox.Text,
                Price = Convert.ToInt32(hddPriceNumericUpDown.Value)
            };
            Device monitor = new Device()
            {
                Model = monitorModelTextBox.Text,
                Creator = monitorCreatorTextBox.Text,
                Vendor = monitorVendorTextBox.Text,
                Price = Convert.ToInt32(monitorPriceNumericUpDown.Value)
            };
            object[] values = new object[]
            {
                cpu.Model,cpu.Creator,cpu.Vendor,cpu.Price,
                gpu.Model,gpu.Creator,gpu.Vendor,gpu.Price,
                hdd.Model,hdd.Creator,hdd.Vendor,hdd.Price,
                monitor.Model,monitor.Creator,monitor.Vendor,monitor.Price
            };
            if (Validator.ValidateRange(values))
            {
                using(DeviceContext deviceContext=new DeviceContext())
                {
                    deviceContext.Devices.Add(cpu);
                    deviceContext.Devices.Add(gpu);
                    deviceContext.Devices.Add(hdd);
                    deviceContext.Devices.Add(monitor);
                    deviceContext.SaveChanges();
                    Computer computer = new Computer() { ProcessorId = cpu.Id, GPUId = gpu.Id, HDDId = hdd.Id, MonitorId = monitor.Id };
                    ComputerContext computerContext = new ComputerContext();
                    computerContext.Computers.Add(computer);
                    computerContext.SaveChanges();
                    computerContext.Dispose();
                }
                MessageBox.Show("Успішно створено");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не вдалось створити запис");
            }
        }

        private void CreateComputerEntryDialog_Load(object sender, EventArgs e)
        {
            cpuPriceNumericUpDown.Maximum = Int32.MaxValue;
            gpuPriceNumericUpDown.Maximum = Int32.MaxValue;
            hddPriceNumericUpDown.Maximum = Int32.MaxValue;
            monitorPriceNumericUpDown.Maximum = Int32.MaxValue;

        }
    }
}
