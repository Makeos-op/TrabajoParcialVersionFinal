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
    public partial class FormEspacio : Form
    {
        ArrendadorService arrendadorService = new ArrendadorService();
        EspacioService espacioService = new EspacioService();
        private Usuario usuario_registro = new Usuario();
        internal FormEspacio(Usuario usuario)
        {
            InitializeComponent();
            usuario_registro = usuario;
            MostrarAlmacenes(arrendadorService.MostrarEspacios(usuario.DNI));
        }
        private void MostrarAlmacenes(List<Espacio> espacio)
        {
            dgEspacio.DataSource = null;
            if (espacio.Count() == 0)
            {
                return;
            }
            dgEspacio.DataSource = espacio;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int id;
            double Tarifa;
            string Ubicacion;
            string Area;

            try
            {
                int.TryParse(tbId.Text, out id);
                double.TryParse(tbTarifaxHora.Text, out Tarifa);
                Ubicacion = tbUbicacion.Text;
                Area = tbArea.Text;
                Espacio espacio = new Espacio();
                {
                    espacio.Id = id;
                    espacio.Area = Area;
                    espacio.TarifaHora = Tarifa;
                    espacio.Ubicacion = Ubicacion;
                    espacio.DniArrendador = usuario_registro.DNI;
                }
                espacioService.Registro(usuario_registro.DNI, espacio);
            }
            catch(FormatException)
            {
                MessageBox.Show("El formato del Espacio no es correcto. Por favor, verifica e intenta nuevamente.",
                                "Error de formato",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
