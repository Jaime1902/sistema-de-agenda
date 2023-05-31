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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;


namespace sistema_de_agenda
{
    public partial class Form1 : Form
    {

        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=db_agenda;";
        bool isSessionActive = false;

        string loginDataFile = "login_data.txt";

        public void login()
        {
            string query = "SELECT id FROM login WHERE username=@username AND password=@password";

            // Preparando la conexión
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = 60;

            // Agregando los parámetros y sus valores
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null) // Se encontró un usuario con las credenciales ingresadas
                {
                    int loginId = Convert.ToInt32(result); // Convertir el resultado a tipo int (login_id)

                    if (!isSessionActive)
                    {
                        string loginData = $"{textBox1.Text}\n{textBox2.Text}";
                        File.WriteAllText(loginDataFile, loginData);
                       
                    }

                    form_p frm2 = new form_p();
                    frm2.LoginIdUsuarioAutenticado = loginId; // Asignar el login_id al formulario form_p
                    frm2.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid credentials!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public Form1()
        {
            InitializeComponent();

            // Verificar si el archivo login_data.txt existe
            if (!File.Exists(loginDataFile))
            {
                // Si no existe, crear el archivo y dejarlo vacío
                File.Create(loginDataFile).Close();
            }
            else
            {
                // Si existe, cargar los datos de inicio de sesión
                string[] loginInfo = File.ReadAllLines(loginDataFile);

                if (loginInfo.Length >= 2)
                {
                    textBox1.Text = loginInfo[0];
                    textBox2.Text = loginInfo[1];
                    
                    isSessionActive = true;
                   

                
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_registrer frm3 = new form_registrer();
            frm3.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (isSessionActive)
            {
                login();
            }
        }
    }
}
