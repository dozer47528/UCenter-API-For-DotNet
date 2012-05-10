using System.Collections.Generic;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 应用程序集合
    /// </summary>
    public class UcApps : UcCollectionReceiveBase<UcApp, UcApps>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcApps(string xml)
            : base(xml)
        {
        }

        private IList<UcApp> _items;
        /// <summary>
        /// 集合
        /// </summary>
        public IList<UcApp> Items { get { return _items ?? (_items = new List<UcApp>()); } }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            SetItems(Items);
        }
    }

}
