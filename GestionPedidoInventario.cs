using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PracticaFinal.Formularios
{
    public partial class GestionPedidoInventario : Form
    {
        public Object _lista { get; set; }
        public Usuario Usuario { get; set; }
        public Boolean _soloLectura { get; set; } = false;
        Consultas _consu = new Consultas();
        ActualizarBD _actBD = new ActualizarBD();

        public GestionPedidoInventario()
        {
            InitializeComponent();
        }

        #region "Métodos"

        private void CargarGrilla()
        {
            Grid.DataSource = _consu.DevolverListaPedidoInvAbiertas(Usuario);
        }

        private void InicializarGrilla()
        {
            Grid.AutoGenerateColumns = false;
            Grid.Columns.Clear();

            Grid.Columns.Add("pei_salaOrigen", "Sala");
            Grid.Columns["pei_salaOrigen"].DataPropertyName = "pei_salaOrigen";
            Grid.Columns["pei_salaOrigen"].Width = 30;
            Grid.Columns["pei_salaOrigen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["pei_salaOrigen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Grid.Columns.Add("usu_usuario", "Usuario");
            Grid.Columns["usu_usuario"].DataPropertyName = "usu_usuario";
            Grid.Columns["usu_usuario"].Width = 85;
            Grid.Columns["usu_usuario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["usu_usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            Grid.Columns.Add("inv_codigoMed", "Cód. artículo");
            Grid.Columns["inv_codigoMed"].DataPropertyName = "inv_codigoMed";
            Grid.Columns["inv_codigoMed"].Width = 70;
            Grid.Columns["inv_codigoMed"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["inv_codigoMed"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            Grid.Columns.Add("inv_descripcion", "Art. descripción");
            Grid.Columns["inv_descripcion"].DataPropertyName = "inv_descripcion";
            Grid.Columns["inv_descripcion"].Width = 110;
            Grid.Columns["inv_descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["inv_descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            Grid.Columns.Add("pei_cantidad", "Cantidad");
            Grid.Columns["pei_cantidad"].DataPropertyName = "pei_cantidad";
            Grid.Columns["pei_cantidad"].Width = 60;
            Grid.Columns["pei_cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["pei_cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Grid.Columns.Add("pei_comentario", "Comentario");
            Grid.Columns["pei_comentario"].DataPropertyName = "pei_comentario";
            Grid.Columns["pei_comentario"].Width = 259;
            Grid.Columns["pei_comentario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["pei_comentario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            Grid.Columns.Add("pei_fechaCarga", "Fecha carga");
            Grid.Columns["pei_fechaCarga"].DataPropertyName = "pei_fechaCarga";
            Grid.Columns["pei_fechaCarga"].Width = 100;
            Grid.Columns["pei_fechaCarga"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["pei_fechaCarga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid.Columns["pei_fechaCarga"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            Grid.Columns.Add("pei_fecha", "Fecha Estado");
            Grid.Columns["pei_fecha"].DataPropertyName = "pei_fecha";
            Grid.Columns["pei_fecha"].Width = 100;
            Grid.Columns["pei_fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["pei_fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid.Columns["pei_fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            Grid.Columns.Add("pes_denom", "Estado");
            Grid.Columns["pes_denom"].DataPropertyName = "pes_denom";
            Grid.Columns["pes_denom"].Width = 70;
            Grid.Columns["pes_denom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["pes_denom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            Grid.Columns.Add("usu_usuarioToma", "Tomado por");
            Grid.Columns["usu_usuarioToma"].DataPropertyName = "usu_usuarioToma";
            Grid.Columns["usu_usuarioToma"].Width = 85;
            Grid.Columns["usu_usuarioToma"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["usu_usuarioToma"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void IniciarFormulario()
        {
            if (_soloLectura)
            {
                btnEntregar.Visible = false;
                btnTomar.Visible = false;
                btnComentario.Visible = false;
            }
        }

        #endregion

        #region "Eventos"

        private void GrillaSeleccionar_Load(object sender, EventArgs e)
        {
            InicializarGrilla();
            CargarGrilla();
            IniciarFormulario();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String _buscar = txtBuscar.Text.Trim();

            List<PedidoInventario> _listaBusq = _consu.DevolverListaPedidoInvAbiertas(Usuario,_buscar );

            if (_listaBusq != null) Grid.DataSource = _listaBusq;
            else MessageBox.Show("No hay datos para buscar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnTomar_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                PedidoInventario _seleccionado = (PedidoInventario)Grid.SelectedRows[0].DataBoundItem;

                if (_seleccionado.pes_codigo < 2)
                {
                    _seleccionado.pes_codigo = 2;
                    _seleccionado.pei_fecha = DateTime.Now;
                    _seleccionado.usu_usuarioToma = Usuario.usu_usuario;

                    if (_actBD.ActualizarPedidoInventario(_seleccionado))
                        CargarGrilla();
                    else
                        MessageBox.Show("Error al actualizar el pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("No se puede tomar el pedido.\nEstado: " + _seleccionado.pes_codigo + " - " + _seleccionado.pes_denom + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                PedidoInventario _seleccionado = (PedidoInventario)Grid.SelectedRows[0].DataBoundItem;

                if (_seleccionado.pes_codigo < 3)
                {
                    _seleccionado.pes_codigo = 3;
                    _seleccionado.pei_fecha = DateTime.Now;

                    if (_actBD.ActualizarPedidoInventario(_seleccionado))
                        CargarGrilla();
                    else
                        MessageBox.Show("Error al actualizar el pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("No se puede entregar el pedido.\nEstado: " + _seleccionado.pes_codigo + " - " + _seleccionado.pes_denom + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                PedidoInventario _seleccionado = (PedidoInventario)Grid.SelectedRows[0].DataBoundItem;

                if (_seleccionado.pes_codigo == 3)
                {
                    _seleccionado.pes_codigo = 4;
                    _seleccionado.pei_fecha = DateTime.Now;

                    if (_actBD.ActualizarPedidoInventario(_seleccionado))
                        CargarGrilla();
                    else
                        MessageBox.Show("Error al actualizar el pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("El pedido tiene que estar en entrega.\nEstado: " + _seleccionado.pes_codigo + " - " + _seleccionado.pes_denom + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                PedidoInventario _seleccionado = (PedidoInventario)Grid.SelectedRows[0].DataBoundItem;

                if (_seleccionado.pes_codigo < 4)
                {
                    _seleccionado.pes_codigo = 5;
                    _seleccionado.pei_fecha = DateTime.Now;

                    if (_actBD.ActualizarPedidoInventario(_seleccionado))
                        CargarGrilla();
                    else
                        MessageBox.Show("Error al actualizar el pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("No se puede cancelar este pedido.\nEstado: " + _seleccionado.pes_codigo + " - " + _seleccionado.pes_denom + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnComentario_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                PedidoInventario _seleccionado = (PedidoInventario)Grid.SelectedRows[0].DataBoundItem;
                if (_seleccionado.pes_codigo < 4)
                {
                    _seleccionado.pei_fecha = DateTime.Now;
                    _seleccionado.pei_comentario = Interaction.InputBox("Ingrese nuevo comentario:", "Comentario", _seleccionado.pei_comentario);

                    if (_actBD.ActualizarPedidoInventario(_seleccionado))
                        CargarGrilla();
                    else
                        MessageBox.Show("Error al actualizar el pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("No se puede comentar este pedido.\nEstado: " + _seleccionado.pes_codigo + " - " + _seleccionado.pes_denom + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
