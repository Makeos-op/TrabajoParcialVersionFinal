using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoParcial.Entities;
using TrabajoParcial.Servicies;

namespace TrabajoParcial
{
    public partial class FormRegistrar : Form
    {
        private UsuarioService usuarioService = new UsuarioService();

        public FormRegistrar()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            txtnombres.Clear();
            txtapellidos.Clear();
            txtedad.Clear();
            txtnacionalidad.Clear();
            txtcorreo.Clear();
            txttelefono.Clear();
            txtdni.Clear();
            txtcontrasena.Clear();
            txtconfirmarcontrasena.Clear();
            cmbtipoususario.SelectedIndex = -1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtnombres.Text == "" || txtdni.Text == "" || txtedad.Text == "" || txtapellidos.Text == "" ||
                txtnacionalidad.Text == "" || txttelefono.Text == "" || cmbtipoususario.Text == "" ||
                txtcorreo.Text == "" || txtcontrasena.Text == "" || txtconfirmarcontrasena.Text == "")
            {
                MessageBox.Show("Por favor, completa todos los campos antes de registrar.",
                                "Campos vacíos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (txtcontrasena.Text != txtconfirmarcontrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifica e intenta nuevamente.",
                                "Error de contraseña",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            Usuario usuario = new Usuario
            {
                DNI = int.Parse(txtdni.Text),
                Nombre = txtnombres.Text,
                Apellidos = txtapellidos.Text,
                Edad = int.Parse(txtedad.Text),
                Nacionalidad = txtnacionalidad.Text,
                Correo = txtcorreo.Text,
                Telefono = int.Parse(txttelefono.Text),
                Contraseña = txtcontrasena.Text,
                TipoUsuario = cmbtipoususario.Text,
                Saldo = 0 
            };
            bool registrado = false;
            switch (usuario.TipoUsuario)
            {
                case "Arrendador":
                    Arrendador usuario1 = new Arrendador(usuario);
                    registrado = usuarioService.Registrar(usuario1);
                    break;
                case "Conductor":
                    Conductor usuario2 = new Conductor(usuario);
                    registrado = usuarioService.Registrar(usuario2);
                    break;
            }
            if (registrado)
            {
                MessageBox.Show("Usuario registrado exitosamente.",
                                "Registro exitoso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                LimpiarCampos();
                Close();
            }
            else
            {
                MessageBox.Show("El correo ya existe. Intenta con otro.",
                                "Error de registro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}

