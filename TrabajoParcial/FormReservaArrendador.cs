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
    public partial class FormReservaArrendador : Form
    {
        private ArrendadorService arrendadorService = new ArrendadorService();
        private EspacioService espacioService = new EspacioService();
        private Usuario usuario_registro = new Usuario();
        internal FormReservaArrendador(Usuario usuario)
        {
            InitializeComponent();
            usuario_registro = usuario;
            MostrarReservas(arrendadorService.BuscarReservasArrendador(usuario_registro.DNI));
        }
        private void MostrarReservas(List<Reserva> reservas)
        {
            dataGridView1.DataSource = null;
            if (reservas.Count() == 0)
            {
                return;
            }
            dataGridView1.DataSource = reservas;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
