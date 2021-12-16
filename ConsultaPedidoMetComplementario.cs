using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PracticaFinal.Formularios
{
    public partial class ConsultaPedidoMetComplementario : Form
    {
        Consultas _consu = new Consultas();
        public Usuario Usuario { get; set; }
        public PedidoMetComplementario Pedido { get; set; }
        public Int32 Pac_codigo { get; set; }

        public ConsultaPedidoMetComplementario()
        {
            InitializeComponent();
        }

        #region "Eventos"

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaPedidoComplementario_Load(object sender, EventArgs e)
        {
            txtComentario.Text = Pedido.pmc_comentario;
            ObjetoGral _destino = _consu.DevolverListaMetComplementarioDestinos().Where(x => x.codigo == Pedido.mcd_codigo).First();
            txtDestino.Text = _destino.denom;
            ObjetoGral _estado = _consu.DevolverListaPedidoEstados().Where(x => x.codigo == Pedido.pes_codigo).First();
            txtEstado.Text = _estado.denom;
            txtFecha.Text = Pedido.pmc_fechaCarga.ToString("dd/MM/yyyy HH:mm");
            txtMedico.Text = Usuario.nombre_completo;
            txtResultado.Text = Pedido.pmc_resultado;
            txtSala.Text = Pedido.pmc_salaOrigen.ToString();
            txtFechaEstado.Text = Pedido.pmc_fecha.ToString("dd/MM/yyyy HH:mm");

            if (Pedido.pmc_documento != null && Pedido.pmc_documento != "" && File.Exists(Pedido.pmc_documento))
            {
                txtDoc.Text = Path.GetFileName(Pedido.pmc_documento);
            }
            else
                btnAbrirDoc.Enabled = false;            
        }

        private void ConsultaPedidoMetComplementario_Shown(object sender, EventArgs e)
        {
            btnVolver.Focus();
        }

        private void btnAbrirDoc_Click(object sender, EventArgs e)
        {
            if (txtDoc.Text.Length > 0)
            {
                Process.Start(Pedido.pmc_documento);
            }
        }
        #endregion
    }
}
