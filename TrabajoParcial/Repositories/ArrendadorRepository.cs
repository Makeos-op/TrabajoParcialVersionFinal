using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public bool Registro(Arrendador arrendador)
        {
            var RepoUsuario = new UsuarioRepository();
            if (!RepoUsuario.RegistrarUsuario(arrendador))
            {
                return false;
            }
            arrendadores.Add(arrendador);
            return true;
        }
        public List<Espacio> MostrarEspacios(int id)
        {
            return Buscar(id).Espacios;
        }
        public bool RegistrarEspacios(int id,Espacio espacio)
        {
            var RepoBrevete = new EspacioRepository();
            if (!RepoBrevete.Registro(espacio))
            {
                return false;
            }
            Buscar(id).Espacios.Add(espacio);
            return true;
        }
        public List<Reserva> BuscarReservasArrendador(int id)
        {
            
            var ReservasRepo=new ReservaRepository();
            return ReservasRepo.Mostrar().Where(r => r.idUbicacion.Equals(MostrarEspacios(id))).ToList();
        }

    }
}
