using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 受保护用户Model
    /// </summary>
    public class UcUserProtected : UcItemReceiveBase<UcUserProtected>
    {
                /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcUserProtected(string xml)
            : base(xml)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcUserProtected(XmlNode xml)
            : base(xml)
        { }

        /// <summary>
        /// Uid
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            Uid = Data.GetInt("uid");
            UserName = Data.GetString("username");
            CheckForSuccess("uid");
        }
    }
}
