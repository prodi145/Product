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
    public class CapaNegocioTipoRAM
    {
        private AccesoSQL operacion = null;
        
        public CapaNegocioTipoRAM(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarTipoRAM(EntidadTipoRAM nuevo, ref string m)
        {
            string sentecia = "insert into TipoRAM(Tipo, Extra) values(@tip, @extr);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("tip",SqlDbType.VarChar,20),
                new SqlParameter("extr",SqlDbType.VarChar,30)
            };
            coleccion[0].Value = nuevo.Tipo;
            coleccion[1].Value = nuevo.Extra;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentecia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarTipoRAM(EntidadTipoRAM nuevo, ref string m)
        {
            string sentencia = "UPDATE TipoRAM set Tipo = @tip, Extra = @extr WHERE id_tipoRAM = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("tip",SqlDbType.VarChar,20),
                new SqlParameter("extr",SqlDbType.VarChar,30)
            };
            coleccion[0].Value = nuevo.Tipo;
            coleccion[1].Value = nuevo.Extra;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean EliminarTipoRAM(EntidadTipoRAM nuevo, ref string m)
        {
            string sentencia = "DELETE FROM TipoRAM WHERE Tipo = @tip";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("tip",SqlDbType.VarChar,20)
            };
            coleccion[0].Value = nuevo.Tipo;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodoTipoRAM(ref string mensaje)
        {
            string consulta = "Select * from TipoRAM";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public List<EntidadTipoRAM> DevuelveInfTipoRAM(ref string mensaje)
        {
            List<EntidadTipoRAM> lista = new List<EntidadTipoRAM>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from TipoRAM";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadTipoRAM()
                    {

                        Tipo = atrapa[1].ToString(),
                        Extra = atrapa[2].ToString(),

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
