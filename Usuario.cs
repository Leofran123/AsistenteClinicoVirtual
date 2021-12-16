using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    public class Usuario
    {
        public String usu_usuario { get; set; }
        public String denomStr
        {
            get { return usu_usuario + " (" + usu_apellido + ", " + usu_nombre + ")"; }
        }
        public String usu_clave { get; set; }
        public String usu_nombre { get; set; }
        public String usu_apellido { get; set; }
        public String usu_email { get; set; }
        public String usu_telefono { get; set; }
        public DateTime usu_nacimiento { get; set; }
        public String usu_direccion { get; set; }
        public Int32 brr_codigo { get; set; }
        public Int32 usu_documento { get; set; }
        public Int32 est_codigo { get; set; }
        public String usu_sexo { get; set; }
        public Int32 esp_codigo { get; set; }
        public Int32 usu_matricula { get; set; }
        public Int32 rol_codigo { get; set; }
        public Boolean usu_habilitado { get; set; }
        public String nombre_completo
        {
            get { return usu_apellido + ", " + usu_nombre; }
        }
    }
}
