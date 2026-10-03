namespace ИС_Склад.Forms
{
    partial class ReceiveGoodsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiveGoodsForm));
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.comboBoxWarehouses = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonAddExistingProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(430, 174);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // comboBoxWarehouses
            // 
            this.comboBoxWarehouses.FormattingEnabled = true;
            this.comboBoxWarehouses.Location = new System.Drawing.Point(13, 193);
            this.comboBoxWarehouses.Name = "comboBoxWarehouses";
            this.comboBoxWarehouses.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWarehouses.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 220);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(122, 36);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(151, 220);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(122, 36);
            this.buttonAddProduct.TabIndex = 3;
            this.buttonAddProduct.Text = "Добавить оборудование";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click_1);
            // 
            // buttonAddExistingProduct
            // 
            this.buttonAddExistingProduct.Location = new System.Drawing.Point(291, 220);
            this.buttonAddExistingProduct.Name = "buttonAddExistingProduct";
            this.buttonAddExistingProduct.Size = new System.Drawing.Size(122, 36);
            this.buttonAddExistingProduct.TabIndex = 4;
            this.buttonAddExistingProduct.Text = "Добавить существующий товар";
            this.buttonAddExistingProduct.UseVisualStyleBackColor = true;
            this.buttonAddExistingProduct.Click += new System.EventHandler(this.buttonAddExistingProduct_Click);
            // 
            // ReceiveGoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 284);
            this.Controls.Add(this.buttonAddExistingProduct);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxWarehouses);
            this.Controls.Add(this.dataGridViewProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReceiveGoodsForm";
            this.Text = "Приемка";
            this.Load += new System.EventHandler(this.ReceiveGoodsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.ComboBox comboBoxWarehouses;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonAddExistingProduct;
    }
}