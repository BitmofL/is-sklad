using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ИС_Склад.Forms
{
    public partial class ShipGoodsForm : Form
    {
        private string connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=kurse_26ip212;Integrated Security=True"; // Замените своей строкой подключения
        private WarehouseItem selectedWarehouse;

        public ShipGoodsForm()
        {
            InitializeComponent();
        }

        private void ShipGoodsForm_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
            LoadClients();
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

        private void LoadClients()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ID_Клиента, Имя FROM Клиенты";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    comboBoxClients.Items.Clear();
                    while (reader.Read())
                    {
                        comboBoxClients.Items.Add(new ClientItem
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
                MessageBox.Show($"Ошибка при загрузке клиентов: {ex.Message}");
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
            if (comboBoxWarehouses.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад для отгрузки товаров.");
                return;
            }
            selectedWarehouse = (WarehouseItem)comboBoxWarehouses.SelectedItem;
            string productId = Interaction.InputBox("Введите ID товара:", "Добавление товара", "");
            if (!string.IsNullOrEmpty(productId) && int.TryParse(productId, out int idТовара))
            {
                string productName = GetProductName(idТовара);
                if (!string.IsNullOrEmpty(productName))
                {
                    string quantityStr = Interaction.InputBox("Введите количество товара:", "Добавление товара", "");
                    if (!string.IsNullOrEmpty(quantityStr) && int.TryParse(quantityStr, out int количество))
                    {
                        if (CheckStockBalance(idТовара, selectedWarehouse.Id, количество))
                        {
                            dataGridViewProducts.Rows.Add(idТовара, productName, количество);
                        }
                        else
                        {
                            MessageBox.Show("Недостаточно товара на складе.");
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
                    command.Parameters.AddWithValue("@ID_Склад", idСклада);
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
            if (comboBoxWarehouses.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад для отгрузки товаров.");
                return;
            }

            if (comboBoxClients.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента для отгрузки товаров.");
                return;
            }

            selectedWarehouse = (WarehouseItem)comboBoxWarehouses.SelectedItem;
            ClientItem selectedClient = (ClientItem)comboBoxClients.SelectedItem;

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

                            // Проверяем, достаточно ли товара на складе
                            if (!CheckStockBalance(idТовара, selectedWarehouse.Id, количество))
                            {
                                MessageBox.Show($"Недостаточно товара {GetProductName(idТовара)} на складе.");
                                return;
                            }

                            // Обновляем количество товара на складе
                            string updateQuery = "UPDATE СкладскиеОстатки SET Количество = Количество - @Количество WHERE ID_Склад = @ID_Склад AND ID_Товара = @ID_Товара";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                            updateCommand.Parameters.AddWithValue("@ID_Склад", selectedWarehouse.Id);
                            updateCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                            updateCommand.Parameters.AddWithValue("@Количество", количество);
                            updateCommand.ExecuteNonQuery();

                            // Здесь можно добавить запись об отгрузке в другую таблицу (например, "Отгрузки")
                            // с информацией о складе, клиенте, товаре и количестве
                            string insertQuery = "INSERT INTO Отгрузки (ID_Склада, ID_Клиента, ID_Товара, Количество, ДатаОтгрузки) VALUES (@ID_Склада, @ID_Клиента, @ID_Товара, @Количество, @ДатаОтгрузки)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@ID_Склада", selectedWarehouse.Id);
                            insertCommand.Parameters.AddWithValue("@ID_Клиента", selectedClient.Id);
                            insertCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                            insertCommand.Parameters.AddWithValue("@Количество", количество);
                            insertCommand.Parameters.AddWithValue("@ДатаОтгрузки", DateTime.Now);
                            insertCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Отгрузка успешно сохранена.");
                    dataGridViewProducts.Rows.Clear(); // Очищаем таблицу после сохранения
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении отгрузки: {ex.Message}");
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
                        if (selectedWarehouse != null)
                        {
                            if (CheckStockBalance(idТовара, selectedWarehouse.Id, количество))
                            {
                                dataGridViewProducts.Rows.Add(idТовара, productName, количество);
                            }
                            else
                            {
                                MessageBox.Show("Недостаточно товара на складе.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите склад.");
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

        private void comboBoxWarehouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedWarehouse = (WarehouseItem)comboBoxWarehouses.SelectedItem;
        }
    }

    public class ClientItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
