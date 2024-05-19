namespace WinFormsAppDEMO
{
    partial class AddusersForm
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
            AddTextBoxLogin = new TextBox();
            AddTextBoxPassword = new TextBox();
            AddComboBoxType = new ComboBox();
            AddComboBoxStatus = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // AddTextBoxLogin
            // 
            AddTextBoxLogin.Location = new Point(12, 21);
            AddTextBoxLogin.Name = "AddTextBoxLogin";
            AddTextBoxLogin.Size = new Size(121, 23);
            AddTextBoxLogin.TabIndex = 0;
            // 
            // AddTextBoxPassword
            // 
            AddTextBoxPassword.Location = new Point(12, 89);
            AddTextBoxPassword.Name = "AddTextBoxPassword";
            AddTextBoxPassword.Size = new Size(121, 23);
            AddTextBoxPassword.TabIndex = 1;
            // 
            // AddComboBoxType
            // 
            AddComboBoxType.FormattingEnabled = true;
            AddComboBoxType.Location = new Point(12, 154);
            AddComboBoxType.Name = "AddComboBoxType";
            AddComboBoxType.Size = new Size(121, 23);
            AddComboBoxType.TabIndex = 2;
            // 
            // AddComboBoxStatus
            // 
            AddComboBoxStatus.FormattingEnabled = true;
            AddComboBoxStatus.Location = new Point(12, 225);
            AddComboBoxStatus.Name = "AddComboBoxStatus";
            AddComboBoxStatus.Size = new Size(121, 23);
            AddComboBoxStatus.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(154, 24);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 4;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(154, 97);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 5;
            label2.Text = "Пароль";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(154, 162);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 6;
            label3.Text = "Роль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(154, 233);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 7;
            label4.Text = "Статус";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(25, 296);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(108, 23);
            buttonAdd.TabIndex = 8;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // AddusersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(219, 353);
            Controls.Add(buttonAdd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AddComboBoxStatus);
            Controls.Add(AddComboBoxType);
            Controls.Add(AddTextBoxPassword);
            Controls.Add(AddTextBoxLogin);
            Name = "AddusersForm";
            Text = "AddusersForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox AddTextBoxLogin;
        private TextBox AddTextBoxPassword;
        private ComboBox AddComboBoxType;
        private ComboBox AddComboBoxStatus;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonAdd;
    }
}