using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Oracle.DataAcces;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace Data
{
    public class Conexion
    {

        private string conectionString;
        public enum TipoConexion {
            principal=0,
            ora7=1
        }
        public Conexion() {

            try
            {
                conectionString = ConfigurationManager.ConnectionStrings["ORACLESTR"].ConnectionString;

            }
            catch (Exception es)
            {
                Console.WriteLine("No hay cadena de conexíon "+es.Message);
            }
        }



        public Conexion(TipoConexion tipo)
        {
            switch (tipo)
            {

                case TipoConexion.principal:
                    conectionString = ConfigurationManager.ConnectionStrings["ORACLESTR"].ConnectionString;
                    break;
                case TipoConexion.ora7:
                    conectionString = ConfigurationManager.ConnectionStrings["ORACLESTR2"].ConnectionString;
                    break;
            }
        }

       

        public DataTable Ejecutar(String Query)
        {
            DataTable dtrpta = new DataTable();
            OracleDataReader reader = null;
            try
            {
                OracleConnection sqlConnection1 = new OracleConnection(conectionString);
                OracleCommand cmd = new OracleCommand();

                cmd.CommandText = Query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                dtrpta.Load(reader);
                sqlConnection1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error ejecutando consulta ==> " + e.Message);
                dtrpta = null;
            }

            return dtrpta;

        }

        public DataTable EjecutarProcedimiento(Procedimiento proc) {

            DataTable dtrpta = null ;
            OracleDataReader reader=null ;
            OracleConnection conn=null;
            OracleCommand command = null;
            try
            {
                conn = new OracleConnection(conectionString);
                
                command = new OracleCommand(proc.nombre, conn);
                command.CommandType = CommandType.StoredProcedure;

                foreach (Parametro param in proc.parametros)
                {
                    OracleParameter paramorcl = null;
                    if (param.tipo == Parametro.tipoIN)
                    {
                        paramorcl = command.Parameters.Add(param.nombreVariable, param.contenido);
                        paramorcl.Direction = ParameterDirection.Input;
                        paramorcl.OracleDbType = param.SQLDBTYPE;
                    }
                    else if (param.tipo == Parametro.tipoINOUT)
                    {
                        paramorcl = command.Parameters.Add(param.nombreVariable, param.contenido);
                        paramorcl.Direction = ParameterDirection.InputOutput;
                        paramorcl.OracleDbType = param.SQLDBTYPE;
                        
                    }
                    else if (param.tipo == Parametro.tipoOUT)
                    {
                        paramorcl = command.Parameters.Add(param.nombreVariable, param.contenido);
                        paramorcl.Direction = ParameterDirection.Output;
                        paramorcl.OracleDbType = param.SQLDBTYPE;
                    }
                }               
                
                command.Parameters.Add("CUR_RPTA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                conn.Open();
                reader = command.ExecuteReader();
                if (reader!=null && reader.HasRows) {
                    dtrpta = new DataTable();
                    dtrpta.Load(reader);
                }                
                conn.Close();

            }
            catch (Exception s)
            {
                Console.WriteLine("Error ejecutando procedimiento ==> " + s.Message);
                dtrpta = null;
            }
            return dtrpta;

        }

    }
}
