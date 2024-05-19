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
        private DatabaseManager databaseManager;
        private void LoadComboBoxData()
        {
            // Для комбобокса с типами пользователей
            string queryUserTypes = "SELECT DISTINCT UserType FROM Users";
            MySqlCommand cmdUserTypes = new MySqlCommand(queryUserTypes, databaseManager.GetConnection());
            using (MySqlDataReader reader = cmdUserTypes.ExecuteReader())
            {
                while (reader.Read())
                {
                    AddComboBoxType.Items.Add(reader.GetString("UserType"));
                }
            }

            // Для комбобокса со статусами пользователей
            string queryUserStatuses = "SELECT DISTINCT UserStatus FROM Users";
            MySqlCommand cmdUserStatuses = new MySqlCommand(queryUserStatuses, databaseManager.GetConnection());
            using (MySqlDataReader reader = cmdUserStatuses.ExecuteReader())
            {
                while (reader.Read())
                {
                    AddComboBoxStatus.Items.Add(reader.GetString("UserStatus"));
                }
            }
        }

        public AddusersForm()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();
            LoadComboBoxData();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string username = AddTextBoxLogin.Text;
            string password = AddTextBoxPassword.Text;
            string userType = AddComboBoxType.SelectedItem.ToString();
            string userStatus = AddComboBoxStatus.SelectedItem.ToString();

            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType) || string.IsNullOrEmpty(userStatus))
            {
                return;
            }

            // Создаем SQL-запрос для добавления пользователя в таблицу
            string query = "INSERT INTO Users (Username, Password, UserType, UserStatus) VALUES (@username, @password, @userType, @userStatus)";
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@userType", userType);
            cmd.Parameters.AddWithValue("@userStatus", userStatus);
            // Выполняем SQL-запрос
            cmd.ExecuteNonQuery();
            this.Close();
        }
    }
}
