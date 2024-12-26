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
    public partial class ViewTasks : Form
    {
        private string? priority;

        public ViewTasks()
        {
            InitializeComponent();
        }

        private void ViewTasks_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Загрузка формы...");
            LoadUsers();
            LoadStatus();
            LoadPriority();
            LoadTasks(null, null, null); // Загрузка данных из таблицы tasks
        }
        private void LoadStatus()
        {
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT DISTINCT status FROM tasks"; // Используем DISTINCT для получения уникальных значений
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            HashSet<string> uniqueStatuses = new HashSet<string>(); // Создаем HashSet для уникальных статусов

                            while (reader.Read())
                            {
                                // Добавляем статусы в HashSet
                                uniqueStatuses.Add(reader["status"].ToString());
                            }

                            // Добавляем уникальные статусы в ComboBox
                            foreach (var status in uniqueStatuses)
                            {
                                comboBoxStatus.Items.Add(status);
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


        private void LoadPriority()
        {
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT DISTINCT priority FROM tasks ORDER BY priority"; // Используем DISTINCT и сортировку
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            HashSet<string> uniquePriorities = new HashSet<string>(); // Создаем HashSet для уникальных приоритетов

                            while (reader.Read())
                            {
                                // Добавляем приоритеты в HashSet
                                uniquePriorities.Add(reader["priority"].ToString());
                            }

                            // Сортируем уникальные приоритеты и добавляем в ComboBox
                            foreach (var priority in uniquePriorities.OrderBy(p => p))
                            {
                                comboBoxPriority.Items.Add(priority);
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

        private void LoadUsers()
        {
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    // Измените SQL-запрос для получения имен пользователей по их ID, добавив сортировку по user_id
                    string sql = "SELECT u.user_id, u.user_name FROM users u ORDER BY u.user_id"; // Сортировка по user_id
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            comboBoxUser.Items.Clear(); // Очищаем ComboBox перед заполнением
                            while (reader.Read())
                            {
                                // Добавляем имена пользователей в ComboBox
                                comboBoxUser.Items.Add(new { Id = reader["user_id"], Name = reader["user_name"] });
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
        private void LoadTasks(int? assigneeId, string status, string? selectedPriority)
        {
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    StringBuilder sql = new StringBuilder("SELECT * FROM tasks WHERE 1=1");

                    if (assigneeId > 0) // Проверяем, что ID пользователя валиден
                    {
                        sql.Append(" AND assignee = @assignee");
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        sql.Append(" AND status = @status");
                    }
                    if (!string.IsNullOrEmpty(selectedPriority))
                    {
                        sql.Append(" AND priority = @priority");
                    }

                    sql.Append(" ORDER BY assignee, priority"); // Сортировка по ID пользователя и приоритету

                    using (NpgsqlCommand command = new NpgsqlCommand(sql.ToString(), connection))
                    {
                        if (assigneeId > 0)
                        {
                            command.Parameters.AddWithValue("@assignee", assigneeId);
                        }
                        if (!string.IsNullOrEmpty(status))
                        {
                            command.Parameters.AddWithValue("@status", status);
                        }
                        if (!string.IsNullOrEmpty(selectedPriority))
                        {
                            command.Parameters.AddWithValue("@priority", selectedPriority);
                        }

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridViewTasks.DataSource = dataTable;
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



        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранного пользователя
            var selectedUser = comboBoxUser.SelectedItem as dynamic;
            if (selectedUser != null)
            {
                int userId = selectedUser.Id; // Получаем ID пользователя
                string userName = selectedUser.Name; // Получаем имя пользователя
                MessageBox.Show("Выбран пользователь: " + userName + " (ID: " + userId + ")");

                // Загружаем задачи для выбранного пользователя
                LoadTasks(userId, comboBoxStatus.SelectedItem?.ToString(), comboBoxPriority.SelectedItem?.ToString());
            }
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Действия при выборе статуса
            var selectedUser = comboBoxUser.SelectedItem as dynamic;
            int userId = selectedUser != null ? selectedUser.Id : 0; // Получаем ID пользователя или 0, если не выбран
            string selectedStatus = comboBoxStatus.SelectedItem?.ToString();

            // Загружаем задачи для выбранного пользователя и статуса
            LoadTasks(userId, selectedStatus, comboBoxPriority.SelectedItem?.ToString());
        }

        private void comboBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Действия при выборе приоритета
            var selectedUser = comboBoxUser.SelectedItem as dynamic;
            int userId = selectedUser != null ? selectedUser.Id : 0; // Получаем ID пользователя или 0, если не выбран
            string selectedStatus = comboBoxStatus.SelectedItem?.ToString();
            string selectedPriority = comboBoxPriority.SelectedItem?.ToString();

            // Загружаем задачи для выбранного пользователя, статуса и приоритета
            LoadTasks(userId, selectedStatus, selectedPriority);
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли задача в DataGridView
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                // Получаем идентификатор выбранной задачи (предполагается, что у вас есть столбец с ID)
                int task_id = Convert.ToInt32(dataGridViewTasks.SelectedRows[0].Cells["task_id"].Value);

                // Подтверждение удаления
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить эту задачу?", "Подтверждение удаления", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteTask(task_id);
                    LoadTasks(null, null, null); // Обновляем список задач после удаления
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления.");
            }
        }

        private void DeleteTask(int task_id)
        {
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    string sql = "DELETE FROM tasks WHERE id = @task_id"; // Замените 'id' на имя вашего столбца с идентификатором
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@task_id", task_id);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Задача успешно удалена.");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка: Задача не найдена.");
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
    }

}
