using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ParcialUno.Models;

namespace ParcialUno.Data
{
    public class UsuarioDAO
    {
        public static List<Usuario> Listar()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = "SELECT * FROM [dbo].[Usuario]";
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
                            listadoUsuarios.Add(new Usuario()
                            {
                                UsuarioApellido = Convert.ToString(dr["UsuarioApellido"]),
                                UsuarioCedula = Convert.ToInt64(dr["UsuarioCedula"]),
                                UsuarioCorreo = Convert.ToString(dr["UsuarioCorreo"]),
                                UsuarioNombre = Convert.ToString(dr["UsuarioNombre"])
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
        public static bool Registrar(Usuario usuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"INSERT INTO [dbo].[Usuario]( UsuarioCedula,UsuarioCorreo,UsuarioNombre,UsuarioApellido) VALUES ({usuario.UsuarioCedula},'{usuario.UsuarioCorreo}','{usuario.UsuarioNombre}','{usuario.UsuarioApellido}')";
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
        public static bool Actualizar(Usuario usuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"UPDATE [dbo].[Usuario] SET UsuarioCorreo='{usuario.UsuarioCorreo}',UsuarioNombre='{usuario.UsuarioNombre}',UsuarioApellido='{usuario.UsuarioApellido}' WHERE UsuarioCedula={usuario.UsuarioCedula}";
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
        public static Usuario Obtener(long usuarioCedula)
        {
            Usuario usuario= new Usuario();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                string cadena = $"SELECT * FROM [dbo].[Usuario] WHERE UsuarioCedula={usuarioCedula}";
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
                            usuario = new Usuario()
                            {
                                UsuarioApellido = Convert.ToString(dr["UsuarioApellido"]),
                                UsuarioCedula = Convert.ToInt64(dr["UsuarioCedula"]),
                                UsuarioCorreo = Convert.ToString(dr["UsuarioCorreo"]),
                                UsuarioNombre = Convert.ToString(dr["UsuarioNombre"])
                            };
                        }
                    }
                    return usuario;
                }
                catch (Exception ex)
                {
                    return usuario;
                }
            }
        }
    }
}
