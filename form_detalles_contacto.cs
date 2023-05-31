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
    public partial class form_detalles_contacto : Form
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "db_agenda";
        private string uid = "root";
        private string password = "";

        private int contactoId;

        public form_detalles_contacto(int contactoId)
        {
            InitializeComponent();
            this.contactoId = contactoId;

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        private void form_detalles_contacto_Load(object sender, EventArgs e)
        {
            CargarDetallesContacto();
        }

        private void CargarDetallesContacto()
        {
            try
            {
                connection.Open();

                // Consulta para obtener los detalles del contacto
                string query = "SELECT * FROM contactos WHERE id = @contactoId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@contactoId", contactoId);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Obtener los valores de las columnas
                    string nombres = reader.GetString("nombres");
                    string apellidos = reader.GetString("apellidos");
                    string numero = reader.GetString("numero");
                    string correo = reader.GetString("correo");
                    DateTime fechaRegistro = reader.GetDateTime("fecha_registro");

                    // Mostrar los detalles en los controles del formulario
                    label_name.Text = $"{nombres} {apellidos}";
                    label_numberphone.Text = numero;
                    label_email.Text = correo;
                    label_date.Text = fechaRegistro.ToString("dd/MM/yyyy");
                }
                else
                {
                    MessageBox.Show("No se encontró el contacto.");
                    Close();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles del contacto: " + ex.Message);
                Close();
            }
            finally
            {
                connection.Close();
            }
        }

        private void label_date_Click(object sender, EventArgs e)
        {

        }

        private void label_email_Click(object sender, EventArgs e)
        {

        }

        private void label_numberphone_Click(object sender, EventArgs e)
        {

        }

        private void label_name_Click(object sender, EventArgs e)
        {

        }
    }
}
