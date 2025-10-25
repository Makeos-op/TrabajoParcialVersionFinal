using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoParcial.Entities;
using TrabajoParcial.Repositories;

namespace TrabajoParcial.Servicies
{
    internal class UsuarioService
    {
        private UsuarioRepository usuarioRepository = new UsuarioRepository();

        public bool Registrar(Usuario usuario)
        {
            if (usuarioRepository.ExisteCorreo(usuario.Correo))
            {
                return false; 
            }
            usuarioRepository.RegistrarUsuario(usuario);
            return true; 
        }

        public bool ExisteCorreo(string correo)
        {
            return usuarioRepository.ExisteCorreo(correo);
        }

        public Usuario CorreoEncontrado(string correo)
        {
            return usuarioRepository.CorreoEncontrado(correo);
        }

        public void EliminarUsuario(Usuario usuario)
        {
            usuarioRepository.EliminarUsuario(usuario);
        }

        public List<Usuario> ListarTodo()
        {
            return usuarioRepository.ListarTodo();
        }

        public bool ContraseñaCorrecta(string correo, string contraseña)
        {
            return usuarioRepository.ContraseñaCorrecta(correo, contraseña);
        }
        public static List<Arrendador> MostrarArrendadores()
        {
            return UsuarioRepository.MostrarArrendadores();
        }

        //MostrarConductores
        public static List<Conductor> MostrarConductores()
        {
            return UsuarioRepository.MostrarConductores();
        }
    }
}
