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
    public partial class PacienteABM : Form
    {
        Consultas _consu = new Consultas();
        ObjetoGral _barrio = null;
        Paciente _paciente = null;

        public PacienteABM()
        {
            InitializeComponent();
        }

        #region "Métodos"

        private void InicializarForm()
        {
            cmbSexo.DisplayMember = "Text";
            cmbSexo.ValueMember = "Value";
            var _items = new[] {
                new { Text = "Seleccione", Value = "Z" },
                new { Text = "Hombre", Value = "H" },
                new { Text = "Mujer", Value = "M" }};
            cmbSexo.DataSource = _items;

            cmbTipoSangre.DisplayMember = "Text";
            cmbTipoSangre.ValueMember = "Value";
            _items = new[] {
                new { Text = "Seleccione", Value = "Z" },
                new { Text = "A+", Value = "A+" },
                new { Text = "O+", Value = "O+" },
                new { Text = "B+", Value = "B+" },
                new { Text = "AB+", Value = "AB+" },
                new { Text = "A-", Value = "A-" },
                new { Text = "O-", Value = "O-" },
                new { Text = "B-", Value = "B-" },
                new { Text = "AB-", Value = "AB-" }

            };
            cmbTipoSangre.DataSource = _items;

            cmbEstadoCivil.DisplayMember = "denom";
            cmbEstadoCivil.ValueMember = "codigo";
            cmbEstadoCivil.DataSource = _consu.DevolverListaEstadosCiviles();

            cmbObraSocial.DisplayMember = "denom";
            cmbObraSocial.ValueMember = "codigo";
            cmbObraSocial.DataSource = _consu.DevolverListaObrasSociales();
        }

        private void Grabar()
        {
            if (Validar())
            {
                if (_paciente == null) _paciente = new Paciente();

                _paciente.pac_nombre = txtNombres.Text;
                _paciente.pac_apellido = txtApellidos.Text;
                _paciente.pac_sexo = cmbSexo.SelectedValue.ToString();
                _paciente.pac_documento = Convert.ToInt32(txtDocumento.Text);
                _paciente.est_codigo = Convert.ToInt32(cmbEstadoCivil.SelectedValue.ToString());
                _paciente.pac_telefono = txtTelefono.Text;
                _paciente.pac_telefonoRef = txtTelefonoRef.Text;
                _paciente.pac_direccion = txtDireccion.Text;
                _paciente.brr_codigo = _barrio.codigo;
                _paciente.pac_email = txtEmail.Text;
                _paciente.obr_codigo = Convert.ToInt32(cmbObraSocial.SelectedValue.ToString());
                _paciente.pac_fechaNac = this.mcaNacimiento.SelectionRange.Start;
                _paciente.pac_tipoSangre = cmbTipoSangre.SelectedValue.ToString();

                if (new ActualizarBD().ActualizarPaciente(_paciente))
                {
                    MessageBox.Show("Paciente grabado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoPaciente();
                }
                else
                    MessageBox.Show("Error al grabar al paciente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean Validar()
        {
            Int32 _pacDoc = Convert.ToInt32(txtDocumento.Text);
            if (!txtDocumento.ReadOnly && _consu.ExistePaciente(_pacDoc))
                {
                MessageBox.Show("El paciente ya existe. Por favor ingrese otro documento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtNombres.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar nombres.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtApellidos.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar apellidos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbSexo.SelectedIndex == 0)
            {
                MessageBox.Show("Favor de seleccionar un sexo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtDocumento.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar un documento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            Int64 _I64Aux = 0;
            Int64.TryParse(txtDocumento.Text, out _I64Aux);
            if (_I64Aux == 0)
            {
                MessageBox.Show("Favor de ingresar un documento válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbEstadoCivil.SelectedIndex == 0)
            {
                MessageBox.Show("Favor de seleccionar un estado civil.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtTelefono.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar un teléfono.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtTelefonoRef.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar un teléfono de referencia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtDireccion.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar una dirección.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtBarrio.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar un barrio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbTipoSangre.SelectedIndex == 0)
            {
                MessageBox.Show("Favor de seleccionar un tipo de sangre.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar un email.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }         

            return true;
        }

        private void CargarPaciente(Paciente _pac)
        {
            _paciente = _pac;
            txtDocumento.ReadOnly = true;

            txtNombres.Text = _pac.pac_nombre;
            txtApellidos.Text = _pac.pac_apellido;
            cmbSexo.SelectedValue = _pac.pac_sexo;
            txtDocumento.Text = _pac.pac_documento.ToString();
            cmbEstadoCivil.SelectedValue = _pac.est_codigo;
            txtTelefono.Text = _pac.pac_telefono;
            txtTelefonoRef.Text = _pac.pac_telefonoRef;
            txtDireccion.Text = _pac.pac_direccion;
            _barrio = _consu.DevolverBarrioxCodigo(_pac.brr_codigo);
            txtBarrio.Text = _barrio.denom;
            txtEmail.Text = _pac.pac_email;
            cmbObraSocial.SelectedValue = _pac.obr_codigo;
            mcaNacimiento.SetDate(_pac.pac_fechaNac);
            cmbTipoSangre.SelectedValue = _pac.pac_tipoSangre;
        }

        private void NuevoPaciente()
        {
            _paciente = null;
            txtDocumento.ReadOnly = false;

            txtNombres.Text = "";
            txtApellidos.Text = "";
            cmbSexo.SelectedIndex = 0;
            txtDocumento.Text = "";
            cmbEstadoCivil.SelectedIndex = 0;
            txtTelefono.Text = "";
            txtTelefonoRef.Text = "";
            txtDireccion.Text = "";
            _barrio = null;
            txtBarrio.Text = "";
            txtEmail.Text = "";
            cmbObraSocial.SelectedIndex = 0;
            mcaNacimiento.SetDate(DateTime.Today);
            cmbTipoSangre.SelectedIndex = 0;
        }

        #endregion

        #region "Eventos"

        private void UsuarioABM_Load(object sender, EventArgs e)
        {
            InicializarForm();
            NuevoPaciente();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void btnBuscarBarrio_Click(object sender, EventArgs e)
        {
            GrillaSeleccionar _frm = new GrillaSeleccionar();
            _frm._lista = _consu.DevolverListaBarrios();
            _frm._textoColumna = "Barrios";
            if (_frm.ShowDialog() == DialogResult.OK)
            {
                _barrio = (ObjetoGral)_frm._seleccionado;
                this.txtBarrio.Text = _barrio.denom;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            Paciente _pac;
            GrillaSeleccionar _frm = new GrillaSeleccionar();
            _frm._lista = _consu.DevolverListaPacientes();
            _frm._textoColumna = "Pacientes";
            if (_frm.ShowDialog() == DialogResult.OK)
            {
                _pac = (Paciente)_frm._seleccionado;
                CargarPaciente(_pac);
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            NuevoPaciente();
        }

        #endregion
    }
}
