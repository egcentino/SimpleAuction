using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Data.Providers
{
    public abstract class SqlServerData
    {
        protected string _connString;
        protected SqlServerData(string connString = null)
        {
            if (string.IsNullOrWhiteSpace(connString))
            {
                _connString = ConfigurationManager.ConnectionStrings["SimpleAuctionDb"].ConnectionString;
            } else
            {
                _connString = connString;
            }
        }

        protected IEnumerable<T> Select<T>(string sql, KeyValuePair<string, object>[] paramData, Func<SqlDataReader,T> mapper)  
        {
            using (var cn = GetConnection())
            {
                using (var cmd = GetCommand(sql,paramData, cn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return mapper(reader);
                        }
                    }
                }
            }
        }

         
        private SqlConnection GetConnection()
        {
            var cn = new SqlConnection();
            cn.ConnectionString = _connString;
            cn.Open();
            return cn;
        }

        private SqlCommand GetCommand(string sql, KeyValuePair<string, object>[] paramData, SqlConnection cn)
        {
            var cmd = new SqlCommand(sql, cn);
            AddParameters(cmd, paramData);
            return cmd;
        }

        public int Save(object dataObject, string tableName = null)
        {
            var type = dataObject.GetType();
            var paramData = type.GetProperties().Where(x => x.CanRead && !x.Name.Equals("id",StringComparison.OrdinalIgnoreCase))
                .Select(x => new KeyValuePair<string, object>(x.Name, x.GetValue(dataObject))).ToArray();
            var columnNames = string.Join(", ", paramData.Select(x => x.Key));
            var parmName = string.Join(", ", paramData.Select(x => $"@{x.Key}"));
            var sql = $"INSERT INTO {tableName ?? type.Name} ({columnNames}) VALUES ({parmName})";
            return Save(sql, paramData);
        }

        protected int Save(string sql, KeyValuePair<string, object>[] paramData)
        {
            var result = -1;
            using (var cn = GetConnection())
            {
                using (var tr = cn.BeginTransaction())
                {
                    using (var cmd = GetCommand(sql, paramData, cn))
                    {
                        cmd.Transaction = tr;
                        result = cmd.ExecuteNonQuery();
                        tr.Commit();
                    }
                }
            }
            return result;
        }

        private void AddParameters(SqlCommand cmd, KeyValuePair<string, object>[] paramData)
        {
            foreach (var p in paramData)
            {
                cmd.Parameters.Add(new SqlParameter(p.Key, p.Value ?? DBNull.Value));
            }
        }

        protected T GetValue<T>(object value)
        {
            if (value == DBNull.Value)
            {
                return default(T);
            }
            return (T)value;
        }
    }
}
