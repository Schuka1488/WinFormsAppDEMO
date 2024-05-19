using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormsAppDEMO
{
    public class DatabaseManager
    {
        // Поле для хранения соединения с базой данных
        private MySqlConnection connection;

        // Константы для параметров подключения к базе данных
        private const string server = "127.0.0.1"; // Адрес сервера базы данных
        private const string database = "demo";    // Имя базы данных
        private const string uid = "root";         // Имя пользователя базы данных
        private const string password = "Vfrcbvtdutybz20042010"; // Пароль пользователя базы данных

        // Конструктор класса, вызывается при создании экземпляра класса DatabaseManager
        public DatabaseManager()
        {
            // Вызов метода инициализации подключения к базе данных
            InitializeDatabaseConnection();
        }

        // Метод для инициализации подключения к базе данных
        private void InitializeDatabaseConnection()
        {
            // Формирование строки подключения к базе данных на основе заданных параметров
            string connectionString;
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            // Создание объекта для подключения к базе данных
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        // Метод для получения объекта подключения к базе данных
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
