using System;
using System.Collections.Generic;

namespace prueba_fernando_gomez.Models
{
    public partial class TbEstadoAfiliacion
    {
        //public TbEstadoAfiliacion()
        //{
        //    TbPacientes = new HashSet<TbPaciente>();
        //}

        public int IdAfiliacion { get; set; }
        public string EstadoAfiliacion { get; set; } = null!;

        public virtual ICollection<TbPaciente> TbPacientes { get; set; }
    }
}
