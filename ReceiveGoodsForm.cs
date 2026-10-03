using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ИС_Склад.Forms
{
    public partial class ReceiveGoodsForm : Form
    {
        private string connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=kurse_26ip212;Integrated Security=True"; // Замените своей строкой подключения

        public ReceiveGoodsForm()
        {
            InitializeComponent();
        }

        private void ReceiveGoodsForm_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
            InitializeDataGridView();
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

                    comboBoxWarehouses.Items.Clear();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке складов: {ex.Message}");
            }
        }

        private void InitializeDataGridView()
        {
            dataGridViewProducts.Columns.Add("ID_Товара", "ID Товара");
            dataGridViewProducts.Columns.Add("Наименование", "Наименование");
            dataGridViewProducts.Columns.Add("Количество", "Количество");

            // Скрываем столбец ID_Товара (если нужно)
            dataGridViewProducts.Columns["ID_Товара"].Visible = false;

            // Запрещаем пользователю добавлять строки напрямую
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.ReadOnly = false;  //Позволяет редактировать ячейки
            dataGridViewProducts.Columns["Наименование"].ReadOnly = true;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            AddProductToDataGridView();
        }

        private void AddProductToDataGridView()
        {
            AddProductForm addProductForm = new AddProductForm(); // Создаем экземпляр формы

            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                // Получаем данные из формы
                string productName = addProductForm.ProductName;
                int productId = addProductForm.ProductId;


                string quantityStr = Interaction.InputBox("Введите количество товара:", "Добавление товара", "");
                if (!string.IsNullOrEmpty(quantityStr) && int.TryParse(quantityStr, out int количество))
                {
                    dataGridViewProducts.Rows.Add(productId, productName, количество);
                }
                else
                {
                    MessageBox.Show("Некорректное количество товара.");
                }


            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxWarehouses.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад для приемки товаров.");
                return;
            }

            WarehouseItem selectedWarehouse = (WarehouseItem)comboBoxWarehouses.SelectedItem;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridViewProducts.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            // Проверяем, что все значения введены.
                            if (row.Cells["ID_Товара"].Value == null || row.Cells["Количество"].Value == null)
                            {
                                MessageBox.Show("Пожалуйста, заполните все ячейки в строке.");
                                return;
                            }

                            int idТовара = Convert.ToInt32(row.Cells["ID_Товара"].Value);
                            int количество = Convert.ToInt32(row.Cells["Количество"].Value);

                            // Проверяем, есть ли уже запись с таким ID_Склада и ID_Товара
                            string checkQuery = "SELECT COUNT(*) FROM СкладскиеОстатки WHERE ID_Склад = @ID_Склад AND ID_Товара = @ID_Товара";
                            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                            checkCommand.Parameters.AddWithValue("@ID_Склад", selectedWarehouse.Id); //Исправлено
                            checkCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count > 0)
                            {
                                // Если запись уже есть, обновляем количество
                                string updateQuery = "UPDATE СкладскиеОстатки SET Количество = Количество + @Количество WHERE ID_Склад = @ID_Склад AND ID_Товара = @ID_Товара";
                                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                                updateCommand.Parameters.AddWithValue("@ID_Склад", selectedWarehouse.Id); //Исправлено
                                updateCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                                updateCommand.Parameters.AddWithValue("@Количество", количество);
                                updateCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                // Если записи нет, добавляем новую
                                string insertQuery = "INSERT INTO СкладскиеОстатки (ID_Склад, ID_Товара, Количество) VALUES (@ID_Склад, @ID_Товара, @Количество)";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                                insertCommand.Parameters.AddWithValue("@ID_Склад", selectedWarehouse.Id); //Исправлено
                                insertCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                                insertCommand.Parameters.AddWithValue("@Количество", количество);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Приемка успешно сохранена.");
                    dataGridViewProducts.Rows.Clear(); // Очищаем таблицу после сохранения
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении приемки: {ex.Message}");
            }
        }

        private void buttonAddExistingProduct_Click(object sender, EventArgs e)
        {
            AddExistingProduct();
        }
        private void AddExistingProduct()
        {
            string productId = Interaction.InputBox("Введите ID товара:", "Добавление товара", "");
            if (!string.IsNullOrEmpty(productId) && int.TryParse(productId, out int idТовара))
            {
                string productName = GetProductName(idТовара);
                if (!string.IsNullOrEmpty(productName))
                {
                    string quantityStr = Interaction.InputBox("Введите количество товара:", "Добавление товара", "");
                    if (!string.IsNullOrEmpty(quantityStr) && int.TryParse(quantityStr, out int количество))
                    {
                        dataGridViewProducts.Rows.Add(idТовара, productName, количество);
                    }
                    else
                    {
                        MessageBox.Show("Некорректное количество товара.");
                    }
                }
                else
                {
                    MessageBox.Show("Товар с указанным ID не найден.");
                }
            }
            else
            {
                MessageBox.Show("Некорректный ID товара.");
            }
        }

        private string GetProductName(int idТовара)
        {
            string productName = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Наименование FROM Товары WHERE ID_Товара = @ID_Товара";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID_Товара", idТовара);
                    object result = command.ExecuteScalar();
                    productName = result != null ? result.ToString() : null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке наименования товара: {ex.Message}");
            }
            return productName;
        }
        private void buttonAddProduct_Click_1(object sender, EventArgs e)
        {
            AddProductToDataGridView();
        }
    }
}
