using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RelativityDBHelper.Models
{
    public class MSSQLResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public SqlDataReader reader { get; set; }
        public SqlConnection connection { get; set; }
    }
}
