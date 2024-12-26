using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Загрузка формы...");
            LoadUsers();
            LoadPriority();
            LoadStatuses();
        }

        private Dictionary<string, int> userDict = new Dictionary<string, int>();

        private void LoadUsers()
        {
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT user_id, user_name FROM users"; // Получаем ID и имя пользователя
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string userName = reader["user_name"].ToString();
                                int userId = Convert.ToInt32(reader["user_id"]);
                                comboBoxUsers.Items.Add(userName);
                                userDict[userName] = userId; // Сохраняем соответствие имени и ID
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Ошибка базы данных: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.ToString());
                }
            }
        }

        
        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Действия при выборе пользователя
            string selectedUser = comboBoxUsers.SelectedItem.ToString();
            MessageBox.Show("Выбран пользователь: " + selectedUser);

        }

        private void LoadPriority()
        {
            // Подключение к базе данных
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    // SQL-запрос для получения приоритетов
                    string sql = "SELECT DISTINCT priority FROM tasks";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Добавляем приоритеты в ComboBox
                                comboBoxPriority.Items.Add(reader["priority"].ToString());
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Ошибка базы данных: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.ToString());
                }
            }
        }
        private void comboBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Действия при выборе пользователя
            string selectedPriority = comboBoxUsers.SelectedItem.ToString();
            MessageBox.Show("Выбран приоритет: " + selectedPriority);

        }

        private void LoadStatuses()
        {
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    // SQL-запрос для получения уникальных статусов
                    string sql = "SELECT DISTINCT status FROM tasks";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Добавляем статусы в ComboBox
                                comboBoxStatus.Items.Add(reader["status"].ToString());
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Ошибка базы данных: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.ToString());
                }
            }
        }
        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Действия при выборе пользователя
            string selectedStatus = comboBoxStatus.SelectedItem.ToString();
            MessageBox.Show("Выбран приоритет: " + selectedStatus);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string projectName = textBoxName.Text;
            DateTime creationDate = dateTimePicker1.Value;
            string description = textBoxDescription.Text;
            string priority = comboBoxPriority.SelectedItem.ToString();
            string selectedUser = comboBoxUsers.SelectedItem.ToString();
            int assigneeId = userDict[selectedUser]; // Получаем ID выбранного пользователя
            string status = comboBoxStatus.SelectedItem.ToString();

            InsertTask(creationDate, projectName, description, priority, assigneeId, status); // Передаем ID
        }
        private void InsertTask(DateTime creationDate, string projectName, string description, string priority, int assigneeId, string status)
        {
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO tasks (creation_date, project_name, description, priority, assignee, status) VALUES (@creation_date, @project_name, @description, @priority, @assignee, @status)";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@creation_date", creationDate);
                        command.Parameters.AddWithValue("@project_name", projectName);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@priority", priority);
                        command.Parameters.AddWithValue("@assignee", assigneeId);
                        command.Parameters.AddWithValue("@status", status);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Задача успешно добавлена");
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Ошибка базы данных: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.ToString());
                }
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            ViewTasks viewtast = new ViewTasks();
            viewtast.ShowDialog();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
