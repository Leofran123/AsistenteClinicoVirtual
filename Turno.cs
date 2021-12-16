using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    public class Turno
    {
        public Int32 tur_codigo { get; set; }
        public DateTime tur_fecha { get; set; }
        public String usu_usuarioCarga { get; set; }
        public String usu_usuarioToma { get; set; }
        public Int32 pac_codigo { get; set; }
        public String pac_nombreCompleto { get; set; }
        public Int32 tni_codigo { get; set; }
        public String tni_denom { get; set; }
        public Int32 tur_cancelado { get; set; }
        public Int32 tur_en_espera { get; set; }
        public DateTime tur_fechaCierre { get; set; }
    }
}
