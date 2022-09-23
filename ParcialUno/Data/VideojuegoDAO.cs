using ParcialUno.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ParcialUno.Data
{
    public class VideojuegoDAO
    {
        public static List<VideoJuego> Listar()
        {
            List<VideoJuego> listadoVideoJuegos = new List<VideoJuego>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = "SELECT * FROM [dbo].[VideoJuego]";
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
                            listadoVideoJuegos.Add(new VideoJuego()
                            {
                                VideoJuegoCodigo = Convert.ToInt64(dr["VideoJuegoCodigo"]),
                                VideoJuegoCodigoEjemplar = Convert.ToInt64(dr["VideoJuegoCodigoEjemplar"]),
                                VideoJuegoNombre = Convert.ToString(dr["VideoJuegoNombre"])
                            });
                        }

                    }



                    return listadoVideoJuegos;
                }
                catch (Exception ex)
                {
                    return listadoVideoJuegos;
                }
            }
        }

        public static bool Registrar(VideoJuego videoJuego)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"INSERT INTO [dbo].[VideoJuego]( VideoJuegoCodigo,VideoJuegoCodigoEjemplar,VideoJuegoNombre) VALUES ({videoJuego.VideoJuegoCodigo},'{videoJuego.VideoJuegoCodigoEjemplar}','{videoJuego.VideoJuegoNombre}')";
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

        public static bool Actualizar(VideoJuego videoJuego)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"UPDATE [dbo].[VideoJuego] SET VideoJuegoNombre='{videoJuego.VideoJuegoNombre}' WHERE VideoJuegoCodigo={videoJuego.VideoJuegoCodigo} AND VideoJuegoCodigoEjemplar={videoJuego.VideoJuegoCodigoEjemplar}";
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
        public static VideoJuego Obtener(long videoJuegoCodigo, long videoJuegoCodigoEjemplar)
        {
            VideoJuego videojuegos = new VideoJuego();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"SELECT * FROM [dbo].[Videojuego] WHERE VideoJuegoCodigo={videoJuegoCodigo} AND VideoJuegoCodigoEjemplar={videoJuegoCodigoEjemplar}";
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
                            videojuegos = new VideoJuego()
                            {
                                VideoJuegoCodigo = Convert.ToInt64(dr["VideoJuegoCodigo"]),
                                VideoJuegoCodigoEjemplar = Convert.ToInt64(dr["VideoJuegoCodigoEjemplar"]),
                                VideoJuegoNombre = Convert.ToString(dr["VideoJuegoNombre"])
                            };
                        }
                    }
                    return videojuegos;
                }
                catch (Exception ex)
                {
                    return videojuegos;
                }
            }
        }
    }
}