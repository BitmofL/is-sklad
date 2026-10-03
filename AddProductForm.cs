using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ИС_Склад
{
    public partial class AddProductForm : Form
    {
        private string connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=kurse_26ip212;Integrated Security=True"; // Замените своей строкой подключения
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ID_Категории, Наименование FROM КатегорииТоваров";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable categoriesTable = new DataTable();
                    adapter.Fill(categoriesTable);

                    comboBoxCategory.DataSource = categoriesTable;
                    comboBoxCategory.DisplayMember = "Наименование";
                    comboBoxCategory.ValueMember = "ID_Категории";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке категорий: {ex.Message}");
            }
        }

        public new string ProductName { get; set; } // Добавьте свойства для доступа к данным
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductUnit { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Проверьте, что все поля заполнены
            if (string.IsNullOrEmpty(textBoxName.Text) ||
                string.IsNullOrEmpty(textBoxDescription.Text) ||
                numericUpDownPrice.Value == 0 ||
                string.IsNullOrEmpty(comboBoxUnit.Text) ||
                comboBoxCategory.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Сохраните данные в свойства
            ProductName = textBoxName.Text;
            ProductDescription = textBoxDescription.Text;
            ProductPrice = numericUpDownPrice.Value;
            ProductUnit = comboBoxUnit.Text;
            ProductCategoryId = Convert.ToInt32(comboBoxCategory.SelectedValue);
            ProductId = AddProductToDatabase(ProductName, ProductDescription, ProductPrice, ProductUnit, ProductCategoryId);

            DialogResult = DialogResult.OK; // Закрываем форму с результатом OK
            Close();
        }

        private int AddProductToDatabase(string name, string description, decimal price, string unit, int categoryId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Товары (Наименование, Описание, Цена, ЕдИзм, ID_Категории) VALUES (@Наименование, @Описание, @Цена, @ЕдИзм, @ID_Категории); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Наименование", name);
                    insertCommand.Parameters.AddWithValue("@Описание", description);
                    insertCommand.Parameters.AddWithValue("@Цена", price);
                    insertCommand.Parameters.AddWithValue("@ЕдИзм", unit);
                    insertCommand.Parameters.AddWithValue("@ID_Категории", categoryId);

                    // Выполняем запрос и получаем ID добавленного товара
                    int newProductId = Convert.ToInt32(insertCommand.ExecuteScalar());
                    return newProductId; // Возвращаем ID нового товара
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
                return 0; // В случае ошибки возвращаем 0
            }
        }
    }
}
