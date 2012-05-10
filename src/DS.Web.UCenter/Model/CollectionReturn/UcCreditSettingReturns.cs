using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 积分设置集合
    /// </summary>
    public class UcCreditSettingReturns : UcCollectionReturnBase<UcCreditSettingReturn>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ucCreditSetting">集合</param>
        public UcCreditSettingReturns(params UcCreditSettingReturn[] ucCreditSetting)
        {
            AddToList(Items, ucCreditSetting);
        }

        private IList<UcCreditSettingReturn> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcCreditSettingReturn> Items { get { return _items ?? (_items = new List<UcCreditSettingReturn>()); } }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetItems()
        {
            var index = 0;
            foreach(var item in Items)
            {
                Data.Add(index++, item);
            }
        }
    }
}
