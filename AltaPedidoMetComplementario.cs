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
    public partial class AltaPedidoMetComplementario : Form
    {
        Consultas _consu = new Consultas();
        public Usuario Usuario { get; set; }
        public Int32 Pac_codigo { get; set; }
        public Int32 NroSala { get; set; }

        public AltaPedidoMetComplementario()
        {
            InitializeComponent();
        }

        #region "Métodos"    

        private void Grabar()
        {
            if (Validar())
            {
                PedidoMetComplementario _pmc = new PedidoMetComplementario();
                _pmc.mcd_codigo = Convert.ToInt32(cmbMetDestino.SelectedValue.ToString()); ;
                _pmc.pac_codigo = Pac_codigo;
                _pmc.pes_codigo = 1;
                _pmc.pmc_codigo = 0;
                _pmc.pmc_comentario = txtComentario.Text;
                _pmc.pmc_fecha = DateTime.Now;
                _pmc.pmc_fechaCarga = DateTime.Now;
                _pmc.pmc_resultado = "";
                _pmc.pmc_salaOrigen = Convert.ToInt32(txtSala.Text);
                _pmc.usu_usuario = Usuario.usu_usuario;                              

                if (new ActualizarBD().ActualizarPedidoMetComplementario(_pmc))
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


            return true;
        }

        private void Limpiar()
        {
            txtComentario.Text = "";
            cmbMetDestino.SelectedIndex = 0;
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

        private void AltaPedidoComplementario_Load(object sender, EventArgs e)
        {
            cmbMetDestino.DisplayMember = "denom";
            cmbMetDestino.ValueMember = "codigo";
            cmbMetDestino.DataSource = _consu.DevolverListaMetComplementarioDestinos();

            if (NroSala != 0) txtSala.Text = NroSala.ToString();
            else txtSala.ReadOnly = false;
        }

        private void AltaPedidoMetComplementario_Shown(object sender, EventArgs e)
        {
            cmbMetDestino.Focus();
        }

        #endregion
    }
}
