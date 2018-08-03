using AppSugar_Vue.Dao.Base;
using AppSugar_Vue.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSugar_Vue.Dao.IDao
{
    public interface IUserDao:IBaseDao
    {
        ///<summary>
        /// 插入数据
        ///</summary>
        ///<param name="model">系统用户</param>
        ///<returns>执行是否成功</returns>
        /// <remarks>2017-07-24  蒋松柏 创建</remarks>
        bool Insert(User model);

        ///<summary>
        /// 根据主键更新数据
        ///</summary>
        ///<param name="model">系统用户</param>
        ///<returns>执行是否成功</returns>
        ///<remarks>2017-07-24  蒋松柏 创建</remarks>
        void Update(User model);

        ///<summary>
        /// 根据主键删除数据
        ///</summary>
        ///<param name="id">主键id</param>
        ///<returns>执行是否成功</returns>
        ///<remarks>2017-07-24  蒋松柏 创建</remarks>
        bool Delete(Guid id);

        ///<summary>
        /// 根据主键获取实体
        ///</summary>
        ///<param name="id">主键id</param>
        /// <returns>系统用户实体</returns>
        /// <remarks>2017-07-24  蒋松柏 创建</remarks>
        User Get(Guid id);

        ///<summary>
        /// 根据账号获取实体
        ///</summary>
        ///<param name="loginName">账号</param>
        /// <returns>系统用户实体</returns>
        /// <remarks>2017-07-24  蒋松柏 创建</remarks>
        User GetByLoginName(string loginName);
    }
}
