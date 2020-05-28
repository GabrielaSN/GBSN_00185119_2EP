using System;
using System.Collections.Generic;
using System.Data;
using Parcial2.controls;

namespace Parcial2.modelo
{
    public class UsuarioDAO
    {
        public static List<usuario> getLista()
        {
            string sql = "select * from appuser";

            DataTable dt = conexion.realizarConsulta(sql);

            List<usuario> lista = new List<usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                usuario u = new usuario();
                u.iduser = fila[0].ToString();
                u.contrasena = fila[3].ToString();
                u.usertype = Convert.ToBoolean(fila[2].ToString());

                lista.Add(u);
            }
            return lista;
        }

        public static void actContra(string usuario, string nuevaContra)
                 {
                     string sql = String.Format(
                         "update usuario set contraseña='{0}' where nombreusuario='{1}';",
                         nuevaContra, usuario);
                     
                     conexion.realizarAccion(sql);
                 }

        public static void crearNuevo(string usuario)
        {
            string sql = String.Format(
                "insert into usuario(nombreusuario, contraseña, admin, activo) " +
                "values('{0}', '{1}', false, true);" ,
                usuario, encriptador.CrearMD5(usuario));
            
            conexion.realizarAccion(sql);
        }

        public static void actualizarPermisos(string usuario, bool admin, bool activo)
        {
            string sql = String.Format(
                "update usuario set admin={0}, activo={1} where nombreusuario='{2}';",
                admin ? "true" : "false", activo ? "true" : "false", usuario);
            
            conexion.realizarAccion(sql);
        }
        
        public static void eliminar(string usuario)
        {
            string sql = String.Format(
                "delete from pedido where nombreusuario ='{0}'; " +
                "delete from usuario where nombreusuario ='{0}';",
                usuario);
            
            conexion.realizarAccion(sql);
        }
    }
}