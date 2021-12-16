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
    public partial class AntecedentesABM : Form
    {
        private Consultas _consu = new Consultas();
        private ActualizarBD _actBD = new ActualizarBD();        
        private Antecedente _ant = null;
        public Int32 Hic_numero { get; set; }

        public AntecedentesABM()
        {
            InitializeComponent();
        }

        #region "Métodos"

        private void InicializarForm()
        {
            _ant = _consu.DevolverAntecedentes(Hic_numero);
            if (_ant != null) CargarAntecedentes(_ant);
            else _ant = new Antecedente();
        }

        private void Grabar()
        {
            _ant.hic_numero = Hic_numero;
            _ant.ant_patologicos = txtAntPatologicos.Text;
            _ant.ant_alergicos  = txtAntAlergicos.Text;
            _ant.ant_quirurgicos = txtAntQuirurgicos.Text;
            _ant.ant_toxicos = txtAntToxicos.Text;

            if (_actBD.ActualizarAntecedentes(_ant))
            {
                MessageBox.Show("Antecedente grabado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Error al grabar el Antecedente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void CargarAntecedentes(Antecedente _ant)
        {
            txtAntPatologicos.Text = _ant.ant_patologicos;
            txtAntQuirurgicos.Text = _ant.ant_quirurgicos;
            txtAntToxicos.Text = _ant.ant_toxicos;
            txtAntAlergicos.Text = _ant.ant_alergicos;
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

        private void AntecedentesABM_Shown(object sender, EventArgs e)
        {
            btnVolver.Focus();
        }

        #endregion              
    }
}
