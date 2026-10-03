using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ИС_Склад.Forms;

namespace ИС_Склад
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            
        }

        private void приемкаТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiveGoodsForm receiveGoodsForm = new ReceiveGoodsForm();
            receiveGoodsForm.Show();
        }

        private void отгрузкаТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShipGoodsForm shipGoodsForm = new ShipGoodsForm();
            shipGoodsForm.Show();
        }

        private void перемещениеТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveGoodsForm moveGoodsForm = new MoveGoodsForm();
            moveGoodsForm.Show();
        }

        private void инвентаризацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.Show();
        }

        private void оСкладскихОстаткахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockBalanceReportForm stockBalanceReportForm = new StockBalanceReportForm();
            stockBalanceReportForm.Show();
        }

        private void движениеТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoodsMovementReportForm goodsMovementReportForm = new GoodsMovementReportForm();
            goodsMovementReportForm.Show();
        }

        private void настройкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ТоварыButton_Click(object sender, EventArgs e)
        {
            ProductForm productsForm = new ProductForm();
            productsForm.Show();
        }

        private void ПоставщикиButton_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm();
            suppliersForm.Show();
        }

        private void СкладыButton_Click(object sender, EventArgs e)
        {
            WarehousesForm warehousesForm = new WarehousesForm();
            warehousesForm.Show();
        }

        private void ClientsMenuItem_Click(object sender, EventArgs e)
        {
            CustomersForm addCustomerForm = new CustomersForm();
            addCustomerForm.Show();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
    }
}
