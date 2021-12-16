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
    public partial class GrillaSeleccionar : Form
    {
        public Object _lista { get; set; }
        public String _textoColumna { get; set; } = "";
        public Object _seleccionado { get; set; }
        public Boolean _nuevo { get; set; } = false;
        private Consultas _consu = new Consultas();

        public GrillaSeleccionar()
        {
            InitializeComponent();
        }

        #region "Eventos"

        private void GrillaSeleccionar_Load(object sender, EventArgs e)
        {
            if (_textoColumna == "PedidoComplementarios")
            {
                this.Text = "Pedidos complementarios";

                Grid.DataSource = _lista;

                for (int i = 0; i < Grid.Columns.Count; i++)
                {
                    if (i == 11)
                    {
                        Grid.Columns[i].Width = 430;
                        Grid.Columns[i].HeaderText = "Nombre paciente - Tipo método complementario";
                    }
                    else
                        Grid.Columns[i].Visible = false;
                }
            }
            else
            {
                this.Text = _textoColumna;

                Grid.DataSource = _lista;

                for (int i = 0; i < Grid.Columns.Count; i++)
                {
                    if (i == 1)
                    {
                        Grid.Columns[i].Width = 430;
                        Grid.Columns[i].HeaderText = _textoColumna;
                    }
                    else
                        Grid.Columns[i].Visible = false;
                }
            }

            btnNuevo.Visible = _nuevo;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }

        #endregion

        #region "Eventos"

        private void Seleccionar()
        {
            if (Grid.Rows.Count > 0)
            {
                _seleccionado = Grid.SelectedRows[0].DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String _buscar = txtBuscar.Text.Trim();

            switch (_textoColumna)
            {
                case "Barrios":
                    Grid.DataSource = _consu.DevolverListaBarrios(_buscar);
                    break;
                case "Usuarios":
                    Grid.DataSource = _consu.DevolverListaUsuarios(_buscar);
                    break;
                case "UsuariosMedicos":
                    Grid.DataSource = _consu.DevolverListaUsuarios(_buscar, 2);
                    break;
                case "Pacientes":
                    Grid.DataSource = _consu.DevolverListaPacientes(_buscar);
                    break;
                case "PedidoComplementarios":
                    Grid.DataSource = _consu.DevolverListaPedidosComplementariosAbiertos(_buscar);
                    break;
                default:
                    MessageBox.Show("No se encontró el método de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }

            if (Grid.Rows.Count == 0) MessageBox.Show("No hay datos para buscar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            switch (_textoColumna)
            {
                case "Barrios":
                    //Grid.DataSource = _consu.DevolverListaBarrios(_buscar);
                    break;
                case "Usuarios":
                    //Grid.DataSource = _consu.DevolverListaUsuarios(_buscar);
                    break;
                case "Pacientes":
                    PacienteABM _frm = new PacienteABM();
                    _frm.ShowDialog();
                    Grid.DataSource = _consu.DevolverListaPacientes();
                    break;
                default:
                    MessageBox.Show("No se encontró el ABM.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }
    }
}
