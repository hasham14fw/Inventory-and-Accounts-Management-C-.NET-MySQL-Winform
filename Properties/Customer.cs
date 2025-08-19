using MySql.Data.MySqlClient; // Add this at the top
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Master_Solar.Properties
{
    public partial class Customer : Form
    {
        string printCustomerName, printContact;
        decimal printOldBalance, printDepositAmount, printNewBalance;
        DateTime printDateTime;

        public Customer()
        {
            InitializeComponent();

        }
        // Auto load of Customers

        //private void LoadCustomerNamesForAutocomplete()
        //{
        //    try
        //    {
        //        AutoCompleteStringCollection nameCollection = new AutoCompleteStringCollection();

        //        string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

        //        using (MySqlConnection con = new MySqlConnection(connectionString))
        //        {
        //            con.Open();
        //            MySqlCommand cmd = new MySqlCommand("SELECT Name FROM Customer", con);
        //            MySqlDataReader dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                nameCollection.Add(dr["Name"].ToString());
        //            }

        //            dr.Close();
        //        }

        //        namebox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        namebox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //        namebox.AutoCompleteCustomSource = nameCollection;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading autocomplete: " + ex.Message);
        //    }
        //}


        private void Customer_Load(object sender, EventArgs e)
        {
            LoadCustomerNames();

            // Enable searchable dropdown
            namebox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            namebox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bill f2 = new Bill();
            f2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stock f2 = new Stock();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            History f2 = new History();
            f2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
            string query = @"
 SELECT c.CustomerID, c.Name, c.Phone, c.Address, ca.Balance
 FROM Customer c
 JOIN CustomerAccount ca ON c.CustomerID = ca.CustomerID
 WHERE ";

            MySqlCommand cmd = new MySqlCommand();

            if (!string.IsNullOrWhiteSpace(idbox.Text))
            {
                query += "c.CustomerID = @CustomerID";
                cmd.Parameters.AddWithValue("@CustomerID", int.Parse(idbox.Text));
            }
            else if (!string.IsNullOrWhiteSpace(namebox.Text))
            {
                query += "c.Name = @Name";
                cmd.Parameters.AddWithValue("@Name", namebox.Text);
            }
            else
            {
                MessageBox.Show("Please enter ID or Name to search.");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = query;

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        idbox1.Text = dr["CustomerID"].ToString();
                        namebox1.Text = dr["Name"].ToString();
                        contact.Text = dr["Phone"].ToString();
                        address.Text = dr["Address"].ToString();
                        balance.Text = dr["Balance"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                    }
                }
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void namebox1_TextChanged(object sender, EventArgs e)
        {

        }
        // updating balance 
        private void UpdateCustomerBalance(int customerId, int newBalance)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE CustomerAccount SET Balance = @NewBalance WHERE CustomerID = @CustomerID";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NewBalance", newBalance);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Balance updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update balance.");
                    }
                }
            }
        }
        // payment history
        private void InsertTransactionHistory(int customerId, int amount, int balanceAfter, DateTime transactionDate)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = @"
            INSERT INTO accounttransactionhistory (CustomerID, Amount, BalanceAfterTransaction, TransactionDate)
            VALUES (@CustomerID, @Amount, @BalanceAfterTransaction, @TransactionDate)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@BalanceAfterTransaction", balanceAfter);
                    cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // update button functioning
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Read customer ID
                if (string.IsNullOrWhiteSpace(idbox1.Text))
                {
                    MessageBox.Show("Customer ID not loaded.");
                    return;
                }

                int customerId = int.Parse(idbox1.Text);

                // 2. Read received amount
                if (!int.TryParse(receive.Text, out int receivedAmount))
                {
                    MessageBox.Show("Please enter a valid number in the 'Receive' field.");
                    return;
                }

                // 3. Read current balance
                if (!int.TryParse(balance.Text, out int currentBalance))
                {
                    MessageBox.Show("Invalid balance format.");
                    return;
                }

                // 4. Calculate new balance (can be negative)
                int newBalance = currentBalance - receivedAmount;
                printCustomerName = namebox1.Text.Trim(); // or textBoxName.Text
                printContact = contact.Text.Trim(); // your contact box if available
                printOldBalance = decimal.Parse(balance.Text);  // before deposit
                printDepositAmount = decimal.Parse(receive.Text);  // deposited amount
                printNewBalance = newBalance;  // after deposit
                printDateTime = DateTime.Now;
                // 5. Show new balance
                MessageBox.Show($"New Balance: {newBalance}");

                // 6. Update balance textbox
                balance.Text = newBalance.ToString();

                // 7. Optional: update in DB
                UpdateCustomerBalance(customerId, newBalance);
                InsertTransactionHistory(customerId, receivedAmount, newBalance, DateTime.Now);

                idbox.Text = "";
                namebox.Text = "";
                idbox1.Text = "";
                namebox1.Text = "";
                contact.Text = "";
                address.Text = "";
                balance.Text = "";
                receive.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void PrintReceipt()
        {
            PrintDocument printDoc = new PrintDocument();

            // Optional: Set printer name
            // printDoc.PrinterSettings.PrinterName = "XP-58"; 

            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 280, 500); // 58mm

            try
            {
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printing failed: " + ex.Message);
            }
        }

        private void idbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }
        private void LoadCustomerNames()
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT DISTINCT Name FROM customer"; // Assuming customer table has a 'Name' column
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            namebox.Items.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = 10;
            int lineHeight = 20;

            Font font = new Font("Courier New", 9);
            Font bold = new Font("Courier New", 9, FontStyle.Bold);

            g.DrawString("   Master Solars Hasilpur", bold, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString("================================", font, Brushes.Black, 10, y); y += lineHeight;

            g.DrawString($"Name  : {printCustomerName}", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString($"Phone : {printContact}", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString($"Date  : {printDateTime:dd/MM/yyyy hh:mm tt}", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString($"Old Balance : Rs. {printOldBalance}", font, Brushes.Black, 10, y); y += lineHeight;

            g.DrawString("--------------------------------", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString($"Deposit     : Rs. {printDepositAmount}", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString($"New Balance : Rs. {printNewBalance}", bold, Brushes.Black, 10, y); y += lineHeight;

            g.DrawString("================================", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString("Thanks for purchasing!", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString("Master Solars - Hasilpur", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString("================================", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString("Developed by: M. Ahmad Hasham", font, Brushes.Black, 10, y); y += lineHeight;
            g.DrawString("Contact: 0327-0222414", font, Brushes.Black, 10, y);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}





