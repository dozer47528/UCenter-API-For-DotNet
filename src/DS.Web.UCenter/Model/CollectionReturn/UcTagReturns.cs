using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Web.UCenter
{
    /// <summary>
    /// Tag集合
    /// </summary>
    public class UcTagReturns : UcCollectionReturnBase<UcTagReturn>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tagName">Tag名字</param>
        /// <param name="ucTagReturn">集合</param>
        public UcTagReturns(string tagName, params UcTagReturn[] ucTagReturn)
        {
            AddToList(Items, ucTagReturn);
            TagName = tagName;
        }

        private IList<UcTagReturn> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcTagReturn> Items { get { return _items ?? (_items = new List<UcTagReturn>()); } }
        /// <summary>
        /// Tag名字
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetItems()
        {
            Data.Add("0",TagName);
            var index = 1;
            foreach(var item in Items)
            {
                Data.Add(index++, item);
            }
        }
    }
}
