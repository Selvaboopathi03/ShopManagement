namespace Store
{
    partial class frmCreateOrders
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
            this.lblSearchProd = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.lblCreateOrd = new System.Windows.Forms.Label();
            this.txtProdDesc = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grdOrder = new System.Windows.Forms.DataGridView();
            this.grdOrderDetails = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearchProd
            // 
            this.lblSearchProd.AutoSize = true;
            this.lblSearchProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchProd.Location = new System.Drawing.Point(74, 108);
            this.lblSearchProd.Name = "lblSearchProd";
            this.lblSearchProd.Size = new System.Drawing.Size(144, 20);
            this.lblSearchProd.TabIndex = 0;
            this.lblSearchProd.Text = "Search Products :";
            // 
            // txtProdName
            // 
            this.txtProdName.Location = new System.Drawing.Point(245, 108);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(459, 22);
            this.txtProdName.TabIndex = 1;
            this.txtProdName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtProdName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProdName_KeyDown);
            // 
            // lblCreateOrd
            // 
            this.lblCreateOrd.AutoSize = true;
            this.lblCreateOrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateOrd.Location = new System.Drawing.Point(250, 35);
            this.lblCreateOrd.Name = "lblCreateOrd";
            this.lblCreateOrd.Size = new System.Drawing.Size(166, 29);
            this.lblCreateOrd.TabIndex = 2;
            this.lblCreateOrd.Text = "Create Orders";
            // 
            // txtProdDesc
            // 
            this.txtProdDesc.Enabled = false;
            this.txtProdDesc.Location = new System.Drawing.Point(245, 181);
            this.txtProdDesc.Name = "txtProdDesc";
            this.txtProdDesc.Size = new System.Drawing.Size(459, 22);
            this.txtProdDesc.TabIndex = 3;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(245, 250);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(459, 22);
            this.txtQty.TabIndex = 4;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(245, 326);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(459, 22);
            this.txtPrice.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Quantity :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(160, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Price :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOrder.Location = new System.Drawing.Point(255, 392);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(133, 40);
            this.btnCreateOrder.TabIndex = 9;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(410, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grdOrder
            // 
            this.grdOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrder.Location = new System.Drawing.Point(78, 507);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.RowHeadersWidth = 51;
            this.grdOrder.RowTemplate.Height = 24;
            this.grdOrder.Size = new System.Drawing.Size(997, 150);
            this.grdOrder.TabIndex = 11;
            this.grdOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrder_CellClick);
            // 
            // grdOrderDetails
            // 
            this.grdOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrderDetails.Location = new System.Drawing.Point(78, 734);
            this.grdOrderDetails.Name = "grdOrderDetails";
            this.grdOrderDetails.RowHeadersWidth = 51;
            this.grdOrderDetails.RowTemplate.Height = 24;
            this.grdOrderDetails.Size = new System.Drawing.Size(997, 150);
            this.grdOrderDetails.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Orders";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 695);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "Order Details";
            // 
            // frmCreateOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 896);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grdOrderDetails);
            this.Controls.Add(this.grdOrder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtProdDesc);
            this.Controls.Add(this.lblCreateOrd);
            this.Controls.Add(this.txtProdName);
            this.Controls.Add(this.lblSearchProd);
            this.Name = "frmCreateOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCreateOrders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCreateOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchProd;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.Label lblCreateOrd;
        private System.Windows.Forms.TextBox txtProdDesc;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView grdOrder;
        private System.Windows.Forms.DataGridView grdOrderDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}