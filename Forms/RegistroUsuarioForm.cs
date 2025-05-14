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
    public partial class RegistroUsuarioForm : Form
    {
        public RegistroUsuarioForm()
        {
            InitializeComponent();
            cmbRol.Items.AddRange(new string[] { "Admin", "Usuario" });
            cmbRol.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContraseña.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string rol = cmbRol.SelectedItem.ToString();

            if (usuario == "" || contrasena == "" || nombre == "")
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            try
            {
                using (var conn = Conexion.Conectar())
                {
                    conn.Open();

                    // Verificar si ya existe el usuario
                    var checkCmd = new OleDbCommand("SELECT COUNT(*) FROM Usuarios WHERE Usuario = ?", conn);
                    checkCmd.Parameters.AddWithValue("?", usuario);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("El nombre de usuario ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insertar nuevo usuario
                    var cmd = new OleDbCommand("INSERT INTO Usuarios (Usuario, Contrasena, Nombre, Rol) VALUES (?, ?, ?, ?)", conn);
                    cmd.Parameters.AddWithValue("?", usuario);
                    cmd.Parameters.AddWithValue("?", contrasena);
                    cmd.Parameters.AddWithValue("?", nombre);
                    cmd.Parameters.AddWithValue("?", rol);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario:\n" + ex.Message);
            }
        }
    }
}
