using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrabajoParcial.Entities;

namespace TrabajoParcial.Repositories
{
    internal class UsuarioRepository
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        //Verificar que el correo existe (correo y contraseña para iniciar sesión)
        public bool ExisteCorreo(string correo)
        {
            return usuarios.Exists(u => u.Correo.Equals(correo));
        }

        public Usuario CorreoEncontrado(string correo)
        {
            return usuarios.Find(u => u.Correo.Equals(correo));
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            if (ExisteCorreo(usuario.Correo))
            {
                return false; 
            }

            usuarios.Add(usuario);
            return true;
        }
        public void EliminarUsuario(Usuario usuario)
        {
            usuarios.RemoveAll(u => u.Correo == usuario.Correo);
        }

        public void EliminarTodo()
        {
            usuarios.Clear();
        }

        public List<Usuario> ListarTodo()
        {
            return usuarios;
        }

        public bool ContraseñaCorrecta(string correo, string contraseña)
        {
            Usuario usuario = usuarios.Find(u => u.Correo.Equals(correo));
            return usuario.Contraseña.Equals(contraseña);
        }

        //MostrarArrendadores
        public static List<Arrendador> MostrarArrendadores()
        {
            return usuarios.OfType<Arrendador>().ToList();
        }

        //MostrarConductores
        public static List<Conductor> MostrarConductores()
        {
            return usuarios.OfType<Conductor>().ToList();
        }


        public void QuitarMonto(double monto, int dni)
        {
            var usuario = usuarios.FirstOrDefault(u => u.DNI == dni);
            if (usuario != null)
            {
                usuario.Saldo -= monto;
            }
        }

        public void AgregarMonto(double monto, int dni)
        {
            var usuario = usuarios.FirstOrDefault(u => u.DNI == dni);
            if (usuario != null)
            {
                usuario.Saldo += monto;
            }
        }

    }
}
