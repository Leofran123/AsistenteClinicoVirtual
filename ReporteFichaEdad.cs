using Microsoft.Reporting.WinForms;
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
    public partial class ReporteFichaEdad : Form
    {
        public Object _lista { get; set; }
        public Turno _seleccionado { get; set; }
        public Usuario Usuario { get; set; }
        Consultas _consu = new Consultas();

        public ReporteFichaEdad()
        {
            InitializeComponent();
        }

        #region "Eventos"

        private void GrillaSeleccionar_Load(object sender, EventArgs e)
        {
            InicializarFiltros();
            this.reportViewer1.RefreshReport();
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

        }

        #endregion

        #region "Métodos"

        private void CargarTurno()
        {

        }

        private void InicializarFiltros()
        {
            cmbMes.DisplayMember = "Text";
            cmbMes.ValueMember = "Value";
            var _items = new[] {
                new { Text = "Enero", Value = "1" },
                new { Text = "Febrero", Value = "2" },
                new { Text = "Marzo", Value = "3" },
                new { Text = "Abril", Value = "4" },
                new { Text = "Mayo", Value = "5" },
                new { Text = "Junio", Value = "6" },
                new { Text = "Julio", Value = "7" },
                new { Text = "Agosto", Value = "8" },
                new { Text = "Septiembre", Value = "9" },
                new { Text = "Octubre", Value = "10" },
                new { Text = "Noviembre", Value = "11" },
                new { Text = "Diciembre", Value = "12" }};
            cmbMes.DataSource = _items;

            cmbAnio.DisplayMember = "denom";
            cmbAnio.ValueMember = "codigo";
            Int32 _anioActual = DateTime.Now.Year;
            List<ObjetoGral> _listaAnios = new List<ObjetoGral>();
            for (int i = _anioActual; i > (_anioActual - 10); i--)
            {
                ObjetoGral _og = new ObjetoGral();
                _og.codigo = i;
                _og.denom = i.ToString();
                _listaAnios.Add(_og);
            }
            cmbAnio.DataSource = _listaAnios;

            cmbMes.SelectedIndex = -1;
        }

        #endregion

        private void chkMes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMes.Checked)
            {
                cmbMes.Enabled = true;
                cmbMes.SelectedIndex = 0;
            }
            else
            {
                cmbMes.Enabled = false;
                cmbMes.SelectedIndex = -1;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void CargarReporte()
        {
            reportViewer1.Reset();
            Int32 _mes = cmbMes.SelectedIndex + 1;
            Int32 _anio = Convert.ToInt32(cmbAnio.SelectedValue.ToString());

            List<ReporteVariables> _lista = _consu.DevolverListaReporteFichaEdad(_mes, _anio);

            if (_lista == null)
            {
                MessageBox.Show("No se encontraron datos con los filtros seleccionados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport _localReport = reportViewer1.LocalReport;
            _localReport.ReportPath = "FichaEdad.rdlc";
            //ReportDataSource _report = new ReportDataSource();
            //_report.Name = "Dataset1";
            //_///report.Value = _lista;
            //_localReport.DataSources.Add(_report);

            String _periodo = "";
            if (_mes != 0) _periodo = _mes + "/" + _anio;
            else _periodo = _anio.ToString();
            ReportParameter[] parameters = new ReportParameter[10];
            parameters[0] = new ReportParameter("Periodo", "Periodo: " + _periodo);
            parameters[1] = new ReportParameter("edad1", _lista.First().edad010.ToString());
            parameters[2] = new ReportParameter("edad2", _lista.First().edad1120.ToString());
            parameters[3] = new ReportParameter("edad3", _lista.First().edad2130.ToString());
            parameters[4] = new ReportParameter("edad4", _lista.First().edad3140.ToString());
            parameters[5] = new ReportParameter("edad5", _lista.First().edad4150.ToString());
            parameters[6] = new ReportParameter("edad6", _lista.First().edad5160.ToString());
            parameters[7] = new ReportParameter("edad7", _lista.First().edad6170.ToString());
            parameters[8] = new ReportParameter("edad8", _lista.First().edad7180.ToString());
            parameters[9] = new ReportParameter("edad9", _lista.First().edad80plus.ToString());
            _localReport.SetParameters(parameters);

            reportViewer1.RefreshReport();

        }
    }
}
