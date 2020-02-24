using RelativityDBHelper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDBHelper
{
    static class MSSQLQuery
    {
        #region Methods
        static public MSSQLResult IsServerConnected(Database db)
        {
            SqlConnection connection = db.SQLConnection;
            using (connection)
            {
                try
                {
                    connection.Open();
                    return new MSSQLResult { success = true, message = "Connection successful" };
                }
                catch (Exception e)
                {
                    return new MSSQLResult { success = false, message = e.Message };
                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        static public MSSQLResult selectQuery(Database db, string queryString)
        {
            SqlConnection connection = db.SQLConnection;
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return new MSSQLResult { success = true, reader = reader, connection = connection };
            }
            catch (Exception e)
            {                
                connection.Close();
                connection.Dispose();
                return new MSSQLResult { success = false, message = e.Message };
            }

        }

        static public MSSQLResult updateQuery(Database db, string queryString)
        {
            SqlConnection connection = db.SQLConnection;
            SqlCommand command = new SqlCommand(queryString, connection);
            MSSQLResult result = new MSSQLResult();

            try
            {
                command.ExecuteNonQuery();
                result = new MSSQLResult { success = true, connection = connection };
            }
            catch (Exception e)
            {                
                connection.Close();
                connection.Dispose();
                result = new MSSQLResult { success = false, message = e.Message };
            }

            return result;
        }

        static public string getData(SqlDataReader reader, string column)
        {
            switch (Type.GetTypeCode(reader.GetFieldType(reader.GetOrdinal(column))))
            {

                case TypeCode.Boolean:
                    return reader.GetBoolean(reader.GetOrdinal(column)).ToString();
                case TypeCode.Byte:
                    return reader.GetByte(reader.GetOrdinal(column)).ToString();
                case TypeCode.Char:
                    return reader.GetChar(reader.GetOrdinal(column)).ToString();
                case TypeCode.DateTime:
                    return reader.GetDateTime(reader.GetOrdinal(column)).ToString("yyyy/mm/dd HH:mm:ss");
                case TypeCode.Decimal:
                    return reader.GetDecimal(reader.GetOrdinal(column)).ToString();
                case TypeCode.Double:
                    return reader.GetDouble(reader.GetOrdinal(column)).ToString();
                case TypeCode.Int16:
                    return reader.GetInt16(reader.GetOrdinal(column)).ToString();
                case TypeCode.Int32:
                    return reader.GetInt32(reader.GetOrdinal(column)).ToString();
                case TypeCode.Int64:
                    return reader.GetInt64(reader.GetOrdinal(column)).ToString();
                case TypeCode.String:
                    return reader.GetString(reader.GetOrdinal(column));
                default:
                    return "";
            }
        }

        #endregion
    }
}
