using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace PracticaFinal
{
    class Consultas
    {
        private String _conexion = @"Server =.\SQLEXPRESS;Database=PracticaSupervisada;User Id = usuario2; Password=pass123;";
        //private String _conexion = @"Server =DESKTOP-QD5GTOD\SQLEXPRESS;Database=PracticaSupervisada;User Id = usuario1; Password=pass123;";

        #region "Devolver datos"

        private ObjetoGral CargarObjetoGral(SqlDataReader _dr)
        {
            ObjetoGral _objGrl = new ObjetoGral();
            _objGrl.codigo = Convert.ToInt32(_dr[0]);
            _objGrl.denom = _dr[1].ToString();

            return _objGrl;
        }

        public List<ObjetoGral> DevolverListaBarrios(String _busqueda = "")
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT brr_codigo, brr_denom FROM Barrios";
                if (_busqueda != "") _sentencia += " WHERE UPPER(brr_denom) LIKE '%" + _busqueda.ToUpper() + "%'";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ObjetoGral>();
                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        public ObjetoGral DevolverBarrioxCodigo(Int32 _codigo)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            ObjetoGral _usu = null;

            try
            {
                String _sentencia = "SELECT brr_codigo, brr_denom FROM Barrios" +
                                   " WHERE brr_codigo = @p_codigo";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_codigo", _codigo);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                    _usu = CargarObjetoGral(_reader);
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _usu;
        }

        public Usuario DevolverUsuarioxUsuario(String _usuario)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            Usuario _usu = null;

            try
            {
                String _sentencia = "SELECT usu_usuario, usu_clave, usu_nombre, usu_apellido, usu_email," +
                                        " usu_telefono, usu_nacimiento, usu_direccion, brr_codigo, usu_documento," +
                                        " est_codigo, usu_sexo, esp_codigo, usu_matricula, rol_codigo, usu_habilitado" +
                                   " FROM usuarios" +
                                   " WHERE UPPER(usu_usuario) = UPPER(@p_usuario)";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usuario", _usuario);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                    _usu = CargarUsuario(_reader);
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _usu;
        }
        public Usuario DevolverUsuarioxUsuarioClave(String _usuario, String _clave)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            Usuario _usu = null;

            try
            {
                String _sentencia = "SELECT usu_usuario, usu_clave, usu_nombre, usu_apellido, usu_email," +
                                        " usu_telefono, usu_nacimiento, usu_direccion, brr_codigo, usu_documento," +
                                        " est_codigo, usu_sexo, esp_codigo, usu_matricula, rol_codigo, usu_habilitado" +
                                   " FROM usuarios" +
                                   " WHERE UPPER(usu_usuario) = UPPER(@p_usuario) AND usu_clave = @p_clave";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usuario", _usuario);
                _command.Parameters.AddWithValue("@p_clave", _clave);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                    _usu = CargarUsuario(_reader);
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _usu;
        }
        public List<Usuario> DevolverListaUsuarios(String _busqueda = "", Int32 _rol = -1)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<Usuario> _lista = new List<Usuario>();

            try
            {
                String _sentencia = "SELECT usu_usuario, usu_clave, usu_nombre, usu_apellido, usu_email," +
                                        " usu_telefono, usu_nacimiento, usu_direccion, brr_codigo, usu_documento," +
                                        " est_codigo, usu_sexo, esp_codigo, usu_matricula, rol_codigo, usu_habilitado" +
                                   " FROM usuarios" +
                                   " WHERE 1=1 ";
                if (_busqueda != "") _sentencia += " AND (UPPER(usu_usuario) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                        " OR UPPER(usu_nombre) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                        " OR UPPER(usu_apellido) LIKE '%" + _busqueda.ToUpper() + "%')";
                if (_rol != -1) _sentencia += " AND rol_codigo = 2";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    _lista.Add(CargarUsuario(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        private Usuario CargarUsuario(SqlDataReader _dr)
        {
            Usuario _usu = new Usuario();

            _usu.usu_usuario = _dr[0].ToString();
            _usu.usu_clave = _dr[1].ToString();
            _usu.usu_nombre = _dr[2].ToString();
            _usu.usu_apellido = _dr[3].ToString();
            _usu.usu_email = _dr[4].ToString();
            _usu.usu_telefono = _dr[5].ToString();
            _usu.usu_nacimiento = Convert.ToDateTime(_dr[6]);
            _usu.usu_direccion = _dr[7].ToString();
            _usu.brr_codigo = Convert.ToInt32(_dr[8]);
            _usu.usu_documento = Convert.ToInt32(_dr[9]);
            _usu.est_codigo = Convert.ToInt32(_dr[10]);
            _usu.usu_sexo = _dr[11].ToString();
            _usu.esp_codigo = Convert.ToInt32(_dr[12]);
            _usu.usu_matricula = Convert.ToInt32(_dr[13]);
            _usu.rol_codigo = Convert.ToInt32(_dr[14]);
            _usu.usu_habilitado = Convert.ToInt32(_dr[15]) == 1;

            return _usu;
        }

        public List<ObjetoGral> DevolverListaEspecialidades()
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT esp_codigo, esp_denom FROM Especialidades";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ObjetoGral>();
                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }

        public List<ObjetoGral> DevolverListaObrasSociales()
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT obr_codigo, obr_denom FROM ObrasSociales";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ObjetoGral>();
                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }

        public List<ObjetoGral> DevolverListaEstadosCiviles()
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT est_codigo, est_denom FROM EstadosCiviles";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null)
                    {
                        _lista = new List<ObjetoGral>();
                        ObjetoGral _obj = new ObjetoGral();
                        _obj.codigo = -1;
                        _obj.denom = "Seleccione";
                        _lista.Add(_obj);
                    }
                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }

        public List<ObjetoGral> DevolverListaRoles()
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT rol_codigo, rol_denom FROM Roles";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null)
                    {
                        _lista = new List<ObjetoGral>();
                        ObjetoGral _obj = new ObjetoGral();
                        _obj.codigo = -1;
                        _obj.denom = "Seleccione";
                        _lista.Add(_obj);
                    }
                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }

        public List<Paciente> DevolverListaPacientes(String _busqueda = "")
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<Paciente> _lista = new List<Paciente>();

            try
            {
                String _sentencia = "SELECT pac_codigo, pac_nombre, pac_apellido, pac_telefono," +
                                          " pac_telefonoRef, pac_fechaNac, pac_direccion, pac_email," +
                                          " brr_codigo, pac_documento, est_codigo, obr_codigo, pac_sexo, pac_tiposangre" +
                                   " FROM pacientes";
                if (_busqueda != "") _sentencia += " WHERE UPPER(pac_nombre) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                        " OR UPPER(pac_apellido) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                        " OR pac_documento LIKE '%" + _busqueda + "%'";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    _lista.Add(CargarPaciente(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        public Paciente DevolverPacientexHC(Int32 _hic_numero)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            Paciente _paciente = null;

            try
            {
                String _sentencia = "SELECT p.pac_codigo, pac_nombre, pac_apellido, pac_telefono," +
                                          " pac_telefonoRef, pac_fechaNac, pac_direccion, pac_email," +
                                          " brr_codigo, pac_documento, est_codigo, obr_codigo, pac_sexo, pac_tiposangre" +
                                   " FROM pacientes p" +
                                   " JOIN HistorialesClinicos hc ON p.pac_codigo = hc.pac_codigo" +
                                   " WHERE hic_numero = @p_hic_numero";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_hic_numero", _hic_numero);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                {
                    _paciente = CargarPaciente(_reader);
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _paciente;
        }
        private Paciente CargarPaciente(SqlDataReader _dr)
        {
            Paciente _pac = new Paciente();

            _pac.pac_codigo = Convert.ToInt32(_dr[0]);
            _pac.pac_nombre = _dr[1].ToString();
            _pac.pac_apellido = _dr[2].ToString();
            _pac.pac_telefono = _dr[3].ToString();
            _pac.pac_telefonoRef = _dr[4].ToString();
            _pac.pac_fechaNac = Convert.ToDateTime(_dr[5]);
            _pac.pac_direccion = _dr[6].ToString();
            _pac.pac_email = _dr[7].ToString();
            _pac.brr_codigo = Convert.ToInt32(_dr[8]);
            _pac.pac_documento = Convert.ToInt32(_dr[9]);
            _pac.est_codigo = Convert.ToInt32(_dr[10]);
            _pac.obr_codigo = Convert.ToInt32(_dr[11]);
            _pac.pac_sexo = _dr[12].ToString();
            _pac.pac_tipoSangre = _dr[13].ToString();

            return _pac;
        }

        public List<ObjetoGral> DevolverListaPrioridades(Boolean _agregarSeleccionar = true)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT tni_codigo, tni_denom FROM TurnoNiveles";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ObjetoGral>();
                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            if (_agregarSeleccionar)
            {
                ObjetoGral _og = new ObjetoGral();
                _og.codigo = -1;
                _og.denom = "Seleccionar";
                _lista.Insert(0, _og);
            }

            return _lista;
        }

        public List<Turno> DevolverListaTurnosPrioridad(String _busqueda = "")
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<Turno> _lista = new List<Turno>();

            try
            {
                String _sentencia = "SELECT tur_codigo, tur_fecha, usu_usuario_carga, usu_usuario_toma," +
                                        " t.pac_codigo, p.pac_apellido + ', ' + p.pac_nombre + '. Documento:'" +
                                        " + ltrim(str(p.pac_documento)) nombreCompleto, t.tni_codigo, tn.tni_denom," +
                                        " tur_cancelado, tur_en_espera, tur_fechaCierre" +
                                   " FROM Turnos t" +
                                   " JOIN TurnoNiveles tn ON t.tni_codigo = tn.tni_codigo" +
                                   " JOIN Pacientes p ON p.pac_codigo = t.pac_codigo" +
                                   " WHERE usu_usuario_toma IS NULL " +
                                        " AND tur_cancelado = 0";

                if (_busqueda != "") _sentencia += " AND (UPPER(p.pac_nombre) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                        " OR UPPER(p.pac_apellido) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                        " OR p.pac_documento LIKE '%" + _busqueda + "%')";

                _sentencia += " ORDER BY tni_codigo desc, tur_fecha";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    _lista.Add(CargarTurno(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        public List<Turno> DevolverListaTurnosGestion(String _busqueda = "")
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<Turno> _lista = new List<Turno>();

            try
            {
                String _sentencia = "SELECT tur_codigo, tur_fecha, usu_usuario_carga, usu_usuario_toma," +
                                        " t.pac_codigo, p.pac_apellido + ', ' + p.pac_nombre + '. Documento:'" +
                                        " + ltrim(str(p.pac_documento)) nombreCompleto, t.tni_codigo, tn.tni_denom," +
                                        " tur_cancelado, tur_en_espera, tur_fechaCierre" +
                                   " FROM Turnos t" +
                                   " JOIN TurnoNiveles tn ON t.tni_codigo = tn.tni_codigo" +
                                   " JOIN Pacientes p ON p.pac_codigo = t.pac_codigo" +
                                   " WHERE (usu_usuario_toma IS NULL OR tur_en_espera = 1)" +
                                        " AND tur_cancelado = 0";

                if (_busqueda != "") _sentencia += " AND (UPPER(p.pac_nombre) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                        " OR UPPER(p.pac_apellido) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                        " OR p.pac_documento LIKE '%" + _busqueda + "%')";

                _sentencia += " ORDER BY tni_codigo desc, tur_fecha";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    _lista.Add(CargarTurno(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        private Turno CargarTurno(SqlDataReader _dr)
        {
            Turno _tur = new Turno();

            _tur.tur_codigo = Convert.ToInt32(_dr[0]);
            _tur.tur_fecha = Convert.ToDateTime(_dr[1]);
            _tur.usu_usuarioCarga = _dr[2].ToString();
            _tur.usu_usuarioToma = _dr[3] == DBNull.Value ? "" : _dr[3].ToString();
            _tur.pac_codigo = Convert.ToInt32(_dr[4]);
            _tur.pac_nombreCompleto = _dr[5].ToString();
            _tur.tni_codigo = Convert.ToInt32(_dr[6]);
            _tur.tni_denom = _dr[7].ToString();
            _tur.tur_cancelado = Convert.ToInt32(_dr[8].ToString());
            _tur.tur_en_espera = Convert.ToInt32(_dr[9].ToString());

            if (_dr[10] != DBNull.Value) _tur.tur_fechaCierre = Convert.ToDateTime(_dr[10]);
            else _tur.tur_fechaCierre = DateTime.MinValue;

            return _tur;
        }

        public List<FichaMedica> DevolverListaFichasMedicas(String _busqueda = "")
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<FichaMedica> _lista = new List<FichaMedica>();

            try
            {
                String _sentencia = "SELECT fic_codigo, usu_usuario, fic_fecha, hic_numero," +
                                        " fic_motivoIngreso, fic_observaciones, fic_derivado," +
                                        " fic_internado, fic_alta, fic_tratamiento" +
                                   " FROM fichas";

                //if (_busqueda != "") _sentencia += " AND UPPER(p.pac_nombre) LIKE '%" + _busqueda.ToUpper() + "%'" +
                //                                        " OR UPPER(p.pac_apellido) LIKE '%" + _busqueda.ToUpper() + "%'" +
                //                                        " OR p.pac_documento LIKE '%" + _busqueda + "%'";

                _sentencia += " ORDER BY tni_codigo desc, tur_fecha";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    _lista.Add(CargarFichaMedica(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        public FichaMedica DevolverUltimaFichaMedicaxPacienteUsuario(Int32 _pac_codigo, String _usu_usuario)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            FichaMedica _fmed = null;

            try
            {
                String _sentencia = "SELECT fic_codigo, usu_usuario, fic_fecha, f.hic_numero," +
                                        " fic_motivoIngreso, fic_observaciones, fic_derivado," +
                                        " fic_internado, fic_alta, fic_tratamiento" +
                                   " FROM fichas f" +
                                   " JOIN HistorialesClinicos h" +
                                        " ON f.hic_numero = h.hic_numero" +
                                   " WHERE usu_usuario = @p_usu_usuario" +
                                        " AND pac_codigo = @p_pac_codigo" +
                                   " ORDER BY fic_fecha DESC";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usu_usuario", _usu_usuario);
                _command.Parameters.AddWithValue("@p_pac_codigo", _pac_codigo);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                    _fmed = CargarFichaMedica(_reader);
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _fmed;
        }
        public FichaMedica DevolverUltimaFichaMedicaxHCUsuario(Int32 _hic_numero, String _usu_usuario)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            FichaMedica _fmed = null;

            try
            {
                String _sentencia = "SELECT fic_codigo, usu_usuario, fic_fecha, f.hic_numero," +
                                        " fic_motivoIngreso, fic_observaciones, fic_derivado," +
                                        " fic_internado, fic_alta, fic_tratamiento" +
                                   " FROM fichas f" +
                                   " WHERE usu_usuario = @p_usu_usuario" +
                                        " AND hic_numero = @p_hic_numero" +
                                   " ORDER BY fic_fecha DESC";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usu_usuario", _usu_usuario);
                _command.Parameters.AddWithValue("@p_hic_numero", _hic_numero);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                    _fmed = CargarFichaMedica(_reader);
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _fmed;
        }
        public FichaMedica DevolverUltimaFichaMedicaxHC(Int32 _hic_numero)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            FichaMedica _fmed = null;

            try
            {
                String _sentencia = "SELECT fic_codigo, usu_usuario, fic_fecha, f.hic_numero," +
                                        " fic_motivoIngreso, fic_observaciones, fic_derivado," +
                                        " fic_internado, fic_alta, fic_tratamiento" +
                                   " FROM fichas f" +
                                   " WHERE hic_numero = @p_hic_numero" +
                                   " ORDER BY fic_fecha DESC";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_hic_numero", _hic_numero);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                    _fmed = CargarFichaMedica(_reader);
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _fmed;
        }
        public FichaMedica DevolverFichaMedicaxCodigo(Int32 _fic_codigo)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            FichaMedica _fmed = null;

            try
            {
                String _sentencia = "SELECT fic_codigo, usu_usuario, fic_fecha, f.hic_numero," +
                                        " fic_motivoIngreso, fic_observaciones, fic_derivado," +
                                        " fic_internado, fic_alta, fic_tratamiento" +
                                   " FROM fichas f" +
                                   " WHERE fic_codigo = @p_fic_codigo";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_fic_codigo", _fic_codigo);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                    _fmed = CargarFichaMedica(_reader);
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _fmed;
        }
        private FichaMedica CargarFichaMedica(SqlDataReader _dr)
        {
            FichaMedica _fmed = new FichaMedica();

            _fmed.fic_codigo = Convert.ToInt32(_dr[0]);
            _fmed.usu_usuario = _dr[1].ToString();
            _fmed.fic_fecha = Convert.ToDateTime(_dr[2]);
            _fmed.hic_numero = Convert.ToInt32(_dr[3]);
            _fmed.fic_motivoIngreso = _dr[4].ToString();
            _fmed.fic_observaciones = _dr[5].ToString();
            _fmed.fic_derivado = _dr[6].ToString();
            _fmed.fic_internado = _dr[7].ToString();
            _fmed.fic_alta = _dr[8].ToString();
            _fmed.fic_tratamiento = _dr[9].ToString();

            return _fmed;
        }

        public Antecedente DevolverAntecedentes(Int32 _hic_numero)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            Antecedente _ant = null;

            try
            {
                String _sentencia = "SELECT hic_numero, ant_patologicos, ant_quirurgicos, ant_toxicos," +
                                        " ant_alergicos" +
                                   " FROM Antecedentes" +
                                   " WHERE hic_numero = @p_hic_numero";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_hic_numero", _hic_numero);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                {
                    _ant = CargarAntecedente(_reader);
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _ant;
        }
        private Antecedente CargarAntecedente(SqlDataReader _dr)
        {
            Antecedente _ant = new Antecedente();

            _ant.hic_numero = Convert.ToInt32(_dr[0]);
            _ant.ant_patologicos = _dr[1].ToString();
            _ant.ant_quirurgicos = _dr[2].ToString();
            _ant.ant_toxicos = _dr[3].ToString();
            _ant.ant_alergicos = _dr[4].ToString();

            return _ant;
        }

        public List<ObjetoGral> DevolverListaInventarioTipos()
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT invt_codigo, invt_denom FROM InventarioTipos";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null)
                    {
                        _lista = new List<ObjetoGral>();

                        ObjetoGral _og = new ObjetoGral();
                        _og.codigo = -1;
                        _og.denom = "Seleccionar";
                        _lista.Add(_og);
                    }

                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }

        public List<ObjetoGral> DevolverListaInventarioMarcas()
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT invm_codigo, invm_denom FROM InventarioMarcas";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null)
                    {
                        _lista = new List<ObjetoGral>();

                        ObjetoGral _og = new ObjetoGral();
                        _og.codigo = -1;
                        _og.denom = "Seleccionar";
                        _lista.Add(_og);
                    }

                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }

        public List<Inventario> DevolverListaInventario(String _busqueda = "")
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<Inventario> _lista = new List<Inventario>();

            try
            {
                String _sentencia = "SELECT inv_codigoMed, inv_descripcion, inv_estanteria, invt_codigo," +
                                        " invm_codigo, inv_cantidad" +
                                   " FROM inventario";
                if (_busqueda != "") _sentencia += "";

                _sentencia += " ORDER BY inv_descripcion";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    _lista.Add(CargarInventario(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        private Inventario CargarInventario(SqlDataReader _dr)
        {
            Inventario _inv = new Inventario();

            _inv.inv_codigoMed = _dr[0].ToString();
            _inv.inv_descripcion = _dr[1].ToString();
            _inv.inv_estanteria = _dr[2].ToString();
            _inv.invt_codigo = Convert.ToInt32(_dr[3]);
            _inv.invm_codigo = Convert.ToInt32(_dr[4]);
            _inv.inv_cantidad = Convert.ToDouble(_dr[5]);

            return _inv;
        }

        public List<PedidoInventario> DevolverListaPedidoInv(String _busqueda = "")
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<PedidoInventario> _lista = new List<PedidoInventario>(); ;

            try
            {
                String _sentencia = "SELECT pei_codigo, usu_usuario, pei_salaOrigen, pi.inv_codigoMed, pi.pes_codigo," +
                                          " pes_denom, pei_comentario, pei_fecha, pei_fechaCarga, pei_cantidad," +
                                          " i.inv_descripcion, pi.usu_usuarioToma" +
                                   " FROM PedidosInventario pi" +
                                   " JOIN PedidoEstados pe ON pi.pes_codigo = pe.pes_codigo" +
                                   " JOIN Inventario i ON i.inv_codigoMed = pi.inv_codigoMed";
                if (_busqueda != "") _sentencia += "";

                _sentencia += " ORDER BY pei_fechaCarga";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    _lista.Add(CargarPedidoInv(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        public List<PedidoInventario> DevolverListaPedidoInvAbiertas(Usuario _usu ,String _busqueda = "")
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<PedidoInventario> _lista = new List<PedidoInventario>();

            try
            {
                String _sentencia = "SELECT pei_codigo, usu_usuario, pei_salaOrigen, pi.inv_codigoMed, pi.pes_codigo," +
                                          " pes_denom, pei_comentario, pei_fecha, pei_fechaCarga, pei_cantidad," +
                                          " i.inv_descripcion, pi.usu_usuarioToma" +
                                   " FROM PedidosInventario pi" +
                                   " JOIN PedidoEstados pe ON pi.pes_codigo = pe.pes_codigo" +
                                   " JOIN Inventario i ON i.inv_codigoMed = pi.inv_codigoMed" +
                                   " WHERE pei_fechaCarga > DATEADD(HH, -12, GETDATE()) ";

                if (_usu.rol_codigo == 2) _sentencia += " AND usu_usuario = '" + _usu.usu_usuario + "'";

                if (_busqueda != "") _sentencia += " AND (UPPER(usu_usuario) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                      " OR UPPER(pei_comentario) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                      " OR UPPER(pi.inv_codigoMed) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                      " OR UPPER(pi.usu_usuarioToma) LIKE '%" + _busqueda.ToUpper() + "%')";

                _sentencia += " ORDER BY pei_fechaCarga";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    _lista.Add(CargarPedidoInv(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        private PedidoInventario CargarPedidoInv(SqlDataReader _dr)
        {
            PedidoInventario _pei = new PedidoInventario();

            _pei.pei_codigo = Convert.ToInt32(_dr[0]);
            _pei.usu_usuario = _dr[1].ToString();
            _pei.pei_salaOrigen = Convert.ToInt32(_dr[2]);
            _pei.inv_codigoMed = _dr[3].ToString();
            _pei.pes_codigo = Convert.ToInt32(_dr[4]);
            _pei.pes_denom = _dr[5].ToString();
            _pei.pei_comentario = _dr[6].ToString();
            _pei.pei_fecha = Convert.ToDateTime(_dr[7]);
            _pei.pei_fechaCarga = Convert.ToDateTime(_dr[8]);
            _pei.pei_cantidad = Convert.ToDouble(_dr[9]);
            _pei.inv_descripcion = _dr[10].ToString();
            _pei.usu_usuarioToma = _dr[11].ToString();

            return _pei;
        }

        public List<ObjetoGral> DevolverListaMetComplementarioDestinos()
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT mcd_codigo, mcd_denom FROM MetComplementarioDestinos";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ObjetoGral>();
                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }

        public PedidoMetComplementario DevolverUltimoPedMetComplementarioxHC(Int32 _hic_numero)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            PedidoMetComplementario _ped = null;

            try
            {
                String _sentencia = "SELECT pmc_codigo, usu_usuario, pmc_salaOrigen, p.pac_codigo," +
                                        " mcd_codigo, pes_codigo, pmc_comentario, pmc_resultado," +
                                        " pmc_fecha, pmc_fechaCarga, pmc_documento, ''" +
                                   " FROM PedidoMetComplementarios p" +
                                   " JOIN HistorialesClinicos hc on p.pac_codigo = hc.pac_codigo " +
                                   " WHERE hic_numero = @p_hic_numero" +
                                   " ORDER BY pmc_fechaCarga DESC";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_hic_numero", _hic_numero);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                    _ped = CargarPedidoMetComplenetario(_reader);
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _ped;
        }
        public PedidoMetComplementario DevolverUltimoPedMetComplementarioxCodigo(Int32 _pmc_codigo)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            PedidoMetComplementario _ped = null;

            try
            {
                String _sentencia = "SELECT pmc_codigo, usu_usuario, pmc_salaOrigen, p.pac_codigo," +
                                        " mcd_codigo, pes_codigo, pmc_comentario, pmc_resultado," +
                                        " pmc_fecha, pmc_fechaCarga, pmc_documento, ''" +
                                   " FROM PedidoMetComplementarios p" +
                                   " JOIN HistorialesClinicos hc on p.pac_codigo = hc.pac_codigo " +
                                   " WHERE pmc_codigo = @p_pmc_codigo";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_pmc_codigo", _pmc_codigo);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                    _ped = CargarPedidoMetComplenetario(_reader);
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _ped;
        }
        public List<PedidoMetComplementario> DevolverListaPedidosComplementariosAbiertos(String _busqueda = "")
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<PedidoMetComplementario> _lista = new List<PedidoMetComplementario>();

            try
            {
                String _sentencia = "SELECT pmc_codigo, usu_usuario, pmc_salaOrigen, p.pac_codigo," +
                                        " p.mcd_codigo, pes_codigo, pmc_comentario, pmc_resultado," +
                                        " pmc_fecha, pmc_fechaCarga, pmc_documento, pac_apellido + ', ' + pac_nombre + ' - ' + mcd_denom" +
                                   " FROM PedidoMetComplementarios p" +
                                   " JOIN HistorialesClinicos hc ON p.pac_codigo = hc.pac_codigo " +
                                   " JOIN Pacientes pa ON pa.pac_codigo = p.pac_codigo" +
                                   " JOIN MetComplementarioDestinos md ON md.mcd_codigo = p.mcd_codigo" +
                                   " WHERE p.pes_codigo = 1";


                if (_busqueda != "") _sentencia += " AND (UPPER(mcd_denom) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                      " OR UPPER(pac_nombre) LIKE '%" + _busqueda.ToUpper() + "%'" +
                                                      " OR UPPER(pac_apellido) LIKE '%" + _busqueda.ToUpper() + "%')";

                _sentencia += " ORDER BY pmc_fechaCarga";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    _lista.Add(CargarPedidoMetComplenetario(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        private PedidoMetComplementario CargarPedidoMetComplenetario(SqlDataReader _dr)
        {
            PedidoMetComplementario _pmc = new PedidoMetComplementario();

            _pmc.pmc_codigo = Convert.ToInt32(_dr[0]);
            _pmc.usu_usuario = _dr[1].ToString();
            _pmc.pmc_salaOrigen = Convert.ToInt32(_dr[2]);
            _pmc.pac_codigo = Convert.ToInt32(_dr[3]);
            _pmc.mcd_codigo = Convert.ToInt32(_dr[4]);
            _pmc.pes_codigo = Convert.ToInt32(_dr[5]);
            _pmc.pmc_comentario = _dr[6].ToString();
            _pmc.pmc_resultado = _dr[7].ToString();
            _pmc.pmc_fecha = Convert.ToDateTime(_dr[8]);
            _pmc.pmc_fechaCarga = Convert.ToDateTime(_dr[9]);
            _pmc.pmc_documento = _dr[10].ToString();
            _pmc.pac_nombreCompleto = _dr[11].ToString();

            return _pmc;
        }

        public List<ObjetoGral> DevolverListaPedidoEstados()
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "SELECT pes_codigo, pes_denom FROM PedidoEstados";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ObjetoGral>();
                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }

        public List<IndiceHC> DevolverListaIndicexHCFiltros(Int32 _hic_numero, DateTime _fechaDesde, DateTime _fechaHasta, Int32 _fichaDesde, Int32 _fichaHasta,
                                                     Int32 _metComplDesde, Int32 _metComplHasta)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<IndiceHC> _lista = null;

            try
            {
                String _sentencia = "SELECT fic_codigo, 'F' as tipo, fic_fecha as fecha, ltrim(STR(usu_matricula))  + ' - ' + usu_apellido + ', ' +  " +
                                            " usu_nombre as medico, fic_motivoIngreso as motCom, fic_tratamiento as traRes" +
                                   " FROM Fichas f" +
                                   " JOIN Usuarios u ON f.usu_usuario = u.usu_usuario" +
                                   " WHERE hic_numero = @p_hic_numero" +
                                        " AND fic_codigo BETWEEN @p_fichaDesde AND @p_fichaHasta" +
                                        " AND cast(fic_fecha As Date) BETWEEN @p_fechaDesde AND @p_fechaHasta" +
                                   " UNION ALL" +
                                   " SELECT pmc_codigo, 'P' as tipo, pmc_fechaCarga, ltrim(STR(usu_matricula))  + ' - ' + usu_apellido + ', ' + " +
                                            " usu_nombre as medico, pmc_comentario as motCom, pmc_resultado as traRes" +
                                   " FROM PedidoMetComplementarios p" +
                                   " JOIN HistorialesClinicos h ON p.pac_codigo = h.pac_codigo" +
                                   " JOIN Usuarios u ON p.usu_usuario = u.usu_usuario" +
                                   " WHERE hic_numero = @p_hic_numero" +
                                        " AND pmc_codigo BETWEEN @p_metComplDesde AND @p_metComplHasta" +
                                        " AND cast(pmc_fechaCarga As Date) BETWEEN @p_fechaDesde AND @p_fechaHasta" +
                                   " ORDER BY fecha desc";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_hic_numero", _hic_numero);
                _command.Parameters.AddWithValue("@p_fechaDesde", _fechaDesde);
                _command.Parameters.AddWithValue("@p_fechaHasta", _fechaHasta);
                _command.Parameters.AddWithValue("@p_fichaDesde", _fichaDesde);
                _command.Parameters.AddWithValue("@p_fichaHasta", _fichaHasta);
                _command.Parameters.AddWithValue("@p_metComplDesde", _metComplDesde);
                _command.Parameters.AddWithValue("@p_metComplHasta", _metComplHasta);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<IndiceHC>();
                    _lista.Add(CargarIndiceHC(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        private IndiceHC CargarIndiceHC(SqlDataReader _dr)
        {
            IndiceHC _ind = new IndiceHC();

            _ind.codigo = Convert.ToInt32(_dr[0]);
            _ind.tipo = _dr[1].ToString();
            _ind.fecha = Convert.ToDateTime(_dr[2]);
            _ind.medico = _dr[3].ToString();
            _ind.motCom = _dr[4].ToString();
            _ind.traRes = _dr[5].ToString();

            return _ind;
        }

        public List<ReporteVariables> DevolverListaReporteFichaEstados(Int32 _mes, Int32 _anio)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ReporteVariables> _lista = null;

            try
            {
                String _sentencia = "SELECT ISNULL(SUM(CASE WHEN fic_alta = '1' THEN 1 ELSE 0 END),0) alta," +
                                          " ISNULL(SUM(CASE WHEN fic_derivado = '1' THEN 1 ELSE 0 END), 0) derivado," +
                                          " ISNULL(SUM(CASE WHEN fic_internado = '1' THEN 1 ELSE 0 END), 0) internado" +
                                   " FROM fichas" +
                                   " WHERE year(fic_fecha) = " + _anio;

                if (_mes != 0) _sentencia += " AND MONTH(fic_fecha) = " + _mes;

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ReporteVariables>();
                    _lista.Add(CargarReporteVariables(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        public List<ReporteVariables> DevolverListaReporteInsumosFaltantes(Int32 _mes, Int32 _anio)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ReporteVariables> _lista = null;

            try
            {
                String _sentencia = "SELECT p.inv_codigoMed, i.inv_descripcion, SUM(pei_cantidad)" +
                                   " FROM PedidosInventario p" +
                                   " JOIN Inventario i ON p.inv_codigoMed = i.inv_codigoMed" +
                                   " WHERE year(pei_fecha) = " + _anio + " AND p.pes_codigo = 5";

                if (_mes != 0) _sentencia += " AND MONTH(pei_fecha) = " + _mes;

                _sentencia += " GROUP BY p.inv_codigoMed, i.inv_descripcion";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ReporteVariables>();
                    _lista.Add(CargarReporteVariablesInsumos(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        public List<ReporteVariables> DevolverListaReporteFichaEdad(Int32 _mes, Int32 _anio)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ReporteVariables> _lista = null;

            try
            {
                String _sentencia = "SELECT " +
                                        " ISNULL(SUM(CASE WHEN(year(GETDATE()) - year(p.pac_fechaNac)) >= 0 and(year(GETDATE()) - year(p.pac_fechaNac)) <= 10 THEN 1 ELSE 0 END), 0) edad010," +
                                        " ISNULL(SUM(CASE WHEN(year(GETDATE()) - year(p.pac_fechaNac)) >= 11 and(year(GETDATE()) - year(p.pac_fechaNac)) <= 20 THEN 1 ELSE 0 END), 0) edad1120," +
                                        " ISNULL(SUM(CASE WHEN(year(GETDATE()) - year(p.pac_fechaNac)) >= 21 and(year(GETDATE()) - year(p.pac_fechaNac)) <= 30 THEN 1 ELSE 0 END), 0) edad2130," +
                                        " ISNULL(SUM(CASE WHEN(year(GETDATE()) - year(p.pac_fechaNac)) >= 31 and(year(GETDATE()) - year(p.pac_fechaNac)) <= 40 THEN 1 ELSE 0 END), 0) edad3140," +
                                        " ISNULL(SUM(CASE WHEN(year(GETDATE()) - year(p.pac_fechaNac)) >= 41 and(year(GETDATE()) - year(p.pac_fechaNac)) <= 50 THEN 1 ELSE 0 END), 0) edad4150," +
                                        " ISNULL(SUM(CASE WHEN(year(GETDATE()) - year(p.pac_fechaNac)) >= 51 and(year(GETDATE()) - year(p.pac_fechaNac)) <= 60 THEN 1 ELSE 0 END), 0) edad5160," +
                                        " ISNULL(SUM(CASE WHEN(year(GETDATE()) - year(p.pac_fechaNac)) >= 61 and(year(GETDATE()) - year(p.pac_fechaNac)) <= 70 THEN 1 ELSE 0 END), 0) edad7170," +
                                        " ISNULL(SUM(CASE WHEN(year(GETDATE()) - year(p.pac_fechaNac)) >= 71 and(year(GETDATE()) - year(p.pac_fechaNac)) <= 80 THEN 1 ELSE 0 END), 0) edad7180," +
                                        " ISNULL(SUM(CASE WHEN(year(GETDATE()) - year(p.pac_fechaNac)) >= 81 THEN 1 ELSE 0 END), 0) edad80plus" +
                                   " FROM fichas f" +
                                   " JOIN HistorialesClinicos h ON h.hic_numero = f.hic_numero" +
                                   " JOIN Pacientes p ON h.pac_codigo = p.pac_codigo" +                                
                                   " WHERE year(fic_fecha) = " + _anio;

                if (_mes != 0) _sentencia += " AND MONTH(fic_fecha) = " + _mes;

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ReporteVariables>();
                    ReporteVariables _rv = new ReporteVariables();

                    _rv.edad010 = Convert.ToInt32(_reader[0]);
                    _rv.edad1120 = Convert.ToInt32(_reader[1]);
                    _rv.edad2130 = Convert.ToInt32(_reader[2]);
                    _rv.edad3140 = Convert.ToInt32(_reader[3]);
                    _rv.edad4150 = Convert.ToInt32(_reader[4]);
                    _rv.edad5160 = Convert.ToInt32(_reader[5]);
                    _rv.edad6170 = Convert.ToInt32(_reader[6]);
                    _rv.edad7180 = Convert.ToInt32(_reader[7]);
                    _rv.edad80plus = Convert.ToInt32(_reader[8]);
                    _lista.Add(_rv);
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }
        private ReporteVariables CargarReporteVariables(SqlDataReader _dr)
        {
            ReporteVariables _rep = new ReporteVariables();

            _rep.sum_alta = Convert.ToInt32(_dr[0]);
            _rep.sum_derivado = Convert.ToInt32(_dr[1]);
            _rep.sum_internado = Convert.ToInt32(_dr[2]);

            return _rep;
        }
        private ReporteVariables CargarReporteVariablesInsumos(SqlDataReader _dr)
        {
            ReporteVariables _rep = new ReporteVariables();

            _rep.inv_codigoMed = _dr[0].ToString(); ;
            _rep.inv_descripcion = _dr[1].ToString();
            _rep.cantidad = _dr[2].ToString();

            return _rep;
        }

        public List<ObjetoGral> DevolverListaHC()
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            List<ObjetoGral> _lista = null;

            try
            {
                String _sentencia = "select hic_numero, pac_apellido + ', ' + pac_nombre +'. Documento: '+ ltrim(STR(pac_documento))  as paciente" +
                                    " from HistorialesClinicos h" +
                                    " join Pacientes p on h.pac_codigo = p.pac_codigo";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    if (_lista == null) _lista = new List<ObjetoGral>();
                    _lista.Add(CargarObjetoGral(_reader));
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _lista;
        }

        #endregion

        #region "Consultas varias"

        public Boolean ExisteUsuario(String _usuario)
        {
            SqlConnection _connection = null;
            Boolean _existe = true;

            try
            {
                String _sentencia = "SELECT COUNT(usu_usuario) FROM usuarios" +
                                   " WHERE UPPER(usu_usuario) = UPPER(@p_usuario)";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usuario", _usuario);
                _connection.Open();
                Int32 _count = Convert.ToInt32(_command.ExecuteScalar());

                if (_count == 0) _existe = false;
            }
            finally
            {
                _connection.Close();
            }

            return _existe;
        }

        public Boolean ExistePaciente(Int32 _pacienteDocumento)
        {
            SqlConnection _connection = null;
            Boolean _existe = true;

            try
            {
                String _sentencia = "SELECT COUNT(pac_codigo) FROM pacientes" +
                                   " WHERE pac_documento = @p_pacienteDocumento";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_pacienteDocumento", _pacienteDocumento);
                _connection.Open();
                Int32 _count = Convert.ToInt32(_command.ExecuteScalar());

                if (_count == 0) _existe = false;
            }
            finally
            {
                _connection.Close();
            }

            return _existe;
        }

        public Boolean ExisteInventario(String _codMedicamento)
        {
            SqlConnection _connection = null;
            Boolean _existe = true;

            try
            {
                String _sentencia = "SELECT COUNT(inv_codigoMed) FROM inventario" +
                                   " WHERE inv_codigoMed = @p_codMed";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_codMed", _codMedicamento);
                _connection.Open();
                Int32 _count = Convert.ToInt32(_command.ExecuteScalar());

                if (_count == 0) _existe = false;
            }
            finally
            {
                _connection.Close();
            }

            return _existe;
        }

        public Int32 DevolverHicNumeroxPacCodigo(Int32 _pac_codigo)
        {
            SqlConnection _connection = null;
            Int32 _hic = 0;

            try
            {
                String _sentencia = "SELECT hic_numero FROM HistorialesClinicos" +
                                   " WHERE pac_codigo = @p_pac_codigo";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_pac_codigo", _pac_codigo);
                _connection.Open();
                _hic = Convert.ToInt32(_command.ExecuteScalar());
            }
            finally
            {
                _connection.Close();
            }

            return _hic;
        }

        public Turno DevolverTurnoEnEspera(String _usu_usuario)
        {
            SqlDataReader _reader = null;
            SqlConnection _connection = null;
            Turno _turno = null;

            try
            {
                String _sentencia = "SELECT tur_codigo, tur_fecha, usu_usuario_carga, usu_usuario_toma," +
                                        " t.pac_codigo, p.pac_apellido + ', ' + p.pac_nombre + '. Documento:'" +
                                        " + ltrim(str(p.pac_documento)) nombreCompleto, t.tni_codigo, tn.tni_denom," +
                                        " tur_cancelado, tur_en_espera, tur_fechaCierre" +
                                   " FROM Turnos t" +
                                   " JOIN TurnoNiveles tn ON t.tni_codigo = tn.tni_codigo" +
                                   " JOIN Pacientes p ON p.pac_codigo = t.pac_codigo" +
                                   " WHERE usu_usuario_toma = @p_usu_usuario" +
                                        " AND tur_en_espera = 1" +
                                   " ORDER BY tur_fecha";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usu_usuario", _usu_usuario);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.Read())
                {
                    _turno = CargarTurno(_reader);
                }
            }
            finally
            {
                _reader.Close();
                _connection.Close();
            }

            return _turno;
        }

        #endregion

    }
}