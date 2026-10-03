using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ИС_Склад
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }


        private void ProductForm_Load_1(object sender, EventArgs e)
        {
            this.товарыTableAdapter1.Fill(this.kurse_26ip212DataSet11.Товары);

        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            int delete = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(delete);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            товарыTableAdapter1.Update(kurse_26ip212DataSet11);
        }
    }
}
