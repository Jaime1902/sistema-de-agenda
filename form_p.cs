using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace sistema_de_agenda
{
    public partial class form_p : Form
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "db_agenda";
        private string uid = "root";
        private string password = "";

        public int LoginIdUsuarioAutenticado { get; set; } // Propiedad para almacenar el login_id

        private form_detalles_contacto formularioDetallesContacto;


        public form_p()
        {
            InitializeComponent();
            
        }

        private async void form_p_Load(object sender, EventArgs e)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);

            await webView21.EnsureCoreWebView2Async();

            webView21.NavigationCompleted += webView21_NavigationCompleted;
            webView21.CoreWebView2.WebMessageReceived += webView21_WebMessageReceived;

            CargarDatosContactos();
            ObtenerNombreUsuario();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hola
        }

        private void CargarDatosContactos()
        {
            try
            {
                connection.Open();

                // Consulta para obtener los datos de los contactos relacionados con el usuario actual
                string query = "SELECT c.id, c.nombres, c.apellidos, c.numero, c.correo, c.fecha_registro " +
                               "FROM usuarios AS u " +
                               "JOIN contactos AS c ON u.id = c.usuario_id " +
                               "WHERE u.login_id = @loginId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@loginId", LoginIdUsuarioAutenticado); // Obtén el login_id del usuario autenticado
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Ordenar los contactos alfabéticamente por nombre
                var contactosOrdenados = dataTable.AsEnumerable()
                    .OrderBy(row => row.Field<string>("nombres"))
                    .ThenBy(row => row.Field<string>("apellidos"));

                // Generar el código HTML con los datos de los contactos
                string html = @"
        <!DOCTYPE html>
        <html>
        <head>
            <title>Agenda de Contactos</title>
            <style>
                body {
                    font-family: Arial, sans-serif;
                    background-color: #fff;
                    margin: 0;
                    padding: 0;
                }

                .container {
                    max-width: 800px;
                    margin: 20px auto;
                    padding: 20px;
                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    display: flex;
                    flex-direction: column;
                }

                h1 {
                    text-align: center;
                    margin-top: 0;
                }

                .letra {
                    font-size: 12px;
                    font-weight: bold;
                    margin-bottom: 10px;
                }

                .contacto {
                    border-bottom: 1px solid #ddd;
                    padding: 10px;
                    cursor: pointer;
                }

                .contacto:hover {
                    background-color: #f2f2f2;
                }

                .resaltado {
                    font-weight: bold;
                    font-size: 16px;
                }
            </style>
        </head>
        <body>
            <div class='container'>
                <h1>Agenda de Contactos</h1>
                <div class='contactos'>";

                char letraActual = 'A'; // Letra inicial
                foreach (DataRow row in contactosOrdenados)
                {
                    string nombreCompleto = row.Field<string>("nombres") + " " + row.Field<string>("apellidos");
                    string nombreLetra = nombreCompleto.Substring(0, 1).ToUpper(); // Obtener la primera letra del nombre

                    if (nombreLetra != letraActual.ToString())
                    {
                        letraActual = nombreLetra[0];
                        html += $@"
                    <h2 class='letra' id='letra_{letraActual}'>{letraActual}</h2>";
                    }

                    html += $@"
                    <div class='contacto' onclick='MostrarDetallesContacto({row["id"]})'>
                        {nombreCompleto}
                    </div>";
                }

                html += @"
                </div>
            </div>
             <script>
            function MostrarDetallesContacto(contactoId) {
                // Ejecutar código JavaScript para enviar el ID del contacto al código C#
                window.chrome.webview.postMessage('MostrarDetallesContacto:' + contactoId);
            }
        </script>
        </body>
        </html>";

                webView21.NavigateToString(html);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void GenerarFormularioContacto(int contactoId)
        {
            if (formularioDetallesContacto == null || formularioDetallesContacto.IsDisposed)
            {
                formularioDetallesContacto = new form_detalles_contacto(contactoId);
            }

            formularioDetallesContacto.Show();
            formularioDetallesContacto.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ObtenerNombreUsuario()
        {
            try
            {
                connection.Open();

                // Consulta para obtener el nombre de usuario de la tabla login
                string query = "SELECT l.username FROM login AS l " +
                               "JOIN usuarios AS u ON l.id = u.login_id " +
                               "WHERE u.login_id = @loginId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@loginId", LoginIdUsuarioAutenticado); // Obtén el login_id del usuario autenticado en la tabla usuarios
                string nombreUsuario = command.ExecuteScalar()?.ToString();

                if (!string.IsNullOrEmpty(nombreUsuario))
                {
                    label1.Text = nombreUsuario;
                }
                else
                {
                    MessageBox.Show("No se encontró el nombre de usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el nombre de usuario: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            webView21.CoreWebView2.ExecuteScriptAsync(@"
                var container = document.querySelector('.container');
                container.style.margin = 'auto';
                container.style.width = '100%';
            ");
        }

        private void webView21_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {

        }

        private void webView21_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string[] message = e.TryGetWebMessageAsString().Split(':');
            if (message.Length == 2 && message[0] == "MostrarDetallesContacto")
            {
                int contactoId;
                if (int.TryParse(message[1], out contactoId))
                {
                    // Generar el formulario de detalles del contacto
                    GenerarFormularioContacto(contactoId);
                }
            }
        }

        private void webView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webView21.CoreWebView2.WebMessageReceived += webView21_WebMessageReceived;
        }
    }
}
