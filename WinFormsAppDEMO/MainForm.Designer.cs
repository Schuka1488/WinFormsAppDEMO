namespace WinFormsAppDEMO
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OrdersButton = new Button();
            UsersButton = new Button();
            ShiftsButton = new Button();
            LogoutButton = new Button();
            SuspendLayout();
            // 
            // OrdersButton
            // 
            OrdersButton.Location = new Point(12, 64);
            OrdersButton.Name = "OrdersButton";
            OrdersButton.Size = new Size(133, 86);
            OrdersButton.TabIndex = 0;
            OrdersButton.Text = "Заказы";
            OrdersButton.UseVisualStyleBackColor = true;
            OrdersButton.Click += OrdersButton_Click;
            // 
            // UsersButton
            // 
            UsersButton.Location = new Point(151, 64);
            UsersButton.Name = "UsersButton";
            UsersButton.Size = new Size(133, 86);
            UsersButton.TabIndex = 1;
            UsersButton.Text = "Управление пользователями";
            UsersButton.UseVisualStyleBackColor = true;
            UsersButton.Click += UsersButton_Click;
            // 
            // ShiftsButton
            // 
            ShiftsButton.Location = new Point(290, 64);
            ShiftsButton.Name = "ShiftsButton";
            ShiftsButton.Size = new Size(133, 86);
            ShiftsButton.TabIndex = 2;
            ShiftsButton.Text = "Смены";
            ShiftsButton.UseVisualStyleBackColor = true;
            ShiftsButton.Click += ShiftsButton_Click;
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(429, 64);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(133, 86);
            LogoutButton.TabIndex = 3;
            LogoutButton.Text = "Выход из учетной записи";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 256);
            Controls.Add(LogoutButton);
            Controls.Add(ShiftsButton);
            Controls.Add(UsersButton);
            Controls.Add(OrdersButton);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button OrdersButton;
        private Button UsersButton;
        private Button ShiftsButton;
        private Button LogoutButton;
    }
}