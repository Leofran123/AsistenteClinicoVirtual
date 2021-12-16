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
    public partial class ListaPrioridades : Form
    {
        public Int32 tni_codigo { get; set; }

        public ListaPrioridades()
        {
            InitializeComponent();
        }

        private void GrillaPrioridades_Load(object sender, EventArgs e)
        {
            Grid.DataSource = new Consultas().DevolverListaPrioridades(false);
            Grid.Columns[0].Visible = false;
            Grid.Columns[1].Width = 218;

            PintarFilas();
        }

        private void PintarFilas()
        {
            foreach (DataGridViewRow row in Grid.Rows)
            {
                Int32 _prioridadCodigo = Convert.ToInt32(row.Cells[0].Value);

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

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                ObjetoGral _seleccionado = (ObjetoGral)Grid.SelectedRows[0].DataBoundItem;
                tni_codigo = _seleccionado.codigo;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
