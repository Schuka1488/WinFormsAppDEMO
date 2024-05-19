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
    public partial class MainForm : Form
    {
        public MainForm(string userType)
        {
            InitializeComponent();

            // Проверяем, является ли тип пользователя не администратором
            if (userType != "Administrator")
            {
                // Если тип пользователя не является администратором, скрываем кнопки для доступа к пользователям и сменам
                UsersButton.Visible = false; // Скрываем кнопку доступа к пользователям
                ShiftsButton.Visible = false; // Скрываем кнопку доступа к сменам
            }
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            // Открываем форму OrdersForm
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.Show();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            // Открываем форму UsersForm
            UsersForm usersForm = new UsersForm();
            usersForm.Show();
        }

        private void ShiftsButton_Click(object sender, EventArgs e)
        {
            // Открываем форму ShiftsForm
            ShiftsForm shiftsForm = new ShiftsForm();
            shiftsForm.Show();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            // Отображаем форму Form1
            Form1 loginForm = new Form1();
            loginForm.Show();

            // Закрываем текущую форму MainForm
            this.Close();
        }
    }
}
