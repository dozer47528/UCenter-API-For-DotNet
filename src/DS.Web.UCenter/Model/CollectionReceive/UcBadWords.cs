using System;
using System.Collections.Generic;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 不良词汇集合
    /// </summary>
    public class UcBadWords : UcCollectionReceiveBase<UcBadWord, UcBadWords>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcBadWords(string xml)
            : base(xml)
        {
        }

        private IList<UcBadWord> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcBadWord> Items { get { return _items ?? (_items = new List<UcBadWord>()); } }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            SetItems(Items);
        }
    }
    
}
