using Microsoft.VisualBasic;
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
    public partial class MenuGeneral : Form
    {
        private Usuario _usuario;
        private Turno _turnoTomado = null;
        private Boolean _generoFichaMed = false;
        private ActualizarBD _actBD = new ActualizarBD();
        private Consultas _consu = new Consultas();
        private Int32 _hicNumeroPaciente;
        private Int32 _nroSalaMedico;

        public MenuGeneral(Usuario _usu)
        {
            InitializeComponent();
            _usuario = _usu;

            //Solo para medicos
            if (_usu.rol_codigo == 2)
            {
                String _nroSalaStr = "";

                do
                {
                    _nroSalaStr = Interaction.InputBox("Favor de ingresar su número de sala:", "Sala", "");
                    Int32.TryParse(_nroSalaStr, out _nroSalaMedico);
                }
                while (_nroSalaMedico == 0 || _nroSalaStr.Length > 8);

                this.Text += " - Usuario: " + _usuario.usu_usuario + " - Sala Nro. " + _nroSalaMedico;
            }
            else
            {
                this.Text += " - Usuario: " + _usuario.usu_usuario;
            }
        }

        private void MenuGeneral_Load(object sender, EventArgs e)
        {
            switch(_usuario.rol_codigo)
            {
                case 2://medico
                    mitAdministracion.Visible = false;
                    //
                    mitPacientesGestion.Visible = false;
                    mitAsignarTurno.Visible = false;
                    //
                    mitInformes.Visible = false;
                    break;
                case 3://enfermero
                    mitUsuarios.Visible = false;
                    mitGestionTurnos.Visible = false;
                    //
                    mitPaciente.Visible = false;
                    //
                    mitSubirMetCompl.Visible = false;
                    mitPedidoInsumo.Visible = false;
                    //
                    mitInformes.Visible = false;
                    break;
                case 4://secretario
                    mitUsuarios.Visible = false;
                    mitInventario.Visible = false;
                    //
                    mitAceptarTurnos.Visible = false;
                    //
                    mitPedidos.Visible = false;
                    break;
            }
        }

        #region "Administracion"

        private void mitUsuarios_Click(object sender, EventArgs e)
        {
            UsuarioABM _frm = new UsuarioABM();
            _frm.ShowDialog();
        }

        #endregion

        private void mitPacientes_Click(object sender, EventArgs e)
        {
            PacienteABM _frm = new PacienteABM();
            _frm.ShowDialog();
        }

        private void mitAsignarTurno_Click(object sender, EventArgs e)
        {
            AsignarTurno _frm = new AsignarTurno();
            _frm.Usuario = _usuario;
            _frm.ShowDialog();
        }

        private void mitAceptarTurnos_Click(object sender, EventArgs e)
        {
            if (_turnoTomado == null)
            {
                Turno _turnoAux = _consu.DevolverTurnoEnEspera(_usuario.usu_usuario);

                if (_turnoAux != null)
                {
                    MessageBox.Show("Se procedera a cargar un turno es espera.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AceptarTurno _frm = new AceptarTurno();
                    _frm.Usuario = _usuario;

                    if (_frm.ShowDialog() == DialogResult.OK)
                    {
                        _turnoAux = _frm._seleccionado;
                        _frm.Close();
                    }
                }

                if (_turnoAux != null)
                {
                    _turnoTomado = _turnoAux;
                    _turnoTomado.tur_en_espera = 0;
                    _hicNumeroPaciente = _actBD.ObtenerHicNumero(_turnoTomado.pac_codigo);
                    pnlPaciente.Visible = true;
                    txtPaciente.Text = _turnoTomado.pac_nombreCompleto;
                    txtTurno.Text = _turnoTomado.tur_codigo.ToString() + " - " + _turnoTomado.tni_denom;
                }
            }
            else
                MessageBox.Show("Favor de terminar con el turno cargado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mitCerrarSesion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCargarFichaMed_Click(object sender, EventArgs e)
        {
            FichaMedABM _frm = new FichaMedABM();
            _frm.Usuario = _usuario;
            _frm.Hic_numero = _hicNumeroPaciente;
            if (!_generoFichaMed) _generoFichaMed = _frm.ShowDialog() == DialogResult.OK;
            else
            {
                _frm.Modificar = true;
                _frm.ShowDialog();
            }
        }

        private void btnAntecendentes_Click(object sender, EventArgs e)
        {
            AntecedentesABM _frm = new AntecedentesABM();
            _frm.Hic_numero = _hicNumeroPaciente;
            _frm.ShowDialog();
        }

        private void btnHistorialClinica_Click(object sender, EventArgs e)
        {
            HistorialClinico _frm = new HistorialClinico();
            _frm.Hic_numero = _hicNumeroPaciente;
            _frm.Usuario = _usuario;
            _frm.ShowDialog();
        }

        private void btnDevolverPaciente_Click(object sender, EventArgs e)
        {
            _turnoTomado.usu_usuarioToma = "";

            if (_actBD.ModificarTurno(_turnoTomado))
            {
                pnlPaciente.Visible = false;
                _turnoTomado = null;
            }
            else
                MessageBox.Show("Error al actualizar el turno del paciente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCerrarPaciente_Click(object sender, EventArgs e)
        {
            _turnoTomado.tur_fechaCierre = DateTime.Today;

            if (_actBD.ModificarTurno(_turnoTomado))
            {
                pnlPaciente.Visible = false;
                _turnoTomado = null;
            }
            else
                MessageBox.Show("Error al actualizar el turno del paciente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnPasarPaciente_Click(object sender, EventArgs e)
        {
            Usuario _usu;
            GrillaSeleccionar _frm = new GrillaSeleccionar();
            _frm._lista = _consu.DevolverListaUsuarios("", 2);
            _frm._textoColumna = "UsuariosMedicos";

            if (_frm.ShowDialog() == DialogResult.OK)
            {
                _usu = (Usuario)_frm._seleccionado;
                _turnoTomado.usu_usuarioToma = _usu.usu_usuario;
                _turnoTomado.tur_en_espera = 1;

                if (_actBD.ModificarTurno(_turnoTomado))
                {
                    pnlPaciente.Visible = false;
                    _turnoTomado = null;
                }
                else
                    MessageBox.Show("Error al actualizar el turno del paciente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mitInventario_Click(object sender, EventArgs e)
        {
            InventarioABM _frm = new InventarioABM();
            _frm.ShowDialog();
        }

        private void gestionarTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionTurnos _frm = new GestionTurnos();
            _frm.ShowDialog();
        }       

        private void estadosDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteFichaEstados _rpt = new ReporteFichaEstados();
            _rpt.ShowDialog();
        }

        private void historialesClínicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrillaSeleccionar _frm = new GrillaSeleccionar();
            _frm._lista = _consu.DevolverListaHC();
            _frm._textoColumna = "Pacientes";
            if (_frm.ShowDialog() == DialogResult.OK)
            {
                Int32 _hcPaciente = ((ObjetoGral)_frm._seleccionado).codigo;

                Paciente _pac = _consu.DevolverPacientexHC(_hcPaciente);
                HistorialClinicoTodos _frm2 = new HistorialClinicoTodos();
                _frm2.Hic_numero = _hcPaciente;
                _frm2.Paciente = _pac;
                _frm2.Usuario = _usuario;
                _frm2.ShowDialog();
            }
        }

        private void btnCargaPedCompl_Click(object sender, EventArgs e)
        {
            if (_turnoTomado != null)
            {
                AltaPedidoMetComplementario _frm = new AltaPedidoMetComplementario();
                _frm.Usuario = _usuario;
                _frm.Pac_codigo = _turnoTomado.pac_codigo;
                _frm.NroSala = _nroSalaMedico;
                _frm.ShowDialog();
            }
            else
                MessageBox.Show("Tiene que haber un paciente cargado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metComplementariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrillaSeleccionar _formGrilla = new GrillaSeleccionar();
            _formGrilla._lista = _consu.DevolverListaPedidosComplementariosAbiertos();
            _formGrilla._textoColumna = "PedidoComplementarios";

            if (_formGrilla.ShowDialog() == DialogResult.OK)
            {
                FinalizarPedidoMetComplementario _frm = new FinalizarPedidoMetComplementario();
                _frm.Pedido = (PedidoMetComplementario)_formGrilla._seleccionado;
                _frm.Usuario = _usuario;
                _frm.ShowDialog();
            }            
        }

        private void edadDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteFichaEdad _rpt = new ReporteFichaEdad();
            _rpt.ShowDialog();
        }

        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteInsumoFaltantes _rpt = new ReporteInsumoFaltantes();
            _rpt.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ContratoyPregFrec _frm = new ContratoyPregFrec();
            _frm.EsPregFrec = true;
            _frm.ShowDialog();
        }

        private void mitPedidoInv_Click(object sender, EventArgs e)
        {
            AltaPedidoInventario _frm = new AltaPedidoInventario();
            _frm.Usuario = _usuario;
            _frm.NroSala = _nroSalaMedico;
            _frm.ShowDialog();
        }

        private void gestionInsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionPedidoInventario _frm = new GestionPedidoInventario();
            if (_usuario.rol_codigo == 2) _frm._soloLectura = true;
            _frm.Usuario = _usuario;
            _frm.ShowDialog();
        }
    }
}
