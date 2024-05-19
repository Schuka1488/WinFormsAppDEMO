namespace WinFormsAppDEMO
{
    partial class OrdersForm
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
            AddOrdersButton = new Button();
            dataGridView1 = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            TableNumberTextBox = new TextBox();
            CustomerCountTextBox = new TextBox();
            StatusComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            WaiterIDComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // AddOrdersButton
            // 
            AddOrdersButton.Location = new Point(12, 12);
            AddOrdersButton.Name = "AddOrdersButton";
            AddOrdersButton.Size = new Size(990, 81);
            AddOrdersButton.TabIndex = 0;
            AddOrdersButton.Text = "Добавить заказ";
            AddOrdersButton.UseVisualStyleBackColor = true;
            AddOrdersButton.Click += AddOrdersButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 255);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(990, 330);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(31, 124);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // TableNumberTextBox
            // 
            TableNumberTextBox.Location = new Point(286, 130);
            TableNumberTextBox.Name = "TableNumberTextBox";
            TableNumberTextBox.Size = new Size(100, 23);
            TableNumberTextBox.TabIndex = 3;
            // 
            // CustomerCountTextBox
            // 
            CustomerCountTextBox.Location = new Point(429, 130);
            CustomerCountTextBox.Name = "CustomerCountTextBox";
            CustomerCountTextBox.Size = new Size(100, 23);
            CustomerCountTextBox.TabIndex = 4;
            // 
            // StatusComboBox
            // 
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(757, 130);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(121, 23);
            StatusComboBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 186);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 7;
            label1.Text = "Дата и время заказа";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(286, 186);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 8;
            label2.Text = "Номер столика";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(429, 186);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 9;
            label3.Text = "Количетсво персон";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(585, 186);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 10;
            label4.Text = "ID официанта";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(757, 186);
            label5.Name = "label5";
            label5.Size = new Size(80, 15);
            label5.TabIndex = 11;
            label5.Text = "Статус заказа";
            // 
            // WaiterIDComboBox
            // 
            WaiterIDComboBox.FormattingEnabled = true;
            WaiterIDComboBox.Location = new Point(585, 130);
            WaiterIDComboBox.Name = "WaiterIDComboBox";
            WaiterIDComboBox.Size = new Size(121, 23);
            WaiterIDComboBox.TabIndex = 12;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 597);
            Controls.Add(WaiterIDComboBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(StatusComboBox);
            Controls.Add(CustomerCountTextBox);
            Controls.Add(TableNumberTextBox);
            Controls.Add(dateTimePicker1);
            Controls.Add(dataGridView1);
            Controls.Add(AddOrdersButton);
            Name = "OrdersForm";
            Text = "OrdersForm";
            Load += OrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddOrdersButton;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private TextBox TableNumberTextBox;
        private TextBox CustomerCountTextBox;
        private ComboBox StatusComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox WaiterIDComboBox;
    }
}