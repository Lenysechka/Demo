namespace WinFormsApp2
{
    partial class ViewTasks
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
            dataGridViewTasks = new DataGridView();
            comboBoxUser = new ComboBox();
            comboBoxStatus = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxPriority = new ComboBox();
            label3 = new Label();
            buttonExit = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTasks
            // 
            dataGridViewTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTasks.Location = new Point(12, 117);
            dataGridViewTasks.Name = "dataGridViewTasks";
            dataGridViewTasks.RowHeadersWidth = 51;
            dataGridViewTasks.Size = new Size(1098, 446);
            dataGridViewTasks.TabIndex = 0;
            // 
            // comboBoxUser
            // 
            comboBoxUser.FormattingEnabled = true;
            comboBoxUser.Location = new Point(138, 61);
            comboBoxUser.Name = "comboBoxUser";
            comboBoxUser.Size = new Size(151, 28);
            comboBoxUser.TabIndex = 1;
            comboBoxUser.SelectedIndexChanged += comboBoxUser_SelectedIndexChanged;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(445, 61);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(176, 28);
            comboBoxStatus.TabIndex = 3;
            comboBoxStatus.SelectedIndexChanged += comboBoxStatus_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 20);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 4;
            label1.Text = "Пользователь";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(484, 20);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 5;
            label2.Text = "Статус задачи";
            // 
            // comboBoxPriority
            // 
            comboBoxPriority.FormattingEnabled = true;
            comboBoxPriority.Location = new Point(803, 62);
            comboBoxPriority.Name = "comboBoxPriority";
            comboBoxPriority.Size = new Size(151, 28);
            comboBoxPriority.TabIndex = 6;
            comboBoxPriority.SelectedIndexChanged += comboBoxPriority_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(828, 20);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 7;
            label3.Text = "Приоритет";
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.Snow;
            buttonExit.Location = new Point(37, 605);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(94, 29);
            buttonExit.TabIndex = 8;
            buttonExit.Text = "Назад";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.Snow;
            buttonDelete.Location = new Point(922, 605);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(188, 29);
            buttonDelete.TabIndex = 9;
            buttonDelete.Text = "Удалить задачу";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // ViewTasks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1142, 656);
            Controls.Add(buttonDelete);
            Controls.Add(buttonExit);
            Controls.Add(label3);
            Controls.Add(comboBoxPriority);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxStatus);
            Controls.Add(comboBoxUser);
            Controls.Add(dataGridViewTasks);
            Name = "ViewTasks";
            Text = "ViewTasks";
            Load += ViewTasks_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTasks;
        private ComboBox comboBoxUser;
        private ComboBox comboBoxStatus;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxPriority;
        private Label label3;
        private Button buttonExit;
        private Button buttonDelete;
    }
}