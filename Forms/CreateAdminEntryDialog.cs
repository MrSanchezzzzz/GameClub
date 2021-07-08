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
    public partial class CreateAdminEntryDialog : Form
    {
        public CreateAdminEntryDialog()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UserWriter.CreateAdminWithValidation(nameTextBox.Text,adressTextBox.Text,Convert.ToInt32(salaryNumericUpDown.Value)))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
