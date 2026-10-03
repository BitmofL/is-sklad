using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИС_Склад
{
    public partial class SuppliersForm : Form
    {
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kurse_26ip212DataSet1.Поставщики". При необходимости она может быть перемещена или удалена.
            this.поставщикиTableAdapter.Fill(this.kurse_26ip212DataSet1.Поставщики);

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            поставщикиTableAdapter.Update(kurse_26ip212DataSet1);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int delete = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(delete);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
