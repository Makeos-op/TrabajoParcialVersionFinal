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
    public partial class FormReservaConductores : Form
    {
        VehiculoService vehiculoService=new VehiculoService();
        EspacioService espacioService= new EspacioService();
        ReservaService reservaService = new ReservaService();
        Usuario usuario1;
        internal FormReservaConductores(Usuario usuario)
        {
            InitializeComponent();
            usuario1 = usuario;
            MostrarAlmacenes(espacioService.Mostrar());
        }
        private void MostrarAlmacenes(List<Espacio> conductores)
        {
            dataGridView1.DataSource = null;
            if (conductores.Count() == 0)
            {
                return;
            }
            dataGridView1.DataSource = conductores;
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)//Verifica si hay una fila seleccionada
            {
                MessageBox.Show("Seleccione un espacio para Reservar");
                return;
            }
            int IdEspacio = int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            Vehiculo vehiculo = vehiculoService.BuscarDueño(usuario1.DNI);
            Espacio espacio = espacioService.Buscar(IdEspacio);
            Reserva reserva = new Reserva(vehiculo, espacio);
            if (reservaService.Registro(reserva))
            {
                MessageBox.Show("Ha sido registrado con exito");
                this.Close();
            }
            MessageBox.Show("No se pudo registrar");
            return;
        }
    }
}
