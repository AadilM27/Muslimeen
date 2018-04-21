using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Muslimeen.DAL
{
    internal class DBHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["MuslimeenDB"].ConnectionString;



    }
}
