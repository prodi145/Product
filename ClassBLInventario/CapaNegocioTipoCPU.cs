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
    public class CapaNegocioTipoCPU
    {
        private AccesoSQL operacion = null;

        public CapaNegocioTipoCPU(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarTipoCPU(EntidadTipoCPU nuevo, ref string m)
        {
            string sentecia = "insert into Tipo_CPU(Tipo, Familia, Velocidad, Extra) values(@tip,@fam,@veloc,@extr);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("tip",SqlDbType.VarChar,40),
                new SqlParameter("fam",SqlDbType.VarChar,30),
                new SqlParameter("veloc",SqlDbType.VarChar,50),
                new SqlParameter("extr",SqlDbType.VarChar,30)
            };
            coleccion[0].Value = nuevo.Tipo;
            coleccion[1].Value = nuevo.Familia;
            coleccion[2].Value = nuevo.Velocidad;
            coleccion[3].Value = nuevo.Extra;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentecia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarTipoCPU(EntidadTipoCPU nuevo, ref string m)
        {
            string sentencia = "UPDATE Tipo_CPU set Tipo = @tip, Familia = @fam, Velocidad = @veloc, Extra = @extr WHERE id_Tcpu = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("tip",SqlDbType.VarChar,40),
                new SqlParameter("fam",SqlDbType.VarChar,30),
                new SqlParameter("veloc",SqlDbType.VarChar,50),
                new SqlParameter("extr",SqlDbType.VarChar,30)
            };
            coleccion[0].Value = nuevo.Tipo;
            coleccion[1].Value = nuevo.Familia;
            coleccion[2].Value = nuevo.Velocidad;
            coleccion[3].Value = nuevo.Extra;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }
        
        public Boolean EliminarTipoCPU(EntidadTipoCPU nuevo, ref string m)
        {
            string sentencia = "DELETE FROM Tipo_CPU WHERE Tipo = @tip";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("tip",SqlDbType.VarChar,40)
            };
            coleccion[0].Value = nuevo.Tipo;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodoTipoCPU(ref string mensaje)
        {
            string consulta = "Select * from Tipo_CPU";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public List<EntidadTipoCPU> DevuelveInfoTipoCPU(ref string mensaje)
        {
            List<EntidadTipoCPU> lista = new List<EntidadTipoCPU>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from Tipo_CPU";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadTipoCPU()
                    {

                        Tipo = atrapa[1].ToString(),
                        Familia = atrapa[2].ToString(),
                        Velocidad = atrapa[3].ToString(),
                        Extra = atrapa[4].ToString()

                    }
                    ); 

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }
    }
}
