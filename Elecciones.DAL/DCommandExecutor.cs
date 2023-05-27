using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DAL
{
    public class DCommandExecutor
    {

        private OleDbConnection Conexion;
        private string dbName;
        private string spName;

        public DCommandExecutor(OleDbConnection Conexion)
        {
            this.Conexion = Conexion;
        }

        public DCommandExecutor(OleDbConnection Conexion, string dbName, string spName)
        {
            this.Conexion = Conexion;
            this.dbName = dbName;
            this.spName = spName;
        }

        public DataTable testconsulta()
        {
            DataTable RespuestaAutorizar = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {
                command.Connection = this.Conexion;
                command.CommandType = CommandType.Text;

                string query = $"SELECT * FROM el_municipio";

                command.CommandText = query;

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }

    }
}
