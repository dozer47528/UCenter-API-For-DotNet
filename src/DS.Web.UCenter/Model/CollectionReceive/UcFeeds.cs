using System;
using System.Collections.Generic;
using System.Collections;

namespace DS.Web.UCenter
{
    /// <summary>
    /// Feed集合
    /// </summary>
    public class UcFeeds : UcCollectionReceiveBase<UcFeed, UcFeeds>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcFeeds(string xml)
            : base(xml)
        {
        }

        private IList<UcFeed> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcFeed> Items { get { return _items ?? (_items = new List<UcFeed>()); } }
        /// <summary>
        /// 总数
        /// </summary>
        public int Type { get; private set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            SetItems(Items, Data);
        }
    }

}
