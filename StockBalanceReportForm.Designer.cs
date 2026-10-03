namespace ИС_Склад.Forms
{
    partial class StockBalanceReportForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockBalanceReportForm));
            this.dataGridViewStockBalance = new System.Windows.Forms.DataGridView();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.comboBoxWarehouses = new System.Windows.Forms.ComboBox();
            this.kurse_26ip212DataSet = new ИС_Склад.kurse_26ip212DataSet();
            this.товарыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.товарыTableAdapter = new ИС_Склад.kurse_26ip212DataSetTableAdapters.ТоварыTableAdapter();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.kurse_26ip212DataSet1 = new ИС_Склад.kurse_26ip212DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurse_26ip212DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.товарыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurse_26ip212DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStockBalance
            // 
            this.dataGridViewStockBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockBalance.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewStockBalance.Name = "dataGridViewStockBalance";
            this.dataGridViewStockBalance.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewStockBalance.TabIndex = 0;
            this.dataGridViewStockBalance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockBalance_CellContentClick);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(16, 214);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(118, 37);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Обновить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // comboBoxWarehouses
            // 
            this.comboBoxWarehouses.FormattingEnabled = true;
            this.comboBoxWarehouses.Location = new System.Drawing.Point(13, 187);
            this.comboBoxWarehouses.Name = "comboBoxWarehouses";
            this.comboBoxWarehouses.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWarehouses.TabIndex = 2;
            this.comboBoxWarehouses.SelectedIndexChanged += new System.EventHandler(this.comboBoxWarehouses_SelectedIndexChanged_1);
            // 
            // kurse_26ip212DataSet
            // 
            this.kurse_26ip212DataSet.DataSetName = "kurse_26ip212DataSet";
            this.kurse_26ip212DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // товарыBindingSource
            // 
            this.товарыBindingSource.DataMember = "Товары";
            this.товарыBindingSource.DataSource = this.kurse_26ip212DataSet;
            // 
            // товарыTableAdapter
            // 
            this.товарыTableAdapter.ClearBeforeFill = true;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Location = new System.Drawing.Point(140, 216);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(118, 35);
            this.buttonGenerateReport.TabIndex = 3;
            this.buttonGenerateReport.Text = "Сделать отчет";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            this.buttonGenerateReport.Click += new System.EventHandler(this.buttonGenerateReport_Click);
            // 
            // kurse_26ip212DataSet1
            // 
            this.kurse_26ip212DataSet1.DataSetName = "kurse_26ip212DataSet";
            this.kurse_26ip212DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StockBalanceReportForm
            // 
            this.ClientSize = new System.Drawing.Size(527, 408);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.comboBoxWarehouses);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.dataGridViewStockBalance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockBalanceReportForm";
            this.Text = "Складские остатки";
            this.Load += new System.EventHandler(this.StockBalanceReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurse_26ip212DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.товарыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurse_26ip212DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.DataGridView dataGridViewStockBalance;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ComboBox comboBoxWarehouses;
        private kurse_26ip212DataSet kurse_26ip212DataSet;
        private System.Windows.Forms.BindingSource товарыBindingSource;
        private kurse_26ip212DataSetTableAdapters.ТоварыTableAdapter товарыTableAdapter;
        private System.Windows.Forms.Button buttonGenerateReport;
        private kurse_26ip212DataSet kurse_26ip212DataSet1;
    }
}