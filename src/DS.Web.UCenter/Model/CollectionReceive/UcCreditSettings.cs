using System;
using System.Collections.Generic;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 积分设置集合
    /// </summary>
    public class UcCreditSettings : UcCollectionReceiveBase<UcCreditSetting, UcCreditSettings>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcCreditSettings(string xml)
            : base(xml)
        {
        }

        private IList<UcCreditSetting> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcCreditSetting> Items { get { return _items ?? (_items = new List<UcCreditSetting>()); } }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            SetItems(Items);
        }
    }

}
