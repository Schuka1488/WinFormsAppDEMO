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
    public partial class UsersForm : Form
    {
        // Объект для управления подключением к базе данных
        private DatabaseManager databaseManager;

        // Объект для хранения данных таблицы
        System.Data.DataTable dataTable;

        // Обработчик события загрузки формы
        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUserData(); // Загрузка данных при загрузке формы
        }

        // Конструктор формы, вызывается при создании экземпляра класса UsersForm
        public UsersForm()
        {
            InitializeComponent();
            // Инициализация объекта для управления подключением к базе данных
            databaseManager = new DatabaseManager();
        }

        // Метод для загрузки данных пользователей в DataGridView
        private void LoadUserData()
        {
            // Очистка источника данных DataGridView
            dataGridView1.DataSource = null;

            // SQL-запрос для получения данных пользователей из базы данных
            string query = "SELECT * FROM users";

            // Создание команды для выполнения SQL-запроса
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());

            // Создание адаптера данных для заполнения DataTable
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);

            // Инициализация DataTable для хранения данных
            dataTable = new System.Data.DataTable();

            // Заполнение DataTable данными из базы данных
            dataAdapter.Fill(dataTable);

            // Создание и настройка комбо-бокса для столбца "Статус" в DataGridView
            DataGridViewComboBoxColumn status = new DataGridViewComboBoxColumn();
            var list = new List<string>() { "Уволен", "Активен" };
            status.DataSource = list;
            status.HeaderText = "Статус";
            status.DataPropertyName = "UserStatus";

            // Присоединение DataTable к источнику данных DataGridView
            dataGridView1.DataSource = dataTable;

            // Установка столбцов "UserID" и "Username" только для чтения
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            // Добавление комбо-бокса статуса в DataGridView
            dataGridView1.Columns.AddRange(status);
        }
        // Метод для установки статуса сотрудника
        void SetStatusEmployee(int id, string fired)
        {
            // SQL-запрос для обновления статуса пользователя в базе данных
            MySqlCommand cmd = new MySqlCommand($"UPDATE users SET UserStatus='{fired}' WHERE UserID={id};", databaseManager.GetConnection());
            // Выполнение SQL-запроса
            cmd.ExecuteNonQuery();
        }
        // Обработчик события нажатия на содержимое ячейки в DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Подтверждаем редактирование ячейки, чтобы сохранить изменения
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        // Обработчик события изменения содержимого ячейки DataGridView
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Получение индекса строки
            int i = e.RowIndex;
            // Установка статуса сотрудника по выбранной строке
            SetStatusEmployee(Convert.ToInt32(dataTable.Rows[i]["UserID"]), Convert.ToString(dataTable.Rows[i]["UserStatus"]));
            // Повторная загрузка данных в DataGridView
            LoadUserData();
        }
        // Обработчик события нажатия кнопки "Добавить пользователя"
        private void AddUsersButton_Click(object sender, EventArgs e)
        {
            // Отображение формы добавления пользователя
            AddusersForm addUsersForm = new AddusersForm();
            addUsersForm.Show();
        }
        // Обработчик события нажатия кнопки "Обновить"
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            // Повторная загрузка данных в DataGridView
            LoadUserData();
        }
    }
}
