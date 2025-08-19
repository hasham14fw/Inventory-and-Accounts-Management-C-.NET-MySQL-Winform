namespace Master_Solar.Properties
{
    partial class Bill
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
            panel3 = new Panel();
            textBox1 = new ComboBox();
            textBox4 = new ComboBox();
            comboBox4 = new ComboBox();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            textBox3 = new TextBox();
            label5 = new Label();
            button7 = new Button();
            panel5 = new Panel();
            textBox2 = new TextBox();
            label3 = new Label();
            label9 = new Label();
            label8 = new Label();
            button6 = new Button();
            button5 = new Button();
            label4 = new Label();
            label1 = new Label();
            panel4 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            button1 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button8 = new Button();
            panel1 = new Panel();
            nameeee = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(comboBox4);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(dataGridView1);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(button7);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(button6);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(241, 69);
            panel3.Name = "panel3";
            panel3.Size = new Size(1653, 895);
            panel3.TabIndex = 5;
            panel3.Paint += panel3_Paint;
            // 
            // textBox1
            // 
            textBox1.FormattingEnabled = true;
            textBox1.Location = new Point(143, 254);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(366, 33);
            textBox1.TabIndex = 38;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // textBox4
            // 
            textBox4.FormattingEnabled = true;
            textBox4.Location = new Point(633, 256);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(366, 33);
            textBox4.TabIndex = 37;
            textBox4.SelectedIndexChanged += textBox4_SelectedIndexChanged;
            textBox4.TextChanged += textBox4_TextChanged;
            textBox4.KeyPress += textBox4_KeyPress;
            textBox4.KeyUp += textBox4_KeyUp;
           // textBox4.Layout += this.textBox4_Layout;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(1086, 254);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(293, 33);
            comboBox4.TabIndex = 36;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(0, 0, 64);
            label6.Location = new Point(1086, 213);
            label6.Name = "label6";
            label6.Size = new Size(89, 32);
            label6.TabIndex = 35;
            label6.Text = "Status";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-1, 440);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1653, 455);
            dataGridView1.TabIndex = 34;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(632, 379);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(367, 31);
            textBox3.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(0, 0, 64);
            label5.Location = new Point(632, 344);
            label5.Name = "label5";
            label5.Size = new Size(183, 32);
            label5.TabIndex = 32;
            label5.Text = "Discouted Bill";
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(0, 0, 64);
            button7.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(1506, 379);
            button7.Name = "button7";
            button7.Size = new Size(141, 46);
            button7.TabIndex = 31;
            button7.Text = "Print";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(0, 0, 64);
            panel5.Location = new Point(0, 306);
            panel5.Name = "panel5";
            panel5.Size = new Size(1652, 16);
            panel5.TabIndex = 30;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(143, 379);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(367, 31);
            textBox2.TabIndex = 29;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 0, 64);
            label3.Location = new Point(136, 344);
            label3.Name = "label3";
            label3.Size = new Size(125, 32);
            label3.TabIndex = 28;
            label3.Text = "Total Bill";
            label3.Click += label3_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(0, 0, 64);
            label9.Location = new Point(779, 113);
            label9.Name = "label9";
            label9.Size = new Size(103, 26);
            label9.TabIndex = 25;
            label9.Text = "Hasilpur";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(0, 0, 64);
            label8.Location = new Point(678, 72);
            label8.Name = "label8";
            label8.Size = new Size(321, 41);
            label8.TabIndex = 24;
            label8.Text = "Master Solar House";
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.FromArgb(0, 0, 64);
            button6.Image = Resources.Search;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(1524, 242);
            button6.Name = "button6";
            button6.Size = new Size(123, 45);
            button6.TabIndex = 23;
            button6.Text = "Search";
            button6.TextAlign = ContentAlignment.MiddleRight;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(0, 0, 64);
            button5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(1506, 328);
            button5.Name = "button5";
            button5.Size = new Size(141, 46);
            button5.TabIndex = 22;
            button5.Text = "Update";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(0, 0, 64);
            label4.Location = new Point(632, 221);
            label4.Name = "label4";
            label4.Size = new Size(82, 32);
            label4.TabIndex = 13;
            label4.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(143, 221);
            label1.Name = "label1";
            label1.Size = new Size(162, 32);
            label1.TabIndex = 10;
            label1.Text = "Customer Id";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(6, 9);
            panel4.Name = "panel4";
            panel4.Size = new Size(1639, 53);
            panel4.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 14F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(10, 9);
            label2.Name = "label2";
            label2.Size = new Size(88, 35);
            label2.TabIndex = 1;
            label2.Text = "Billing";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left;
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button8);
            panel2.Location = new Point(1, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(239, 961);
            panel2.TabIndex = 34;
            panel2.Paint += panel2_Paint_1;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = Color.FromArgb(0, 0, 64);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Elephant", 10F);
            button1.ForeColor = Color.White;
            button1.Image = Resources.Stock;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(3, 307);
            button1.Name = "button1";
            button1.Size = new Size(210, 33);
            button1.TabIndex = 6;
            button1.Text = "Histroy     ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button4.BackColor = Color.FromArgb(0, 0, 64);
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Elephant", 10F);
            button4.ForeColor = Color.White;
            button4.Image = Resources.Histroy;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(3, 262);
            button4.Name = "button4";
            button4.Size = new Size(210, 33);
            button4.TabIndex = 5;
            button4.Text = "Stocks      ";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button3.BackColor = Color.FromArgb(0, 0, 64);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Elephant", 10F);
            button3.ForeColor = Color.DarkOrange;
            button3.Image = Resources.Bill;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(1, 214);
            button3.Name = "button3";
            button3.Size = new Size(212, 33);
            button3.TabIndex = 4;
            button3.Text = "Billing      ";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.BackColor = Color.FromArgb(0, 0, 64);
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Elephant", 10F);
            button2.ForeColor = Color.White;
            button2.Image = Resources.Customer;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(3, 169);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(210, 29);
            button2.TabIndex = 3;
            button2.Text = " Customers";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(0, 0, 64);
            button8.FlatStyle = FlatStyle.Popup;
            button8.Font = new Font("Elephant", 10F);
            button8.ForeColor = Color.White;
            button8.Image = Resources.Home;
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Location = new Point(-1, 120);
            button8.Name = "button8";
            button8.Size = new Size(214, 29);
            button8.TabIndex = 2;
            button8.Text = "Home       ";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(nameeee);
            panel1.Location = new Point(1, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1251, 69);
            panel1.TabIndex = 7;
            // 
            // nameeee
            // 
            nameeee.AutoSize = true;
            nameeee.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameeee.ForeColor = SystemColors.Control;
            nameeee.Location = new Point(9, 12);
            nameeee.Name = "nameeee";
            nameeee.Size = new Size(404, 39);
            nameeee.TabIndex = 0;
            nameeee.Text = "Master  Solar  House  Hasilpur";
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // Bill
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1898, 1024);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            ForeColor = Color.FromArgb(0, 0, 64);
            Name = "Bill";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bill";
            WindowState = FormWindowState.Maximized;
            Load += Bill_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private Label label9;
        private Label label8;
        private Button button6;
        private Button button5;
        private Label label4;
        private Label label1;
        private Panel panel4;
        private Label label2;
        private Label label3;
        private Panel panel5;
        private TextBox textBox2;
        private Button button7;
        private TextBox textBox3;
        private Label label5;
        private Panel panel2;
        private Button button1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button8;
        private Panel panel1;
        private Label nameeee;
        private DataGridView dataGridView1;
        private ComboBox comboBox4;
        private Label label6;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private ComboBox textBox4;
        private ComboBox textBox1;
    }
}