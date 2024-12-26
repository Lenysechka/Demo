
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Npgsql;


namespace WinFormsApp2
{

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.");
                return;
            }
            string connstring = "Server=localhost;Port=5432;Database=Demo_2;UserId=postgres;Password=Ktyf2005;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connstring))
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT COUNT(*) FROM users WHERE user_name = @login AND user_pass = @password";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        // Assuming you have text boxes named textBoxLogin and textBoxPassword
                        command.Parameters.AddWithValue("@login", textBoxLogin.Text);
                        command.Parameters.AddWithValue("@password", textBoxPassword.Text);

                        int userCount = Convert.ToInt32(command.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("Вы авторизовались.");
                            Form2 form = new Form2();
                            form.ShowDialog();
                            this.Hide();

                            // Proceed to the next form or functionality
                        }
                        else
                        {
                            MessageBox.Show("Неверный Логин или Пароль");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }
    }
}
