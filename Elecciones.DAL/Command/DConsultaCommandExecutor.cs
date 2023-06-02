using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elecciones.DTOs;

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
        public DataTable consultaUsuario(string email, string passWord)
        {
            DataTable RespuestaAutorizar = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = this.Conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = $"{this.dbName}..{this.spName}";

                command.Parameters.AddWithValue("@emial", email);
                command.Parameters.AddWithValue("@password", passWord);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }
        public DataTable consultaCandidatos(consultaCandidatosDTO candidato)
        {
            DataTable RespuestaAutorizar = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = this.Conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = $"{this.dbName}..{this.spName}";

                command.Parameters.AddWithValue("@CARGO", candidato.cargo);
                command.Parameters.AddWithValue("@MUNICIPIO", candidato.municipio);
                command.Parameters.AddWithValue("@DEPARTAMENTO", candidato.departamento);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(RespuestaAutorizar);
                }
            }
            return RespuestaAutorizar;
        }

        public DataTable VerificaVotoCiudadano(string identificacion, int eleccion)
        {
            DataTable Response = new DataTable();
            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = this.Conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = $"{this.dbName}..{this.spName}";

                command.Parameters.AddWithValue("@i_num_identificacion", identificacion);
                command.Parameters.AddWithValue("@i_eleccion", eleccion);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(Response);
                }
            }
            return Response;
        }

    }
}
