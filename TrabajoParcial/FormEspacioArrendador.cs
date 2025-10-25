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
using static System.Windows.Forms.MonthCalendar;

namespace TrabajoParcial
{
    public partial class FormEspacioArrendador : Form
    {
        ArrendadorRepository arrendadorRepository = new ArrendadorRepository();
        Usuario usuario1;
        internal FormEspacioArrendador(Usuario usuario)
        {
            InitializeComponent();
            usuario1 = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idText = txtidespacioalquilar.Text.Trim();
            string tarifaText = txttarifaporhora.Text.Trim();
            string ubicacion = txtubicacionalquilar.Text.Trim();
            string areaText = txtareaalquilar.Text.Trim();

            if (string.IsNullOrWhiteSpace(idText) ||
                string.IsNullOrWhiteSpace(tarifaText) ||
                string.IsNullOrWhiteSpace(ubicacion) ||
                string.IsNullOrWhiteSpace(areaText))
            {
                MessageBox.Show("Por favor complete todos los campos antes de registrar.",
                                "Campos vacíos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int id;
            double tarifa;

            if (!int.TryParse(idText, out id))
            {
                MessageBox.Show("El ID debe ser un número entero válido.",
                                "Error de formato",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(tarifaText, out tarifa))
            {
                MessageBox.Show("La tarifa debe ser un número válido (use solo dígitos o coma decimal).",
                                "Error de formato",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (tarifa <= 0)
            {
                MessageBox.Show("La tarifa por hora debe ser mayor a 0.",
                                "Valor inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            Espacio espacio= new Espacio();
            {
                espacio.DniArrendador = id;
                espacio.TarifaHora = tarifa;
                espacio.Area = areaText;
                espacio.Ubicacion = ubicacion;
                espacio.Id = id;
            }
            bool registrar = arrendadorRepository.RegistrarEspacios(espacio.Id,espacio);
            if (registrar)
            {
                MessageBox.Show("Espacio registrado correctamente",
                "Registro exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Espacio ya ha sido registrado",
                "Duplicado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

        }
    }
}
