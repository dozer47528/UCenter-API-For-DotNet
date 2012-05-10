using System;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 检查邮件 Model
    /// </summary>
    public class UcPmCheckNew:UcItemReceiveBase<UcPmCheckNew>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcPmCheckNew(string xml)
            : base(xml)
        {}
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcPmCheckNew(XmlNode xml)
            : base(xml)
        { }

        /// <summary>
        /// 未读消息数
        /// </summary>
        public int NewPm { get; set; }
        /// <summary>
        /// 私人消息数
        /// </summary>
        public int NewProvatePm { get; set; }
        /// <summary>
        /// 公共消息数
        /// </summary>
        public int AnnouncePm { get; set; }
        /// <summary>
        /// 系统消息数
        /// </summary>
        public int SystemPm { get; set; }
        /// <summary>
        /// 最后消息时间
        /// </summary>
        public DateTime LastDate { get; set; }
        /// <summary>
        /// 最后消息发件人 ID
        /// </summary>
        public int LastMsgFromId { get; set; }
        /// <summary>
        /// 最后消息发件人用户名
        /// </summary>
        public string LastMsgFrom { get; set; }
        /// <summary>
        /// 最后消息内容
        /// </summary>
        public string LastMsg { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            NewPm = Data.GetInt("newpm");
            NewProvatePm = Data.GetInt("newprivatepm");
            AnnouncePm = Data.GetInt("announcepm");
            SystemPm = Data.GetInt("systempm");
            LastDate = Data.GetDateTime("lastdate");
            LastMsgFromId = Data.GetInt("lastmsgfromid");
            LastMsgFrom = Data.GetString("lastmsgfrom");
            LastMsg = Data.GetString("lastmsg");
            CheckForSuccess("newpm");
        }
    }
}
