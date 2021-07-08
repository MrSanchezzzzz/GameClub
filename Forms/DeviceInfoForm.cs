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
    public partial class DeviceInfoForm : Form
    {
        int _deviceId;
        public DeviceInfoForm(int deviceId)
        {
            InitializeComponent();
            this._deviceId = deviceId;
        }

        private void DeviceInfoForm_Load(object sender, EventArgs e)
        {
            Device device;
            using (DeviceContext deviceContext =new DeviceContext())
            {
                device = deviceContext.Devices.First(d => d.Id == _deviceId);
            }
            this.idLabel.Text = device.Id.ToString();
            this.modelLabel.Text = device.Model.ToString();
            this.creatorLabel.Text = device.Creator.ToString();
            this.vendorLabel.Text = device.Vendor.ToString();
            priceLabel.Text = device.Price.ToString();
        }
    }
}
