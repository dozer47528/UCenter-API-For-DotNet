using System;
using System.Collections.Generic;
using System.Collections;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 短消息集合
    /// </summary>
    public class UcFriends : UcCollectionReceiveBase<UcFriend, UcFriends>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcFriends(string xml)
            : base(xml)
        {
        }

        private IList<UcFriend> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcFriend> Items { get { return _items ?? (_items = new List<UcFriend>()); } }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            SetItems(Items, Data);
        }
    }

}
