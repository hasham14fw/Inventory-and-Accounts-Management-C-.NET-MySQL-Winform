using MySql.Data.MySqlClient;
using System.Drawing;
using Master_Solar.Properties;
using MySqlX.XDevAPI.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Globalization;
namespace Master_Solar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadMonthlySale();
            LoadMonthlyProfit();
            LoadBalanceSummary();
        }

        // recovery and additional
        private void LoadBalanceSummary()
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = @"
            SELECT
                IFNULL(SUM(CASE WHEN Balance < 0 THEN Balance ELSE 0 END), 0) AS NegativeBalance,
                IFNULL(SUM(CASE WHEN Balance > 0 THEN Balance ELSE 0 END), 0) AS PositiveBalance
            FROM customeraccount;";  // ✅ Corrected table name

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int negative = Convert.ToInt32(reader["NegativeBalance"]);
                        int positive = Convert.ToInt32(reader["PositiveBalance"]);

                        label21.Text = negative.ToString();
                        label20.Text = positive.ToString();
                    }
                }
            }
        }



        // Monthly Profit
        private void LoadMonthlyProfit()
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string saleQuery = @"
                SELECT SaleItemID, ItemID, QuantitySold, FinalPrice
                FROM saleitems
                WHERE MONTH(Date) = MONTH(CURDATE()) 
                  AND YEAR(Date) = YEAR(CURDATE())
                ORDER BY Date ASC;";

                    MySqlCommand saleCmd = new MySqlCommand(saleQuery, con);
                    MySqlDataReader saleReader = saleCmd.ExecuteReader();

                    var sales = new List<(string ItemID, int Qty, decimal FinalPrice)>();
                    while (saleReader.Read())
                    {
                        string itemId = saleReader.GetString("ItemID");
                        int qty = saleReader.GetInt32("QuantitySold");
                        decimal final = saleReader.GetDecimal("FinalPrice");

                        sales.Add((itemId, qty, final));
                    }
                    saleReader.Close();

                    decimal totalProfit = 0;

                    foreach (var sale in sales)
                    {
                        int remainingQty = sale.Qty;
                        decimal totalCost = 0;

                        string batchQuery = @"
                    SELECT PurchasePrice, Quantity
                    FROM inventory_batches
                    WHERE ItemID = @ItemID
                    AND Quantity > 0
                    ORDER BY EntryDate ASC;";

                        using (MySqlCommand batchCmd = new MySqlCommand(batchQuery, con))
                        {
                            batchCmd.Parameters.Clear();
                            batchCmd.Parameters.AddWithValue("@ItemID", sale.ItemID);
                            using (MySqlDataReader batchReader = batchCmd.ExecuteReader())
                            {
                                while (batchReader.Read() && remainingQty > 0)
                                {
                                    int batchQty = batchReader.GetInt32("Quantity");
                                    decimal purchasePrice = batchReader.GetDecimal("PurchasePrice");

                                    int usedQty = Math.Min(remainingQty, batchQty);
                                    totalCost += usedQty * purchasePrice;
                                    remainingQty -= usedQty;
                                }
                            }
                        }

                        // If not enough stock in batches, skip profit to avoid incorrect negative
                        if (remainingQty == 0)
                        {
                            decimal profit = sale.FinalPrice - totalCost;
                            totalProfit += profit;
                        }
                    }

                    label22.Text = totalProfit.ToString("F0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading monthly profit:\n" + ex.Message);
            }
        }

        private void LoadMonthlySale()
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = @"SELECT IFNULL(SUM(FinalPrice), 0) AS MonthlySale
                         FROM saleitems
                         WHERE MONTH(Date) = MONTH(CURDATE()) AND YEAR(Date) = YEAR(CURDATE());";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    object result = cmd.ExecuteScalar();
                    int monthlySale = Convert.ToInt32(result);
                    label19.Text = monthlySale.ToString() + "";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // List of months
            string[] months = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            // Remove empty last entry and add to ComboBox
            comboBox1.Items.AddRange(months.Where(m => !string.IsNullOrWhiteSpace(m)).ToArray());

            // Enable autocomplete
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bill f2 = new Bill();
            f2.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            New_Customer f2 = new New_Customer();
            f2.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Customer f2 = new Customer();
            f2.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=hasham;database=master_solar;";
            string selectedMonth = comboBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(selectedMonth))
            {
                MessageBox.Show("Please select a month.");
                return;
            }

            int monthNumber;
            try
            {
                monthNumber = DateTime.ParseExact(selectedMonth, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;
            }
            catch
            {
                MessageBox.Show("Invalid month name.");
                return;
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    // 1. Load saleitems for selected month
                    string saleQuery = @"
                SELECT SaleItemID, ItemID, QuantitySold, FinalPrice
                FROM saleitems 
                WHERE MONTH(Date) = @Month AND YEAR(Date) = YEAR(CURDATE())
                ORDER BY Date ASC;";

                    MySqlCommand saleCmd = new MySqlCommand(saleQuery, con);
                    saleCmd.Parameters.AddWithValue("@Month", monthNumber);

                    MySqlDataReader saleReader = saleCmd.ExecuteReader();

                    var sales = new List<(string ItemID, int Qty, decimal FinalPrice)>();
                    decimal totalSales = 0;

                    while (saleReader.Read())
                    {
                        string itemId = saleReader.GetString("ItemID"); // now as string
                        int qty = saleReader.GetInt32("QuantitySold");
                        decimal final = saleReader.GetDecimal("FinalPrice");

                        sales.Add((itemId, qty, final));
                        totalSales += final;
                    }
                    saleReader.Close();

                    decimal totalProfit = 0;

                    foreach (var sale in sales)
                    {
                        // 2. Load inventory_batches for the item (FIFO: by EntryDate)
                        string batchQuery = @"
                    SELECT PurchasePrice, Quantity 
                    FROM inventory_batches 
                    WHERE ItemID = @ItemID 
                    ORDER BY EntryDate ASC;";

                        MySqlCommand batchCmd = new MySqlCommand(batchQuery, con);
                        batchCmd.Parameters.AddWithValue("@ItemID", sale.ItemID);

                        MySqlDataReader batchReader = batchCmd.ExecuteReader();

                        int remainingQty = sale.Qty;
                        decimal cost = 0;

                        while (batchReader.Read() && remainingQty > 0)
                        {
                            int batchQty = batchReader.GetInt32("Quantity");
                            decimal purchasePrice = batchReader.GetDecimal("PurchasePrice");

                            int usedQty = Math.Min(remainingQty, batchQty);
                            cost += usedQty * purchasePrice;
                            remainingQty -= usedQty;
                        }

                        batchReader.Close();

                        decimal profit = sale.FinalPrice - cost;
                        totalProfit += profit;
                    }

                    label23.Text = totalSales.ToString("F0"); // Monthly Sales
                    label24.Text = totalProfit.ToString("F0"); // Monthly Profit
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading monthly report:\n" + ex.Message);
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
