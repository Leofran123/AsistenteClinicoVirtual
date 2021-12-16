using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaFinal.Formularios
{
    public partial class AsignarTurno : Form
    {
        Consultas _consu;
        Paciente _paciente;
        public Usuario Usuario { get; set; }

        public AsignarTurno()
        {
            InitializeComponent();
        }

        #region "Métodos"

        private void Limpiar()
        {
            cmbPrioridad.SelectedIndex = 0;
            _paciente = null;
            txtPaciente.Text = "";
        }

        #endregion

        #region "Eventos"

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Int32 _prioridad = Convert.ToInt32(cmbPrioridad.SelectedValue.ToString());

            if (_paciente == null)
            {
                MessageBox.Show("Favor de seleccionar un paciente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_prioridad == -1)
            {
                MessageBox.Show("Favor de seleccionar una prioridad.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (new ActualizarBD().GrabarTurno(_paciente.pac_codigo, Usuario.usu_usuario, _prioridad))
            {
                MessageBox.Show("Turno grabado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("Error al grabar el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            GrillaSeleccionar _frm = new GrillaSeleccionar();
            _frm._lista = _consu.DevolverListaPacientes();
            _frm._textoColumna = "Pacientes";
            _frm._nuevo = true;
            if (_frm.ShowDialog() == DialogResult.OK)
            {
                _paciente = (Paciente)_frm._seleccionado;
                txtPaciente.Text = _paciente.nombre_completo;
            }
        }

        private void AsignarTurno_Load(object sender, EventArgs e)
        {
            _consu = new Consultas();

            cmbPrioridad.DisplayMember = "denom";
            cmbPrioridad.ValueMember = "codigo";
            cmbPrioridad.DataSource = _consu.DevolverListaPrioridades();
        }

        #endregion
    }
}
