using System;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// HostModel
    /// </summary>
    public class UcHost : UcItemReceiveBase<UcHost>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcHost(string xml)
            : base(xml)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcHost(XmlNode xml)
            : base(xml)
        { }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// Ip
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            Id = Data.GetInt("id");
            Domain = Data.GetString("domain");
            Ip = Data.GetString("ip");
            CheckForSuccess("id");
        }
    }
}
