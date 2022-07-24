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
    public class CapaNegocioComFinImg
    {
        private AccesoSQL operacion = null;

        public CapaNegocioComFinImg(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarCompFinImg(EntidadComputaFinalImg nuevo, ref string m)
        {
            string sentencia = "insert into compufinalimg(urluno, urldos, urltres, " +
                "fkcompfinal) values(@un, @do, @tr, @fk);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("un",SqlDbType.VarChar,255),
                new SqlParameter("do",SqlDbType.VarChar,255),
                new SqlParameter("tr",SqlDbType.VarChar,255),
                new SqlParameter("fk",SqlDbType.VarChar, 10)
            };
            coleccion[0].Value = nuevo.urluno;
            coleccion[1].Value = nuevo.urldos;
            coleccion[2].Value = nuevo.urltres;
            coleccion[3].Value = nuevo.fkcompfinal;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarCompFinImg(EntidadComputaFinalImg nuevo, ref string m)
        {
            string sentencia = "UPDATE compufinalimg set urluno = @un, urldos = @do, urltres = @tr," +
                "fkcompfinal = @fk WHERE idimg = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("un",SqlDbType.VarChar,255),
                new SqlParameter("do",SqlDbType.VarChar,255),
                new SqlParameter("tr",SqlDbType.VarChar,255),
                new SqlParameter("fk",SqlDbType.VarChar, 10)
            };
            coleccion[0].Value = nuevo.idimg;
            coleccion[1].Value = nuevo.urluno;
            coleccion[2].Value = nuevo.urldos;
            coleccion[3].Value = nuevo.urltres;
            coleccion[4].Value = nuevo.fkcompfinal;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadComputaFinalImg> DevuelveInfoCompFinImg(ref string mensaje)
        {
            List<EntidadComputaFinalImg> lista = new List<EntidadComputaFinalImg>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from compufinalimg";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadComputaFinalImg()
                    {
                        urluno = atrapa[1].ToString(),
                        urldos = atrapa[2].ToString(),
                        urltres = atrapa[3].ToString(),
                        fkcompfinal = atrapa[4].ToString()
                    }
                    );
                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public DataTable ObtenTodasCompFinImg(ref string mensaje)
        {
            string consulta = "Select * from compufinalimg";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean EliminarCompFinImg(EntidadComputaFinalImg nuevo, ref string m)
        {
            string sentencia = "DELETE FROM compufinalimg WHERE urluno = @un";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("un",SqlDbType.VarChar,255),
            };
            coleccion[0].Value = nuevo.urluno;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }
    }
}
