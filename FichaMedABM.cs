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
    public partial class FichaMedABM : Form
    {
        Consultas _consu = new Consultas();
        ActualizarBD _actBD = new ActualizarBD();
        public Usuario Usuario { get; set; }
        public Boolean Modificar { get; set; } = false;
        public Int32 Hic_numero { get; set; }
        public Boolean SoloLectura { get; set; } = false;
        public FichaMedica Ficha { get; set; } 

        public FichaMedABM()
        {
            InitializeComponent();
        }

        #region "Métodos"

        private void InicializarForm()
        {
            NuevoFichaMed();
            txtMedico.Text = Usuario.nombre_completo;

            if (Modificar)
            {
                lblTitulo.Text = "Modificar ficha médica";
                this.Text = "Modificar ficha médica";
                FichaMedica _fichaMed = _consu.DevolverUltimaFichaMedicaxHCUsuario(Hic_numero, Usuario.usu_usuario);
                CargarFichaMed(_fichaMed);
            }

            if (SoloLectura)
            {
                CargarFichaMed(Ficha);

                btnGrabar.Visible = false;
                txtMotivo.ReadOnly = true;
                txtObservaciones.ReadOnly = true;
                txtTratamiento.ReadOnly = true;
                chkAlta.AutoCheck = false;
                chkDerivado.AutoCheck = false;
                chkInternado.AutoCheck = false;

                this.Text = "Ficha médica";
                lblTitulo.Text = "Ficha médica";
            }
            
            txtMotivo.Focus();
        }

        private void Grabar()
        {
            if (Validar())
            {
                FichaMedica _fme = new FichaMedica();
                _fme.fic_motivoIngreso = txtMotivo.Text;
                _fme.fic_observaciones = txtObservaciones.Text;
                _fme.fic_derivado = chkDerivado.Checked ? "1" : "0";
                _fme.fic_internado = chkInternado.Checked ? "1" : "0";
                _fme.fic_alta = chkAlta.Checked ? "1" : "0";
                _fme.usu_usuario = Usuario.usu_usuario;
                _fme.hic_numero = Hic_numero;
                _fme.fic_tratamiento = txtTratamiento.Text;

                if (_actBD.ActualizarFichaMedica(_fme))
                {
                    MessageBox.Show("Ficha médica grabada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Error al grabar la ficha médica.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean Validar()
        {
            return true;
        }

        private void CargarFichaMed(FichaMedica _fme)
        {
            txtMotivo.Text = _fme.fic_motivoIngreso;
            txtObservaciones.Text = _fme.fic_observaciones;
            chkDerivado.Checked = _fme.fic_derivado == "1";
            chkInternado.Checked = _fme.fic_internado == "1";
            chkAlta.Checked = _fme.fic_alta == "1";
            txtTratamiento.Text = _fme.fic_tratamiento;
        }

        private void NuevoFichaMed()
        {
            txtMotivo.Text = "";
            txtObservaciones.Text = "";
            chkDerivado.Checked = false;
            chkAlta.Checked = false;
            chkInternado.Checked = false;
            txtTratamiento.Text = "";
        }

        #endregion

        #region "Eventos"

        private void FichaMedABM_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void FichaMedABM_Shown(object sender, EventArgs e)
        {
            btnVolver.Focus();
        }

        #endregion
    }
}
