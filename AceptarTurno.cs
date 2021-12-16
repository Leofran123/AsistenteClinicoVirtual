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
    public partial class AceptarTurno : Form
    {
        public Object _lista { get; set; }
        public Turno _seleccionado { get; set; }
        public Usuario Usuario { get; set; }
        Consultas _consu = new Consultas();

        public AceptarTurno()
        {
            InitializeComponent();
        }

        #region "Eventos"

        private void GrillaSeleccionar_Load(object sender, EventArgs e)
        {
            InicializarGrilla();

            Grid.DataSource = _consu.DevolverListaTurnosPrioridad();

            PintarFilas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            CargarTurno();
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            CargarTurno();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String _buscar = txtBuscar.Text.Trim();
            Grid.DataSource = _consu.DevolverListaTurnosPrioridad(_buscar);

            if (Grid.Rows.Count == 0) MessageBox.Show("No hay datos para buscar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else PintarFilas();
        }

        #endregion

        #region "Métodos"

        private void CargarTurno()
        {
            if (Grid.Rows.Count > 0)
            {
                _seleccionado = (Turno)Grid.SelectedRows[0].DataBoundItem;

                if (new ActualizarBD().TomarTurno(_seleccionado.tur_codigo, Usuario.usu_usuario))
                {
                    _seleccionado.usu_usuarioToma = Usuario.usu_usuario;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void InicializarGrilla()
        {
            Grid.AutoGenerateColumns = false;
            Grid.Columns.Clear();
            Grid.Columns.Add("tur_fecha", "Fecha");
            Grid.Columns["tur_fecha"].DataPropertyName = "tur_fecha";
            Grid.Columns["tur_fecha"].Width = 100;
            Grid.Columns["tur_fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["tur_fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid.Columns["tur_fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            Grid.Columns.Add("pac_nombreCompleto", "Paciente");
            Grid.Columns["pac_nombreCompleto"].DataPropertyName = "pac_nombreCompleto";
            Grid.Columns["pac_nombreCompleto"].Width = 330;
            Grid.Columns["pac_nombreCompleto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["pac_nombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            Grid.Columns.Add("tni_denom", "Prioridad");
            Grid.Columns["tni_denom"].DataPropertyName = "tni_denom";
            Grid.Columns["tni_denom"].Width = 80;
            Grid.Columns["tni_denom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["tni_denom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            Grid.Columns.Add("tni_codigo", "tni_codigo");
            Grid.Columns["tni_codigo"].DataPropertyName = "tni_codigo";
            Grid.Columns["tni_codigo"].Visible = false;
        }

        private void PintarFilas()
        {
            foreach (DataGridViewRow row in Grid.Rows)
            {
                Int32 _prioridadCodigo = Convert.ToInt32(row.Cells[3].Value);

                switch (_prioridadCodigo)
                {
                    case 1:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 108, 177, 255);
                        break;
                    case 2:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 122, 255, 108);
                        break;
                    case 3:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 251, 108);
                        break;
                    case 4:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 177, 108);
                        break;
                    case 5:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 108, 108);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
