using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Fury_Software.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtContraseña.Text.Trim();

            if (usuario == "" || clave == "")
            {
                MessageBox.Show("Ingrese usuario y contraseña.");
                return;
            }

            try
            {
                using (var conn = Conexion.Conectar())
                {
                    conn.Open();
                    string query = "SELECT * FROM Usuarios WHERE Usuario = ? AND Contrasena = ?";
                    var cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", usuario);
                    cmd.Parameters.AddWithValue("?", clave);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string nombre = reader["Nombre"].ToString();
                        string rol = reader["Rol"].ToString();

                        MessageBox.Show($"Bienvenido, {nombre}", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir formulario principal
                        MainForm main = new MainForm(usuario, clave);
                        this.Hide();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroUsuarioForm regForm = new RegistroUsuarioForm();
            regForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
