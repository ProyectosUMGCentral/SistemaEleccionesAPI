using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DAL
{
    public class DShowOleDbException
    {

        public string GetOleDbException(OleDbException e)
        {

            string errorMessages = "";

            for (int i = 0; i < e.Errors.Count; i++)
            {
                errorMessages += "Index #" + i + "\n" +
                                 "Message: " + e.Errors[i].Message + "\n" +
                                 "NativeError: " + e.Errors[i].NativeError + "\n" +
                                 "Source: " + e.Errors[i].Source + "\n" +
                                 "SQLState: " + e.Errors[i].SQLState + "\n";
            }

            return errorMessages;
        }

    }
}
