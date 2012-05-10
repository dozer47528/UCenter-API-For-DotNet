using System.Collections.Specialized;

namespace DS.Web.UCenter.Api
{
    /// <summary>
    /// Requser参数
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// </summary>
    public interface IUcRequestArguments
    {       
        /// <summary>
        /// Action
        /// </summary>
        string Action { get; }
        /// <summary>
        /// 时间
        /// </summary>
        long Time { get; }
        /// <summary>
        /// Query参数
        /// </summary>
        NameValueCollection QueryString { get; }

        /// <summary>
        /// Form参数
        /// </summary>
        string FormData { get; }

        /// <summary>
        /// 
        /// </summary>
        bool IsInvalidRequest { get; }
        /// <summary>
        /// 
        /// </summary>
        bool IsAuthracationExpiried { get; }
    }
}