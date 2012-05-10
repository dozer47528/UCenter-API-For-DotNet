using System;
using System.Collections.Generic;

namespace DS.Web.UCenter
{
    /// <summary>
    /// Host集合
    /// </summary>
    public class UcHosts : UcCollectionReceiveBase<UcHost, UcHosts>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcHosts(string xml)
            : base(xml)
        {
        }

        private IList<UcHost> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcHost> Items { get { return _items ?? (_items = new List<UcHost>()); } }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            SetItems(Items);
        }
    }
    
}
