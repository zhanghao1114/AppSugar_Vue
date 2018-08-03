using System;
using System.Collections.Generic;
using System.Text;

namespace AppSugar_Vue.DTO.Base
{
    public class Result
    {
        /// <summary>
        /// 错误代码 错误码，400:未登录或已过期
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        ///信息
        /// </summary>

        public string Message { get; set; }

        /// <summary>
        /// 执行是否错误
        /// </summary>

        public bool IsError { get; set; } = false;
    }

    /// <summary>
    /// 公共返回泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result
    {
        /// <summary>
        /// 返回的数据
        /// </summary>
        public T Data { get; set; }
    }
}
