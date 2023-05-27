using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DAL
{
    public class DVotaciones
    {

        private DConexionDB _dConexionDB = DConexionDB.GetInstance();

        public DataTable testResultadoDB()
        {
            try
            {
                _dConexionDB.OpenConexion();
                DCommandExecutor Executor = new DCommandExecutor(_dConexionDB.DBConexion, "Sistema_Electoral", "sp_ln_autoriza_pais");
                DataTable resultadoEjecucion = Executor.testconsulta();
                return resultadoEjecucion;
            }
            catch (Exception ex)
            {
                throw new Exception("DALException:", ex);
            }
            finally
            {
                _dConexionDB.CloseConexion();
            }
        }


    }
}
