using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 黑名单Model
    /// </summary>
    public class UcPmBlacklsGet
    {
        /// <summary>
        /// 黑名单
        /// </summary>
        public string[] DeleteNumber { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcPmBlacklsGet(string xml)
        {
            DeleteNumber = xml.Split(',');
        }
    }
}
