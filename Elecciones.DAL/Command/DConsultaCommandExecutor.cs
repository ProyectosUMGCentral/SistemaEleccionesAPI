using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DAL.Command
{
    internal class DConsultaCommandExecutor
    {
        private OleDbConnection Conexion;
        private string dbName;
        private string spName;

        public DConsultaCommandExecutor(OleDbConnection Conexion)
        {
            this.Conexion = Conexion;
        }

        public DConsultaCommandExecutor(OleDbConnection Conexion, string dbName, string spName)
        {
            this.Conexion = Conexion;
            this.dbName = dbName;
            this.spName = spName;
        }

        public DataTable consultaCiudadano(string identificacion)
        {
            DataTable RespuestaAutorizar = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = this.Conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = $"{this.dbName}..{this.spName}";

                command.Parameters.AddWithValue("@identificacion", identificacion);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }
    }
}
