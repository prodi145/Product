using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data;
using System.Data.SqlClient;
using ClassAccesoDatosSQL22;
using ClassCapaEntidad;

namespace ClassBLInventario
{
    public class CapaNegocioMouse
    {
        private AccesoSQL operacion = null;

        public CapaNegocioMouse(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarMouse(EntidadMouse nuevo, ref string m)
        {
            string sentencia = "insert into mouse(f_marcamouse, conector) values(@f_maMous, @con);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("f_maMous",SqlDbType.Int),
                new SqlParameter("con",SqlDbType.VarChar,64)
            };
            coleccion[0].Value = nuevo.f_marcamouse;
            coleccion[1].Value = nuevo.conector;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarMouse(EntidadMouse nuevo, ref string m)
        {
            string sentencia = "UPDATE mouse set f_marcamouse = @f_maMous, conector = @con" +
                "WHERE id_mouse =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("f_maMous",SqlDbType.Int),
                new SqlParameter("con",SqlDbType.VarChar,64)
            };
            coleccion[0].Value = nuevo.id_mouse;
            coleccion[1].Value = nuevo.f_marcamouse;
            coleccion[2].Value = nuevo.conector;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadMouse> DevuelveInfoMouse(ref string mensaje)
        {
            List<EntidadMouse> lista = new List<EntidadMouse>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from mouse";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadMouse()
                    {
                        f_marcamouse = Convert.ToInt16(atrapa[1]),
                        conector = atrapa[2].ToString()
                    }
                    );
                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public DataTable ObtenTodMouse(ref string mensaje)
        {
            string consulta = "Select * from mouse";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean EliminarMouse(EntidadMouse nuevo, ref string m)
        {
            string sentencia = "DELETE FROM mouse WHERE conector = @con";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("con",SqlDbType.VarChar,10),
            };
            coleccion[0].Value = nuevo.conector;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }
    }
}

