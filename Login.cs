using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PracticaFinal.Formularios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (Validar()) Loguear();
        }

        private Boolean Validar()
        {
            if (txtUsuario.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese un usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtClave.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese una clave.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void Loguear()
        {
            Consultas _consultas = new Consultas();
            String _usuario = txtUsuario.Text.Trim(), _clave = txtClave.Text;
            Boolean _existeUsuario = _consultas.ExisteUsuario(_usuario);

            if (_existeUsuario)
            {
                Usuario _usu = _consultas.DevolverUsuarioxUsuarioClave(_usuario, _clave);

                if (_usu == null) MessageBox.Show("Clave incorrecta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (_usu.usu_habilitado)
                    {
                        this.Visible = false;
                        MenuGeneral _frm = new MenuGeneral(_usu);
                        if (_frm.ShowDialog() == DialogResult.Cancel)
                            this.Close();
                        else
                        {
                            this.Visible = true;
                            txtClave.Text = "";
                            txtUsuario.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario deshabilitado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                    
                }
            }
            else
                MessageBox.Show("Usuario no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                if (Validar()) Loguear();
        }

        private void Login_LoadAsync(object sender, EventArgs e)
        {
            String _path = Directory.GetCurrentDirectory() + @"\contrato.txt";
            if (File.Exists(_path) && File.ReadAllText(_path).Equals("0"))
            {
                ContratoyPregFrec _frm = new ContratoyPregFrec();
                if (_frm.ShowDialog() == DialogResult.Yes)
                {
                    File.WriteAllText(_path, "1");
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
