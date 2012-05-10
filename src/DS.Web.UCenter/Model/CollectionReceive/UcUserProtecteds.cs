using System;
using System.Collections.Generic;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 受保护用户集合
    /// </summary>
    public class UcUserProtecteds : UcCollectionReceiveBase<UcUserProtected, UcUserProtecteds>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcUserProtecteds(string xml)
            : base(xml)
        {
        }

        private IList<UcUserProtected> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcUserProtected> Items { get { return _items ?? (_items = new List<UcUserProtected>()); } }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            SetItems(Items);
        }
    }

}
