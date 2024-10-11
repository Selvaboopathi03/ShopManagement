using NLog; // Add NLog
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class frmAddProducts : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger(); // Logger instance

        private readonly AppDbContext _context = new AppDbContext();
        private List<Product> products = new List<Product>();
        private bool isDeleting = false; // Flag to track deletion

        public frmAddProducts()
        {
            InitializeComponent();
            Bindgrid();
        }

        private void frmAddProducts_Load(object sender, EventArgs e)
        {
            grdProd.CellClick += grdProd_CellClick;
            logger.Info("Product form loaded.");
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            logger.Info("Add Products button clicked.");
            lblprodname.Visible = true;
            lblDesc.Visible = true;
            lblPrice.Visible = true;
            lblStock.Visible = true;
            txtProdName.Visible = true;
            txtDesc.Visible = true;
            txtPrice.Visible = true;
            txtStock.Visible = true;
            btnSavaProducts.Visible = true;
            btnCancel.Visible = true;
        }

        private void btnSavaProducts_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProdName.Text))
            {
                MessageBox.Show("Please Enter the Product Name", "Shop", MessageBoxButtons.OK);
                logger.Warn("Product name is empty.");
                return;
            }
            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show("Please Enter the Product Description", "Shop", MessageBoxButtons.OK);
                logger.Warn("Product description is empty.");
                return;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Please Enter the Product Price", "Shop", MessageBoxButtons.OK);
                logger.Warn("Product price is empty.");
                return;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("Please Enter the Product Stock", "Shop", MessageBoxButtons.OK);
                logger.Warn("Product stock is empty.");
                return;
            }

            Product product = new Product();
            product.ProductName = txtProdName.Text;
            product.Description = txtDesc.Text;
            product.Price = Convert.ToDecimal(txtPrice.Text);
            product.Stock = Convert.ToInt32(txtStock.Text);

            try
            {
                if (btnSavaProducts.Text == "Save")
                {
                    var CheckProduct = _context.Products.FirstOrDefault(a => a.ProductName.Equals(txtProdName));
                    if (CheckProduct == null)
                    {
                        var AddProduct = _context.Products.Add(product);
                        _context.SaveChanges();
                        logger.Info("Product '{0}' added successfully.", product.ProductName);

                        if (AddProduct != null)
                        {
                            MessageBox.Show("Product Added Successfully", "Shop", MessageBoxButtons.OK);
                            Bindgrid();
                            ClearForm();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product Already Exists", "Shop", MessageBoxButtons.OK);
                        logger.Warn("Product '{0}' already exists.", txtProdName.Text);
                    }
                }
                else if (btnSavaProducts.Text == "Update")
                {
                    var ExistingProduct = _context.Products.Find(Convert.ToInt32(txtProdId.Text));
                    if (ExistingProduct != null)
                    {
                        ExistingProduct.ProductName = txtProdName.Text;
                        ExistingProduct.Description = txtDesc.Text;
                        ExistingProduct.Price = Convert.ToDecimal(txtPrice.Text);
                        ExistingProduct.Stock = Convert.ToInt32(txtStock.Text);
                        _context.SaveChanges();
                        logger.Info("Product '{0}' updated successfully.", ExistingProduct.ProductName);
                        MessageBox.Show("Product Updated Successfully", "Shop", MessageBoxButtons.OK);
                        Bindgrid();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while saving product.");
                MessageBox.Show("An error occurred while saving the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Bindgrid()
        {
            try
            {
                products = _context.Products.ToList();
                grdProd.DataSource = null;
                if (products != null && products.Count > 0)
                {
                    grdProd.DataSource = products;
                    grdProd.Columns["ProductID"].Visible = false;
                    AddEditDeleteButtons();
                    logger.Info("Product grid bound with {0} products.", products.Count);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error binding product grid.");
            }
        }

        private void AddEditDeleteButtons()
        {
            if (!grdProd.Columns.Contains("btnEdit") && !grdProd.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.HeaderText = "Edit";
                btnEdit.Name = "btnEdit";
                btnEdit.Text = "Edit";
                btnEdit.UseColumnTextForButtonValue = true;
                btnEdit.DisplayIndex = 0;
                grdProd.Columns.Add(btnEdit);

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.HeaderText = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.DisplayIndex = 1;
                grdProd.Columns.Add(btnDelete);

                grdProd.CellClick += grdProd_CellClick;
            }
        }

        private void grdProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < grdProd.Columns.Count)
            {
                if (grdProd.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string columnHeader = grdProd.Columns[e.ColumnIndex].HeaderText;
                    int productId = Convert.ToInt32(grdProd.Rows[e.RowIndex].Cells["ProductID"].Value);

                    if (columnHeader == "Edit")
                    {
                        EditProduct(productId);
                    }
                    else if (columnHeader == "Delete")
                    {
                        if (!isDeleting)
                        {
                            isDeleting = true;
                            DeleteProduct(productId);
                            isDeleting = false;
                        }
                    }
                }
            }
        }

        private void EditProduct(int productId)
        {
            Product checkproduct = products.FirstOrDefault(a => a.ProductID == productId);

            if (checkproduct != null)
            {
                txtProdId.Text = checkproduct.ProductID.ToString();
                txtProdName.Text = checkproduct.ProductName;
                txtDesc.Text = checkproduct?.Description;
                txtPrice.Text = Convert.ToString(checkproduct.Price);
                txtStock.Text = Convert.ToString(checkproduct.Stock);
                btnSavaProducts.Text = "Update";
                lblAddProd.Text = "Update Product";
                logger.Info("Editing product '{0}'.", checkproduct.ProductName);
            }
        }

        private void DeleteProduct(int productId)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the product?", "Shop", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var productToDelete = _context.Products.Find(productId);
                    if (productToDelete != null)
                    {
                        _context.Products.Remove(productToDelete);
                        _context.SaveChanges();
                        logger.Info("Product '{0}' deleted successfully.", productToDelete.ProductName);
                        MessageBox.Show("Product deleted successfully", "Shop", MessageBoxButtons.OK);
                        Bindgrid();
                    }
                    else
                    {
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Warn("Attempted to delete product with ID {0}, but product not found.", productId);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting product.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            btnSavaProducts.Text = "Save";
            lblAddProd.Text = "Add Products";
            logger.Info("Product form cleared.");
        }

        private void ClearForm()
        {
            txtProdName.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStock.Text = string.Empty;
        }
    }
}
