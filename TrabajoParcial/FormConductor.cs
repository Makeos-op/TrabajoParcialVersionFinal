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
    public partial class FormConductor : Form
    {
        ConductorService conductorService = new ConductorService();
        Usuario usuario1;
        internal FormConductor(Usuario usuario)
        {
            InitializeComponent();
            MostrarAlmacenes(conductorService.MostrarVehiculos(usuario1.DNI));
            usuario1 = usuario;
        }
        private void MostrarAlmacenes(List<Vehiculo> conductores)
        {
            dataGridView1.DataSource = null;
            if (conductores.Count() == 0)
            {
                return;
            }
            dataGridView1.DataSource = conductores;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormVehiculo form = new FormVehiculo();
            form.Show();
            form.FormClosed += (s, args) =>
            {
                MostrarAlmacenes(conductorService.MostrarVehiculos(usuario1.DNI));
                return;
            };
            return;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBreveteMenu form = new FormBreveteMenu(usuario1);
            form.Show();
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReservaConductores form = new FormReservaConductores();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
