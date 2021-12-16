using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    public class FichaMedica
    {   
        public Int32 fic_codigo { get; set; }
        public String usu_usuario { get; set; }
        public DateTime fic_fecha { get; set; }
        public Int32 hic_numero { get; set; }
        public String fic_motivoIngreso { get; set; }
        public String fic_observaciones { get; set; }
        public String fic_derivado { get; set; }
        public String fic_internado { get; set; }
        public String fic_alta { get; set; }
        public String fic_tratamiento { get; set; }
    }
}