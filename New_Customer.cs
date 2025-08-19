
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Master_Solar.Properties;

namespace Master_Solar
{
    public partial class New_Customer : Form
    {
        public New_Customer()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer f2 = new Customer();
            f2.Show();
            this.Hide();

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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Read values from textboxes
                int customerId = int.Parse(idbox.Text.Trim());
                string name = namebox.Text.Trim();
                string phone = contactbox.Text.Trim();
                string address = addressbox.Text.Trim();
                int initialBalance = int.Parse(balancebox.Text.Trim());

                // Step 2: Connection string
                string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    // Start a transaction to keep both inserts atomic
                    MySqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        // Insert into Customer table
                        string customerInsertQuery = @"
                    INSERT INTO Customer (CustomerID, Name, Phone, Address) 
                    VALUES (@CustomerID, @Name, @Phone, @Address)";

                        using (MySqlCommand cmd = new MySqlCommand(customerInsertQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", customerId);
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Phone", phone);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.ExecuteNonQuery();
                        }

                        // Insert into CustomerAccount table
                        string accountInsertQuery = @"
                    INSERT INTO CustomerAccount (CustomerID, Balance) 
                    VALUES (@CustomerID, @Balance)";

                        using (MySqlCommand cmd = new MySqlCommand(accountInsertQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", customerId);
                            cmd.Parameters.AddWithValue("@Balance", initialBalance);
                            cmd.ExecuteNonQuery();
                        }

                        // Commit the transaction
                        transaction.Commit();
                        MessageBox.Show("Customer added successfully.");
                        idbox.Text = "";
                        namebox.Text = "";
                        contactbox.Text = "";
                        addressbox.Text = "";
                        balancebox.Text = "";
                    }
                    catch (Exception ex)
                    {
                        // Rollback if any insert fails
                        transaction.Rollback();
                        MessageBox.Show("Error inserting customer: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input error: " + ex.Message);
            }
        }
    }
}
