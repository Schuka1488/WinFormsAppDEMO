using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppDEMO
{
    public partial class ShiftsForm : Form
    {
        // Объект для управления подключением к базе данных
        private DatabaseManager databaseManager;

        // Объект для хранения данных таблицы
        System.Data.DataTable dataTable;

        // Обработчик события загрузки формы
        private void ShiftsForm_Load(object sender, EventArgs e)
        {
            LoadShiftsData(); // Загрузка данных при загрузке формы
        }

        // Конструктор формы, вызывается при создании экземпляра класса ShiftsForm
        public ShiftsForm()
        {
            InitializeComponent();
            // Инициализация объекта для управления подключением к базе данных
            databaseManager = new DatabaseManager();
        }

        // Метод для загрузки данных смен в DataGridView
        private void LoadShiftsData()
        {
            // Очистка источника данных DataGridView
            dataGridView1.DataSource = null;

            // SQL-запрос для получения данных смен из базы данных
            string query = "SELECT * FROM shifts";

            // Создание команды для выполнения SQL-запроса
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());

            // Создание адаптера данных для заполнения DataTable
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);

            // Инициализация DataTable для хранения данных
            dataTable = new System.Data.DataTable();

            // Заполнение DataTable данными из базы данных
            dataAdapter.Fill(dataTable);

            // Присоединение DataTable к источнику данных DataGridView
            dataGridView1.DataSource = dataTable;
        }

        // Обработчик события нажатия кнопки "Добавить смену"
        private void AddShiftsButton_Click(object sender, EventArgs e)
        {
            // Получение даты смены и описания смены из соответствующих компонентов управления
            string datetime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string description = DescriptionTextBox.Text;

            // Проверка, что все поля заполнены
            if (string.IsNullOrEmpty(datetime) || string.IsNullOrEmpty(description))
            {
                return; // Если какое-то из полей не заполнено, выходим из метода
            }

            // Создание SQL-запроса для добавления смены в таблицу
            string query = "INSERT INTO Shifts (ShiftDate, ShiftDescription) VALUES (@date, @desc)";
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());
            cmd.Parameters.AddWithValue("@date", datetime); // Передача параметра даты смены
            cmd.Parameters.AddWithValue("@desc", description); // Передача параметра описания смены

            // Выполнение SQL-запроса
            cmd.ExecuteNonQuery();

            // Повторная загрузка данных смен в DataGridView
            LoadShiftsData();
        }
    }
}
