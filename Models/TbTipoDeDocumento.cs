using System;
using System.Collections.Generic;

namespace prueba_fernando_gomez.Models
{
    public partial class TbTipoDeDocumento
    {
        //public TbTipoDeDocumento()
        //{
        //    TbPacientes = new HashSet<TbPaciente>();
        //}

        public int IdTipoDocumento { get; set; }
        public string NombreTipoDocumento { get; set; } = null!;

        public virtual ICollection<TbPaciente> TbPacientes { get; set; }
    }
}
