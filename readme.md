# Master Solar Inventory & Accounts Management System

**Master Solar** is a specialized desktop application designed for solar energy businesses (specifically tailored for Master Solars, Hasilpur). It provides a comprehensive solution for managing inventory, tracking sales, handling customer accounts, and generating professional bills.

---

## Key Features

### 1. Advanced Inventory Management
- **FIFO (First-In-First-Out) System**: Tracks inventory batches by entry date to ensure accurate cost of goods sold and profit calculation.
- **Batch Tracking**: Manage multiple batches of the same item with different purchase prices.
- **Real-time Stock Monitoring**: Search and view current stock levels with automated warnings for low or zero stock during billing.
- **Dynamic Pricing**: Easily update selling prices for existing inventory items.

### 2. Smart Billing & Sales
- **Professional Bill Generation**: Automated formatting and printing for thermal/standard printers.
- **Flexible Payment Modes**:
  - **Paid**: Immediate cash transactions.
  - **Account**: Credit-based sales that automatically update customer balances.
- **Discount Management**: Apply per-unit discounts during the billing process.
- **Customer Auto-lookup**: Quickly find customers by Name or ID during billing.

### 3. Customer & Account Management
- **Balance Tracking**: Maintain a real-time record of what customers owe (Positive Balance) or what they have overpaid (Negative Balance).
- **Payment History**: Detailed logs of all payments made by customers.
- **Recovery Tracking**: Dedicated view for monitoring outstanding debts and prioritizing recoveries.
- **Transaction Ledger**: Automatic recording of transaction history for every balance update.

### 4. Dashboard & Analytics
- **Monthly Performance**: View total sales and net profit for the current month.
- **Financial Summary**: Instant overview of total positive and negative balances across all customer accounts.
- **Report Filtering**: Generate performance reports for specific months.

---

## Technical Stack
- **Frontend**: C# .NET WinForms
- **Backend**: MySQL Database
- **Data Access**: MySql.Data
- **Printing**: System.Drawing.Printing (Receipt-style formatting)

---

## User Manual

### How to Manage Stock
1. Go to the **Stock** section.
2. To add a **new item** type, enter the Item ID and Name and click the add button.
3. To **restock** an existing item, select the item name, enter the Purchase Price, Selling Price, and Quantity, then click update. *Note: This creates a new batch for FIFO tracking.*

### How to Create a Bill
1. Go to the **Bill** section.
2. Select the **Mode** (Paid or Account).
3. If "Account" is selected, search for the customer by Name or ID.
4. In the grid, type the **Item Name**. The system will auto-suggest items.
5. Press **Enter** to load item details.
6. Adjust the **Quantity** and **Discount** as needed.
7. Click the **Save/Print** button to record the sale, update stock (FIFO), and print the receipt.

### How to Handle Customer Payments
1. Go to the **Customer** section.
2. Search for the customer by Name/ID and click **Search**.
3. View the current balance. To record a payment, enter the amount in the **Receive** field.
4. Click the **Update** button. This will update the balance in the database and record the transaction in the history.
5. A receipt will be generated automatically for the payment.

### How to View Reports
1. On the **Dashboard**, view the current month's sales and profit.
2. Select a different month from the dropdown and click the filter button to see historic data.
3. Use the **History** section to filter Sales, Payments, or Recovery lists by customer or month.

---

## Setup & Installation
1. Ensure **MySQL Server** is installed and running.
2. Create a database named `master_solar`.
3. Update the connection string in the source code (if your MySQL `root` password is not `hasham`):
   `"server=localhost;user=root;password=YOUR_PASSWORD;database=master_solar;"`
4. Build and run the project using Visual Studio.

---
**Developed By**: M. Ahmad Hasham  
**Contact**: 0327-0222414  
**Location**: Hasilpur, Pakistan
