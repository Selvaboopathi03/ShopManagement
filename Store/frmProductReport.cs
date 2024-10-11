using Microsoft.Reporting.WinForms;
using NLog; // Make sure to include NLog
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class frmProductReport : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger(); // Create a logger instance
        private readonly AppDbContext _context = new AppDbContext();
        private List<Product> _products = new List<Product>();

        public frmProductReport(List<Product> products)
        {
            InitializeComponent();
            _products = products;
        }

        private void frmProductReport_Load(object sender, EventArgs e)
        {
            try
            {
                Logger.Info("Loading product report."); // Log when report loading starts

                // Use verbatim string literal for the full path
                string reportPath = @"C:\Users\Kalai\source\repos\Store\Store\ProductReport.rdlc";

                // Check if the file exists
                if (!System.IO.File.Exists(reportPath))
                {
                    Logger.Error("Report file not found: {0}", reportPath); // Log error if report file is not found
                    MessageBox.Show("Report file not found: " + reportPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Set the report path
                ProductReportViewer.LocalReport.ReportPath = reportPath;
                _products.Clear();
                _products = _context.Products.ToList();

                // Log the number of products retrieved
                Logger.Info("Retrieved {0} products for the report.", _products.Count);

                // Create a ReportDataSource
                ReportDataSource rds = new ReportDataSource("ProductDataSet", _products); // Ensure "ProductDataSet" matches your RDLC

                // Clear existing data sources and add the new one
                ProductReportViewer.LocalReport.DataSources.Clear();
                ProductReportViewer.LocalReport.DataSources.Add(rds);

                // Refresh the report viewer to display the report
                ProductReportViewer.RefreshReport();
                Logger.Info("Product report loaded successfully."); // Log success message
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error loading report."); // Log the error message with exception details
                MessageBox.Show("Error loading report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
