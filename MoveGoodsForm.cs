using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ИС_Склад.Forms
{
    public partial class MoveGoodsForm : Form
    {
        private string connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=kurse_26ip212;Integrated Security=True"; // Замените своей строкой подключения
        private WarehouseItem selectedFromWarehouse;
        private WarehouseItem selectedToWarehouse;

        public MoveGoodsForm()
        {
            InitializeComponent();
        }

        private void MoveGoodsForm_Load(object sender, EventArgs e)
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

                    comboBoxFromWarehouse.Items.Clear();
                    comboBoxToWarehouse.Items.Clear();
                    while (reader.Read())
                    {
                        WarehouseItem warehouse = new WarehouseItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                        comboBoxFromWarehouse.Items.Add(warehouse);
                        comboBoxToWarehouse.Items.Add(warehouse);
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
            if (comboBoxFromWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад-отправитель.");
                return;
            }

            selectedFromWarehouse = (WarehouseItem)comboBoxFromWarehouse.SelectedItem;
            string productId = Interaction.InputBox("Введите ID товара:", "Добавление товара", "");
            if (!string.IsNullOrEmpty(productId) && int.TryParse(productId, out int idТовара))
            {
                string productName = GetProductName(idТовара);
                if (!string.IsNullOrEmpty(productName))
                {
                    string quantityStr = Interaction.InputBox("Введите количество товара:", "Добавление товара", "");
                    if (!string.IsNullOrEmpty(quantityStr) && int.TryParse(quantityStr, out int количество))
                    {
                        if (CheckStockBalance(idТовара, selectedFromWarehouse.Id, количество))
                        {
                            dataGridViewProducts.Rows.Add(idТовара, productName, количество);
                        }
                        else
                        {
                            MessageBox.Show("Недостаточно товара на складе-отправителе.");
                        }
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

        private bool CheckStockBalance(int idТовара, int idСклада, int количество)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Количество FROM СкладскиеОстатки WHERE ID_Склад = @ID_Склад AND ID_Товара = @ID_Товара";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID_Склад", idСклада); // Добавляем параметр и его значение
                    command.Parameters.AddWithValue("@ID_Товара", idТовара);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int stockQuantity = Convert.ToInt32(result);
                        return stockQuantity >= количество; // Возвращаем true, если товара достаточно
                    }
                    else
                    {
                        return false; // Возвращаем false, если товара нет на складе
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке остатков: {ex.Message}");
                return false; // В случае ошибки возвращаем false
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxFromWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад-отправитель.");
                return;
            }

            if (comboBoxToWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад-получатель.");
                return;
            }

            selectedFromWarehouse = (WarehouseItem)comboBoxFromWarehouse.SelectedItem;
            selectedToWarehouse = (WarehouseItem)comboBoxToWarehouse.SelectedItem;

            if (selectedFromWarehouse.Id == selectedToWarehouse.Id)
            {
                MessageBox.Show("Склад-отправитель и склад-получатель не могут быть одинаковыми.");
                return;
            }

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

                            // Проверяем, достаточно ли товара на складе-отправителе
                            if (!CheckStockBalance(idТовара, selectedFromWarehouse.Id, количество))
                            {
                                MessageBox.Show($"Недостаточно товара {GetProductName(idТовара)} на складе-отправителе.");
                                return;
                            }

                            // Обновляем количество товара на складе-отправителе
                            string updateFromQuery = "UPDATE СкладскиеОстатки SET Количество = Количество - @Количество WHERE ID_Склад = @ID_Склад AND ID_Товара = @ID_Товара";
                            SqlCommand updateFromCommand = new SqlCommand(updateFromQuery, connection);
                            updateFromCommand.Parameters.AddWithValue("@ID_Склад", selectedFromWarehouse.Id); // Добавляем параметр и его значение
                            updateFromCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                            updateFromCommand.Parameters.AddWithValue("@Количество", количество);
                            updateFromCommand.ExecuteNonQuery();

                            // Проверяем, есть ли уже запись с таким ID_Склада и ID_Товара на складе-получателе
                            string checkQuery = "SELECT COUNT(*) FROM СкладскиеОстатки WHERE ID_Склад = @ID_Склад AND ID_Товара = @ID_Товара";
                            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                            checkCommand.Parameters.AddWithValue("@ID_Склад", selectedToWarehouse.Id); // Добавляем параметр и его значение
                            checkCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count > 0)
                            {
                                // Если запись уже есть, обновляем количество
                                string updateToQuery = "UPDATE СкладскиеОстатки SET Количество = Количество + @Количество WHERE ID_Склад = @ID_Склад AND ID_Товара = @ID_Товара";
                                SqlCommand updateToCommand = new SqlCommand(updateToQuery, connection);
                                updateToCommand.Parameters.AddWithValue("@ID_Склад", selectedToWarehouse.Id); // Добавляем параметр и его значение
                                updateToCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                                updateToCommand.Parameters.AddWithValue("@Количество", количество);
                                updateToCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                // Если записи нет, добавляем новую
                                string insertQuery = "INSERT INTO СкладскиеОстатки (ID_Склад, ID_Товара, Количество) VALUES (@ID_Склад, @ID_Товара, @Количество)";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                                insertCommand.Parameters.AddWithValue("@ID_Склад", selectedToWarehouse.Id); // Добавляем параметр и его значение
                                insertCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                                insertCommand.Parameters.AddWithValue("@Количество", количество);
                                insertCommand.ExecuteNonQuery();
                            }


                            // Здесь можно добавить запись о перемещении в другую таблицу (например, "Перемещения")
                            // с информацией о складах, товаре и количестве
                        }
                    }

                    MessageBox.Show("Перемещение успешно сохранено.");
                    dataGridViewProducts.Rows.Clear(); // Очищаем таблицу после сохранения
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении перемещения: {ex.Message}");
            }
        }
    }
}
