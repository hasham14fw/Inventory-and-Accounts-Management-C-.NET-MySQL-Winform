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

namespace Master_Solar.Properties
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            namebox1.KeyUp += namebox1_KeyUp;
        }
        private void namebox1_KeyUp(object sender, KeyEventArgs e)
        {
            // Avoid filtering on navigation keys
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                return;

            string input = namebox1.Text;
            if (!string.IsNullOrWhiteSpace(input))
            {
                LoadMatchingNames(input);
            }
        }
        private void LoadMatchingNames(string input)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT DISTINCT Name FROM Customer WHERE Name LIKE @input LIMIT 10";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@input", input + "%");

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            List<string> suggestions = new List<string>();
                            while (dr.Read())
                            {
                                suggestions.Add(dr["Name"].ToString());
                            }

                            // Save the typed text before clearing
                            string currentText = namebox1.Text;
                            int cursor = namebox1.SelectionStart;

                            namebox1.BeginUpdate();
                            namebox1.Items.Clear();
                            namebox1.Items.AddRange(suggestions.ToArray());
                            namebox1.DroppedDown = true;
                            namebox1.EndUpdate();

                            // Restore typed text and cursor
                            namebox1.Text = currentText;
                            namebox1.SelectionStart = cursor;
                            namebox1.SelectionLength = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suggestions: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stock f2 = new Stock();
            f2.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer f2 = new Customer();
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bill f2 = new Bill();
            f2.Show();
            this.Hide();
        }

        private void History_Load(object sender, EventArgs e)
        {
            namebox1.DropDownStyle = ComboBoxStyle.DropDown;
            //namebox1.TextChanged += namebox1_TextChanged;
            comboBox1.Items.Add("Sales");
            comboBox1.Items.Add("Payment");
            comboBox1.Items.Add("Recovery");
            comboBox1.SelectedIndex = 0;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // auto completion
        private void UpdateDropdownItems(string input)
        {
            isUpdatingDropdown = true;

            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT DISTINCT Name FROM Customer WHERE Name LIKE @input LIMIT 10";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@input", input + "%");

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            var results = new List<string>();
                             while (dr.Read())
                            {
                                results.Add(dr["Name"].ToString());
                            }

                            namebox1.BeginUpdate();
                            namebox1.Items.Clear();
                            namebox1.Items.AddRange(results.ToArray());
                            namebox1.EndUpdate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading names: " + ex.Message);
            }
            finally
            {
                isUpdatingDropdown = false;
            }
        }

        private bool isUpdatingDropdown = false;



        private void namebox1_TextChanged(object sender, EventArgs e)
        {

        }







        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
            string customerId = idbox.Text.Trim();
            string customerName = namebox1.Text.Trim();
            string selectedMonth = month.Text.Trim(); // Expecting full month name (e.g., "July")
            string selectedType = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedType))
            {
                MessageBox.Show("Please select a Type (Sales, Payment or Recovery).");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                if (selectedType == "Sales")
                {
                    query = @"
                SELECT s.SaleItemID, s.ItemName, s.QuantitySold, s.SellingPrice, s.Discount, s.FinalPrice, s.Date, c.CustomerID, c.Name
                FROM saleitems s
                LEFT JOIN customer c ON s.CustomerID = c.CustomerID
                WHERE 1 = 1
            ";

                    if (!string.IsNullOrWhiteSpace(customerId))
                    {
                        query += " AND s.CustomerID = @CustomerID ";
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    }

                    if (!string.IsNullOrWhiteSpace(customerName))
                    {
                        query += " AND c.Name LIKE @CustomerName ";
                        cmd.Parameters.AddWithValue("@CustomerName", "%" + customerName + "%");
                    }

                    if (!string.IsNullOrWhiteSpace(selectedMonth))
                    {
                        query += " AND MONTHNAME(s.Date) = @Month ";
                        cmd.Parameters.AddWithValue("@Month", selectedMonth);
                    }
                }
                else if (selectedType == "Payment")
                {
                    query = @"
                SELECT a.TransactionID, a.CustomerID, c.Name, a.Amount, a.TransactionDate
                FROM accounttransactionhistory a
                LEFT JOIN customer c ON a.CustomerID = c.CustomerID
                WHERE 1 = 1
            ";

                    if (!string.IsNullOrWhiteSpace(customerId))
                    {
                        query += " AND a.CustomerID = @CustomerID ";
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    }

                    if (!string.IsNullOrWhiteSpace(customerName))
                    {
                        query += " AND c.Name LIKE @CustomerName ";
                        cmd.Parameters.AddWithValue("@CustomerName", "%" + customerName + "%");
                    }

                    if (!string.IsNullOrWhiteSpace(selectedMonth))
                    {
                        query += " AND MONTHNAME(a.TransactionDate) = @Month ";
                        cmd.Parameters.AddWithValue("@Month", selectedMonth);
                    }
                }
                else if (selectedType == "Recovery")
                {
                    // Updated according to your schema: customer and customeraccount
                    query = @"
                SELECT c.CustomerID, c.Name, c.Phone, c.Address, ca.Balance
                FROM customer c
                INNER JOIN customeraccount ca ON c.CustomerID = ca.CustomerID
                WHERE ca.Balance > 0
            ";

                    if (!string.IsNullOrWhiteSpace(customerId))
                    {
                        query += " AND c.CustomerID = @CustomerID ";
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    }

                    if (!string.IsNullOrWhiteSpace(customerName))
                    {
                        query += " AND c.Name LIKE @CustomerName ";
                        cmd.Parameters.AddWithValue("@CustomerName", "%" + customerName + "%");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Type selected.");
                    return;
                }

                cmd.CommandText = query;

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void namebox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
