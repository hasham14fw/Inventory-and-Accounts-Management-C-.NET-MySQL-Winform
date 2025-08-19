namespace Master_Solar
{
    partial class Stock
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
            panel1 = new Panel();
            name = new Label();
            panel2 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            panel8 = new Panel();
            label10 = new Label();
            button8 = new Button();
            panel7 = new Panel();
            label9 = new Label();
            label8 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            textBox2 = new ComboBox();
            button7 = new Button();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            panel6 = new Panel();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button6 = new Button();
            panel5 = new Panel();
            name1 = new Label();
            panel4 = new Panel();
            label2 = new Label();
            label11 = new Label();
            textBox7 = new TextBox();
            label12 = new Label();
            textBox8 = new TextBox();
            button9 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(name);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1251, 70);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name.ForeColor = SystemColors.Control;
            name.Location = new Point(9, 12);
            name.Name = "name";
            name.Size = new Size(404, 39);
            name.TabIndex = 0;
            name.Text = "Master  Solar  House  Hasilpur";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left;
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(1, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(239, 961);
            panel2.TabIndex = 5;
            panel2.Paint += panel2_Paint;
            // 
            // button5
            // 
            button5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button5.BackColor = Color.FromArgb(0, 0, 64);
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Elephant", 10F);
            button5.ForeColor = Color.White;
            button5.Image = Properties.Resources.Stock;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(3, 307);
            button5.Name = "button5";
            button5.Size = new Size(210, 33);
            button5.TabIndex = 6;
            button5.Text = "Histroy     ";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button4.BackColor = Color.FromArgb(0, 0, 64);
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Elephant", 10F);
            button4.ForeColor = Color.DarkOrange;
            button4.Image = Properties.Resources.Histroy;
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
            button3.ForeColor = Color.White;
            button3.Image = Properties.Resources.Bill;
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
            button2.Image = Properties.Resources.Customer;
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 0, 64);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Elephant", 10F);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.Home;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(-1, 120);
            button1.Name = "button1";
            button1.Size = new Size(214, 29);
            button1.TabIndex = 2;
            button1.Text = "Home       ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(button9);
            panel3.Controls.Add(textBox8);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(textBox7);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(button8);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(textBox6);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(textBox5);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(button7);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(dataGridView1);
            panel3.Controls.Add(button6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(name1);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(244, 68);
            panel3.Name = "panel3";
            panel3.Size = new Size(1653, 895);
            panel3.TabIndex = 7;
            panel3.Paint += panel3_Paint;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(0, 0, 64);
            panel8.Controls.Add(label10);
            panel8.Location = new Point(921, 8);
            panel8.Name = "panel8";
            panel8.Size = new Size(721, 53);
            panel8.TabIndex = 39;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Impact", 14F);
            label10.ForeColor = SystemColors.Control;
            label10.Location = new Point(10, 9);
            label10.Name = "label10";
            label10.Size = new Size(164, 35);
            label10.TabIndex = 1;
            label10.Text = "Return Items";
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(0, 0, 64);
            button8.FlatStyle = FlatStyle.Popup;
            button8.Font = new Font("Elephant", 10F);
            button8.ForeColor = Color.White;
            button8.Image = Properties.Resources.Home;
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Location = new Point(1285, 727);
            button8.Name = "button8";
            button8.Size = new Size(204, 38);
            button8.TabIndex = 35;
            button8.Text = "Add Item";
            button8.TextAlign = ContentAlignment.BottomCenter;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel7.Controls.Add(label9);
            panel7.Location = new Point(921, 483);
            panel7.Name = "panel7";
            panel7.Size = new Size(721, 53);
            panel7.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Impact", 14F);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(10, 9);
            label9.Name = "label9";
            label9.Size = new Size(121, 35);
            label9.TabIndex = 1;
            label9.Text = "New Item";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(0, 0, 64);
            label8.Location = new Point(921, 695);
            label8.Name = "label8";
            label8.Size = new Size(40, 32);
            label8.TabIndex = 31;
            label8.Text = "Id";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(921, 732);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(300, 31);
            textBox6.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(0, 0, 64);
            label7.Location = new Point(921, 585);
            label7.Name = "label7";
            label7.Size = new Size(142, 32);
            label7.TabIndex = 30;
            label7.Text = "Item Name";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(921, 622);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(568, 31);
            textBox5.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(0, 0, 64);
            label6.Location = new Point(17, 797);
            label6.Name = "label6";
            label6.Size = new Size(122, 32);
            label6.TabIndex = 38;
            label6.Text = "Quantity";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 832);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(279, 31);
            textBox1.TabIndex = 37;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(17, 620);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(712, 33);
            comboBox1.TabIndex = 36;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.FormattingEnabled = true;
            textBox2.Location = new Point(18, 127);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(514, 33);
            textBox2.TabIndex = 35;
            textBox2.SelectedIndexChanged += textBox2_SelectedIndexChanged;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(0, 0, 64);
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Elephant", 10F);
            button7.ForeColor = Color.White;
            button7.Image = Properties.Resources.Home;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(480, 832);
            button7.Name = "button7";
            button7.Size = new Size(204, 38);
            button7.TabIndex = 34;
            button7.Text = "Add Stock";
            button7.TextAlign = ContentAlignment.BottomCenter;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(0, 0, 64);
            label5.Location = new Point(480, 695);
            label5.Name = "label5";
            label5.Size = new Size(182, 32);
            label5.TabIndex = 33;
            label5.Text = "Puchase Price";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(480, 730);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(249, 31);
            textBox4.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(0, 0, 64);
            label4.Location = new Point(8, 697);
            label4.Name = "label4";
            label4.Size = new Size(165, 32);
            label4.TabIndex = 31;
            label4.Text = "Selling Price";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(17, 732);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(280, 31);
            textBox3.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 0, 64);
            label3.Location = new Point(8, 585);
            label3.Name = "label3";
            label3.Size = new Size(67, 32);
            label3.TabIndex = 29;
            label3.Text = "Item";
            label3.Click += label3_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel6.Controls.Add(label1);
            panel6.Location = new Point(7, 483);
            panel6.Name = "panel6";
            panel6.Size = new Size(722, 53);
            panel6.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 14F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(132, 35);
            label1.TabIndex = 1;
            label1.Text = "New Stock";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 202);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(729, 261);
            dataGridView1.TabIndex = 26;
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.FromArgb(0, 0, 64);
            button6.Image = Properties.Resources.Search;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(606, 127);
            button6.Name = "button6";
            button6.Size = new Size(123, 33);
            button6.TabIndex = 23;
            button6.Text = "Search";
            button6.TextAlign = ContentAlignment.MiddleRight;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(0, 0, 64);
            panel5.Location = new Point(-1, 464);
            panel5.Name = "panel5";
            panel5.Size = new Size(1654, 12);
            panel5.TabIndex = 9;
            // 
            // name1
            // 
            name1.AutoSize = true;
            name1.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            name1.ForeColor = Color.FromArgb(0, 0, 64);
            name1.Location = new Point(18, 92);
            name1.Name = "name1";
            name1.Size = new Size(67, 32);
            name1.TabIndex = 4;
            name1.Text = "Item";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(8, 8);
            panel4.Name = "panel4";
            panel4.Size = new Size(721, 53);
            panel4.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 14F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(10, 9);
            label2.Name = "label2";
            label2.Size = new Size(191, 35);
            label2.TabIndex = 1;
            label2.Text = "Stock  Checkup";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(0, 0, 64);
            label11.Location = new Point(921, 92);
            label11.Name = "label11";
            label11.Size = new Size(206, 32);
            label11.TabIndex = 40;
            label11.Text = "Sale ID Number";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(921, 129);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(329, 31);
            textBox7.TabIndex = 41;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(0, 0, 64);
            label12.Location = new Point(921, 183);
            label12.Name = "label12";
            label12.Size = new Size(214, 32);
            label12.TabIndex = 42;
            label12.Text = "Return Quantity";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(921, 218);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(329, 31);
            textBox8.TabIndex = 43;
            // 
            // button9
            // 
            button9.BackColor = Color.White;
            button9.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.FromArgb(0, 0, 64);
            button9.Image = Properties.Resources.Search;
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(1127, 270);
            button9.Name = "button9";
            button9.Size = new Size(123, 33);
            button9.TabIndex = 44;
            button9.Text = "Return";
            button9.TextAlign = ContentAlignment.MiddleRight;
            button9.UseVisualStyleBackColor = false;
            // 
            // Stock
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1898, 1024);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Stock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stock";
            WindowState = FormWindowState.Maximized;
            Load += Stock_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label name;
        private Panel panel2;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button5;
        private Panel panel3;
        private DataGridView dataGridView1;
        private Button button6;
        private Panel panel5;
        private Label name1;
        private Panel panel4;
        private Label label2;
        private Panel panel6;
        private Label label1;
        private Label label3;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Button button7;
        private ComboBox textBox2;
        private ComboBox comboBox1;
        private Label label6;
        private TextBox textBox1;
        private Button button8;
        private Panel panel7;
        private Label label9;
        private Label label8;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox5;
        private Panel panel8;
        private Label label10;
        private TextBox textBox8;
        private Label label12;
        private TextBox textBox7;
        private Label label11;
        private Button button9;
    }
}