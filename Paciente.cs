using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    public class Paciente
    {
        public Int32 pac_codigo { get; set; }
        public String denomStr
        {
            get { return pac_apellido + ", " + pac_nombre + ". Documento: " + pac_documento.ToString(); }
        }
        public String pac_nombre { get; set; }
        public String pac_apellido { get; set; }
        public String pac_telefono { get; set; }
        public String pac_telefonoRef { get; set; }
        public DateTime pac_fechaNac { get; set; }
        public String pac_direccion { get; set; }
        public String pac_email { get; set; }
        public Int32 brr_codigo { get; set; }
        public Int32 pac_documento { get; set; }
        public Int32 est_codigo { get; set; }
        public Int32 obr_codigo { get; set; }
        public String pac_sexo { get; set; }
        public String pac_tipoSangre { get; set; }
        
        public String nombre_completo
        {
            get { return pac_apellido + ", " + pac_nombre; }
        }
        public String sexo_str
        {
            get
            {
                if (pac_sexo == "H") return "Hombre";
                else return "Mujer";
            }
        }
    }
}
