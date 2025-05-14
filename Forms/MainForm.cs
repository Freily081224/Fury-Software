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
    public partial class MainForm : Form
    {
        private string usuarioLogueado;
        private string rolUsuario;
        public MainForm(string usuario, string rol)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
            rolUsuario = rol;
            lblBienvenido.Text = $"Bienvenido: {usuarioLogueado} ({rolUsuario})";
        }

        
    }
}
