﻿using Elecciones.DAL.Command;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elecciones.DTOs;

namespace Elecciones.DAL
{
    public class DConsultasDB
    {
        private DConexionDB _dConexionDB = DConexionDB.GetInstance();

        public DataTable consultaCiudadano(string identificacion)
        {
            try
            {
                _dConexionDB.OpenConexion();
                DConsultaCommandExecutor Executor = new DConsultaCommandExecutor(_dConexionDB.DBConexion, "Sistema_Electoral", "sp_cons_ciudadano");
                DataTable resultadoEjecucion = Executor.consultaCiudadano(identificacion);
                return resultadoEjecucion;
            }
            catch (Exception ex)
            {
                if (ex is OleDbException)
                {
                    DShowOleDbException dShowOleDbException = new DShowOleDbException();
                    string errorMessage = dShowOleDbException.GetOleDbException((OleDbException)ex);
                    throw new Exception(errorMessage);
                }
                throw new Exception("DALException:", ex);
            }
            finally
            {
                _dConexionDB.CloseConexion();
            }
        }
        public DataTable consultaUsuario (string email, string passWord)
        {
            try
            {
                _dConexionDB.OpenConexion();
                DConsultaCommandExecutor Executor = new DConsultaCommandExecutor(_dConexionDB.DBConexion, "Sistema_Electoral", "sp_cons_usuario");
                DataTable resultadoEjecucion = Executor.consultaUsuario(email, passWord);
                return resultadoEjecucion;
            }
            catch (Exception ex)
            {
                if (ex is OleDbException)
                {
                    DShowOleDbException dShowOleDbException = new DShowOleDbException();
                    string errorMessage = dShowOleDbException.GetOleDbException((OleDbException)ex);
                    throw new Exception(errorMessage);
                }
                throw new Exception("DALException:", ex);
            }
            finally
            {
                _dConexionDB.CloseConexion();
            }
        }
        public DataTable consultaCandidato(consultaCandidatosDTO candidato)
        {
            try
            {
                _dConexionDB.OpenConexion();
                DConsultaCommandExecutor Executor = new DConsultaCommandExecutor(_dConexionDB.DBConexion, "Sistema_Electoral", "sp_cons_candidatos");
                DataTable resultadoEjecucion = Executor.consultaCandidatos(candidato);
                return resultadoEjecucion;
            }
            catch (Exception ex)
            {
                if (ex is OleDbException)
                {
                    DShowOleDbException dShowOleDbException = new DShowOleDbException();
                    string errorMessage = dShowOleDbException.GetOleDbException((OleDbException)ex);
                    throw new Exception(errorMessage);
                }
                throw new Exception("DALException:", ex);
            }
            finally
            {
                _dConexionDB.CloseConexion();
            }
        }

        public DataTable VerificaVotoCiudadano(string identificacion, int eleccion)
        {
            try
            {
                _dConexionDB.OpenConexion();
                DConsultaCommandExecutor Executor = new DConsultaCommandExecutor(_dConexionDB.DBConexion, "Sistema_Electoral", "sp_verifica_voto_ciudadano");
                DataTable resultadoEjecucion = Executor.VerificaVotoCiudadano(identificacion, eleccion);
                return resultadoEjecucion;
            }
            catch (Exception ex)
            {
                if (ex is OleDbException)
                {
                    DShowOleDbException dShowOleDbException = new DShowOleDbException();
                    string errorMessage = dShowOleDbException.GetOleDbException((OleDbException)ex);
                    throw new Exception(errorMessage);
                }
                throw new Exception("DALException:", ex);
            }
            finally
            {
                _dConexionDB.CloseConexion();
            }
        }

    }
}
