using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    public class PedidoInventario
    {
        public Int32 pei_codigo { get; set; }
        public String usu_usuario { get; set; }
        public Int32 pei_salaOrigen { get; set; }
        public String inv_codigoMed { get; set; }
        public Int32 pes_codigo { get; set; }
        public String pes_denom { get; set; }
        public String pei_comentario { get; set; }
        public DateTime pei_fecha { get; set; }
        public DateTime pei_fechaCarga { get; set; }
        public Double pei_cantidad { get; set; }
        public String inv_descripcion { get; set; }
        public String usu_usuarioToma { get; set; }
    }
}