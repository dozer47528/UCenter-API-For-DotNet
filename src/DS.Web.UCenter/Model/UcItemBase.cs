using System.Collections;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 项目基类
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// </summary>
    public abstract class UcItemBase
    {
        private IDictionary _data;
        /// <summary>
        /// 数据
        /// </summary>
        protected IDictionary Data
        {
            get { return _data ?? (_data = new Hashtable()); }
            set { _data = value; }
        }
    }
}