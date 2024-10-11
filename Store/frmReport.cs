using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NLog;

namespace Store
{
    public partial class frmReport : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger(); // Create a logger instance
        private readonly AppDbContext _context = new AppDbContext();
        private int _userId;

        public frmReport(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.Info("Fetching products for report generation."); // Log info

                // Fetch products from the database
                List<Product> products = _context.Products.ToList();

                // Check if there are any products available
                if (products == null || products.Count == 0)
                {
                    Logger.Warn("No products available to generate a report."); // Log warning
                    MessageBox.Show("No products available to generate a report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Exit if no products found
                }

                // Create and show the product report form
                frmProductReport frmProductReport = new frmProductReport(products);
                frmProductReport.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "An error occurred while fetching the products."); // Log error
                MessageBox.Show("An error occurred while fetching the products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Logger.Info($"Fetching order report data for user ID: {_userId}"); // Log info

            //List<OrderReportModel> orderData = GetOrderReportData(_userId);

            //if (orderData.Count == 0)
            //{
            //    Logger.Warn("No orders found for this user."); // Log warning
            //    MessageBox.Show("No orders found for this user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //// Create and show the order report form
            //frmOrderReport orderReportForm = new frmOrderReport(orderData);
            //orderReportForm.ShowDialog();
        }

        //private List<OrderReportModel> GetOrderReportData(int userId)
        //{
        //    using (var context = new AppDbContext())
        //    {
        //        try
        //        {
        //            // Query to fetch data for the report
        //            var orders = from order in context.Orders
        //                         where order.UserID == userId
        //                         join orderDetail in context.OrderDetails on order.OrderID equals orderDetail.OrderID
        //                         join product in context.Products on orderDetail.ProductID equals product.ProductID
        //                         join user in context.Users on order.UserID equals user.UserID
        //                         select new OrderReportModel
        //                         {
        //                             ProductName = product.ProductName,
        //                             Description = product.Description,
        //                             Quantity = orderDetail.Quantity,
        //                             UnitPrice = orderDetail.UnitPrice,
        //                             OrderDate = order.OrderDate,
        //                             Username = user.Username
        //                         };

        //            Logger.Info("Order report data retrieved successfully."); // Log info
        //            return orders.ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.Error(ex, "An error occurred while fetching order report data."); // Log error
        //            throw; // Rethrow the exception to handle it in the calling method
        //        }
        //    }
        //}
    }
}
