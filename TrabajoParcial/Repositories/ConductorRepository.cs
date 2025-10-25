using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoParcial.Entities;

namespace TrabajoParcial.Repositories
{
    internal class ConductorRepository
    {
        private List<Conductor> conductores = new List<Conductor>();
        //Usuarios Conductores como lista (Tipo conductor == objeto conductor)
        public List<Conductor> MostrarConductores()
        {
            conductores = UsuarioRepository.MostrarConductores();
            return conductores;
        }
        public Conductor Buscar(int DNI)
        {
            return MostrarConductores().Find(i => i.DNI.Equals(DNI));
        }
        public bool Registro(Conductor conductor)
        {
            var RepoUsuario = new UsuarioRepository();
            if (!RepoUsuario.RegistrarUsuario(conductor))
            {
                return false;
            }
            conductores.Add(conductor);
            return true;
        }
        public bool RegistroBrevete(int DNI, Brevete brevete)
        {
            var RepoBrevete = new BreveteRepository();
            if (!RepoBrevete.Registro(brevete))
            {
                return false;
            }
            Buscar(DNI).brevetes.Add(brevete);
            return true;
        }
        public List<Vehiculo> MostrarVehiculos(int id)
        {
            return Buscar(id).vehiculos;
        }
        public List<Brevete> MostrarBrevetes(int id)
        {
            return Buscar(id).brevetes;
        }
        public List<Reserva> MostrarReservas(int id)
        {
            var ReservaRepo = new ReservaRepository();
            return ReservaRepo.Mostrar().Where(r=>r.matricula.Equals(MostrarVehiculos(id))).ToList();
        }
    }
}
