using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sistema_de_agenda
{
    public partial class form_registrer : Form
    {

        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "db_agenda";
        private string uid = "root";
        private string password = "";

        public form_registrer()
        {
            InitializeComponent();
        }

        private void form_registrer_Load(object sender, EventArgs e)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void text_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_surnames_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string username = text_username.Text;
            string password = text_password.Text;
            string nombres = text_name.Text;
            string apellidos = text_surnames.Text;
            string correo = text_mail.Text;
            string numero = text_number.Text;

            try
            {
                connection.Open();

                // Insertar el usuario en la tabla "login"
                string loginQuery = $"INSERT INTO login (username, password) VALUES (@username, @password)";
                MySqlCommand loginCommand = new MySqlCommand(loginQuery, connection);
                loginCommand.Parameters.AddWithValue("@username", username);
                loginCommand.Parameters.AddWithValue("@password", password);
                loginCommand.ExecuteNonQuery();

                // Obtener el id del usuario recién creado
                int loginId = (int)loginCommand.LastInsertedId;

                // Insertar el usuario en la tabla "usuarios"
                string usuariosQuery = $"INSERT INTO usuarios (login_id, nombres, apellidos, correos, numeros) VALUES (@loginId, @nombres, @apellidos, @correo, @numero)";
                MySqlCommand usuariosCommand = new MySqlCommand(usuariosQuery, connection);
                usuariosCommand.Parameters.AddWithValue("@loginId", loginId);
                usuariosCommand.Parameters.AddWithValue("@nombres", nombres);
                usuariosCommand.Parameters.AddWithValue("@apellidos", apellidos);
                usuariosCommand.Parameters.AddWithValue("@correo", correo);
                usuariosCommand.Parameters.AddWithValue("@numero", numero);
                usuariosCommand.ExecuteNonQuery();

                MessageBox.Show("Usuario guardado correctamente.");

                // Limpiar los campos del formulario
                text_username.Text = "";
                text_password.Text = "";
                text_name.Text = "";
                text_surnames.Text = "";
                text_mail.Text = "";
                text_number.Text = "";

                //Redirigir el usurio al login.

                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();

        }
    }
}
