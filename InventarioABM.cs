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
    public partial class InventarioABM : Form
    {
        Consultas _consu = new Consultas();
        Inventario _inventario = null;

        public InventarioABM()
        {
            InitializeComponent();
        }

        #region "Métodos"

        private void InicializarForm()
        {
            cmbTipos.DisplayMember = "denom";
            cmbTipos.ValueMember = "codigo";
            cmbTipos.DataSource = _consu.DevolverListaInventarioTipos();

            cmbMarcas.DisplayMember = "denom";
            cmbMarcas.ValueMember = "codigo";
            cmbMarcas.DataSource = _consu.DevolverListaInventarioMarcas();
        }

        private void Grabar()
        {
            if (Validar())
            {
                if (_inventario == null) _inventario = new Inventario();

                _inventario.inv_codigoMed = txtCodMed.Text;
                _inventario.inv_descripcion = txtDescripcion.Text;
                _inventario.inv_estanteria = txtEstanteria.Text;
                _inventario.invt_codigo = Convert.ToInt32(cmbTipos.SelectedValue.ToString());
                _inventario.invm_codigo = Convert.ToInt32(cmbMarcas.SelectedValue.ToString());
                _inventario.inv_cantidad = Convert.ToInt32(txtCantidad.Text);

                if (new ActualizarBD().ActualizarInventario(_inventario))
                {
                    MessageBox.Show("Articulo grabado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoInventario();
                }
                else
                    MessageBox.Show("Error al grabar el Articulo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean Validar()
        {
            if (txtCodMed.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar un código de medicamento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!txtCodMed.ReadOnly && _consu.ExisteInventario(txtCodMed.Text))
            {
                MessageBox.Show("El código de medicamento ya existe. Favor de ingresar otro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar una descripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtEstanteria.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar una estantería.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbTipos.SelectedIndex == 0)
            {
                MessageBox.Show("Favor de seleccionar un tipo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbMarcas.SelectedIndex == 0)
            {
                MessageBox.Show("Favor de seleccionar una marca.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            Int64 _I64Aux = 0;
            Int64.TryParse(txtCantidad.Text, out _I64Aux);
            if (_I64Aux == 0)
            {
                MessageBox.Show("Favor de ingresar una cantidad válida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void CargarInventario(Inventario _inv)
        {
            _inventario = _inv;
            txtCodMed.ReadOnly = true;

            txtCodMed.Text = _inventario.inv_codigoMed;
            txtDescripcion.Text = _inventario.inv_descripcion;
            txtEstanteria.Text = _inventario.inv_estanteria;
            cmbTipos.SelectedValue = _inventario.invt_codigo;
            cmbMarcas.SelectedValue = _inventario.invm_codigo;
            txtCantidad.Text = _inventario.inv_cantidad.ToString();
        }

        private void NuevoInventario()
        {
            _inventario = null;
            txtCodMed.ReadOnly = false;

            txtCodMed.Text = "";
            txtDescripcion.Text = "";
            txtEstanteria.Text = "";
            cmbTipos.SelectedIndex = 0;
            cmbMarcas.SelectedIndex = 0;
            txtCantidad.Text = "";
        }

        #endregion

        #region "Eventos"

        private void InventarioABM_Load(object sender, EventArgs e)
        {
            InicializarForm();
            NuevoInventario();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            Inventario _inv;
            GrillaSeleccionar _frm = new GrillaSeleccionar();
            _frm._lista = _consu.DevolverListaInventario();
            _frm._textoColumna = "Articulos";
            if (_frm.ShowDialog() == DialogResult.OK)
            {
                _inv = (Inventario)_frm._seleccionado;
                CargarInventario(_inv);
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            NuevoInventario();
        }

        #endregion
    }
}
