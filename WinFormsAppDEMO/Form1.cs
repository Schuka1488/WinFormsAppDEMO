using MySql.Data.MySqlClient;

namespace WinFormsAppDEMO
{
    public partial class Form1 : Form
    {
        // Создаем объект для управления подключением к базе данных
        private DatabaseManager dbManager;

        // Конструктор формы, вызывается при создании экземпляра класса Form1
        public Form1()
        {
            InitializeComponent();
            // Инициализируем объект dbManager для работы с базой данных
            dbManager = new DatabaseManager();
        }

        // Обработчик события нажатия кнопки "Вход"
        private void Autorization_Click(object sender, EventArgs e)
        {
            // Получаем значения логина и пароля из текстовых полей
            string username = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            // Получаем объект подключения к базе данных
            MySqlConnection connection = dbManager.GetConnection();

            // Формируем SQL-запрос для проверки существования пользователя с заданным логином и паролем
            string query = "SELECT UserType FROM Users WHERE Username = @username AND Password = @password";

            // Создаем объект команды для выполнения SQL-запроса
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username); // Добавляем параметр для логина
            cmd.Parameters.AddWithValue("@password", password); // Добавляем параметр для пароля

            // Выполняем SQL-запрос и получаем тип пользователя
            object userType = cmd.ExecuteScalar();

            // Проверяем, был ли найден пользователь с заданным логином и паролем
            if (userType != null)
            {
                // Если пользователь найден, открываем главную форму, передавая ей тип пользователя
                MainForm mainForm = new MainForm(userType.ToString());
                this.Hide(); // Скрываем текущую форму
                mainForm.Show(); // Отображаем главную форму
            }
            else
            {
                // Если пользователь не найден, выводим сообщение об ошибке
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
