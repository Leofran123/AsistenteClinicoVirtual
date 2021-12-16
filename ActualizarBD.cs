using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal
{
    class ActualizarBD
    {
        private String _conexion = @"Server =.\SQLEXPRESS;Database=PracticaSupervisada;User Id = usuario2; Password=pass123;";
        //private String _conexion = @"Server =DESKTOP-QD5GTOD\SQLEXPRESS;Database=PracticaSupervisada;User Id = usuario1; Password=pass123;";

        public Boolean ActualizarUsuario(Usuario _usu)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;

            try
            {
                String _sentencia = "UPDATE usuarios" +
                                   " SET usu_clave = @p_usu_clave," +
                                       " usu_nombre = @p_usu_nombre," +
                                       " usu_apellido = @p_usu_apellido," +
                                       " usu_email = @p_usu_email," +
                                       " usu_telefono = @p_usu_telefono," +
                                       " usu_nacimiento = @p_usu_nacimiento," +
                                       " usu_direccion = @p_usu_direccion," +
                                       " brr_codigo = @p_brr_codigo," +
                                       " usu_documento = @p_usu_documento," +
                                       " est_codigo = @p_est_codigo," +
                                       " usu_sexo = @p_usu_sexo," +
                                       " esp_codigo = @p_esp_codigo," +
                                       " usu_matricula = @p_usu_matricula," +
                                       " rol_codigo = @p_rol_codigo," +
                                       " usu_habilitado = @p_usu_habilitado" +
                                   " WHERE usu_usuario = @p_usu_usuario";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usu_usuario", _usu.usu_usuario);
                _command.Parameters.AddWithValue("@p_usu_clave", _usu.usu_clave);
                _command.Parameters.AddWithValue("@p_usu_nombre", _usu.usu_nombre);
                _command.Parameters.AddWithValue("@p_usu_apellido", _usu.usu_apellido);
                _command.Parameters.AddWithValue("@p_usu_email", _usu.usu_email);
                _command.Parameters.AddWithValue("@p_usu_telefono", _usu.usu_telefono);
                _command.Parameters.AddWithValue("@p_usu_nacimiento", _usu.usu_nacimiento);
                _command.Parameters.AddWithValue("@p_usu_direccion", _usu.usu_direccion);
                _command.Parameters.AddWithValue("@p_brr_codigo", _usu.brr_codigo);
                _command.Parameters.AddWithValue("@p_usu_documento", _usu.usu_documento);
                _command.Parameters.AddWithValue("@p_est_codigo", _usu.est_codigo);
                _command.Parameters.AddWithValue("@p_usu_sexo", _usu.usu_sexo);
                _command.Parameters.AddWithValue("@p_esp_codigo", _usu.esp_codigo);
                _command.Parameters.AddWithValue("@p_usu_matricula", _usu.usu_matricula);
                _command.Parameters.AddWithValue("@p_rol_codigo", _usu.rol_codigo);
                _command.Parameters.AddWithValue("@p_usu_habilitado", _usu.usu_habilitado ? 1 : 0);

                _connection.Open();
                if (_command.ExecuteNonQuery() == 0)
                {
                    _sentencia = "INSERT INTO usuarios" +
                                " VALUES(@p_usu_usuario, @p_usu_clave, @p_usu_nombre, @p_usu_apellido, @p_usu_email, @p_usu_telefono," +
                                       " @p_usu_nacimiento, @p_usu_direccion, @p_brr_codigo, @p_usu_documento, @p_est_codigo, @p_usu_sexo," +
                                       " @p_esp_codigo, @p_usu_matricula, @p_rol_codigo, @p_usu_habilitado)";
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }

        public Boolean ActualizarPaciente(Paciente _pac)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;
            String _sentencia = "";

            try
            {
                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_pac_nombre", _pac.pac_nombre);
                _command.Parameters.AddWithValue("@p_pac_apellido", _pac.pac_apellido);
                _command.Parameters.AddWithValue("@p_pac_telefono", _pac.pac_telefono);
                _command.Parameters.AddWithValue("@p_pac_telefonoRef", _pac.pac_telefonoRef);
                _command.Parameters.AddWithValue("@p_pac_fechaNac", _pac.pac_fechaNac);
                _command.Parameters.AddWithValue("@p_pac_direccion", _pac.pac_direccion);
                _command.Parameters.AddWithValue("@p_pac_email", _pac.pac_email);
                _command.Parameters.AddWithValue("@p_brr_codigo", _pac.brr_codigo);
                _command.Parameters.AddWithValue("@p_pac_documento", _pac.pac_documento);
                _command.Parameters.AddWithValue("@p_est_codigo", _pac.est_codigo);
                _command.Parameters.AddWithValue("@p_obr_codigo", _pac.obr_codigo);
                _command.Parameters.AddWithValue("@p_pac_sexo", _pac.pac_sexo);
                _command.Parameters.AddWithValue("@p_pac_codigo", _pac.pac_codigo);
                _command.Parameters.AddWithValue("@p_pac_tiposangre", _pac.pac_tipoSangre);
                _connection.Open();

                if (_pac.pac_codigo > 0)
                {
                    _sentencia = "UPDATE pacientes" +
                                 " SET pac_nombre = @p_pac_nombre," +
                                     " pac_apellido = @p_pac_apellido," +
                                     " pac_telefono = @p_pac_telefono," +
                                     " pac_telefonoRef = @p_pac_telefonoRef," +
                                     " pac_fechaNac = @p_pac_fechaNac," +
                                     " pac_direccion = @p_pac_direccion," +
                                     " pac_email = @p_pac_email," +
                                     " brr_codigo = @p_brr_codigo," +
                                     " pac_documento = @p_pac_documento," +
                                     " est_codigo = @p_est_codigo," +
                                     " obr_codigo = @p_obr_codigo," +
                                     " pac_sexo = @p_pac_sexo," +
                                     " pac_tiposangre = @p_pac_tiposangre" +
                                 " WHERE pac_codigo = @p_pac_codigo";
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
                else
                {
                    _sentencia = "INSERT INTO pacientes" +
                                " VALUES(@p_pac_nombre, @p_pac_apellido, @p_pac_telefono, @p_pac_telefonoRef, @p_pac_fechaNac," +
                                       " @p_pac_direccion, @p_pac_email, @p_brr_codigo, @p_pac_documento, @p_est_codigo," +
                                       " @p_obr_codigo, @p_pac_sexo, @p_pac_tiposangre)";
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }

        public Boolean GrabarTurno(Int32 _paciente, String _usuario, Int32 _prioridad)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;
            String _sentencia = "";

            try
            {
                _connection = new SqlConnection(_conexion);
                _sentencia = "INSERT INTO Turnos" +
                            " VALUES(SYSDATETIME(), @p_usu_usuario , NULL, @p_pac_codigo , @p_tni_codigo, 0 , 0, NULL)";
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usu_usuario", _usuario);
                _command.Parameters.AddWithValue("@p_pac_codigo", _paciente);
                _command.Parameters.AddWithValue("@p_tni_codigo", _prioridad);
                _connection.Open();
                _command.CommandText = _sentencia;
                _command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }

        public Boolean ModificarTurno(Turno _turno)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;
            String _sentencia = "";

            try
            {
                _connection = new SqlConnection(_conexion);
                _sentencia = "UPDATE Turnos" +
                            " SET tur_fecha = @p_tur_fecha," +
                                " usu_usuario_carga = @p_usu_usuario_carga," +
                                " usu_usuario_toma = @p_usu_usuario_toma," +
                                " pac_codigo = @p_pac_codigo," +
                                " tni_codigo = @p_tni_codigo," +
                                " tur_cancelado = @p_tur_cancelado," +
                                " tur_en_espera = @p_tur_en_espera," +
                                " tur_fechaCierre = @p_tur_fechaCierre" +
                            " WHERE tur_codigo = @p_tur_codigo";

                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_tur_fecha", _turno.tur_fecha);
                _command.Parameters.AddWithValue("@p_usu_usuario_carga", _turno.usu_usuarioCarga);
                if (_turno.usu_usuarioToma == "") _command.Parameters.AddWithValue("@p_usu_usuario_toma", DBNull.Value);
                else _command.Parameters.AddWithValue("@p_usu_usuario_toma", _turno.usu_usuarioToma);
                _command.Parameters.AddWithValue("@p_pac_codigo", _turno.pac_codigo);
                _command.Parameters.AddWithValue("@p_tni_codigo", _turno.tni_codigo);
                _command.Parameters.AddWithValue("@p_tur_cancelado", _turno.tur_cancelado);
                _command.Parameters.AddWithValue("@p_tur_en_espera", _turno.tur_en_espera);
                _command.Parameters.AddWithValue("@p_tur_codigo", _turno.tur_codigo);
                if (_turno.tur_fechaCierre == DateTime.MinValue) _command.Parameters.AddWithValue("@p_tur_fechaCierre", DBNull.Value);
                else _command.Parameters.AddWithValue("@p_tur_fechaCierre", _turno.tur_fechaCierre);
                _connection.Open();
                _command.CommandText = _sentencia;
                _command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }

        public Boolean TomarTurno(Int32 _idTurno, String _usuario)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;
            String _sentencia = "";

            try
            {
                _connection = new SqlConnection(_conexion);
                _sentencia = "UPDATE Turnos" +
                            " SET usu_usuario_toma = @p_usu_usuario," +
                                " tur_en_espera = 1" +
                            " WHERE tur_codigo = @p_idTurno";
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usu_usuario", _usuario);
                _command.Parameters.AddWithValue("@p_idTurno", _idTurno);
                _connection.Open();
                _command.CommandText = _sentencia;
                _command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }

        public Boolean ActualizarFichaMedica(FichaMedica _fmed)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;
            String _sentencia = "";

            try
            {
                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);

                _command.Parameters.AddWithValue("@p_fic_codigo", _fmed.fic_codigo);
                _command.Parameters.AddWithValue("@p_usu_usuario", _fmed.usu_usuario);
                _command.Parameters.AddWithValue("@p_fic_fecha", DateTime.Now);
                _command.Parameters.AddWithValue("@p_hic_numero", _fmed.hic_numero);
                _command.Parameters.AddWithValue("@p_fic_motivoIngreso", _fmed.fic_motivoIngreso);
                _command.Parameters.AddWithValue("@p_fic_observaciones", _fmed.fic_observaciones);
                _command.Parameters.AddWithValue("@p_fic_derivado", _fmed.fic_derivado);
                _command.Parameters.AddWithValue("@p_fic_internado", _fmed.fic_internado);
                _command.Parameters.AddWithValue("@p_fic_alta", _fmed.fic_alta);
                _command.Parameters.AddWithValue("@p_fic_tratamiento", _fmed.fic_tratamiento);
                _connection.Open();

                if (_fmed.fic_codigo > 0)
                {
                    _sentencia = "UPDATE Fichas" +
                                 " SET usu_usuario = @p_usu_usuario," +
                                     " fic_fecha = @p_fic_fecha," +
                                     " p_hic_numero = @p_p_hic_numero," +
                                     " fic_motivoIngreso = @p_fic_motivoIngreso," +
                                     " fic_observaciones = @p_fic_observaciones," +
                                     " fic_derivado = @p_fic_derivado," +
                                     " fic_internado = @p_fic_internado," +
                                     " fic_alta = @p_fic_alta," +
                                     " fic_tratamiento = @p_fic_tratamiento" +
                                 " WHERE fic_codigo = @p_fic_codigo";
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
                else
                {
                    _sentencia = "INSERT INTO Fichas" +
                                " VALUES(@p_usu_usuario, @p_fic_fecha, @p_hic_numero, @p_fic_motivoIngreso, @p_fic_observaciones," +
                                       " @p_fic_tratamiento, @p_fic_derivado, @p_fic_internado, @p_fic_alta)";
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }

        public Int32 ObtenerHicNumero(Int32 _pac_codigo)
        {
            Int32 _hicNumero = new Consultas().DevolverHicNumeroxPacCodigo(_pac_codigo);

            if (_hicNumero == 0)
            {
                SqlConnection _connection = null;
                String _sentencia = "";

                try
                {
                    _sentencia = "INSERT INTO HistorialesClinicos" +
                                " VALUES(@p_pac_nombre)";

                    _connection = new SqlConnection(_conexion);
                    SqlCommand _command = new SqlCommand(_sentencia, _connection);
                    _command.Parameters.AddWithValue("@p_pac_nombre", _pac_codigo);
                    _connection.Open();
                    _command.ExecuteNonQuery();
                    _hicNumero = new Consultas().DevolverHicNumeroxPacCodigo(_pac_codigo);
                }
                finally
                {
                    _connection.Close();
                }
            }

            return _hicNumero;
        }

        public Boolean ActualizarAntecedentes(Antecedente _ant)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;

            try
            {
                String _sentencia = "UPDATE Antecedentes" +
                                   " SET ant_patologicos =  @p_ant_patologicos," +
                                       " ant_quirurgicos = @p_ant_quirurgicos," +
                                       " ant_toxicos = @p_ant_toxicos," +
                                       " ant_alergicos = @p_ant_alergicos" +
                                   " WHERE hic_numero = @p_hic_numero";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_ant_patologicos", _ant.ant_patologicos);
                _command.Parameters.AddWithValue("@p_ant_quirurgicos", _ant.ant_quirurgicos);
                _command.Parameters.AddWithValue("@p_ant_toxicos", _ant.ant_toxicos);
                _command.Parameters.AddWithValue("@p_ant_alergicos", _ant.ant_alergicos);
                _command.Parameters.AddWithValue("@p_hic_numero", _ant.hic_numero);

                _connection.Open();
                if (_command.ExecuteNonQuery() == 0)
                {
                    _sentencia = "INSERT INTO Antecedentes" +
                                " VALUES(@p_hic_numero, @p_ant_patologicos, @p_ant_quirurgicos, @p_ant_toxicos, @p_ant_alergicos)";
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }

        public Boolean ActualizarInventario(Inventario _inv)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;

            try
            {
                String _sentencia = "UPDATE Inventario" +
                                   " SET inv_descripcion =  @p_inv_descripcion," +
                                       " inv_estanteria = @p_inv_estanteria," +
                                       " invm_codigo = @p_invm_codigo," +
                                       " invt_codigo = @p_invt_codigo," +
                                       " inv_cantidad = @p_inv_cantidad" +
                                   " WHERE inv_codigoMed = @p_inv_codigoMed";

                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_inv_codigoMed", _inv.inv_codigoMed);
                _command.Parameters.AddWithValue("@p_inv_descripcion", _inv.inv_descripcion);
                _command.Parameters.AddWithValue("@p_inv_estanteria", _inv.inv_estanteria);
                _command.Parameters.AddWithValue("@p_invt_codigo", _inv.invt_codigo);
                _command.Parameters.AddWithValue("@p_invm_codigo", _inv.invm_codigo);
                _command.Parameters.AddWithValue("@p_inv_cantidad", _inv.inv_cantidad);

                _connection.Open();
                if (_command.ExecuteNonQuery() == 0)
                {
                    _sentencia = "INSERT INTO Inventario" +
                                " VALUES(@p_inv_codigoMed, @p_inv_descripcion, @p_inv_estanteria, @p_invt_codigo," +
                                    " @p_invm_codigo, @p_inv_cantidad)";
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }

        public Boolean ActualizarPedidoInventario(PedidoInventario _pei)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;

            try
            {
                String _sentencia = "";
                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_usu_usuario", _pei.usu_usuario);
                _command.Parameters.AddWithValue("@p_pei_salaOrigen", _pei.pei_salaOrigen);
                _command.Parameters.AddWithValue("@p_inv_codigoMed", _pei.inv_codigoMed);
                _command.Parameters.AddWithValue("@p_pes_codigo", _pei.pes_codigo);
                _command.Parameters.AddWithValue("@p_pei_comentario", _pei.pei_comentario);
                _command.Parameters.AddWithValue("@p_pei_fecha", _pei.pei_fecha);
                _command.Parameters.AddWithValue("@p_pei_fechaCarga", _pei.pei_fechaCarga);
                _command.Parameters.AddWithValue("@p_pei_cantidad", _pei.pei_cantidad);

                if (_pei.usu_usuarioToma != null && _pei.usu_usuarioToma != "") _command.Parameters.AddWithValue("@p_usu_usuarioToma", _pei.usu_usuarioToma);
                else _command.Parameters.AddWithValue("@p_usu_usuarioToma", DBNull.Value);
                
                _connection.Open();

                if (_pei.pei_codigo == 0)
                {
                    _sentencia = "INSERT INTO PedidosInventario" +
                                " VALUES(@p_usu_usuario, @p_pei_salaOrigen, @p_inv_codigoMed, @p_pes_codigo," +
                                       " @p_pei_comentario, @p_pei_fecha, @p_pei_fechaCarga, @p_pei_cantidad, @p_usu_usuarioToma)";
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
                else
                {
                    _sentencia = "UPDATE PedidosInventario" +
                                " SET usu_usuario =  @p_usu_usuario," +
                                    " pei_salaOrigen = @p_pei_salaOrigen," +
                                    " inv_codigoMed = @p_inv_codigoMed," +
                                    " pes_codigo = @p_pes_codigo," +
                                    " pei_comentario = @p_pei_comentario," +
                                    " pei_fecha = @p_pei_fecha," +
                                    " pei_fechaCarga = @p_pei_fechaCarga," +
                                    " pei_cantidad = @p_pei_cantidad," +
                                    " usu_usuarioToma = @p_usu_usuarioToma" +
                                " WHERE pei_codigo = @p_pei_codigo";

                    _command.Parameters.AddWithValue("@p_pei_codigo", _pei.pei_codigo);
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }

        public Boolean ActualizarPedidoMetComplementario(PedidoMetComplementario _pmc)
        {
            Boolean _bool = true;
            SqlConnection _connection = null;

            try
            {
                String _sentencia = "";
                _connection = new SqlConnection(_conexion);
                SqlCommand _command = new SqlCommand(_sentencia, _connection);
                _command.Parameters.AddWithValue("@p_mcd_codigo", _pmc.mcd_codigo);
                _command.Parameters.AddWithValue("@p_pac_codigo", _pmc.pac_codigo);
                _command.Parameters.AddWithValue("@p_pes_codigo", _pmc.pes_codigo);
                _command.Parameters.AddWithValue("@p_pmc_codigo", _pmc.pmc_codigo);
                _command.Parameters.AddWithValue("@p_pmc_fecha", _pmc.pmc_fecha);
                _command.Parameters.AddWithValue("@p_pmc_fechaCarga", _pmc.pmc_fechaCarga);
                _command.Parameters.AddWithValue("@p_pmc_resultado", _pmc.pmc_resultado);
                _command.Parameters.AddWithValue("@p_pmc_salaOrigen", _pmc.pmc_salaOrigen);
                _command.Parameters.AddWithValue("@p_usu_usuario", _pmc.usu_usuario);
                _command.Parameters.AddWithValue("@p_pmc_comentario", _pmc.pmc_comentario);
                
                if (_pmc.pmc_documento == null) _command.Parameters.AddWithValue("@p_pmc_documento", DBNull.Value);
                else _command.Parameters.AddWithValue("@p_pmc_documento", _pmc.pmc_documento);

                _connection.Open();

                if (_pmc.pmc_codigo == 0)
                {
                    _sentencia = "INSERT INTO PedidoMetComplementarios" +
                                " VALUES(@p_usu_usuario, @p_pmc_salaOrigen, @p_pac_codigo, @p_mcd_codigo," +
                                       " @p_pes_codigo, @p_pmc_comentario, @p_pmc_resultado, @p_pmc_fecha," +
                                       " @p_pmc_fechaCarga, @p_pmc_documento)";
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
                else
                {
                    _sentencia = "UPDATE PedidoMetComplementarios" +
                                " SET mcd_codigo =  @p_mcd_codigo," +
                                    " pac_codigo = @p_pac_codigo," +
                                    " pes_codigo = @p_pes_codigo," +
                                    " pmc_fecha = @p_pmc_fecha," +
                                    " pmc_fechaCarga = @p_pmc_fechaCarga," +
                                    " pmc_resultado = @p_pmc_resultado," +
                                    " pmc_salaOrigen = @p_pmc_salaOrigen," +
                                    " pmc_comentario = @p_pmc_comentario," +
                                    " usu_usuario = @p_usu_usuario," +
                                    " pmc_documento = @p_pmc_documento" +
                                " WHERE pmc_codigo = @p_pmc_codigo";

                    _command.Parameters.AddWithValue("@p_pei_codigo", _pmc.pmc_codigo);
                    _command.CommandText = _sentencia;
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                _bool = false;
            }
            finally
            {
                _connection.Close();
            }

            return _bool;
        }
    }
}
