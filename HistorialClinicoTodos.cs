using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaFinal.Formularios
{
    public partial class HistorialClinicoTodos : Form
    {
        Consultas _consu = new Consultas();
        public Int32 Hic_numero { get; set; }
        public Usuario Usuario { get; set; }
        public Paciente Paciente { get; set; }
        private List<IndiceHC> _indices;

        public HistorialClinicoTodos()
        {
            InitializeComponent();
        }

        #region "Métodos"    

        private void CargarDatos()
        {
            lblHC.Text = "Historial clínico N° " + Hic_numero;
            lblPaciente.Text = "Paciente: " + Paciente.nombre_completo;
            txtFechaDesde.Text = DateTime.Now.AddYears(-1).ToShortDateString();
            txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            Buscar();           
        }

        private void Buscar()
        {
            DateTime _fechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _fechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            Int32 _fichaDesde = Convert.ToInt32(txtFichaDesde.Text);
            Int32 _fichaHasta = Convert.ToInt32(txtFichaHasta.Text);
            Int32 _metComplDesde = Convert.ToInt32(txtMetComplDesde.Text);
            Int32 _metComplHasta = Convert.ToInt32(txtMetComplHasta.Text);

            _indices = _consu.DevolverListaIndicexHCFiltros(Hic_numero, _fechaDesde, _fechaHasta, _fichaDesde, _fichaHasta,
                                                            _metComplDesde, _metComplHasta);
        }

        private void CargarPanel()
        {
            if (_indices != null)
            {
                Int32 _topRatio = 110;
                Int32 _contIndice = 0;
                foreach (IndiceHC _it in _indices)
                {
                    //panel contenedor
                    Panel _panel = new Panel();
                    _panel.BorderStyle = BorderStyle.FixedSingle;
                    _panel.Width = pnlTest.Width;
                    _panel.Height = pnlTest.Height;
                    _panel.Top = (_contIndice * _topRatio + 12);
                    _panel.Left = 5;

                    Label _labelTipo = new Label();
                    _labelTipo.Size = lblTestTipo.Size;
                    _labelTipo.Text = _it.tipo == "F" ? ("Ficha - " + _it.codigo) : ("Mét complementario - " + _it.codigo);
                    _labelTipo.Location = lblTestTipo.Location;
                    _labelTipo.Font = lblTestTipo.Font;
                    _panel.Controls.Add(_labelTipo);

                    Label _labelMedico = new Label();
                    _labelMedico.Text = lblTestMedico.Text;
                    _labelMedico.Location = lblTestMedico.Location;
                    _labelMedico.Size = lblTestMedico.Size;
                    _labelMedico.Font = lblTestMedico.Font;
                    _panel.Controls.Add(_labelMedico);

                    TextBox _txtMedico = new TextBox();
                    _txtMedico.Text = _it.medico;
                    _txtMedico.Location = txtTestMedico.Location;
                    _txtMedico.Size = txtTestMedico.Size;
                    _txtMedico.ReadOnly = true;
                    _txtMedico.Font = txtTestMedico.Font;
                    _panel.Controls.Add(_txtMedico);

                    Label _labelFecha = new Label();
                    _labelFecha.Text = lblTestFecha.Text;
                    _labelFecha.Location = lblTestFecha.Location;
                    _labelFecha.Size = lblTestFecha.Size;
                    _labelFecha.Font = lblTestFecha.Font;
                    _panel.Controls.Add(_labelFecha);

                    TextBox _txtFecha = new TextBox();
                    _txtFecha.Text = _it.fecha.ToString("dd/MM/yyyy HH:mm");
                    _txtFecha.Location = txtTestFecha.Location;
                    _txtFecha.Size = txtTestFecha.Size;
                    _txtFecha.ReadOnly = true;
                    _txtFecha.Font = txtTestFecha.Font;
                    _panel.Controls.Add(_txtFecha);

                    Button _button = new Button();
                    _button.Text = "Ver";
                    _button.Location = btnTest.Location;
                    _button.Size = btnTest.Size;
                    _button.Font = btnTest.Font;
                    _button.Tag = _it;
                    _button.Click += new EventHandler(botonGenerado_Click);
                    _button.TabIndex = 20;
                    _panel.Controls.Add(_button);

                    Label _labelMotCom = new Label();
                    _labelMotCom.Text = _it.tipo == "F" ? "Motivo ingreso" : "Comentario";
                    _labelMotCom.Location = lblTestMotComen.Location;
                    _labelMotCom.Size = lblTestMotComen.Size;
                    _labelMotCom.Font = lblTestMotComen.Font;
                    _panel.Controls.Add(_labelMotCom);

                    TextBox _txtMotCom = new TextBox();
                    _txtMotCom.Text = _it.motCom;
                    _txtMotCom.Location = txtTestMotCom.Location;
                    _txtMotCom.Size = txtTestMotCom.Size;
                    _txtMotCom.ReadOnly = true;
                    _txtMotCom.Font = txtTestMotCom.Font;
                    _panel.Controls.Add(_txtMotCom);

                    Label _labelTraRes = new Label();
                    _labelTraRes.Text = _it.tipo == "F" ? "Tratamiento" : "Resultado";
                    _labelTraRes.Location = lblTestTraRes.Location;
                    _labelTraRes.Size = lblTestTraRes.Size;
                    _labelTraRes.Font = lblTestTraRes.Font;
                    _panel.Controls.Add(_labelTraRes);

                    TextBox _txtTraRes = new TextBox();
                    _txtTraRes.Text = _it.traRes;
                    _txtTraRes.Location = txtTestTraRes.Location;
                    _txtTraRes.Size = txtTestTraRes.Size;
                    _txtTraRes.ReadOnly = true;
                    _txtTraRes.Font = txtTestTraRes.Font;
                    _panel.Controls.Add(_txtTraRes);

                    panelContenedor.Controls.Add(_panel);
                    _contIndice++;
                }
            }
        }


        #endregion

        #region "Eventos"

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HistorialClinico_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarPanel();
        }


        protected void botonGenerado_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            IndiceHC _ind = (IndiceHC)button.Tag;

            if (_ind.tipo == "F")
            {
                FichaMedABM _frm = new FichaMedABM();
                _frm.SoloLectura = true;
                _frm.Usuario = Usuario;
                _frm.Ficha = _consu.DevolverFichaMedicaxCodigo(_ind.codigo);
                _frm.ShowDialog();
            }
            else
            {
                ConsultaPedidoMetComplementario _frm = new ConsultaPedidoMetComplementario();
                _frm.Usuario = Usuario;
                _frm.Pedido = new Consultas().DevolverUltimoPedMetComplementarioxCodigo(_ind.codigo);
                _frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Buscar();
            panelContenedor.Controls.Clear();
            CargarPanel();
        }
        #endregion


    }
}
