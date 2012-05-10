using System;
using System.Collections.Generic;
using System.Xml;
using System.Collections;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 应用Model
    /// </summary>
    public class UcApp : UcItemReceiveBase<UcApp>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcApp(string xml)
            : base(xml)
        {}
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcApp(XmlNode xml)
            : base(xml)
        { }

        /// <summary>
        /// AppId
        /// </summary>
        public int AppId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Ip
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 其他地址
        /// </summary>
        public string ViewProUrl { get; set; }
        /// <summary>
        /// 接口名称
        /// </summary>
        public string ApiFileName { get; set; }
        /// <summary>
        /// 字符集
        /// </summary>
        public string CharSet { get; set; }
        /// <summary>
        /// 是否同步登陆
        /// </summary>
        public bool SynLogin { get; set; }
        private IDictionary<string, string> _extra;
        /// <summary>
        /// 附加信息
        /// </summary>
        public IDictionary<string, string> Extra { get { return _extra ?? (_extra = new Dictionary<string, string>()); } }
        /// <summary>
        /// 传输信息
        /// </summary>
        public string RecvNote { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            AppId = Data.GetInt("appid");
            TypeName = Data.GetString("type");
            Name = Data.GetString("name");
            Url = Data.GetString("url");
            Ip = Data.GetString("ip");
            ViewProUrl = Data.GetString("viewprourl");
            ApiFileName = Data.GetString("apifilename");
            CharSet = Data.GetString("charset");
            SynLogin = Data.GetBool("synlogin");
            Extra.Add("apppath", Data.GetHashtable("extra").GetString("apppath"));
            RecvNote = Data.GetString("recvnote");
            CheckForSuccess("appid");
        }
    }
}
