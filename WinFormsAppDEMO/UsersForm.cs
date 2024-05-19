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
        private DatabaseManager databaseManager;
        System.Data.DataTable dataTable;
        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
        public UsersForm()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();
        }

        private void LoadUserData()
        {
            dataGridView1.DataSource = null;
            string query = "SELECT * FROM users";
            MySqlCommand cmd = new MySqlCommand(query, databaseManager.GetConnection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            dataTable = new System.Data.DataTable();
            dataAdapter.Fill(dataTable);

            DataGridViewComboBoxColumn status = new DataGridViewComboBoxColumn();
            var list = new List<string>() { "Уволен", "Активен" };

            status.DataSource = list;
            status.HeaderText = "Статус";
            status.DataPropertyName = "UserStatus";

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns.AddRange(status);
        }

        void SetStatusEmployee(int id, string fired)
        {
            MySqlCommand cmd = new MySqlCommand($"UPDATE users SET UserStatus='{fired}' WHERE UserID={id};", databaseManager.GetConnection());
            cmd.ExecuteNonQuery();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            SetStatusEmployee(Convert.ToInt32(dataTable.Rows[i]["UserID"]), Convert.ToString(dataTable.Rows[i]["UserStatus"]));
            LoadUserData();
        }

        private void AddUsersButton_Click(object sender, EventArgs e)
        {
            AddusersForm addUsersForm = new AddusersForm();
            addUsersForm.Show();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
