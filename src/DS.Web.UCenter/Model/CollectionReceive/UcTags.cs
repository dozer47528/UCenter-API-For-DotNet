using System;
using System.Collections.Generic;
using System.Collections;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 短消息集合
    /// </summary>
    public class UcTags : UcCollectionReceiveBase<UcTag, UcTags>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcTags(string xml)
            : base(xml)
        {
        }

        private IList<UcTag> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcTag> Items { get { return _items ?? (_items = new List<UcTag>()); } }
        /// <summary>
        /// 总数
        /// </summary>
        public int Type { get; private set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            SetItems(Items, (Hashtable)Data["data"]);
            Type = Data.GetInt("type");
        }
    }

}
