using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDBHelper
{
    public class Database
    {
        public SqlConnection SQLConnection 
        {
            get 
            {
                return connnection;
            }

        }

        private SqlConnection connnection=null;

        public Database(string server, string userid, string password, string timeout = "120")
        {
            this.connnection = new SqlConnection("Database=Master; Server=" + server + "; Connect Timeout=" + timeout + "; User Id=" + userid + "; Password=" + password + ";");
        }
    }

}
