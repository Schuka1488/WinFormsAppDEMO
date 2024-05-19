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
        // Объект для управления подключением к базе данных
        private DatabaseManager databaseManager;

        System.Data.DataTable dataTable;

        // Метод для загрузки данных в комбобоксы WaiterIDComboBox и StatusComboBox
        private void LoadComboBoxData()
        {
            // SQL-запрос для получения уникальных идентификаторов официантов из таблицы Orders
            string querywait = "SELECT DISTINCT WaiterID FROM Orders";
            MySqlCommand cmdwait = new MySqlCommand(querywait, databaseManager.GetConnection());
            using (MySqlDataReader reader = cmdwait.ExecuteReader())
            {
                // Чтение результатов запроса и добавление идентификаторов официантов в комбобокс WaiterIDComboBox
                while (reader.Read())
                {
                    WaiterIDComboBox.Items.Add(reader.GetInt32("WaiterID"));
                }
            }

            // SQL-запрос для получения уникальных статусов заказов из таблицы Orders
            string querystatus = "SELECT DISTINCT Status FROM Orders";
            MySqlCommand cmdstatus = new MySqlCommand(querystatus, databaseManager.GetConnection());
            using (MySqlDataReader reader = cmdstatus.ExecuteReader())
            {
                // Чтение результатов запроса и добавление статусов заказов в комбобокс StatusComboBox
                while (reader.Read())
                {
                    StatusComboBox.Items.Add(reader.GetString("Status"));
                }
            }
        }

        // Метод, вызываемый при загрузке формы
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrdersData(); // Загрузка данных о заказах при загрузке формы
        }

        // Конструктор формы, вызывается при создании экземпляра класса OrdersForm
        public OrdersForm()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager(); // Инициализация объекта для управления подключением к базе данных
            LoadComboBoxData(); // Загрузка данных в комбобоксы при открытии формы
        }

        // Метод для загрузки данных о заказах в DataGridView
        private void LoadOrdersData()
        {
            // Очистка источника данных DataGridView
            dataGridView1.DataSource = null;

            // SQL-запрос для получения всех данных о заказах из таблицы Orders
            string query = "SELECT * FROM orders";

            // Создание команды для выполнения SQL-запроса
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());

            // Создание адаптера данных для заполнения DataTable
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);

            // Инициализация DataTable для хранения данных
            dataTable = new System.Data.DataTable();

            // Заполнение DataTable данными из базы данных
            dataAdapter.Fill(dataTable);

            // Создание комбобокс-столбца для установки статуса заказа в DataGridView
            DataGridViewComboBoxColumn status = new DataGridViewComboBoxColumn();
            var list = new List<string>() { "Принят", "Оплачен", "Готовится", "Готов" };
            status.DataSource = list;
            status.HeaderText = "Статус";
            status.DataPropertyName = "Status";

            // Присоединение DataTable к источнику данных DataGridView
            dataGridView1.DataSource = dataTable;

            // Установка определенных столбцов только для чтения
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;

            // Добавление комбобокс-столбца в DataGridView
            dataGridView1.Columns.AddRange(status);
        }

        // Метод для установки статуса заказа в базе данных по его ID
        void SetStatusEmployee(int id, string fired)
        {
            // SQL-запрос для обновления статуса заказа в таблице Orders по его ID
            MySqlCommand cmd = new MySqlCommand($"UPDATE orders SET Status='{fired}' WHERE OrderID={id};", databaseManager.GetConnection());
            // Выполнение SQL-запроса
            cmd.ExecuteNonQuery();
        }

        // Обработчик события нажатия на содержимое ячейки в DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // Обработчик события изменения значения ячейки в DataGridView
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Получение индекса строки, содержащей измененную ячейку
            int i = e.RowIndex;
            // Установка нового статуса заказа в базе данных по его ID и обновление данных в DataGridView
            SetStatusEmployee(Convert.ToInt32(dataTable.Rows[i]["OrderID"]), Convert.ToString(dataTable.Rows[i]["Status"]));
            LoadOrdersData(); // Повторная загрузка данных о заказах для обновления таблицы
        }

        // Обработчик события нажатия на кнопку "Добавить заказ"
        private void AddOrdersButton_Click(object sender, EventArgs e)
        {
            // Получение данных о новом заказе из компонентов управления на форме
            string datetime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string TNumber = TableNumberTextBox.Text;
            string countCustomer = CustomerCountTextBox.Text;
            string WaitID = WaiterIDComboBox.SelectedItem.ToString();
            string statusOrder = StatusComboBox.SelectedItem.ToString();

            // Проверка, что все необходимые поля заполнены
            if (string.IsNullOrEmpty(datetime) || string.IsNullOrEmpty(TNumber) || string.IsNullOrEmpty(countCustomer) || string.IsNullOrEmpty(WaitID) || string.IsNullOrEmpty(statusOrder))
            {
                return; // Если какое-то из полей не заполнено, прерываем выполнение метода
            }

            // Создание SQL-запроса для добавления нового заказа в таблицу Orders
            string query = "INSERT INTO Orders (OrderDate, TableNumber, CustomerCount, WaiterID, Status) VALUES (@date, @number, @count, @wait, @status )";
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());
            // Установка параметров для SQL-запроса
            cmd.Parameters.AddWithValue("@date", datetime);
            cmd.Parameters.AddWithValue("@number", TNumber);
            cmd.Parameters.AddWithValue("@count", countCustomer);
            cmd.Parameters.AddWithValue("@wait", WaitID);
            cmd.Parameters.AddWithValue("@status", statusOrder);

            // Выполнение SQL-запроса
            cmd.ExecuteNonQuery();
            LoadOrdersData(); // Повторная загрузка данных о заказах для обновления таблицы
        }
    }
}
