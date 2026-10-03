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
    public partial class WarehousesForm : Form
    {
        public WarehousesForm()
        {
            InitializeComponent();
        }

        private void WarehousesForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kurse_26ip212DataSet1.Склады". При необходимости она может быть перемещена или удалена.
            this.складыTableAdapter.Fill(this.kurse_26ip212DataSet1.Склады);

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            складыTableAdapter.Update(kurse_26ip212DataSet1);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int delete = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(delete);
        }
    }
}
