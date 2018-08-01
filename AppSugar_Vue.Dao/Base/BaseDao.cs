using AppSugar_Vue.Common;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AppSugar_Vue.Dao.Base
{
    public class BaseDao : IDisposable
    {
        static ConcurrentDictionary<string, SqlSugarClient> DBContextPool = new ConcurrentDictionary<string, SqlSugarClient>();

        private static readonly IConfiguration Configuration = AppSettingHelper.Configuration("Dao.Appsettings.json");

        private List<MappingTable> _mappingTables;

        private SqlSugarClient _db;

        protected void SetMappingTables(List<MappingTable> mappingTables)
        {
            this._mappingTables = mappingTables;
        }
        protected SqlSugarClient DBContext
        {
            get
            {
                SqlSugarClient result;
                result = CreateDBContext();
                return result;
            }
        }
        /// <summary>
        /// 从链接对象池获取对象
        /// </summary>
        /// <param name="localIdentifier">本地事务标识</param>
        /// <returns></returns>
        private SqlSugarClient GetDBContext(string localIdentifier)
        {
            if (DBContextPool.TryAdd(localIdentifier, null))
            {
                DBContextPool[localIdentifier] = CreateDBContext();
            }

            return DBContextPool[localIdentifier];
        }

        /// <summary>
        /// 创建数据库链接对象
        /// </summary>
        /// <returns></returns>
        private SqlSugarClient CreateDBContext()
        {

            _db = new SqlSugarClient(new ConnectionConfig { ConnectionString = Configuration.GetConnectionString("DefaultConnection"), DbType = DbType.SqlServer, IsAutoCloseConnection = true });
            if (_mappingTables != null)
            {
                _db.MappingTables.AddRange(_mappingTables);
            }
#if DEBUG
            _db.Ado.IsEnableLogEvent = true;//启用日志事件
            System.Diagnostics.Debug.WriteLine("※Begin SQL※");
            _db.Ado.LogEventStarting = (sql, par) => { System.Diagnostics.Debug.WriteLine(sql + "\r\n" + _db.Utilities.SerializeObject(par)); };
            System.Diagnostics.Debug.WriteLine("※End SQL※");
#endif
            return _db;
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }

        ~BaseDao()
        {
            Dispose();
        }
    }
}
