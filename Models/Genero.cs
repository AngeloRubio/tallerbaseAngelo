using System;
using System.Collections.Generic;

namespace tallerbaseAngelo.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
