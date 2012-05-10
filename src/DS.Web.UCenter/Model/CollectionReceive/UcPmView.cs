using System;
using System.Collections.Generic;
using System.Collections;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 短消息集合
    /// </summary>
    public class UcPmView : UcCollectionReceiveBase<UcPm, UcPmView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcPmView(string xml)
            : base(xml)
        {
        }

        private IList<UcPm> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcPm> Items { get { return _items ?? (_items = new List<UcPm>()); } }


        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            SetItems(Items, Data);
        }
    }

}
