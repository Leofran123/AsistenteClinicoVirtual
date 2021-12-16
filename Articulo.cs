using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    public class Inventario
    {
        public String inv_codigoMed { get; set; }
        public String denomStr
        {
            get { return inv_descripcion + " (Cantidad: " + inv_cantidad + ")"; }
        }
        public String inv_descripcion { get; set; }
        public String inv_estanteria { get; set; }
        public Int32 invt_codigo { get; set; }
        public Int32 invm_codigo { get; set; }
        public Double inv_cantidad { get; set; }
    }
}