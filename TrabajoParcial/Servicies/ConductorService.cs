using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoParcial.Entities;
using TrabajoParcial.Repositories;

namespace TrabajoParcial.Servicies
{
    internal class ConductorService
    {
        private ConductorRepository conductorRepository = new ConductorRepository();

        public List<Conductor> MostrarConductores()
        {
            return conductorRepository.MostrarConductores();
        }
        public Conductor BuscarConductores(int DNI)
        {
            return conductorRepository.Buscar(DNI);
        }
        public bool Registro(Conductor conductor)
        {
            return conductorRepository.Registro(conductor);
        }
        public List<Vehiculo> MostrarVehiculos(int id)
        {
            return conductorRepository.MostrarVehiculos(id);    
        }
        public List<Brevete> MostrarBrevetes(int id)
        {
            return conductorRepository.MostrarBrevetes(id);
        }
        public Conductor Buscar(int DNI)
        {
           return conductorRepository.Buscar(DNI);
        }
        public List<Reserva> MostrarReservas(int id)
        {
            return conductorRepository.MostrarReservas(id);
        }
        public bool RegistroBrevete(int DNI, Brevete brevete)
        {
            return conductorRepository.RegistroBrevete(DNI, brevete);
        }
    }
}
