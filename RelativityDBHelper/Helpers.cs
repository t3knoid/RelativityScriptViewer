using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelativityDBHelper.Models;

namespace RelativityDBHelper
{
    public class Helpers
    {
        private Database Database;

        public Helpers(Database db)
        {
            Database = db;
        }

        public Helpers()
        {
        }
        
        /// <summary>
        /// Queries the database for the Relativity version information
        /// </summary>
        /// <returns>Relativity version information</returns>
        public string getRelativityProductVersion()
        {
            string productVersion = string.Empty;

            try
            {
                string strSql = "SELECT max(ProductVersion) FROM [EDDS].[eddsdbo].[Version]";
                MSSQLResult result = MSSQLQuery.selectQuery(Database, strSql);
                while (result.reader.Read())
                {
                    productVersion = result.reader.GetString(0);
                }
                result.reader.Close();
            }
            catch (Exception ex)
            {
                //Logging.writeMessage("getRelativityProductVersion() failed to get Relativity SQL Server Name. " + ex.Message);
                return productVersion;
            }
            finally
            {
                Database.SQLConnection.Close();
            }

            return productVersion;
        }
        /// <summary>
        /// Returns a list of scripts from the Relativity script library
        /// </summary>
        /// <returns>List of strings</returns>
        public List<string> getScriptList()
        {
            List<string> scriptList = new List<string>();            

            try
            {
                string strSql = "SELECT Name FROM [EDDS].[eddsdbo].[RelativityScript]";
                MSSQLResult result = MSSQLQuery.selectQuery(Database, strSql);
                while (result.reader.Read())
                {
                    scriptList.Add(result.reader.GetString(0));
                }
                result.reader.Close();
            }
            catch (Exception ex)
            {
                //Logging.writeMessage("getRelativityProductVersion() failed to get Relativity SQL Server Name. " + ex.Message);
                return null; ;
            }
            finally
            {
                Database.SQLConnection.Close();
            }

            return scriptList;
        }

        public string getScript(string scriptname)
        {
            string script = String.Empty;

            try
            {
                string strSql = "SELECT Body FROM [EDDS].[eddsdbo].[RelativityScript] where Name = '" + scriptname + "'";
                MSSQLResult result = MSSQLQuery.selectQuery(Database, strSql);
                while (result.reader.Read())
                {
                    script = result.reader.GetString(0);
                }
                result.reader.Close();
            }
            catch (Exception ex)
            {
                //Logging.writeMessage("getRelativityProductVersion() failed to get Relativity SQL Server Name. " + ex.Message);
                return null; ;
            }
            finally
            {
                Database.SQLConnection.Close();
            }

            return script;
        }
    }
}
