using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NLog;

namespace Store
{
    public partial class frmMain : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger(); // Create a logger instance
        private int _userId;
        private MenuStrip menuStrip;
        private readonly AppDbContext _appDbContext = new AppDbContext();

        public frmMain(int userId)
        {
            InitializeComponent();
            _userId = userId;
            this.IsMdiContainer = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string Role = _appDbContext.Users.FirstOrDefault(a => a.UserID.Equals(_userId)).Role;
            Logger.Info("Main form loaded."); // Log info when the form loads

            // Create a MenuStrip
            MenuStrip menuStrip = new MenuStrip();

            // Add File menu
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Options");
            menuStrip.Items.Add(fileMenu);

            if (Role.ToLower().ToString() == "Admin".ToLower().ToString())
            {
                // Add items to File menu
                ToolStripMenuItem ProductItem = new ToolStripMenuItem("Add Products");
                ProductItem.Click += new EventHandler(AddProducts_Click);
                fileMenu.DropDownItems.Add(ProductItem);
            }           

            ToolStripMenuItem OrderItem = new ToolStripMenuItem("Create Orders");
            OrderItem.Click += new EventHandler(CreateOrders_Click);
            fileMenu.DropDownItems.Add(OrderItem);

            ToolStripMenuItem Report = new ToolStripMenuItem("Report");
            Report.Click += new EventHandler(reportbutton_click);
            fileMenu.DropDownItems.Add(Report);

            // Add the MenuStrip to the form
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // Add Settings menu
            ToolStripMenuItem toolSetting = new ToolStripMenuItem("Settings");
            menuStrip.Items.Add(toolSetting);

            ToolStripMenuItem ThemeItem = new ToolStripMenuItem("Theme");
            ThemeItem.Click += new EventHandler(Theme_Click);
            toolSetting.DropDownItems.Add(ThemeItem);

            ToolStripMenuItem LanguageItem = new ToolStripMenuItem("Language");
            LanguageItem.Click += new EventHandler(language_click);
            toolSetting.DropDownItems.Add(LanguageItem);

            ToolStripMenuItem toolExit = new ToolStripMenuItem("Exit");
            toolExit.Click += new EventHandler(Exit_Click);
            menuStrip.Items.Add(toolExit);
        }


        private void Theme_Click(object sender, EventArgs e)
        {
            Logger.Info("Theme settings clicked."); // Log info when theme settings are clicked
            // Implement theme change logic here
        }

        private void language_click(object sender, EventArgs e)
        {
            Logger.Info("Language settings clicked."); // Log info when language settings are clicked
            // Implement language change logic here
        }

        // Event handlers for menu and toolbar items
        private void AddProducts_Click(object sender, EventArgs e)
        {
            Logger.Info("Adding new product."); // Log info when adding a product
            frmAddProducts frmAddProducts = new frmAddProducts();
            frmAddProducts.MdiParent = this;
            frmAddProducts.Dock = DockStyle.Fill;
            frmAddProducts.Show();
        }

        private void CreateOrders_Click(object sender, EventArgs e)
        {
            Logger.Info("Creating new order for user ID: {0}.", _userId); // Log info when creating an order
            frmCreateOrders frmCreateOrders = new frmCreateOrders(_userId);
            frmCreateOrders.MdiParent = this;
            frmCreateOrders.Dock = DockStyle.Fill;
            frmCreateOrders.Show();
        }

        private void reportbutton_click(object sender, EventArgs e)
        {
            Logger.Info("Generating report for user ID: {0}.", _userId); // Log info when generating report
            frmReport frmReport = new frmReport(_userId);
            frmReport.MdiParent = this;
            frmReport.Dock = DockStyle.Fill;
            frmReport.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure Exit the application?", "Shop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                Application.Exit();
                Logger.Info("Exiting the application.");
            }
            // Log info when exiting the application
            // Implement exit logic here
        }
    }
}
