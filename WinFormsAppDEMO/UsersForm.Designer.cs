namespace WinFormsAppDEMO
{
    partial class UsersForm
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
            dataGridView1 = new DataGridView();
            AddUsersButton = new Button();
            RefreshButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 252);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // AddUsersButton
            // 
            AddUsersButton.Location = new Point(14, 278);
            AddUsersButton.Name = "AddUsersButton";
            AddUsersButton.Size = new Size(774, 61);
            AddUsersButton.TabIndex = 1;
            AddUsersButton.Text = "Добавить пользователя";
            AddUsersButton.UseVisualStyleBackColor = true;
            AddUsersButton.Click += AddUsersButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 345);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(774, 61);
            RefreshButton.TabIndex = 2;
            RefreshButton.Text = "Обновить данные";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RefreshButton);
            Controls.Add(AddUsersButton);
            Controls.Add(dataGridView1);
            Name = "UsersForm";
            Text = "UsersForm";
            Load += UsersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddUsersButton;
        private Button RefreshButton;
    }
}