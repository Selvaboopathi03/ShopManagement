namespace Store
{
    partial class frmAddProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddProducts = new System.Windows.Forms.Button();
            this.lblprodname = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnSavaProducts = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grdProd = new System.Windows.Forms.DataGridView();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.lblAddProd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdProd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddProducts
            // 
            this.btnAddProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProducts.Location = new System.Drawing.Point(47, 29);
            this.btnAddProducts.Name = "btnAddProducts";
            this.btnAddProducts.Size = new System.Drawing.Size(211, 45);
            this.btnAddProducts.TabIndex = 0;
            this.btnAddProducts.Text = "Add Product  +";
            this.btnAddProducts.UseVisualStyleBackColor = true;
            this.btnAddProducts.Visible = false;
            this.btnAddProducts.Click += new System.EventHandler(this.btnAddProducts_Click);
            // 
            // lblprodname
            // 
            this.lblprodname.AutoSize = true;
            this.lblprodname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprodname.Location = new System.Drawing.Point(115, 120);
            this.lblprodname.Name = "lblprodname";
            this.lblprodname.Size = new System.Drawing.Size(121, 20);
            this.lblprodname.TabIndex = 1;
            this.lblprodname.Text = "ProductName :";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(131, 174);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(105, 20);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description :";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(178, 223);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(58, 20);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price :";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(175, 275);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(61, 20);
            this.lblStock.TabIndex = 4;
            this.lblStock.Text = "Stock :";
            // 
            // txtProdName
            // 
            this.txtProdName.Location = new System.Drawing.Point(327, 120);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(309, 22);
            this.txtProdName.TabIndex = 5;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(327, 174);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(309, 22);
            this.txtDesc.TabIndex = 6;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(327, 223);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(309, 22);
            this.txtPrice.TabIndex = 7;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(327, 273);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(309, 22);
            this.txtStock.TabIndex = 8;
            // 
            // btnSavaProducts
            // 
            this.btnSavaProducts.BackColor = System.Drawing.SystemColors.Control;
            this.btnSavaProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavaProducts.Location = new System.Drawing.Point(340, 342);
            this.btnSavaProducts.Name = "btnSavaProducts";
            this.btnSavaProducts.Size = new System.Drawing.Size(75, 38);
            this.btnSavaProducts.TabIndex = 9;
            this.btnSavaProducts.Text = "Save";
            this.btnSavaProducts.UseVisualStyleBackColor = false;
            this.btnSavaProducts.Click += new System.EventHandler(this.btnSavaProducts_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(448, 342);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grdProd
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdProd.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdProd.Location = new System.Drawing.Point(119, 423);
            this.grdProd.Name = "grdProd";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProd.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdProd.RowHeadersWidth = 51;
            this.grdProd.RowTemplate.Height = 24;
            this.grdProd.Size = new System.Drawing.Size(805, 150);
            this.grdProd.TabIndex = 11;
            this.grdProd.Visible = false;
            this.grdProd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProd_CellClick);
            // 
            // txtProdId
            // 
            this.txtProdId.Location = new System.Drawing.Point(642, 120);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(309, 22);
            this.txtProdId.TabIndex = 12;
            this.txtProdId.Visible = false;
            // 
            // lblAddProd
            // 
            this.lblAddProd.AutoSize = true;
            this.lblAddProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddProd.Location = new System.Drawing.Point(334, 29);
            this.lblAddProd.Name = "lblAddProd";
            this.lblAddProd.Size = new System.Drawing.Size(189, 31);
            this.lblAddProd.TabIndex = 13;
            this.lblAddProd.Text = "Add Products";
            // 
            // frmAddProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 639);
            this.Controls.Add(this.lblAddProd);
            this.Controls.Add(this.txtProdId);
            this.Controls.Add(this.grdProd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSavaProducts);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtProdName);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblprodname);
            this.Controls.Add(this.btnAddProducts);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAddProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddProducts";
            this.Load += new System.EventHandler(this.frmAddProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddProducts;
        private System.Windows.Forms.Label lblprodname;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnSavaProducts;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView grdProd;
        private System.Windows.Forms.TextBox txtProdId;
        private System.Windows.Forms.Label lblAddProd;
    }
}