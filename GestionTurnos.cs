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
    public partial class GestionTurnos : Form
    {
        public Object _lista { get; set; }
        public Usuario Usuario { get; set; }
        Consultas _consu = new Consultas();
        ActualizarBD _actBD = new ActualizarBD();

        public GestionTurnos()
        {
            InitializeComponent();
        }

        #region "Eventos"

        private void GrillaSeleccionar_Load(object sender, EventArgs e)
        {
            InicializarGrilla();

            CargarGrilla();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {        
            String _buscar = txtBuscar.Text.Trim();
            Grid.DataSource = _consu.DevolverListaTurnosGestion(_buscar);

            if (Grid.Rows.Count == 0) MessageBox.Show("No hay datos para buscar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else PintarFilas();
        }

        private void btnCambiarPrioridad_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                ListaPrioridades _frm = new ListaPrioridades();
                if (_frm.ShowDialog() == DialogResult.OK)
                {
                    Turno _seleccionado = (Turno)Grid.SelectedRows[0].DataBoundItem;
                    _seleccionado.tni_codigo = _frm.tni_codigo;

                    if (_actBD.ModificarTurno(_seleccionado))
                        CargarGrilla();
                    else
                        MessageBox.Show("Error al actualizar el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAsignarMedico_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                Turno _seleccionado = (Turno)Grid.SelectedRows[0].DataBoundItem;
                List<Usuario> _listaUsuarios = _consu.DevolverListaUsuarios("", 2);

                GrillaSeleccionar _frm = new GrillaSeleccionar();
                _frm._lista = _listaUsuarios;
                _frm._textoColumna = "UsuariosMedicos";
                if (_frm.ShowDialog() == DialogResult.OK)
                {
                    Usuario _usu = (Usuario)_frm._seleccionado;
                    _seleccionado.usu_usuarioToma = _usu.usu_usuario;
                    _seleccionado.tur_en_espera = 1;

                    if (_actBD.ModificarTurno(_seleccionado))
                        CargarGrilla();
                    else
                        MessageBox.Show("Error al actualizar el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                Turno _seleccionado = (Turno)Grid.SelectedRows[0].DataBoundItem;
                _seleccionado.usu_usuarioToma = "";
                _seleccionado.tur_en_espera = 0;
                _seleccionado.tur_cancelado = 1;
                _seleccionado.tur_fechaCierre = DateTime.Today;

                if (_actBD.ModificarTurno(_seleccionado))
                    CargarGrilla();
                else
                    MessageBox.Show("Error al actualizar el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSacarMedico_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                Turno _seleccionado = (Turno)Grid.SelectedRows[0].DataBoundItem;                           
                _seleccionado.usu_usuarioToma = "";
                _seleccionado.tur_en_espera = 0;

                if (_actBD.ModificarTurno(_seleccionado))
                    CargarGrilla();
                else
                    MessageBox.Show("Error al actualizar el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Métodos"

        //private void CargarTurno()
        //{
        //    if (Grid.Rows.Count > 0)
        //    {
        //        _seleccionado = (Turno)Grid.SelectedRows[0].DataBoundItem;

        //        if (new ActualizarBD().TomarTurno(_seleccionado.tur_codigo, Usuario.usu_usuario))
        //        {
        //            this.DialogResult = DialogResult.OK;
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error al actualizar el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //    }
        //}

        private void CargarGrilla()
        {
            Grid.DataSource = _consu.DevolverListaTurnosGestion();

            PintarFilas();
        }

        private void InicializarGrilla()
        {
            Grid.AutoGenerateColumns = false;
            Grid.Columns.Clear();
            Grid.Columns.Add("tur_fecha", "Fecha ingreso");
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

            Grid.Columns.Add("usu_usuarioToma", "Médico en espera");
            Grid.Columns["usu_usuarioToma"].DataPropertyName = "usu_usuarioToma";
            Grid.Columns["usu_usuarioToma"].Width = 120;
            Grid.Columns["usu_usuarioToma"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["usu_usuarioToma"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
