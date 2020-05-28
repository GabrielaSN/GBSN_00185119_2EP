using System;
using System.Collections.Generic;
using System.Data;
using Parcial2.controls;

namespace Parcial2.modelo
{
    public class productDAO
    {
        public static List<product> getLista()
        {
            string sql = "select * from producto";

            DataTable dt = conexion.realizarConsulta(sql);

            List<product> lista = new List<product>();
            foreach (DataRow fila in dt.Rows)
            {
                product f = new product();
                f.idproduct = fila[0].ToString();
                f.idbusinnes = fila[1].ToString();
                f.nombre = fila[2].ToString();

                
                
                lista.Add(f);
            }
            return lista;
        }
        
    }
}