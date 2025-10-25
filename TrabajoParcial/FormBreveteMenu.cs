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
using TrabajoParcial.Repositories;
using TrabajoParcial.Servicies;

namespace TrabajoParcial
{
    public partial class FormBreveteMenu : Form
    {
        UsuarioService usuarioService = new UsuarioService();
        Usuario usuario1;
        ConductorService conductorService = new ConductorService();
        internal FormBreveteMenu(Usuario usuario)
        {
            InitializeComponent();
            usuario1 = usuario;
            Mostrar(conductorService.MostrarBrevetes(usuario.DNI));
        }
        private void Mostrar(List<Brevete> conductores)
        {
            dataGridView1.DataSource = null;
            if (conductores.Count() == 0)
            {
                return;
            }
            dataGridView1.DataSource = conductores;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBrevete form = new FormBrevete(usuario1);
            form.Show();
        }
    }
}
