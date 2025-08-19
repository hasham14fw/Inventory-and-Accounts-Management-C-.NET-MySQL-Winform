using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Master_Solar.Properties
{
    public partial class Bill : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private string billContent = ""; // Stores formatted printable bill
        public Bill()
        {
            InitializeComponent();
            textBox4.KeyUp += textBox4_KeyUp;
            dataGridView1.AllowUserToAddRows = true;



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
                            string currentText = textBox4.Text;
                            int cursor = textBox4.SelectionStart;

                            textBox4.BeginUpdate();
                            textBox4.Items.Clear();
                            textBox4.Items.AddRange(suggestions.ToArray());
                            textBox4.DroppedDown = true;
                            textBox4.EndUpdate();

                            // Restore typed text and cursor
                            textBox4.Text = currentText;
                            textBox4.SelectionStart = cursor;
                           textBox4.SelectionLength = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suggestions: " + ex.Message);
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stock f2 = new Stock();
            f2.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.Name == "ItemName")
            {
                // Use fully qualified name to resolve ambiguity
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();

                    string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "SELECT DISTINCT ItemName FROM inventory";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                suggestions.Add(dr.GetString(0));
                            }
                        }
                    }

                    tb.AutoCompleteCustomSource = suggestions;
                }
            }
        }



        private void Bill_Load(object sender, EventArgs e)
        {
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;


            dataGridView1.Columns.Add("ItemID", "Item ID"); // Readonly
            dataGridView1.Columns.Add("ItemName", "Item Name");
            dataGridView1.Columns.Add("SellingPrice", "Selling Price"); // Readonly
            dataGridView1.Columns.Add("Discount", "Discount");
            dataGridView1.Columns.Add("PriceAfterDiscount", "Price After Discount"); // Readonly
            dataGridView1.Columns.Add("Quantity", "Quantity");
            dataGridView1.Columns.Add("Total", "Total"); // Readonly

            // Make read-only columns
            dataGridView1.Columns["ItemID"].ReadOnly = true;
            dataGridView1.Columns["SellingPrice"].ReadOnly = true;
            dataGridView1.Columns["PriceAfterDiscount"].ReadOnly = true;
            dataGridView1.Columns["Total"].ReadOnly = true;


            comboBox4.Items.Add("Paid");
            comboBox4.Items.Add("Account");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            textBox4.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox4.SelectedItem = "Paid"; // default mode
            textBox1.Enabled = false;
            textBox1.Enabled = false;


        }
        private void RecalculateTotals()
        {
            int totalBeforeDiscount = 0;
            int totalAfterDiscount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int.TryParse(row.Cells["SellingPrice"].Value?.ToString(), out int price);
                int.TryParse(row.Cells["Discount"].Value?.ToString(), out int discount);
                int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int qty);

                if (qty <= 0) qty = 1;
                if (discount < 0) discount = 0;

                int priceAfterDiscount = price - discount;
                if (priceAfterDiscount < 0) priceAfterDiscount = 0;

                totalBeforeDiscount += price * qty;
                totalAfterDiscount += priceAfterDiscount * qty;
            }

            textBox2.Text = totalBeforeDiscount.ToString();  // 💰 SellingPrice × Quantity (before discount)
            textBox3.Text = totalAfterDiscount.ToString();   // 💰 After discount
        }




        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (dataGridView1.Rows[rowIndex].IsNewRow) return;

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (columnName == "ItemName")
            {
                string itemName = dataGridView1.Rows[rowIndex].Cells["ItemName"].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(itemName))
                {
                    LoadItemDetails(itemName, rowIndex);
                }
            }
            else if (columnName == "Discount" || columnName == "Quantity")
            {
                string itemName = dataGridView1.Rows[rowIndex].Cells["ItemName"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(itemName)) return;

                int.TryParse(dataGridView1.Rows[rowIndex].Cells["SellingPrice"].Value?.ToString(), out int price);
                int.TryParse(dataGridView1.Rows[rowIndex].Cells["Discount"].Value?.ToString(), out int discount);
                int.TryParse(dataGridView1.Rows[rowIndex].Cells["Quantity"].Value?.ToString(), out int qty);

                if (qty <= 0) qty = 1;
                if (discount < 0) discount = 0;

                // ✅ Check available stock
                int availableStock = GetAvailableStock(itemName);
                if (qty > availableStock)
                {
                    MessageBox.Show($"Only {availableStock} units of \"{itemName}\" are available in inventory.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.Rows.RemoveAt(rowIndex); // ❌ Remove row
                    return;
                }

                int priceAfterDiscount = price - discount;
                if (priceAfterDiscount < 0) priceAfterDiscount = 0;

                int total = priceAfterDiscount * qty;

                dataGridView1.Rows[rowIndex].Cells["PriceAfterDiscount"].Value = priceAfterDiscount;
                dataGridView1.Rows[rowIndex].Cells["Total"].Value = total;

                RecalculateTotals();
            }
        }
        //============================  New Available Stock   ===============================
        private int GetAvailableStock(string itemName)
        {
            int stock = 0;
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = @"
            SELECT SUM(b.Quantity) AS TotalStock
            FROM inventory i
            JOIN inventory_batches b ON i.ItemID = b.ItemID
            WHERE i.ItemName = @ItemName";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ItemName", itemName);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        int.TryParse(result.ToString(), out stock);
                    }
                }
            }

            return stock;
        }

        //============================  New Item Details   ===============================
        private void LoadItemDetails(string itemName, int rowIndex)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = @"
            SELECT 
                i.ItemID, 
                i.SellingPrice, 
                IFNULL(SUM(b.Quantity), 0) AS TotalStock
            FROM 
                inventory i
            LEFT JOIN 
                inventory_batches b ON i.ItemID = b.ItemID
            WHERE 
                i.ItemName = @ItemName
            GROUP BY 
                i.ItemID, i.SellingPrice";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ItemName", itemName);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int price = Convert.ToInt32(dr["SellingPrice"]);
                            int totalStock = Convert.ToInt32(dr["TotalStock"]);

                            if (totalStock < 1)
                            {
                                MessageBox.Show("Insufficient stock available.");

                                // Clear the row
                                foreach (DataGridViewCell cell in dataGridView1.Rows[rowIndex].Cells)
                                {
                                    cell.Value = null;
                                }
                                return;
                            }

                            dataGridView1.Rows[rowIndex].Cells["ItemID"].Value = dr["ItemID"].ToString();
                            dataGridView1.Rows[rowIndex].Cells["SellingPrice"].Value = price;
                            dataGridView1.Rows[rowIndex].Cells["Quantity"].Value = 1;
                            dataGridView1.Rows[rowIndex].Cells["Discount"].Value = 0;

                            int priceAfterDiscount = price;
                            int total = priceAfterDiscount;

                            dataGridView1.Rows[rowIndex].Cells["PriceAfterDiscount"].Value = priceAfterDiscount;
                            dataGridView1.Rows[rowIndex].Cells["Total"].Value = total;

                            RecalculateTotals();
                        }
                        else
                        {
                            MessageBox.Show("Item not found.");
                            // Also clear row if item not found
                            foreach (DataGridViewCell cell in dataGridView1.Rows[rowIndex].Cells)
                            {
                                cell.Value = null;
                            }
                        }
                    }
                }
            }
        }





        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents going to new row
                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name == "ItemName")
                {
                    string itemName = dataGridView1.Rows[rowIndex].Cells["ItemName"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(itemName))
                    {
                        LoadItemDetails(itemName, rowIndex);
                    }
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                int? customerId = null;

                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    customerId = int.Parse(textBox1.Text);

                    if (comboBox4.SelectedItem?.ToString() == "Account")
                    {
                        int.TryParse(textBox3.Text, out int amount);
                        string updateBalanceQuery = "UPDATE customeraccount SET Balance = Balance + @amount WHERE CustomerID = @CustomerID";
                        using (MySqlCommand balanceCmd = new MySqlCommand(updateBalanceQuery, con))
                        {
                            balanceCmd.Parameters.AddWithValue("@amount", amount);
                            balanceCmd.Parameters.AddWithValue("@CustomerID", customerId);
                            balanceCmd.ExecuteNonQuery();
                        }
                    }
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string itemID = row.Cells["ItemID"].Value?.ToString();
                    string itemName = row.Cells["ItemName"].Value?.ToString();
                    int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int qtyNeeded);
                    int.TryParse(row.Cells["SellingPrice"].Value?.ToString(), out int sellingPrice);
                    int.TryParse(row.Cells["Discount"].Value?.ToString(), out int perUnitDiscount);

                    int unitFinalPrice = sellingPrice - perUnitDiscount;

                    // Get FIFO batches
                    List<(int BatchID, int Quantity, int PurchasePrice)> fifoBatches = new List<(int, int, int)>();
                    string batchQuery = @"
                SELECT BatchID, Quantity, PurchasePrice 
                FROM inventory_batches 
                WHERE ItemID = @ItemID AND Quantity > 0 
                ORDER BY EntryDate ASC";

                    using (MySqlCommand batchCmd = new MySqlCommand(batchQuery, con))
                    {
                        batchCmd.Parameters.AddWithValue("@ItemID", itemID);
                        using (MySqlDataReader reader = batchCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int batchId = Convert.ToInt32(reader["BatchID"]);
                                int qty = Convert.ToInt32(reader["Quantity"]);
                                int purchasePrice = Convert.ToInt32(reader["PurchasePrice"]);
                                fifoBatches.Add((batchId, qty, purchasePrice));
                            }
                        }
                    }

                    foreach (var batch in fifoBatches)
                    {
                        if (qtyNeeded <= 0) break;

                        int usedQty = Math.Min(batch.Quantity, qtyNeeded);
                        int totalFinalPrice = unitFinalPrice * usedQty;

                        string insertQuery = @"
                    INSERT INTO saleitems 
                    (ItemID, ItemName, QuantitySold, SellingPrice, Discount, FinalPrice, CustomerID, Date, BatchID)
                    VALUES 
                    (@ItemID, @ItemName, @QuantitySold, @SellingPrice, @Discount, @FinalPrice, @CustomerID, CURDATE(), @BatchID)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@ItemID", itemID);
                            insertCmd.Parameters.AddWithValue("@ItemName", itemName);
                            insertCmd.Parameters.AddWithValue("@QuantitySold", usedQty);
                            insertCmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);  // per unit
                            insertCmd.Parameters.AddWithValue("@Discount", perUnitDiscount);  // per unit
                            insertCmd.Parameters.AddWithValue("@FinalPrice", totalFinalPrice); // total for this batch
                            insertCmd.Parameters.AddWithValue("@CustomerID", customerId.HasValue ? (object)customerId.Value : DBNull.Value);
                            insertCmd.Parameters.AddWithValue("@BatchID", batch.BatchID);
                            insertCmd.ExecuteNonQuery();
                        }

                        // Update inventory_batches
                        string updateBatchQuery = "UPDATE inventory_batches SET Quantity = Quantity - @UsedQty WHERE BatchID = @BatchID";
                        using (MySqlCommand updateBatchCmd = new MySqlCommand(updateBatchQuery, con))
                        {
                            updateBatchCmd.Parameters.AddWithValue("@UsedQty", usedQty);
                            updateBatchCmd.Parameters.AddWithValue("@BatchID", batch.BatchID);
                            updateBatchCmd.ExecuteNonQuery();
                        }

                        qtyNeeded -= usedQty;
                    }
                }
                MessageBox.Show("Ch Ahmad Sb hun Client ko Paise pharlo ku ke bill ho gya je...");
            }
            GenerateBillText();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument.Print(); // Sends to default printer
            dataGridView1.Rows.Clear();
            textBox4.SelectedIndex = -1;
            textBox1.SelectedIndex = -1;
            textBox2.Clear();
            textBox3.Clear();
        }

        private void GenerateBillText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("           Master  Solars         ");
            sb.AppendLine("              Hasilpur           ");
            sb.AppendLine("      ----------------------     ");
            sb.AppendLine($"Date: {DateTime.Now.ToShortDateString()}    Time: {DateTime.Now.ToShortTimeString()}");

            if (!string.IsNullOrWhiteSpace(textBox1.Text) && comboBox4.SelectedItem?.ToString() == "Account")
            {
                sb.AppendLine("Customer: " + textBox1.Text);
            }

            sb.AppendLine("================================================");
            sb.AppendLine("Item       Price  Disc  Qty  Total");
            sb.AppendLine("------------------------------------------------");

            decimal totalDiscountAmount = 0;
            decimal totalFinalAmount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells["ItemName"].Value?.ToString();
                string qtyStr = row.Cells["Quantity"].Value?.ToString();
                string priceStr = row.Cells["SellingPrice"].Value?.ToString();
                string discountStr = row.Cells["Discount"].Value?.ToString();
                string priceAfterDiscStr = row.Cells["PriceAfterDiscount"].Value?.ToString();
                string totalStr = row.Cells["Total"].Value?.ToString();

                int qty = int.TryParse(qtyStr, out var q) ? q : 0;
                decimal price = decimal.TryParse(priceStr, out var p) ? p : 0;
                decimal discount = decimal.TryParse(discountStr, out var d) ? d : 0;
                decimal priceAfterDiscount = decimal.TryParse(priceAfterDiscStr, out var pad) ? pad : 0;
                decimal total = decimal.TryParse(totalStr, out var t) ? t : 0;

                decimal itemDiscountTotal = discount * qty;

                totalDiscountAmount += itemDiscountTotal;
                totalFinalAmount += total;

                if (!string.IsNullOrWhiteSpace(name))
                {
                    name = name.Length > 10 ? name.Substring(0, 10) : name.PadRight(10);
                    string pricePadded = price.ToString("F0").PadLeft(5);
                    string discountPadded = discount.ToString("F0").PadLeft(5);
                    string qtyPadded = qtyStr?.PadLeft(3);
                    string totalPadded = total.ToString("F0").PadLeft(6);

                    sb.AppendLine($"{name} {pricePadded} {discountPadded} {qtyPadded} {totalPadded}");
                }
            }

            sb.AppendLine("------------------------------------------------");
            sb.AppendLine($"Total Discount: {totalDiscountAmount:F0}".PadLeft(42));
            sb.AppendLine($"Total Amount  : {totalFinalAmount:F0}".PadLeft(42));
            sb.AppendLine($"Mode          : {comboBox4.SelectedItem?.ToString()}".PadLeft(42));
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine("   Thank you for your purchase!  ");
            sb.AppendLine("         Master Solars Hasilpur            ");
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine("Developed By : M. Ahmad Hasham");
            sb.AppendLine("Contact: 0327-0222414");

            billContent = sb.ToString();
        }


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Courier New", 10); // fixed-width for alignment
            float x = 10, y = 10;
            e.Graphics.DrawString(billContent, printFont, Brushes.Black, x, y);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isAccount = comboBox4.SelectedItem?.ToString() == "Account";

            textBox1.Enabled = isAccount;
            textBox4.Enabled = isAccount;

            if (!isAccount)
            {
                textBox1.SelectedIndex = -1;
                textBox4.SelectedIndex = -1;
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {

            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                // If user entered name, fetch ID
                if (!string.IsNullOrWhiteSpace(textBox4.Text) && string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    string query = "SELECT CustomerID FROM customer WHERE Name = @name LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", textBox4.Text.Trim());
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            textBox1.Text = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Customer not found by name.");
                        }
                    }
                }

                // If user entered ID, fetch name
                else if (!string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    string query = "SELECT Name FROM customer WHERE CustomerID = @id LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", textBox1.Text.Trim());
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            textBox4.Text = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Customer not found by ID.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter either Customer Name or ID.");
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (comboBox4.SelectedItem?.ToString() != "Account")
            //{
            //    e.Handled = true; // block input
            //}
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (comboBox4.SelectedItem?.ToString() != "Account")
            //{
            //    e.Handled = true; // block input
            //}
        }

        private void textBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            // Avoid filtering on navigation keys
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                return;

            string input = textBox4.Text;
            if (!string.IsNullOrWhiteSpace(input))
            {
                LoadMatchingNames(input);
            }
        }
    }
}



