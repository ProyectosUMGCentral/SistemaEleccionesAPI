using Elecciones.DAL.Command;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
