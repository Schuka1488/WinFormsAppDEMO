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
    public partial class AddusersForm : Form
    {
        // Объект для управления подключением к базе данных
        private DatabaseManager databaseManager;

        // Метод для загрузки данных в комбобоксы с типами и статусами пользователей
        private void LoadComboBoxData()
        {
            // SQL-запрос для получения уникальных типов пользователей из базы данных
            string queryUserTypes = "SELECT DISTINCT UserType FROM Users";
            MySqlCommand cmdUserTypes = new MySqlCommand(queryUserTypes, databaseManager.GetConnection());
            using (MySqlDataReader reader = cmdUserTypes.ExecuteReader())
            {
                // Чтение результатов запроса и добавление типов пользователей в комбобокс
                while (reader.Read())
                {
                    AddComboBoxType.Items.Add(reader.GetString("UserType"));
                }
            }

            // SQL-запрос для получения уникальных статусов пользователей из базы данных
            string queryUserStatuses = "SELECT DISTINCT UserStatus FROM Users";
            MySqlCommand cmdUserStatuses = new MySqlCommand(queryUserStatuses, databaseManager.GetConnection());
            using (MySqlDataReader reader = cmdUserStatuses.ExecuteReader())
            {
                // Чтение результатов запроса и добавление статусов пользователей в комбобокс
                while (reader.Read())
                {
                    AddComboBoxStatus.Items.Add(reader.GetString("UserStatus"));
                }
            }
        }

        // Конструктор формы, вызывается при создании экземпляра класса AddusersForm
        public AddusersForm()
        {
            InitializeComponent();
            // Инициализация объекта для управления подключением к базе данных
            databaseManager = new DatabaseManager();
            // Загрузка данных в комбобоксы при открытии формы
            LoadComboBoxData();
        }

        // Обработчик события нажатия на кнопку "Добавить"
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Получение значений полей для создания нового пользователя
            string username = AddTextBoxLogin.Text;
            string password = AddTextBoxPassword.Text;
            string userType = AddComboBoxType.SelectedItem.ToString();
            string userStatus = AddComboBoxStatus.SelectedItem.ToString();

            // Проверка, что все поля заполнены
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType) || string.IsNullOrEmpty(userStatus))
            {
                return; // Если какое-то из полей не заполнено, прерываем выполнение метода
            }

            // Создаем SQL-запрос для добавления нового пользователя в таблицу Users
            string query = "INSERT INTO Users (Username, Password, UserType, UserStatus) VALUES (@username, @password, @userType, @userStatus)";
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());
            // Устанавливаем параметры для SQL-запроса
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@userType", userType);
            cmd.Parameters.AddWithValue("@userStatus", userStatus);
            // Выполняем SQL-запрос
            cmd.ExecuteNonQuery();
            // Закрываем форму добавления пользователя после успешного добавления
            this.Close();
        }
    }
}
