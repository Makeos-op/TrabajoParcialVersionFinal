namespace TrabajoParcial.Entities
{
    internal class Usuario
    {
        public Usuario() { }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Nacionalidad { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Contraseña { get; set; }
        public string TipoUsuario { get; set; }
        public double Saldo { get; set; }
    }
}
