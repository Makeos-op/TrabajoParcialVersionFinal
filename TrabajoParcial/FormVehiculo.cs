using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoParcial.Entities;
using TrabajoParcial.Servicies;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrabajoParcial
{
    public partial class FormVehiculo : Form
    {
        private VehiculoService vehiculoService = new VehiculoService();
        Usuario usuario1;
        internal FormVehiculo(Usuario usuario)
        {
            InitializeComponent();
            usuario1 = usuario;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (tbMatricula.Text == "" || tbModelo.Text == "" || tbMarca.Text == "" || tbColor.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.",
                                "Campos Vacíos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            Vehiculo vehiculo = new Vehiculo();
            {
                vehiculo.Matricula = tbMatricula.Text;
                vehiculo.Marca = tbMarca.Text;
                vehiculo.Color = tbColor.Text;
                vehiculo.Modelo = tbModelo.Text;
                vehiculo.dniConductor = usuario1.DNI;
                vehiculo.LicenciaNecesaria = comboBox1.Text;
            }
            bool registro = vehiculoService.Registro(vehiculo.dniConductor, vehiculo);
            if (registro)
            {
                MessageBox.Show("La matrícula ingresada Registrada en el sistema.",
                                "Registro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return; 
            }
        }
            private void btnSalir_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    }
}
