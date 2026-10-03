using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ИС_Склад.Forms
{
    public partial class InventoryForm : Form
    {
        private string connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=kurse_26ip212;Integrated Security=True"; // Замените своей строкой подключения
        private WarehouseItem selectedWarehouse;

        public InventoryForm()
        {
            InitializeComponent();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
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

                    comboBoxWarehouse.Items.Clear();
                    while (reader.Read())
                    {
                        comboBoxWarehouse.Items.Add(new WarehouseItem
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
            dataGridViewInventory.Columns.Add("ID_Товара", "ID Товара");
            dataGridViewInventory.Columns.Add("Наименование", "Наименование");
            dataGridViewInventory.Columns.Add("УчетноеКоличество", "Учетное количество");
            dataGridViewInventory.Columns.Add("ФактическоеКоличество", "Фактическое количество");
            dataGridViewInventory.Columns.Add("Отклонение", "Отклонение");

            // Скрываем столбец ID_Товара (если нужно)
            dataGridViewInventory.Columns["ID_Товара"].Visible = false;

            // Разрешаем пользователю редактировать только столбец "Фактическое количество"
            dataGridViewInventory.ReadOnly = false;
            foreach (DataGridViewColumn column in dataGridViewInventory.Columns)
            {
                if (column.Name != "ФактическоеКоличество")
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void buttonStartInventory_Click(object sender, EventArgs e)
        {
            if (comboBoxWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад для инвентаризации.");
                return;
            }

            selectedWarehouse = (WarehouseItem)comboBoxWarehouse.SelectedItem;
            LoadInventoryData();
        }

        private void LoadInventoryData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                        СкладскиеОстатки.ID_Товара, 
                                        Товары.Наименование, 
                                        СкладскиеОстатки.Количество 
                                    FROM СкладскиеОстатки 
                                    INNER JOIN Товары ON СкладскиеОстатки.ID_Товара = Товары.ID_Товара 
                                    WHERE СкладскиеОстатки.ID_Склад = @ID_Склада";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID_Склада", selectedWarehouse.Id);

                    SqlDataReader reader = command.ExecuteReader();
                    dataGridViewInventory.Rows.Clear();

                    while (reader.Read())
                    {
                        int idТовара = reader.GetInt32(0);
                        string наименование = reader.GetString(1);
                        int учетноеКоличество = reader.GetInt32(2);
                        dataGridViewInventory.Rows.Add(idТовара, наименование, учетноеКоличество, 0, 0); // Фактическое количество и отклонение пока = 0
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных инвентаризации: {ex.Message}");
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            CalculateОтклонения();
        }

        private void CalculateОтклонения()
        {
            foreach (DataGridViewRow row in dataGridViewInventory.Rows)
            {
                if (!row.IsNewRow)
                {
                    try
                    {
                        // Получаем учетное и фактическое количество
                        int учетноеКоличество = Convert.ToInt32(row.Cells["УчетноеКоличество"].Value);
                        int фактическоеКоличество = Convert.ToInt32(row.Cells["ФактическоеКоличество"].Value);

                        // Рассчитываем отклонение
                        int отклонение = фактическоеКоличество - учетноеКоличество;
                        row.Cells["Отклонение"].Value = отклонение;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Пожалуйста, введите корректное числовое значение для фактического количества.");
                        row.Cells["ФактическоеКоличество"].Value = 0; // Сбрасываем значение
                        row.Cells["Отклонение"].Value = 0;
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад для сохранения результатов инвентаризации.");
                return;
            }

            selectedWarehouse = (WarehouseItem)comboBoxWarehouse.SelectedItem;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridViewInventory.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int idТовара = Convert.ToInt32(row.Cells["ID_Товара"].Value);
                            int фактическоеКоличество = Convert.ToInt32(row.Cells["ФактическоеКоличество"].Value);

                            // Обновляем количество товара на складе
                            string updateQuery = "UPDATE СкладскиеОстатки SET Количество = @Количество WHERE ID_Склад = @ID_Склад AND ID_Товара = @ID_Товара";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                            updateCommand.Parameters.AddWithValue("@ID_Склад", selectedWarehouse.Id);
                            updateCommand.Parameters.AddWithValue("@ID_Товара", idТовара);
                            updateCommand.Parameters.AddWithValue("@Количество", фактическоеКоличество);
                            updateCommand.ExecuteNonQuery();

                            // Здесь можно добавить запись об инвентаризации в другую таблицу (например, "Инвентаризации")
                            // с информацией о складе, товаре, учетном количестве, фактическом количестве и отклонении
                        }
                    }

                    MessageBox.Show("Результаты инвентаризации успешно сохранены.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении результатов инвентаризации: {ex.Message}");
            }
        }


    }
}
