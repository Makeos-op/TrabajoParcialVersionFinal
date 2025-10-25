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
    public partial class FormLogin : Form
    {
        private UsuarioService usuarioService = new UsuarioService();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            txtususario.Clear();
            txtcontrasenalogin.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnregistrarse_Click(object sender, EventArgs e)
        {
            FormRegistrar form = new FormRegistrar();
            form.Show();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            string correoIngresado;

            try
            {
                correoIngresado = txtususario.Text;
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del correo es inválido. Por favor, verifica e intenta nuevamente.",
                                "Error de formato",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (usuarioService.ExisteCorreo(correoIngresado))
            {
                Usuario usuario = usuarioService.CorreoEncontrado(correoIngresado);

                if (usuario.Contraseña != txtcontrasenalogin.Text)
                {
                    MessageBox.Show("Contraseña incorrecta. Por favor, verifica e intenta nuevamente.",
                                    "Error de contraseña",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("¡Inicio de sesión exitoso!",
                                    "Bienvenido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    LimpiarCampos();

                    if (usuario.TipoUsuario == "Conductor")
                    {
                        FormConductor formConductor = new FormConductor();
                        formConductor.Show();
                        this.Hide(); 
                    }
                    else if (usuario.TipoUsuario == "Arrendador")
                    {
                        FormArrendador formArrendador = new FormArrendador();
                        formArrendador.Show();
                        this.Hide(); 
                    }
                    else
                    {
                        MessageBox.Show("Tipo de usuario no válido.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", 
                                "Error al iniciar sesión", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
