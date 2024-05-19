using MySql.Data.MySqlClient;

namespace WinFormsAppDEMO
{
    public partial class Form1 : Form
    {
        // ������� ������ ��� ���������� ������������ � ���� ������
        private DatabaseManager dbManager;

        // ����������� �����, ���������� ��� �������� ���������� ������ Form1
        public Form1()
        {
            InitializeComponent();
            // �������������� ������ dbManager ��� ������ � ����� ������
            dbManager = new DatabaseManager();
        }

        // ���������� ������� ������� ������ "����"
        private void Autorization_Click(object sender, EventArgs e)
        {
            // �������� �������� ������ � ������ �� ��������� �����
            string username = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            // �������� ������ ����������� � ���� ������
            MySqlConnection connection = dbManager.GetConnection();

            // ��������� SQL-������ ��� �������� ������������� ������������ � �������� ������� � �������
            string query = "SELECT UserType FROM Users WHERE Username = @username AND Password = @password";

            // ������� ������ ������� ��� ���������� SQL-�������
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username); // ��������� �������� ��� ������
            cmd.Parameters.AddWithValue("@password", password); // ��������� �������� ��� ������

            // ��������� SQL-������ � �������� ��� ������������
            object userType = cmd.ExecuteScalar();

            // ���������, ��� �� ������ ������������ � �������� ������� � �������
            if (userType != null)
            {
                // ���� ������������ ������, ��������� ������� �����, ��������� �� ��� ������������
                MainForm mainForm = new MainForm(userType.ToString());
                this.Hide(); // �������� ������� �����
                mainForm.Show(); // ���������� ������� �����
            }
            else
            {
                // ���� ������������ �� ������, ������� ��������� �� ������
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
