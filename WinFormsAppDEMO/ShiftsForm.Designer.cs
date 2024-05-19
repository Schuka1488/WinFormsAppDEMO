namespace WinFormsAppDEMO
{
    partial class ShiftsForm
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
            AddShiftsButton = new Button();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            DescriptionTextBox = new TextBox();
            ShiftsButtonRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 202);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(817, 347);
            dataGridView1.TabIndex = 0;
            // 
            // AddShiftsButton
            // 
            AddShiftsButton.Location = new Point(22, 15);
            AddShiftsButton.Name = "AddShiftsButton";
            AddShiftsButton.Size = new Size(817, 68);
            AddShiftsButton.TabIndex = 1;
            AddShiftsButton.Text = "Добавить смену";
            AddShiftsButton.UseVisualStyleBackColor = true;
            AddShiftsButton.Click += AddShiftsButton_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(22, 111);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 115);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 3;
            label1.Text = "Дата смены";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 162);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 4;
            label2.Text = "Описание смены";
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(22, 158);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(200, 23);
            DescriptionTextBox.TabIndex = 5;
            // ShiftsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 561);
            Controls.Add(ShiftsButtonRefresh);
            Controls.Add(DescriptionTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(AddShiftsButton);
            Controls.Add(dataGridView1);
            Name = "ShiftsForm";
            Text = "ShiftsForm";
            Load += ShiftsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddShiftsButton;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private TextBox DescriptionTextBox;
        private Button ShiftsButtonRefresh;
    }
}