using System;
using System.Collections.Generic;

namespace prueba_fernando_gomez.Models
{
    public partial class TbPaciente
    {
        public int IdPacientes { get; set; }
        public int? IdTipoDocumento { get; set; }
        public int NumeroDeDocumento { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string? Telefono { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public int? IdAfiliacion { get; set; }

        public virtual TbEstadoAfiliacion? IdAfiliacionNavigation { get; set; }
        public virtual TbTipoDeDocumento? IdTipoDocumentoNavigation { get; set; }
    }
}
