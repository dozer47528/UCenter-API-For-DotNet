using System;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 短消息Model
    /// </summary>
    public class UcPm : UcItemReceiveBase<UcPm>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcPm(string xml)
            : base(xml)
        {}
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcPm(XmlNode xml)
            : base(xml)
        { }

        /// <summary>
        /// 短消息Id
        /// </summary>
        public int PmId { get; set; }
        /// <summary>
        /// 发件人
        /// </summary>
        public string MsgFrom { get; set; }
        /// <summary>
        /// 发件人Id
        /// </summary>
        public int MsgFromId { get; set; }
        /// <summary>
        /// 收件人Id
        /// </summary>
        public int MsgToId { get; set; }
        /// <summary>
        /// 是否未读
        /// </summary>
        public bool IsNew{ get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            PmId = Data.GetInt("pmid");
            MsgFrom = Data.GetString("msgfrom");
            MsgFromId = Data.GetInt("msgfromid");
            MsgToId = Data.GetInt("msgtoid");
            IsNew = Data.GetBool("new");
            Subject = Data.GetString("subject");
            Time = Data.GetDateTime("dateline");
            Message = Data.GetString("message");
            CheckForSuccess("pmid");
        }
    }
}
