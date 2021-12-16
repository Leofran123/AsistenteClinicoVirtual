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
    public partial class AltaPedidoInventario : Form
    {
        Consultas _consu = new Consultas();
        public Usuario Usuario { get; set; }
        Inventario _inv = null;
        public Int32 NroSala { get; set; }

        public AltaPedidoInventario()
        {
            InitializeComponent();
        }

        #region "Métodos"    

        private void Grabar()
        {
            if (Validar())
            {
                PedidoInventario _pei = new PedidoInventario();
                _pei.pei_codigo = 0;
                _pei.usu_usuario = Usuario.usu_usuario;
                _pei.pei_salaOrigen = Convert.ToInt32(txtSala.Text);
                _pei.inv_codigoMed = _inv.inv_codigoMed;
                _pei.pes_codigo = 1;
                _pei.pei_comentario = txtComentario.Text;
                _pei.pei_fecha = DateTime.Now;
                _pei.pei_fechaCarga = DateTime.Now;
                _pei.pei_cantidad = Convert.ToDouble(txtCantidad.Text);

                if (new ActualizarBD().ActualizarPedidoInventario(_pei))
                {
                    MessageBox.Show("Pedido grabado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("Error al grabar el pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean Validar()
        {
            if (_inv == null)
            {
                MessageBox.Show("Favor de ingresar un artículo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void Limpiar()
        {
            _inv = null;

            txtComentario.Text = "";
            txtCantidad.Text = "";
            txtArticulo.Text = "";
        }

        #endregion

        #region "Eventos"

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            GrillaSeleccionar _frm = new GrillaSeleccionar();
            _frm._lista = _consu.DevolverListaInventario();
            _frm._textoColumna = "Articulos";
            if (_frm.ShowDialog() == DialogResult.OK)
            {
                _inv = (Inventario)_frm._seleccionado;
                txtArticulo.Text = _inv.inv_descripcion;
            }
        }

        private void AltaPedidoInventario_Load(object sender, EventArgs e)
        {
            if (NroSala != 0) txtSala.Text = NroSala.ToString();
            else txtSala.ReadOnly = false;
        }

        private void AltaPedidoInventario_Shown(object sender, EventArgs e)
        {
            txtCantidad.Focus();
        }

        #endregion
    }
}
