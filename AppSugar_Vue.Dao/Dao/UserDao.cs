using AppSugar_Vue.Dao.Base;
using AppSugar_Vue.Dao.IDao;
using AppSugar_Vue.DTO.Base;
using AppSugar_Vue.Model.Base;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSugar_Vue.Dao.Dao
{
    public class UserDao : BaseDao, IUserDao
    {
        ///<summary>
        /// 构造方法
        ///</summary>
        public UserDao()
        {
            SetMappingTables(new List<MappingTable>
            {
                new MappingTable { EntityName = "User", DbTableName = "User" }
            });
        }

        ///<summary>
        /// 插入数据
        ///</summary>
        ///<param name="model">系统用户</param>
        ///<returns>执行是否成功</returns>
        /// <remarks>2017-07-24  蒋松柏 创建</remarks>
        public bool Insert(User model)
        {
            return DBContext.Insertable(model).ExecuteCommand() > 0;
        }

        ///<summary>
        /// 根据主键更新数据
        ///</summary>
        ///<param name="model">系统用户</param>
        ///<returns>执行是否成功</returns>
        public void Update(User model)
        {
            var count = DBContext.Updateable(model).Where(it => it.Id == model.Id).ExecuteCommand();
            if (count <= 0)
            {
                throw new Exception("更新失败！");
            }
        }

        ///<summary>
        /// 根据主键删除数据
        ///</summary>
        ///<param name="id">主键id</param>
        ///<returns>执行是否成功</returns>
        ///<remarks>2017-07-24  蒋松柏 创建</remarks>
        public bool Delete(Guid id)
        {
            int i = DBContext.Deleteable<User>().Where(it => it.Id == id).ExecuteCommand();
            return i > 0;
        }

        ///<summary>
        /// 根据主键获取实体
        ///</summary>
        ///<param name="id">主键id</param>
        /// <returns>系统用户实体</returns>
        /// <remarks>2017-07-24  蒋松柏 创建</remarks>
        public User Get(Guid id)
        {
            return DBContext.Queryable<User>().Single(u => u.Id == id);
        }

        ///<summary>
        /// 根据账号获取实体
        ///</summary>
        ///<param name="loginName">账号</param>
        /// <returns>系统用户实体</returns>
        /// <remarks>2017-07-24  蒋松柏 创建</remarks>
        public User GetByLoginName(string loginName)
        {
            return DBContext.Queryable<User>().Single(u => u.LoginName == loginName);
        }
    }
}
