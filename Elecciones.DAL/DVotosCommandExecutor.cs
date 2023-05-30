using Elecciones.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DAL
{
    public class DVotosCommandExecutor
    {

        private OleDbConnection Conexion;
        private string dbName;
        private string spName;

        public DVotosCommandExecutor(OleDbConnection Conexion)
        {
            this.Conexion = Conexion;
        }

        public DVotosCommandExecutor(OleDbConnection Conexion, string dbName, string spName)
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

                command.Parameters.AddWithValue("@i_id_eleccion", id);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }

        public DataTable EmitirVoto(EmisionVotoDTO emisionVoto)
        {
            DataTable RespuestaAutorizar = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = this.Conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = $"{this.dbName}..{this.spName}";

                command.Parameters.AddWithValue("@i_num_identificacion", emisionVoto.num_identificacion);
                command.Parameters.AddWithValue("@i_centro_votacion", emisionVoto.centro_votacion);
                command.Parameters.AddWithValue("@i_terminal_voto", emisionVoto.terminal_voto);
                command.Parameters.AddWithValue("@i_candidato", emisionVoto.candidato);
                command.Parameters.AddWithValue("@i_eleccion", emisionVoto.eleccion);
                command.Parameters.AddWithValue("@i_autoridad_mesa", emisionVoto.autoridad_mesa);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }

        public DataTable FinalizaEleccion(int id)
        {
            DataTable RespuestaAutorizar = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = this.Conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = $"{this.dbName}..{this.spName}";

                command.Parameters.AddWithValue("@i_id_eleccion", id);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }

    }
}
