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
    public partial class UsuarioABM : Form
    {
        Consultas _consu = new Consultas();
        ObjetoGral _barrio = null;

        public UsuarioABM()
        {
            InitializeComponent();
        }

        #region "Métodos"

        private void InicializarForm()
        {
            cmbSexo.DisplayMember = "Text";
            cmbSexo.ValueMember = "Value";
            var _items = new[] {
                new { Text = "Seleccione", Value = "S" },
                new { Text = "Hombre", Value = "H" },
                new { Text = "Mujer", Value = "M" }};
            cmbSexo.DataSource = _items;

            cmbEstadoCivil.DisplayMember = "denom";
            cmbEstadoCivil.ValueMember = "codigo";
            cmbEstadoCivil.DataSource = _consu.DevolverListaEstadosCiviles();

            cmbEspecialidad.DisplayMember = "denom";
            cmbEspecialidad.ValueMember = "codigo";
            cmbEspecialidad.DataSource = _consu.DevolverListaEspecialidades();

            cmbRol.DisplayMember = "denom";
            cmbRol.ValueMember = "codigo";
            cmbRol.DataSource = _consu.DevolverListaRoles();
        }

        private void Grabar()
        {
            if (Validar())
            {
                Usuario _usu = new Usuario();
                _usu.usu_usuario = txtUsuario.Text;
                _usu.usu_clave = txtClave.Text;
                _usu.usu_nombre = txtNombres.Text;
                _usu.usu_apellido = txtApellidos.Text;
                _usu.usu_sexo = cmbSexo.SelectedValue.ToString();
                _usu.usu_documento = Convert.ToInt32(txtDocumento.Text);
                _usu.est_codigo = Convert.ToInt32(cmbEstadoCivil.SelectedValue.ToString());
                _usu.usu_direccion = txtDireccion.Text;
                _usu.brr_codigo = _barrio.codigo;
                _usu.usu_email = txtEmail.Text;
                _usu.usu_telefono = txtTelefono.Text;
                if (txtMatricula.Text != "") _usu.usu_matricula = Convert.ToInt32(txtMatricula.Text);
                _usu.esp_codigo = Convert.ToInt32(cmbEspecialidad.SelectedValue.ToString());
                _usu.rol_codigo = Convert.ToInt32(cmbRol.SelectedValue.ToString());
                _usu.usu_habilitado = chkHabilitado.Checked;
                _usu.usu_nacimiento = this.mcaNacimiento.SelectionRange.Start;

                if (new ActualizarBD().ActualizarUsuario(_usu))
                {
                    MessageBox.Show("Usuario grabado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoUsuario();
                }
                else
                    MessageBox.Show("Error al grabar el usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean Validar()
        { 
            if (txtUsuario.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar un usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!txtUsuario.ReadOnly && _consu.ExisteUsuario(txtUsuario.Text))
            {
                MessageBox.Show("El usuario ya existe. Favor de ingresar otro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtClave.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar una clave.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtNombres.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar nombres.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtApellidos.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar apellidos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbSexo.SelectedIndex == 0)
            {
                MessageBox.Show("Favor de seleccionar un sexo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtDocumento.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar un documento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbEstadoCivil.SelectedIndex == 0)
            {
                MessageBox.Show("Favor de seleccionar un estado civil.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtDireccion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar una dirección.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtBarrio.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar un barrio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar un email.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtTelefono.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar un teléfono.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtMatricula.Enabled && txtMatricula.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de ingresar una matrícula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbRol.SelectedIndex == 0)
            {
                MessageBox.Show("Favor de seleccionar un rol.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void CargarUsuario(Usuario _usu)
        {
            txtUsuario.ReadOnly = true;

            txtUsuario.Text = _usu.usu_usuario;
            txtClave.Text = _usu.usu_clave;
            txtNombres.Text = _usu.usu_nombre;
            txtApellidos.Text = _usu.usu_apellido;
            cmbSexo.SelectedValue = _usu.usu_sexo;
            txtDocumento.Text = _usu.usu_documento.ToString();
            cmbEstadoCivil.SelectedValue = _usu.est_codigo;
            txtDireccion.Text = _usu.usu_direccion;
            _barrio = _consu.DevolverBarrioxCodigo(_usu.brr_codigo);
            txtBarrio.Text = _barrio.denom;
            txtEmail.Text = _usu.usu_email;
            txtTelefono.Text = _usu.usu_telefono;            
            cmbEspecialidad.SelectedValue = _usu.esp_codigo;
            cmbRol.SelectedValue = _usu.rol_codigo;
            chkHabilitado.Checked = _usu.usu_habilitado;
            mcaNacimiento.SetDate(_usu.usu_nacimiento);            
            txtMatricula.Text = (_usu.usu_matricula.ToString() == "0" ? "" : _usu.usu_matricula.ToString());
        }

        private void NuevoUsuario()
        {
            txtUsuario.ReadOnly = false;

            txtUsuario.Text = "";
            txtClave.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cmbSexo.SelectedIndex = 0;
            txtDocumento.Text = "";
            cmbEstadoCivil.SelectedIndex = 0;
            txtDireccion.Text = "";
            _barrio = null;
            txtBarrio.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtMatricula.Text = "";
            cmbEspecialidad.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;
            chkHabilitado.Checked = true;
            mcaNacimiento.SetDate(DateTime.Today);
        }

        #endregion

        #region "Eventos"

        private void UsuarioABM_Load(object sender, EventArgs e)
        {
            InicializarForm();
            NuevoUsuario();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Usuario _usu;
            GrillaSeleccionar _frm = new GrillaSeleccionar();
            _frm._lista = _consu.DevolverListaUsuarios();
            _frm._textoColumna = "Usuarios";
            if (_frm.ShowDialog() == DialogResult.OK)
            {
                _usu = (Usuario)_frm._seleccionado;
                CargarUsuario(_usu);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoUsuario();
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEspecialidad.Enabled = cmbRol.SelectedIndex == 2;
            cmbEspecialidad.SelectedIndex = 0;
            txtMatricula.Enabled = cmbRol.SelectedIndex == 2;
            txtMatricula.Text = "";
        }

        #endregion

    }
}
