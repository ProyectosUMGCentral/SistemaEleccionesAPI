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

        public DataTable InicioEleccion(int id)
        {
            DataTable RespuestaAutorizar = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = this.Conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = $"{this.dbName}..{this.spName}";

                command.Parameters.AddWithValue("@i_num_identificacion", id);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }

    }
}
