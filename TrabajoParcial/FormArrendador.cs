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
    public partial class FormArrendador : Form
    {
        ArrendadorService arrendadorService= new ArrendadorService();

        private Usuario usuario_registro = new Usuario();
        internal FormArrendador(Usuario usuario)
        {
            InitializeComponent();
            usuario_registro = usuario;
            var arrendador = arrendadorService.Buscar(usuario.DNI);
            MostrarAlmacenes(arrendador.Espacios);
        }
        private void MostrarAlmacenes(List<Espacio> espacio)
        {
            dataGridView1.DataSource = null;
            if (espacio.Count() == 0)
            {
                return;
            }
            dataGridView1.DataSource = espacio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEspacio form = new FormEspacio(usuario_registro);
            form.Show();
            form.FormClosed += (s, args) =>
            {
                MostrarAlmacenes(arrendadorService.MostrarEspacios(usuario_registro.DNI));
                return;
            };
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReservaArrendador form = new FormReservaArrendador(usuario_registro);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form loginForm = Application.OpenForms.OfType<FormLogin>().FirstOrDefault();
            if (loginForm != null)
            {
                loginForm.Show();
            }
            this.Close();
        }
    }
}
