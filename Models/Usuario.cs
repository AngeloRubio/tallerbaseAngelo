using System;
using System.Collections.Generic;

namespace tallerbaseAngelo.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NombreUsario { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public bool Estado { get; set; }
        public int GeneroId { get; set; }

        public virtual Genero Genero { get; set; } = null!;
    }
}
