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
        ConductorService conductorService = new ConductorService();
        Usuario usuario1;
        internal FormBreveteMenu(Usuario usuario)
        {
            InitializeComponent();
            usuario1 = usuario;
            Mostrar(conductorService.MostrarBrevetes(usuario.DNI));
        }
        private void Mostrar(List<Brevete> conductores)
        {
            dataGridViewBrete.DataSource = null;
            if (conductores.Count() == 0)
            {
                return;
            }
            dataGridViewBrete.DataSource = conductores;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBrevete form = new FormBrevete(usuario1);
            form.Show();
            form.FormClosed += (s, args) =>
            {
                Mostrar(conductorService.MostrarBrevetes(usuario1.DNI));
                return;
            };
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mostrar(conductorService.MostrarBrevetes(usuario1.DNI));
        }
    }
}
