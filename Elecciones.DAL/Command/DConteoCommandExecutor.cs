using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DAL.Command
{
    public class DConteoCommandExecutor
    {

        private OleDbConnection Conexion;
        private string dbName;
        private string spName;

        public DConteoCommandExecutor(OleDbConnection Conexion)
        {
            this.Conexion = Conexion;
        }

        public DConteoCommandExecutor(OleDbConnection Conexion, string dbName, string spName)
        {
            this.Conexion = Conexion;
            this.dbName = dbName;
            this.spName = spName;
        }

        public DataTable ConteoVotos(int? centro_votacion)
        {
            DataTable RespuestaAutorizar = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = this.Conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = $"{this.dbName}..{this.spName}";

                command.Parameters.AddWithValue("@i_modo_consulta", "CONTEO-VOTOS");
                command.Parameters.AddWithValue("@i_centro_votacion", centro_votacion);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }

        public DataTable PorcentajeCentroVotacion(int centro_votacion)
        {
            DataTable RespuestaAutorizar = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = this.Conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = $"{this.dbName}..{this.spName}";

                command.Parameters.AddWithValue("@i_modo_consulta", "PORCENTAJE-CV");
                command.Parameters.AddWithValue("@i_centro_votacion", centro_votacion);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }

    }
}
