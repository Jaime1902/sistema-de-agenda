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
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        private void form_detalles_contacto_Load(object sender, EventArgs e)
        {
            CargarDetallesContacto();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
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

        private void button_back_Click(object sender, EventArgs e)
        {
            Hide(); // Ocultar el formulario en lugar de cerrarlo
            Dispose(); // Eliminar el formulario para liberar recursos
        }

        private void button_edit_Click(object sender, EventArgs e)
        {

        }

        private void button_view_Click(object sender, EventArgs e)
        {
            CargarDetallesContacto();
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este contacto?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    connection.Open();

                    // Consulta para eliminar el contacto
                    string query = "DELETE FROM contactos WHERE id = @contactoId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@contactoId", contactoId);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("El contacto ha sido eliminado correctamente.");
                        Hide(); // Ocultar el formulario después de eliminar el contacto
                        Dispose(); // Eliminar el formulario para liberar recursos
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el contacto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el contacto: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}