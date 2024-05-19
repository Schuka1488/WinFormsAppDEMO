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
        private DatabaseManager databaseManager;
        System.Data.DataTable dataTable;
        private void ShiftsForm_Load(object sender, EventArgs e)
        {
            LoadShiftsData();
        }
        public ShiftsForm()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();
        }
        private void LoadShiftsData()
        {
            dataGridView1.DataSource = null;
            string query = "SELECT * FROM shifts";
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            dataTable = new System.Data.DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void AddShiftsButton_Click(object sender, EventArgs e)
        {
            string datetime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string description = DescriptionTextBox.Text;

            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(datetime) || string.IsNullOrEmpty(description))
            {
                return;
            }

            // Создаем SQL-запрос для добавления пользователя в таблицу
            string query = "INSERT INTO Shifts (ShiftDate, ShiftDescription) VALUES (@date, @desc)";
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());
            cmd.Parameters.AddWithValue("@date", datetime);
            cmd.Parameters.AddWithValue("@desc", description);
            // Выполняем SQL-запрос
            cmd.ExecuteNonQuery();
            LoadShiftsData();
        }
    }
}
