using ParcialUno.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ParcialUno.Data
{
    public class PrestamosDAO
    {
        public static List<Prestamo> Listar()
        {
            List<Prestamo> listadoUsuarios = new List<Prestamo>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = "SELECT * FROM [dbo].[Prestamo] WHERE EsDevuelto=0";
                SqlCommand cmd = new SqlCommand(cadena, oConexion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listadoUsuarios.Add(new Prestamo()
                            {
                                PrestamoFechaRegistro = Convert.ToDateTime(dr["PrestamoFechaRegistro"]),
                                UsuarioCedula = Convert.ToInt64(dr["UsuarioCedula"]),
                                EsDevuelto = Convert.ToBoolean(dr["EsDevuelto"]),
                                VideoJuegoCodigo = Convert.ToInt64(dr["VideoJuegoCodigo"]),
                                VideoJuegoCodigoEjemplar = Convert.ToInt64(dr["VideoJuegoCodigoEjemplar"]),
                                PrestamoId = Convert.ToInt64(dr["PrestamoId"])
                            });
                        }

                    }



                    return listadoUsuarios;
                }
                catch (Exception ex)
                {
                    return listadoUsuarios;
                }
            }
        }
        public static bool Registrar(Prestamo Prestamo)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"INSERT INTO [dbo].[Prestamo]( UsuarioCedula,VideoJuegoCodigo,VideoJuegoCodigoEjemplar,PrestamoFechaRegistro,EsDevuelto) VALUES ({Prestamo.UsuarioCedula},'{Prestamo.VideoJuegoCodigo}','{Prestamo.VideoJuegoCodigoEjemplar}','{Prestamo.PrestamoFechaRegistro}','{Prestamo.EsDevuelto}')";
                SqlCommand cmd = new SqlCommand(cadena, oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Actualizar(Prestamo Prestamo)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"UPDATE [dbo].[Prestamo] SET UsuarioCedula='{Prestamo.UsuarioCedula}',PrestamoFechaRegistro='{Prestamo.PrestamoFechaRegistro}',EsDevuelto='{Prestamo.EsDevuelto}' WHERE PrestamoId={Prestamo.PrestamoId}";
                SqlCommand cmd = new SqlCommand(cadena, oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static Prestamo Obtener(long prestamoId)
        {
            Prestamo Prestamo = new Prestamo();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"SELECT * FROM [dbo].[Prestamo] WHERE PrestamoId={prestamoId}";
                SqlCommand cmd = new SqlCommand(cadena, oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Prestamo = new Prestamo()
                            {
                                PrestamoFechaRegistro = Convert.ToDateTime(dr["PrestamoFechaRegistro"]),
                                UsuarioCedula = Convert.ToInt64(dr["UsuarioCedula"]),
                                EsDevuelto = Convert.ToBoolean(dr["EsDevuelto"]),
                                VideoJuegoCodigo = Convert.ToInt64(dr["VideoJuegoCodigo"]),
                                VideoJuegoCodigoEjemplar = Convert.ToInt64(dr["VideoJuegoCodigoEjemplar"]),
                                PrestamoId = Convert.ToInt64(dr["PrestamoId"])
                            };
                        }
                    }
                    return Prestamo;
                }
                catch (Exception ex)
                {
                    return Prestamo;
                }
            }
        }

        public static Prestamo ObtenerPrestamoVideoJuego(long videoJuegoCodigo)
        {
            Prestamo Prestamo = new Prestamo();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"SELECT * FROM [dbo].[Prestamo] WHERE VideoJuegoCodigo={videoJuegoCodigo}";
                SqlCommand cmd = new SqlCommand(cadena, oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Prestamo = new Prestamo()
                            {
                                PrestamoFechaRegistro = Convert.ToDateTime(dr["PrestamoFechaRegistro"]),
                                UsuarioCedula = Convert.ToInt64(dr["UsuarioCedula"]),
                                EsDevuelto = Convert.ToBoolean(dr["EsDevuelto"]),
                                VideoJuegoCodigo = Convert.ToInt64(dr["VideoJuegoCodigo"]),
                                VideoJuegoCodigoEjemplar = Convert.ToInt64(dr["VideoJuegoCodigoEjemplar"]),
                                PrestamoId = Convert.ToInt64(dr["PrestamoId"])
                            };
                        }
                    }
                    return Prestamo;
                }
                catch (Exception ex)
                {
                    return Prestamo;
                }
            }
        }
    }
}