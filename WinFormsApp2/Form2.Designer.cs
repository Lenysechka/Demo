namespace WinFormsApp2
{
    partial class Form2
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
            label1 = new Label();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button1 = new Button();
            comboBoxUsers = new ComboBox();
            comboBoxStatus = new ComboBox();
            comboBoxPriority = new ComboBox();
            buttonView = new Button();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(171, 41);
            label1.Name = "label1";
            label1.Size = new Size(280, 38);
            label1.TabIndex = 0;
            label1.Text = "Задачи предприятия";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(250, 165);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(201, 27);
            textBoxName.TabIndex = 2;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(250, 215);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(201, 27);
            textBoxDescription.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 168);
            label2.Name = "label2";
            label2.Size = new Size(176, 20);
            label2.TabIndex = 7;
            label2.Text = "Наименование проекта";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 328);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 8;
            label3.Text = "Пользователь";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 270);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 9;
            label4.Text = "Приоритет";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 218);
            label5.Name = "label5";
            label5.Size = new Size(131, 20);
            label5.TabIndex = 10;
            label5.Text = "Описание задачи";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(54, 120);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 11;
            label6.Text = "Дата";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(54, 376);
            label7.Name = "label7";
            label7.Size = new Size(104, 20);
            label7.TabIndex = 12;
            label7.Text = "Статус задачи";
            // 
            // button1
            // 
            button1.BackColor = Color.Snow;
            button1.Location = new Point(311, 477);
            button1.Name = "button1";
            button1.Size = new Size(140, 58);
            button1.TabIndex = 13;
            button1.Text = "Внести задачу";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(250, 328);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(201, 28);
            comboBoxUsers.TabIndex = 14;
            comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(250, 376);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(201, 28);
            comboBoxStatus.TabIndex = 15;
            // 
            // comboBoxPriority
            // 
            comboBoxPriority.FormattingEnabled = true;
            comboBoxPriority.Location = new Point(250, 270);
            comboBoxPriority.Name = "comboBoxPriority";
            comboBoxPriority.Size = new Size(201, 28);
            comboBoxPriority.TabIndex = 16;
            // 
            // buttonView
            // 
            buttonView.BackColor = Color.Snow;
            buttonView.Cursor = Cursors.SizeAll;
            buttonView.Location = new Point(54, 477);
            buttonView.Name = "buttonView";
            buttonView.Size = new Size(143, 58);
            buttonView.TabIndex = 17;
            buttonView.Text = "Просмотр всех задач";
            buttonView.UseVisualStyleBackColor = false;
            buttonView.Click += buttonView_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(250, 113);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(201, 27);
            dateTimePicker1.TabIndex = 18;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(554, 621);
            Controls.Add(dateTimePicker1);
            Controls.Add(buttonView);
            Controls.Add(comboBoxPriority);
            Controls.Add(comboBoxStatus);
            Controls.Add(comboBoxUsers);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button1;
        private ComboBox comboBoxUsers;
        private ComboBox comboBoxStatus;
        private ComboBox comboBoxPriority;
        private Button buttonView;
        private DateTimePicker dateTimePicker1;
    }
}