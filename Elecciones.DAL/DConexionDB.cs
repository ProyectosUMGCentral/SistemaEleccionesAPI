using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Elecciones.DAL
{
    public class DConexionDB
    {
        public OleDbConnection DBConexion;
        private static DConexionDB _instance;
        private static object _protectInstance = new object();
        private string ConexionString;

        private DConexionDB()
        {
            this.ConexionString = WebConfigurationManager.AppSettings["SQLConn"];
        }

        public static DConexionDB GetInstance()
        {
            lock (_protectInstance)
            {
                return _instance == null ? new DConexionDB() : _instance;
            }
        }

        public void OpenConexion()
        {
            DBConexion = new OleDbConnection(this.ConexionString);
            DBConexion.Open();
        }

        public void CloseConexion()
        {
            if (DBConexion != null && DBConexion.State == ConnectionState.Open)
            {
                DBConexion.Close();
                DBConexion.Dispose();
            }
        }

    }
}
