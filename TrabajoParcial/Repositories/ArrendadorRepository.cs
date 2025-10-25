using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoParcial.Entities;

namespace TrabajoParcial.Repositories
{
    internal class ArrendadorRepository
    {
        private List<Arrendador> arrendadores = UsuarioRepository.MostrarArrendadores();
        //Usuarios Arrendadores como lista (Tipo Arrendador == objeto Arrendador)
        public List<Arrendador> MostrarArrendadores()
        {
            return UsuarioRepository.MostrarArrendadores();
        }
        public Arrendador Buscar(int DNI)
        {
            return MostrarArrendadores().Find(i => i.DNI.Equals(DNI));
        }
        public bool Registro(Arrendador arrendador, Espacio espacio)
        {
            var espacioRepo = new EspacioRepository();
            arrendador.TipoUsuario = "Conductor";
            bool EspacioRegistro = espacioRepo.Registro(arrendador.DNI,espacio);
            if (!EspacioRegistro)
            {
                return false;
            }
            arrendador.Espacios.Add(espacio);
            new UsuarioRepository().RegistrarUsuario(arrendador);
            return true;
        }
        public List<Espacio> MostrarEspacios(int id)
        {
            return Buscar(id).Espacios;
        }
        public List<Reserva> BuscarReservasArrendador(int id)
        {
            
            var ReservasRepo=new ReservaRepository();
            return ReservasRepo.Mostrar().Where(r => r.idUbicacion.Equals(MostrarEspacios(id))).ToList();
        }

    }
}
