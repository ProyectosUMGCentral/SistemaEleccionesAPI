using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DAL
{
    public class DConteo
    {

        private DConexionDB _dConexionDB = DConexionDB.GetInstance();

        public DataTable CantidadVotos(int centro_votacion)
        {
            try
            {
                _dConexionDB.OpenConexion();
                DConteoCommandExecutor Executor = new DConteoCommandExecutor(_dConexionDB.DBConexion, "Sistema_Electoral", "sp_cons_info");
                DataTable resultadoEjecucion = Executor.ConteoVotos(centro_votacion);
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

        public DataTable PorcentajeCV(int centro_votacion)
        {
            try
            {
                _dConexionDB.OpenConexion();
                DConteoCommandExecutor Executor = new DConteoCommandExecutor(_dConexionDB.DBConexion, "Sistema_Electoral", "sp_cons_info");
                DataTable resultadoEjecucion = Executor.PorcentajeCentroVotacion(centro_votacion);
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
