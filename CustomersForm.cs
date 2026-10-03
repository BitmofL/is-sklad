using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИС_Склад
{
    public partial class CustomersForm: Form
    {
        private string connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=kurse_26ip212;Integrated Security=True"; // Замените своей строкой подключения
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public CustomersForm()
        {
            InitializeComponent();
        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapter.Update(dataTable);
                MessageBox.Show("Изменения успешно сохранены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить этого клиента?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Получаем индекс выбранной строки
                        int rowIndex = dataGridViewCustomers.SelectedRows[0].Index;

                        //Удаление строки из DataTable
                        dataTable.Rows[rowIndex].Delete();

                        // Обновляем базу данных
                        dataAdapter.Update(dataTable);

                        MessageBox.Show("Клиент успешно удален.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении клиента: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для удаления.");
            }
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID_Клиента, Имя, Адрес, Телефон FROM Клиенты";
                    dataAdapter = new SqlDataAdapter(query, connection);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter); // Для генерации команд Update, Insert, Delete
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewCustomers.DataSource = dataTable;

                    // Скрываем столбец ID_Клиента
                    dataGridViewCustomers.Columns["ID_Клиента"].Visible = false;
                    //Автоматическое изменение размера столбцов
                    dataGridViewCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //Разрешаем добавление строк
                    dataGridViewCustomers.AllowUserToAddRows = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных клиентов: {ex.Message}");
            }
        }
    }
}
