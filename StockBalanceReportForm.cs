using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace ИС_Склад.Forms
{
    public partial class StockBalanceReportForm : Form
    {
        private string connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=kurse_26ip212;Integrated Security=True";
        public StockBalanceReportForm()
        {
            InitializeComponent();
        }

        private void StockBalanceReportForm_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
        }

        private void LoadWarehouses()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT ID_Склада, Наименование FROM Склады";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBoxWarehouses.Items.Add(new WarehouseItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }

                    reader.Close();
                }

                if (comboBoxWarehouses.Items.Count > 0)
                {
                    comboBoxWarehouses.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке складов: {ex.Message}");
            }
        }



        private void LoadStockBalance()
        {
            if (comboBoxWarehouses.SelectedItem == null) return;

            WarehouseItem selectedWarehouse = (WarehouseItem)comboBoxWarehouses.SelectedItem;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT t.Наименование, so.Количество
                    FROM СкладскиеОстатки so
                    JOIN Товары t ON so.ID_Товара = t.ID_Товара
                    WHERE so.ID_Склад = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", selectedWarehouse.Id);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridViewStockBalance.DataSource = table;
            }
        }



        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadStockBalance();
        }

        private void comboBoxWarehouses_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadStockBalance();
        }

        private void dataGridViewStockBalance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            if (comboBoxWarehouses.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад для создания отчета.");
                return;
            }

            WarehouseItem selectedWarehouse = (WarehouseItem)comboBoxWarehouses.SelectedItem;
            string fileName = $"Отчет_по_складу_{selectedWarehouse.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string filePath = Path.Combine(Application.StartupPath, fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"Отчет по складу: {selectedWarehouse.Name}");
                    writer.WriteLine($"Дата создания: {DateTime.Now}");
                    writer.WriteLine("----------------------------------------------------");

                    foreach (DataGridViewRow row in dataGridViewStockBalance.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            writer.WriteLine($"Товар: {row.Cells[0].Value}, Количество: {row.Cells[1].Value}");
                        }
                    }

                    writer.WriteLine("----------------------------------------------------");
                    MessageBox.Show($"Отчет успешно сохранен в файл: {filePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}");
            }
        }
    }

    public class WarehouseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
