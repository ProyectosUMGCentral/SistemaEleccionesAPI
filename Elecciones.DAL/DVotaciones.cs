using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DAL
{
    public class DVotaciones
    {

        private DConexionDB _dConexionDB = DConexionDB.GetInstance();

        public DataTable InicioEleccion(int id_eleccion)
        {
            try
            {
                _dConexionDB.OpenConexion();
                DCommandExecutor Executor = new DCommandExecutor(_dConexionDB.DBConexion, "Sistema_Electoral", "sp_inicio_eleccion");
                DataTable resultadoEjecucion = Executor.InicioEleccion(id_eleccion);
                return resultadoEjecucion;
            }
            catch (Exception ex)
            {
                if(ex is OleDbException)
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
