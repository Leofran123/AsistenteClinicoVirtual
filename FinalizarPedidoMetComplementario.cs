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
    public partial class FinalizarPedidoMetComplementario : Form
    {
        Consultas _consu = new Consultas();
        public Usuario Usuario { get; set; }
        public PedidoMetComplementario Pedido { get; set; }
        public Int32 Pac_codigo { get; set; }

        public FinalizarPedidoMetComplementario()
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
            //txtDoc.Text = Pedido.pmc_documento; cargar el titulo del archivo, get file por ahi
        }

        private void ConsultaPedidoMetComplementario_Shown(object sender, EventArgs e)
        {
            btnVolver.Focus();
        }

        private void btnAbrirDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog _op = new OpenFileDialog();
            _op.Title = "Subir estudio del método complementario";
            if (_op.ShowDialog() == DialogResult.OK)
            {
                txtDoc.Text = _op.FileName;                
            }

            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length == 0)
            {
                MessageBox.Show("Favor de agregar un resultado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Pedido.pmc_comentario = txtComentario.Text;
            Pedido.pmc_resultado = txtResultado.Text;
            Pedido.pmc_documento = txtDoc.Text;
            Pedido.pmc_fecha = DateTime.Today;
            Pedido.pes_codigo = 4;

            if (new ActualizarBD().ActualizarPedidoMetComplementario(Pedido))
            {
                MessageBox.Show("Método complementario grabado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Error al grabar el método complementario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        #endregion
    }
}
