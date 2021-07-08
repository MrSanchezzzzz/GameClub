using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClub2.Objects;
namespace GameClub2.Forms
{
    public partial class CreateDataEntryDialog : Form
    {
        public CreateDataEntryDialog()
        {
            InitializeComponent();
        }
        private int minutes;
        int price;
        private void CreateDataEntryDialog_Load(object sender, EventArgs e)
        {
            UserContext UC = new UserContext();
            Admin[] admins = UC.Admins.ToArray();
            foreach (Admin adm in admins)
                AdminChooseComboBox.Items.Add(adm.Id.ToString()+". "+adm.Name);
            UC.Dispose();

            ComputerContext computerContext = new ComputerContext();
            DataContext dataContext = new DataContext();
            var excludeList = dataContext.Datas.Where(d => d.RentEndDate > DateTime.Now).Select(dd=>dd.Id);
            var comps = computerContext.Computers.Where(d=>d.Id!=0);
            var ids = comps.Select(c => c.Id).ToList();
            ids = ids.Where(i => !excludeList.Contains(i)).ToList();
            ids.Sort();
            computerContext.Dispose();
            dataContext.Dispose();
            foreach (int i in ids)
                computerChooseComboBox.Items.Add(i);

            if(AdminChooseComboBox.Items.Count>0)
            AdminChooseComboBox.SelectedIndex = 0;

            if (computerChooseComboBox.Items.Count > 0)
                computerChooseComboBox.SelectedIndex = 0;
            else
                computerIncorrectLabel.Visible = true; 
            durationFormatComboBox.SelectedIndex = 1;

            CalculatePrice();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            nameIncorrectLabel.Visible = !Validator.Validate(nameTextBox.Text.Trim());
        }

        private void adressTextBox_TextChanged(object sender, EventArgs e)
        {
            adressIncorrectLabel.Visible = !Validator.Validate(adressTextBox.Text.Trim());
        }

        private void durationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            durationIncorrectLabel.Visible = !Validator.Validate(Convert.ToInt32(durationNumericUpDown.Value));
            CalculatePrice();
           
        }
        private void CalculatePrice()
        {
            minutes = durationFormatComboBox.SelectedIndex == 0 ? Convert.ToInt32(durationNumericUpDown.Value * 60) : Convert.ToInt32(durationNumericUpDown.Value);
            price = Convert.ToInt32(Properties.Resources.Tariff) * minutes;
            priceLabel.Text = price.ToString() + "UAH";
        }

        private void durationFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = nameTextBox.Text,
                adress=adressTextBox.Text;
            int ComputerId = Convert.ToInt32(computerChooseComboBox.SelectedItem),
            AdminId=Convert.ToInt32(AdminChooseComboBox.SelectedItem.ToString().Split('.')[0]);
            DateTime rentBeginDate = DateTime.Now,
                rentEndDate = rentBeginDate.AddMinutes(minutes);
            string hashSource = name + adress + ComputerId.ToString() + AdminId.ToString() + rentBeginDate.ToString() + rentEndDate.ToString();
            string hash;
            using (SHA256 sha256Hash = SHA256.Create())
            {
               hash = GetHash(sha256Hash, hashSource);
            }
            UserContext userContext = new UserContext();
            Player player = new Player() { Name = name, Adress = adress };
            userContext.Players.Add(player);
            userContext.SaveChanges();

            userContext.Dispose();
            Data entry = new Data()
            {
                CompId = ComputerId,
                RentDate = rentBeginDate,
                RentEndDate = rentEndDate,
                TransactionCode = hash,
                AdminId = AdminId,
                PlayerId = player.Id
            };
            DataContext dataContext = new DataContext();
            dataContext.Datas.Add(entry);
            if (dataContext.SaveChanges() > 0)
                MessageBox.Show("Запис створено");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool[] validationResults = new bool[] {Validator.Validate(nameTextBox.Text),
                    Validator.Validate(adressTextBox.Text),
                    Validator.Validate(AdminChooseComboBox.SelectedItem.ToString()),
                    Validator.Validate(Convert.ToInt32(computerChooseComboBox.SelectedItem)),
                    Validator.Validate(Convert.ToInt32(durationNumericUpDown.Value))
                };
            button1.Enabled = validationResults.All(r => r);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
