using System.Windows.Forms;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace Master_Solar
{
    public partial class Stock : Form
    {
        // Add this at the top inside the class
        private System.Windows.Forms.Timer debounceTimer;
        private string lastSearchText;

        public Stock()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Stock_Load(object sender, EventArgs e)
        {
            debounceTimer = new System.Windows.Forms.Timer();
            debounceTimer.Interval = 300; // milliseconds
            debounceTimer.Tick += DebounceTimer_Tick;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            textBox2.TextChanged += (s, ev) =>
            {
                if (textBox2.Focused && textBox2.Text.Length >= 1)
                {
                    lastSearchText = textBox2.Text;
                    debounceTimer.Stop();
                    debounceTimer.Start();
                }
            };

            comboBox1.TextChanged += (s, ev) =>
            {
                if (comboBox1.Focused && comboBox1.Text.Length >= 1)
                {
                    lastSearchText = comboBox1.Text;
                    debounceTimer.Stop();
                    debounceTimer.Start();
                }
            };

            // Handle Enter key to move focus
            comboBox1.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    ev.SuppressKeyPress = true; // prevent ding sound
                    textBox3.Focus();
                }
                textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            };
        }
        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            if (textBox2.Focused)
                LoadMatchingItems(textBox2.Text);
            else if (comboBox1.Focused)
                LoadMatchingItemsForComboBox1(comboBox1.Text);
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            History f2 = new History();
            f2.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
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
        //==============================================================
        private void LoadMatchingItems(string searchTerm)
        {
            textBox2.Items.Clear();
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT ItemName FROM inventory WHERE ItemName LIKE @term LIMIT 10";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@term", searchTerm + "%");
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox2.Items.Add(reader.GetString("ItemName"));
                        }
                    }
                }
            }
            if (textBox2.Items.Count > 0)
            {
                textBox2.DroppedDown = true;
                textBox2.SelectionStart = textBox2.Text.Length;
                textBox2.SelectionLength = 0;
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string itemName = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemName))
            {
                MessageBox.Show("Please enter an item name.");
                return;
            }

            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"SELECT i.ItemID, i.ItemName, i.SellingPrice, SUM(b.Quantity) AS TotalQuantity
FROM
    inventory i
JOIN
    inventory_batches b ON i.ItemID = b.ItemID
WHERE
    i.ItemName = @ItemName
GROUP BY
    i.ItemID, i.ItemName, i.SellingPrice";
                    // exact match — change to LIKE for partial search

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", itemName);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        if (resultTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No item found with that name.");
                        }

                        dataGridView1.DataSource = resultTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stock: " + ex.Message);
            }
        }
        //=============================
        private void LoadMatchingItemsForComboBox1(string input)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT DISTINCT ItemName FROM inventory WHERE ItemName LIKE @input LIMIT 10";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@input", input + "%");

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            List<string> suggestions = new List<string>();
                            while (dr.Read())
                            {
                                suggestions.Add(dr["ItemName"].ToString());
                            }

                            // Save current text and cursor position
                            string currentText = comboBox1.Text;
                            int cursor = comboBox1.SelectionStart;

                            comboBox1.BeginUpdate();
                            comboBox1.Items.Clear();
                            comboBox1.Items.AddRange(suggestions.ToArray());
                            comboBox1.DroppedDown = true;
                            comboBox1.EndUpdate();

                            // Restore text and cursor
                            comboBox1.Text = currentText;
                            comboBox1.SelectionStart = cursor;
                            comboBox1.SelectionLength = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading item suggestions for comboBox1: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
            string selectedItemName = comboBox1.Text.Trim();
            int purchasePrice = int.Parse(textBox4.Text.Trim());
            int sellingPrice = int.Parse(textBox3.Text.Trim());
            int quantity = int.Parse(textBox1.Text.Trim());

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                // Step 1: Get ItemID from ItemName
                string getItemIDQuery = "SELECT ItemID FROM inventory WHERE ItemName = @ItemName LIMIT 1";
                MySqlCommand getItemCmd = new MySqlCommand(getItemIDQuery, con);
                getItemCmd.Parameters.AddWithValue("@ItemName", selectedItemName);

                string itemId = getItemCmd.ExecuteScalar()?.ToString();

                if (string.IsNullOrEmpty(itemId))
                {
                    MessageBox.Show("Item not found in inventory.");
                    return;
                }

                // Step 2: Update SellingPrice in inventory
                string updateInventoryQuery = "UPDATE inventory SET SellingPrice = @SellingPrice WHERE ItemID = @ItemID";
                MySqlCommand updateCmd = new MySqlCommand(updateInventoryQuery, con);
                updateCmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                updateCmd.Parameters.AddWithValue("@ItemID", itemId);
                updateCmd.ExecuteNonQuery();

                // Step 3: Insert new inventory_batch record (for FIFO)
                string insertBatchQuery = @"
            INSERT INTO inventory_batches (ItemID, EntryDate, PurchasePrice, Quantity)
            VALUES (@ItemID, CURDATE(), @PurchasePrice, @Quantity)";
                MySqlCommand insertBatchCmd = new MySqlCommand(insertBatchQuery, con);
                insertBatchCmd.Parameters.AddWithValue("@ItemID", itemId);
                insertBatchCmd.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
                insertBatchCmd.Parameters.AddWithValue("@Quantity", quantity);
                insertBatchCmd.ExecuteNonQuery();

                MessageBox.Show("Inventory updated and new batch added (FIFO enabled).");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string itemId = textBox6.Text.Trim();
            string itemName = textBox5.Text.Trim();

            if (string.IsNullOrEmpty(itemId) || string.IsNullOrEmpty(itemName))
            {
                MessageBox.Show("Please enter both Item ID and Item Name.");
                return;
            }
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO inventory (ItemID, ItemName, SellingPrice) VALUES (@ItemID, @ItemName, 0)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemId);
                        cmd.Parameters.AddWithValue("@ItemName", itemName);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item added successfully with SellingPrice.");
                            textBox5.Clear();
                            textBox6.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert item.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
