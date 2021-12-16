using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PracticaFinal.Formularios
{
    public partial class HistorialClinico : Form
    {
        Consultas _consu = new Consultas();
        public Int32 Hic_numero { get; set; }
        private Int32 _ultimaFichaCodigo = 0;
        private Int32 _ultimoPedMetCompleCodigo = 0;
        public Usuario Usuario { get; set; }
        private Paciente _pac;

        public HistorialClinico()
        {
            InitializeComponent();
        }

        #region "Métodos"    

        private void CargarDatos()
        {
            lblHC.Text = "Historial clínico N° " + Hic_numero;

            _pac = _consu.DevolverPacientexHC(Hic_numero);
            txtPacNombreCompleto.Text = _pac.nombre_completo;
            txtPacDocumento.Text = _pac.pac_documento.ToString();
            txtPacFechaNac.Text = _pac.pac_fechaNac.ToString("dd/MM/yyyy");
            txtPacSexo.Text = _pac.sexo_str;
            ObjetoGral _estadoCivil = _consu.DevolverListaEstadosCiviles().Where(x => x.codigo == _pac.est_codigo).First();
            txtPacEstadoCivil.Text = _estadoCivil.denom;
            ObjetoGral _obraSocial = _consu.DevolverListaObrasSociales().Where(x => x.codigo == _pac.obr_codigo).First();
            txtPacObraSocial.Text = _obraSocial.denom;
            txtPacTelefono.Text = _pac.pac_telefono;
            txtPacTelefonoRef.Text = _pac.pac_telefonoRef;
            txtPacEmail.Text = _pac.pac_email;
            txtPacDireccion.Text = _pac.pac_direccion;
            ObjetoGral _barrio = _consu.DevolverBarrioxCodigo(_pac.brr_codigo);
            txtPacBarrio.Text = _barrio.denom;
            txtTipoSangre.Text = _pac.pac_tipoSangre;

            FichaMedica _ficha = _consu.DevolverUltimaFichaMedicaxHC(Hic_numero);
            if (_ficha != null)
            {
                txtFicFecha.Text = _ficha.fic_fecha.ToString("dd/MM/yyyy HH:mm");
                Usuario _usu = _consu.DevolverUsuarioxUsuario(_ficha.usu_usuario);
                txtFicMedico.Text = _usu.nombre_completo;
                txtFicMotivoIng.Text = _ficha.fic_motivoIngreso;
                txtFicTratamiento.Text = _ficha.fic_tratamiento;
                chkDerivado.Checked = _ficha.fic_derivado == "1";
                chkInternado.Checked = _ficha.fic_internado == "1";
                chkAlta.Checked = _ficha.fic_alta == "1";
                _ultimaFichaCodigo = _ficha.fic_codigo;
            }
            else
                txtFicMedico.Text = "No poseé fichas médicas";

            PedidoMetComplementario _ped = _consu.DevolverUltimoPedMetComplementarioxHC(Hic_numero);
            if (_ped != null)
            {
                txtPedComentario.Text = _ped.pmc_comentario;
                ObjetoGral _destino = _consu.DevolverListaMetComplementarioDestinos().Where(x => x.codigo == _ped.mcd_codigo).First();
                txtPedDestino.Text = _destino.denom;
                txtPedFecha.Text = _ped.pmc_fechaCarga.ToString("dd/MM/yyyy HH:mm");
                Usuario _usu = _consu.DevolverUsuarioxUsuario(_ped.usu_usuario);
                txtPedMedico.Text = _usu.nombre_completo;
                txtPedResultado.Text = _ped.pmc_resultado;
                _ultimoPedMetCompleCodigo = _ped.pmc_codigo;
                chkArchivo.Checked = _ped.pmc_documento != null && _ped.pmc_documento != "";                
            }
            else
                txtPedMedico.Text = "No poseé pedidos de mét. compl.";
        }

        #endregion

        #region "Eventos"

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HistorialClinico_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_ultimaFichaCodigo > 0)
            {
                FichaMedABM _frm = new FichaMedABM();
                _frm.SoloLectura = true;
                _frm.Usuario = Usuario;
                _frm.Ficha = _consu.DevolverFichaMedicaxCodigo(_ultimaFichaCodigo);
                _frm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_ultimoPedMetCompleCodigo > 0)
            {
                ConsultaPedidoMetComplementario _frm = new ConsultaPedidoMetComplementario();
                _frm.Usuario = Usuario;
                _frm.Pedido = new Consultas().DevolverUltimoPedMetComplementarioxCodigo(_ultimoPedMetCompleCodigo);
                _frm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HistorialClinicoTodos _frm = new HistorialClinicoTodos();
            _frm.Hic_numero = Hic_numero;
            _frm.Paciente = _pac;
            _frm.Usuario = Usuario;
            _frm.ShowDialog();
        }

        #endregion
    }
}
