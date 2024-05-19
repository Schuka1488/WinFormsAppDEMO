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
    public partial class OrdersForm : Form
    {
        private DatabaseManager databaseManager;
        System.Data.DataTable dataTable;
        private void LoadComboBoxData()
        {
            // Для комбобокса с типами пользователей
            string querywait = "SELECT DISTINCT WaiterID FROM Orders";
            MySqlCommand cmdwait = new MySqlCommand(querywait, databaseManager.GetConnection());
            using (MySqlDataReader reader = cmdwait.ExecuteReader())
            {
                while (reader.Read())
                {
                    WaiterIDComboBox.Items.Add(reader.GetInt32("WaiterID"));
                }
            }

            // Для комбобокса со статусами пользователей
            string querystatus = "SELECT DISTINCT Status FROM Orders";
            MySqlCommand cmdstatus = new MySqlCommand(querystatus, databaseManager.GetConnection());
            using (MySqlDataReader reader = cmdstatus.ExecuteReader())
            {
                while (reader.Read())
                {
                    StatusComboBox.Items.Add(reader.GetString("Status"));
                }
            }
        }
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrdersData();
        }
        public OrdersForm()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();
            LoadComboBoxData();
        }
        private void LoadOrdersData()
        {
            dataGridView1.DataSource = null;
            string query = "SELECT * FROM orders";
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            dataTable = new System.Data.DataTable();
            dataAdapter.Fill(dataTable);

            DataGridViewComboBoxColumn status = new DataGridViewComboBoxColumn();
            var list = new List<string>() { "Принят", "Оплачен", "Готовится", "Готов" };

            status.DataSource = list;
            status.HeaderText = "Статус";
            status.DataPropertyName = "Status";

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns.AddRange(status);
        }
        void SetStatusEmployee(int id, string fired)
        {
            MySqlCommand cmd = new MySqlCommand($"UPDATE orders SET Status='{fired}' WHERE OrderID={id};", databaseManager.GetConnection());
            cmd.ExecuteNonQuery();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            SetStatusEmployee(Convert.ToInt32(dataTable.Rows[i]["OrderID"]), Convert.ToString(dataTable.Rows[i]["Status"]));
            LoadOrdersData();
        }

        private void AddOrdersButton_Click(object sender, EventArgs e)
        {
            string datetime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string TNumber = TableNumberTextBox.Text;
            string countCustomer = CustomerCountTextBox.Text;
            string WaitID = WaiterIDComboBox.SelectedItem.ToString();
            string statusOrder = StatusComboBox.SelectedItem.ToString();

            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(datetime) || string.IsNullOrEmpty(TNumber) || string.IsNullOrEmpty(countCustomer) || string.IsNullOrEmpty(WaitID) || string.IsNullOrEmpty(statusOrder))
            {
                return;
            }

            // Создаем SQL-запрос для добавления пользователя в таблицу
            string query = "INSERT INTO Orders (OrderDate, TableNumber, CustomerCount, WaiterID, Status) VALUES (@date, @number, @count, @wait, @status )";
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());
            cmd.Parameters.AddWithValue("@date", datetime);
            cmd.Parameters.AddWithValue("@number", TNumber);
            cmd.Parameters.AddWithValue("@count", countCustomer);
            cmd.Parameters.AddWithValue("@wait", WaitID); 
            cmd.Parameters.AddWithValue("@status", statusOrder);

            // Выполняем SQL-запрос
            cmd.ExecuteNonQuery();
            LoadOrdersData();
        }
    }
}
