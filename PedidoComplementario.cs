using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    public class PedidoMetComplementario
    {
        public Int32 pmc_codigo { get; set; }
        public String usu_usuario { get; set; }
        public Int32 pmc_salaOrigen { get; set; }
        public Int32 pac_codigo { get; set; }
        public Int32 mcd_codigo { get; set; }
        public Int32 pes_codigo { get; set; }
        public String pmc_comentario { get; set; }
        public String pmc_resultado { get; set; }
        public DateTime pmc_fecha { get; set; }
        public DateTime pmc_fechaCarga { get; set; }
        public String pmc_documento { get; set; }
        public String pac_nombreCompleto { get; set; }
    }
}