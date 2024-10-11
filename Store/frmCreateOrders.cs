using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Store
{
    public partial class frmCreateOrders : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly AppDbContext _context = new AppDbContext();
        private List<Product> products = new List<Product>();
        private Product Product = new Product();
        private List<string> productNames;
        private int _userId;
        public frmCreateOrders(int UserId)
        {
            InitializeComponent();
            _userId = UserId;
            Logger.Info("frmCreateOrders initialized for user ID: {0}", _userId);

            try
            {
                productNames = _context.Products.Select(p => p.ProductName).ToList();
                SetupAutoComplete();
                grdOrder.CellClick += grdOrder_CellClick;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error during initialization of frmCreateOrders");
                MessageBox.Show("Error loading product names.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCreateOrders_Load(object sender, EventArgs e)
        {
            Logger.Info("Loading order details for user ID: {0}", _userId);
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            Logger.Info("Loading order details...");
            var orderDetails = GetOrder1();
            grdOrder.DataSource = orderDetails;
            grdOrder.Columns["OrderId"].Visible = false;
            CustomizeGridView();
        }

        public List<OrderViewModel> GetOrder1()
        {
            Logger.Info("Retrieving order details from the database.");
            var orders = _context.Orders.Where(a=>a.UserID == _userId).ToList();
            var userName = _context.Users.FirstOrDefault(a => a.UserID.Equals(_userId))?.Username;
            var orderDetails = new List<OrderViewModel>();
            if (orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    orderDetails.Add(new OrderViewModel
                    {
                        OrderId = order.OrderID,
                        UserName = userName,
                        OrderDate = order.OrderDate,
                        TotalAmount = order.TotalAmount,
                    });
                }
            }
            Logger.Info("Retrieved {0} orders for user {1}.", orderDetails.Count, userName);
            return orderDetails;
        }

        private void BindOrderDetails(int orderId)
        {
            Logger.Info("Binding order details for order ID: {0}", orderId);
            List<OrderDetailsViewModel> orderDetailsViewModels = GetOrderDetails(orderId);
            grdOrderDetails.DataSource = orderDetailsViewModels;
            CustomizeOrderDetailsGridView();
        }

        private void CustomizeGridView()
        {
            Logger.Info("Customizing the order grid view.");
            // Check if the columns exist before attempting to set properties
            if (grdOrder.Columns.Contains("OrderId"))
            {
                grdOrder.Columns["OrderId"].HeaderText = "OrderId";
            }
            else
            {
                Logger.Warn("Column 'OrderId' does not exist.");
            }

            if (grdOrder.Columns.Contains("UserName"))
            {
                grdOrder.Columns["UserName"].HeaderText = "User Name";
            }
            else
            {
                Logger.Warn("Column 'UserName' does not exist.");
            }

            if (grdOrder.Columns.Contains("OrderDate"))
            {
                grdOrder.Columns["OrderDate"].HeaderText = "Order Date";
                grdOrder.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy"; // Format the date
            }
            else
            {
                Logger.Warn("Column 'OrderDate' does not exist.");
            }

            if (grdOrder.Columns.Contains("TotalAmount"))
            {
                grdOrder.Columns["TotalAmount"].HeaderText = "Total Amount";
                grdOrder.Columns["TotalAmount"].DefaultCellStyle.Format = "C2"; // Format as currency
            }
            else
            {
                Logger.Warn("Column 'TotalAmount' does not exist.");
            }
        }


        private void CustomizeOrderDetailsGridView()
        {
            Logger.Info("Customizing the order details grid view.");
            grdOrderDetails.Columns["ProductName"].HeaderText = "Product Name";
            grdOrderDetails.Columns["Description"].HeaderText = "Description";
            grdOrderDetails.Columns["Qty"].HeaderText = "Quantity";
            grdOrderDetails.Columns["UnitPrice"].HeaderText = "Unit Price";
            grdOrderDetails.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
        }



        public List<OrderDetailsViewModel> GetOrderDetails(int orderId)
        {
            Logger.Info("Fetching order details for order ID: {0}", orderId);
            // Fetch the order details
            List<OrderDetail> orderDetails = _context.OrderDetails
                .Where(a => a.OrderID == orderId)
                .ToList();

            // Fetch all products from the database
            List<Product> products = _context.Products.ToList();

            // Create a list to hold the view models
            List<OrderDetailsViewModel> orderDetailsViewModels = new List<OrderDetailsViewModel>();

            // Map each order detail to the view model
            foreach (var orderDetail in orderDetails)
            {
                var product = products.FirstOrDefault(p => p.ProductID == orderDetail.ProductID);
                if (product != null)
                {
                    orderDetailsViewModels.Add(new OrderDetailsViewModel
                    {
                        ProductName = product.ProductName,
                        Description = product.Description,
                        Qty = orderDetail.Quantity,
                        UnitPrice = orderDetail.UnitPrice.ToString("C") // Format as currency
                    });
                }
                else
                {
                    Logger.Warn("Product with ID {0} not found for order detail ID {1}", orderDetail.ProductID, orderDetail.OrderDetailID);
                }
            }

            Logger.Info("Retrieved {0} order details for order ID: {1}", orderDetailsViewModels.Count, orderId);
            return orderDetailsViewModels;
        }

        private void grdOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the Order ID from the clicked row
                int orderId = Convert.ToInt32(grdOrder.Rows[e.RowIndex].Cells["OrderId"].Value);
                Logger.Info("Order ID {0} clicked in the grid.", orderId);

                // Bind the order details to the order details grid
                BindOrderDetails(orderId);
            }
            else
            {
                Logger.Warn("Invalid cell clicked: RowIndex={0}, ColumnIndex={1}", e.RowIndex, e.ColumnIndex);
            }
        }

        private void SetupAutoComplete()
        {
            Logger.Info("Setting up auto-complete for product names.");
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

            // Add product names to the AutoCompleteStringCollection
            autoCompleteCollection.AddRange(productNames.ToArray());

            // Set the properties of the TextBox
            txtProdName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProdName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProdName.AutoCompleteCustomSource = autoCompleteCollection;

            Logger.Info("Auto-complete setup complete with {0} product names.", productNames.Count);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtProdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logger.Info("Product name entered: {0}", txtProdName.Text);
                Product = _context.Products.FirstOrDefault(a => a.ProductName.Equals(txtProdName.Text));
                if (Product == null)
                {
                    Logger.Warn("Product not found: {0}", txtProdName.Text);
                    MessageBox.Show("Please Enter the Correct Product name", "Shop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Product.Stock == 0)
                {
                    Logger.Warn("Product stock is not available for product: {0}", Product.ProductName);
                    MessageBox.Show("Product Stock is not Available", "Shop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtProdDesc.Text = Product.Description;
                    Logger.Info("Product description set: {0}", Product.Description);
                }
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtQty.Text, out int enterqty) && enterqty > 0)
            {
                var product = _context.Products.FirstOrDefault(a => a.ProductName.Equals(txtProdName.Text));
                if (product != null)
                {
                    if (enterqty <= product.Stock)
                    {
                        decimal unitPrice = product.Price / product.Stock;
                        decimal currentPrice = unitPrice * enterqty;

                        txtPrice.Text = currentPrice.ToString("F2");  // Format to 2 decimal places
                        Logger.Info("Price calculated: {0} for quantity: {1}", currentPrice, enterqty);
                    }
                    else
                    {
                        Logger.Warn("Quantity exceeds available stock. Requested: {0}, Available: {1}", enterqty, product.Stock);
                        MessageBox.Show("Quantity exceeds available stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQty.Text = string.Empty;
                    }
                }
                else
                {
                    Logger.Warn("Product not found for quantity validation: {0}", txtProdName.Text);
                    MessageBox.Show("Product not found.", "Invalid Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                txtPrice.Clear();  // Clear the price if the quantity is invalid
                Logger.Warn("Invalid quantity entered: {0}", txtQty.Text);
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            Logger.Info("Creating order for user ID: {0}", _userId);
            Order order = new Order();
            OrderDetail detail = new OrderDetail();

            // Set order properties
            order.UserID = _userId;
            order.OrderDate = DateTime.Now;

            // Validate product and quantity
            if (Product == null)
            {
                Logger.Error("Product not found while creating order.");
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!int.TryParse(txtQty.Text, out int enteredQty) || enteredQty <= 0)
            {
                Logger.Error("Invalid quantity entered: {0}", txtQty.Text);
                MessageBox.Show("Please enter a valid quantity greater than 0.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (Product.Stock < enteredQty)
            {
                Logger.Warn("Not enough stock available. Requested: {0}, Available: {1}", enteredQty, Product.Stock);
                MessageBox.Show("Not enough stock available.", "Error", MessageBoxButtons.OK);
                return;
            }

            var existingOrder = _context.Orders.FirstOrDefault(a => a.UserID == _userId);
            if (existingOrder == null)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                existingOrder = _context.Orders.FirstOrDefault(a => a.UserID == _userId);
                Logger.Info("Created new order with ID: {0}", existingOrder.OrderID);
            }

            decimal unitPrice = Product.Price / Product.Stock;

            var existingOrderDetail = _context.OrderDetails
                .FirstOrDefault(a => a.ProductID == Product.ProductID && a.OrderID == existingOrder.OrderID);

            if (existingOrderDetail == null)
            {
                detail.OrderID = existingOrder.OrderID;
                detail.ProductID = Product.ProductID;
                detail.Quantity = enteredQty;
                detail.UnitPrice = unitPrice;

                _context.OrderDetails.Add(detail);
                Product.Stock -= enteredQty;  // Decrease stock by the entered quantity
                Logger.Info("Added new order detail for ProductID: {0}, Quantity: {1}", Product.ProductID, enteredQty);
            }
            else
            {
                int previousQty = existingOrderDetail.Quantity;
                Logger.Info("Updating existing order detail for ProductID: {0}. Previous Quantity: {1}, New Quantity: {2}",
                            Product.ProductID, previousQty, enteredQty);

                if (enteredQty > previousQty)
                {
                    Product.Stock -= (enteredQty - previousQty);
                }
                else if (enteredQty < previousQty)
                {
                    Product.Stock += (previousQty - enteredQty);
                }

                if (Product.Stock < 0)
                {
                    Logger.Warn("Stock cannot be negative after update. Current Stock: {0}", Product.Stock);
                    MessageBox.Show("Not enough stock available.", "Error", MessageBoxButtons.OK);
                    return;
                }

                existingOrderDetail.Quantity = enteredQty;
                existingOrderDetail.UnitPrice = unitPrice;
            }

            _context.SaveChanges();

            // Calculate total amount for the order
            List<OrderDetail> lstOrderDetails = _context.OrderDetails
                .Where(a => a.OrderID == existingOrder.OrderID)
                .ToList();
            decimal totalAmount = lstOrderDetails.Sum(orderDetail => orderDetail.Quantity * orderDetail.UnitPrice);
            existingOrder.TotalAmount = totalAmount;
            existingOrder.OrderDate = DateTime.Now;
            _context.SaveChanges();
            Logger.Info("Total amount updated for order ID: {0}. Total Amount: {1}", existingOrder.OrderID, totalAmount);

            // Update product price based on remaining stock
            if (Product.Stock > 0)
            {
                Product.Price = unitPrice * Product.Stock;
            }
            else
            {
                Product.Price = 0; // If no stock, price should be zero
            }

            _context.SaveChanges();

            MessageBox.Show("Order processed successfully.", "Shop", MessageBoxButtons.OK);
            LoadOrderDetails();
            grdOrderDetails.DataSource = null;
            txtProdName.Text = string.Empty;
            txtProdDesc.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQty.Text = string.Empty;

            Logger.Info("Order processing completed successfully.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtProdName.Text = string.Empty;
            txtProdDesc.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtProdName.Enabled = true;
            btnCreateOrder.Text = "Create Order";
            Logger.Info("Order creation cancelled.");
        }
    }
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        // Add other properties from the Order class as needed
    }

    public class OrderDetailsViewModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public string UnitPrice { get; set; }

    }
}
