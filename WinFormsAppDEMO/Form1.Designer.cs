﻿namespace WinFormsAppDEMO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            Autorization = new Button();
            SuspendLayout();
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(118, 28);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.Size = new Size(100, 23);
            LoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(118, 66);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(100, 23);
            PasswordTextBox.TabIndex = 1;
            // 
            // Autorization
            // 
            Autorization.Location = new Point(118, 119);
            Autorization.Name = "Autorization";
            Autorization.Size = new Size(110, 23);
            Autorization.TabIndex = 2;
            Autorization.Text = "Авторизоваться";
            Autorization.UseVisualStyleBackColor = true;
            Autorization.Click += Autorization_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 224);
            Controls.Add(Autorization);
            Controls.Add(PasswordTextBox);
            Controls.Add(LoginTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginTextBox;
        private TextBox PasswordTextBox;
        private Button Autorization;
    }
}
