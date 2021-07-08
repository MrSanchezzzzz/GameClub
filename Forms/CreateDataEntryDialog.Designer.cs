namespace GameClub2.Forms
{
    partial class CreateDataEntryDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.adressTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AdminChooseComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.computerChooseComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.durationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.durationFormatComboBox = new System.Windows.Forms.ComboBox();
            this.nameIncorrectLabel = new System.Windows.Forms.Label();
            this.adressIncorrectLabel = new System.Windows.Forms.Label();
            this.durationIncorrectLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.priceLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.computerIncorrectLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.adressTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(234, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Користувач";
            // 
            // adressTextBox
            // 
            this.adressTextBox.Location = new System.Drawing.Point(85, 64);
            this.adressTextBox.Name = "adressTextBox";
            this.adressTextBox.Size = new System.Drawing.Size(142, 26);
            this.adressTextBox.TabIndex = 3;
            this.adressTextBox.TextChanged += new System.EventHandler(this.adressTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Адреса:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(61, 32);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(166, 26);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ПІБ: ";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.AdminChooseComboBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(13, 145);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(234, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Адміністратор";
            // 
            // AdminChooseComboBox
            // 
            this.AdminChooseComboBox.FormattingEnabled = true;
            this.AdminChooseComboBox.Location = new System.Drawing.Point(7, 27);
            this.AdminChooseComboBox.Name = "AdminChooseComboBox";
            this.AdminChooseComboBox.Size = new System.Drawing.Size(220, 28);
            this.AdminChooseComboBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.computerChooseComboBox);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(13, 237);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(234, 82);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Комп\'ютер";
            // 
            // computerChooseComboBox
            // 
            this.computerChooseComboBox.FormattingEnabled = true;
            this.computerChooseComboBox.Location = new System.Drawing.Point(7, 27);
            this.computerChooseComboBox.Name = "computerChooseComboBox";
            this.computerChooseComboBox.Size = new System.Drawing.Size(220, 28);
            this.computerChooseComboBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.durationNumericUpDown);
            this.groupBox4.Controls.Add(this.durationFormatComboBox);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(13, 329);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(234, 82);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Тривалість";
            // 
            // durationNumericUpDown
            // 
            this.durationNumericUpDown.Location = new System.Drawing.Point(7, 29);
            this.durationNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.durationNumericUpDown.Name = "durationNumericUpDown";
            this.durationNumericUpDown.Size = new System.Drawing.Size(142, 26);
            this.durationNumericUpDown.TabIndex = 1;
            this.durationNumericUpDown.ValueChanged += new System.EventHandler(this.durationNumericUpDown_ValueChanged);
            // 
            // durationFormatComboBox
            // 
            this.durationFormatComboBox.FormattingEnabled = true;
            this.durationFormatComboBox.Items.AddRange(new object[] {
            "год",
            "хв"});
            this.durationFormatComboBox.Location = new System.Drawing.Point(155, 27);
            this.durationFormatComboBox.Name = "durationFormatComboBox";
            this.durationFormatComboBox.Size = new System.Drawing.Size(72, 28);
            this.durationFormatComboBox.TabIndex = 0;
            this.durationFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.durationFormatComboBox_SelectedIndexChanged);
            // 
            // nameIncorrectLabel
            // 
            this.nameIncorrectLabel.AutoSize = true;
            this.nameIncorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameIncorrectLabel.ForeColor = System.Drawing.Color.Red;
            this.nameIncorrectLabel.Location = new System.Drawing.Point(254, 50);
            this.nameIncorrectLabel.Name = "nameIncorrectLabel";
            this.nameIncorrectLabel.Size = new System.Drawing.Size(194, 26);
            this.nameIncorrectLabel.TabIndex = 4;
            this.nameIncorrectLabel.Text = "Ім\'я повинне бути непробільним\r\nі складатись більше ніж з 4 символів";
            // 
            // adressIncorrectLabel
            // 
            this.adressIncorrectLabel.AutoSize = true;
            this.adressIncorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adressIncorrectLabel.ForeColor = System.Drawing.Color.Red;
            this.adressIncorrectLabel.Location = new System.Drawing.Point(254, 82);
            this.adressIncorrectLabel.Name = "adressIncorrectLabel";
            this.adressIncorrectLabel.Size = new System.Drawing.Size(194, 26);
            this.adressIncorrectLabel.TabIndex = 5;
            this.adressIncorrectLabel.Text = "Адреса повинна бути непробільною\r\nі складатись більше ніж з 4 символів";
            // 
            // durationIncorrectLabel
            // 
            this.durationIncorrectLabel.AutoSize = true;
            this.durationIncorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.durationIncorrectLabel.ForeColor = System.Drawing.Color.Red;
            this.durationIncorrectLabel.Location = new System.Drawing.Point(254, 365);
            this.durationIncorrectLabel.Name = "durationIncorrectLabel";
            this.durationIncorrectLabel.Size = new System.Drawing.Size(123, 13);
            this.durationIncorrectLabel.TabIndex = 8;
            this.durationIncorrectLabel.Text = "Тривалість не вказано";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(9, 419);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Ціна:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Створити запис";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceLabel.Location = new System.Drawing.Point(66, 419);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(3);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(0, 20);
            this.priceLabel.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // computerIncorrectLabel
            // 
            this.computerIncorrectLabel.AutoSize = true;
            this.computerIncorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.computerIncorrectLabel.ForeColor = System.Drawing.Color.Red;
            this.computerIncorrectLabel.Location = new System.Drawing.Point(254, 272);
            this.computerIncorrectLabel.Name = "computerIncorrectLabel";
            this.computerIncorrectLabel.Size = new System.Drawing.Size(144, 13);
            this.computerIncorrectLabel.TabIndex = 12;
            this.computerIncorrectLabel.Text = "Вільних комп\'ютерів немає";
            this.computerIncorrectLabel.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 445);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 13;
            this.button2.Text = "Відмінити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CreateDataEntryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(414, 462);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.computerIncorrectLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.durationIncorrectLabel);
            this.Controls.Add(this.adressIncorrectLabel);
            this.Controls.Add(this.nameIncorrectLabel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CreateDataEntryDialog";
            this.Text = "Створити запис";
            this.Load += new System.EventHandler(this.CreateDataEntryDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox adressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox AdminChooseComboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox computerChooseComboBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown durationNumericUpDown;
        private System.Windows.Forms.ComboBox durationFormatComboBox;
        private System.Windows.Forms.Label nameIncorrectLabel;
        private System.Windows.Forms.Label adressIncorrectLabel;
        private System.Windows.Forms.Label durationIncorrectLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label computerIncorrectLabel;
        private System.Windows.Forms.Button button2;
    }
}