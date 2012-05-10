using System;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 积分设置Model
    /// </summary>
    public class UcClientSetting : UcItemReceiveBase<UcClientSetting>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcClientSetting(string xml)
            : base(xml)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcClientSetting(XmlNode xml)
            : base(xml)
        { }

        /// <summary>
        /// 
        /// </summary>
        public string AccessEmail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CensorEmail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CensoruserName { get; set; }
        /// <summary>
        /// 时间格式
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Doublee { get; set; }
        /// <summary>
        /// 时区（秒）
        /// </summary>
        public int TimeoffSet { get; set; }
        /// <summary>
        /// 每日短消息限制
        /// </summary>
        public int PmLimit1Day { get; set; }
        /// <summary>
        /// 短信间隔时间
        /// </summary>
        public int PmFloodCtrl { get; set; }
        /// <summary>
        /// 启用短消息中心
        /// </summary>
        public bool PmCenter { get; set; }
        /// <summary>
        /// 启用短信验证码
        /// </summary>
        public bool SendPmSeccode { get; set; }
        /// <summary>
        /// 发短消息最少注册天数
        /// </summary>
        public int PmSendRegDays { get; set; }
        /// <summary>
        /// 邮件来源地址
        /// </summary>
        public string MailDefault { get; set; }
        /// <summary>
        /// 邮件发送方式
        /// </summary>
        public string MailSend { get; set; }
        /// <summary>
        /// SMTP 服务器
        /// </summary>
        public string MailServer { get; set; }
        /// <summary>
        /// SMTP 端口
        /// </summary>
        public int MailPort { get; set; }
        /// <summary>
        /// SMTP 服务器要求身份验证
        /// </summary>
        public string MailAuth { get; set; }
        /// <summary>
        /// 发信人邮件地址
        /// </summary>
        public string MailFrom { get; set; }
        /// <summary>
        /// SMTP 身份验证用户名
        /// </summary>
        public string MailAuthUserName { get; set; }
        /// <summary>
        /// SMTP 身份验证密码
        /// </summary>
        public string MailAuthPassWord { get; set; }
        /// <summary>
        /// 邮件分隔符
        /// </summary>
        public string MailDelimiter { get; set; }
        /// <summary>
        /// 收件人地址中包含用户名
        /// </summary>
        public string MailUserName { get; set; }
        /// <summary>
        /// 屏蔽邮件发送中的全部错误提示
        /// </summary>
        public string MailSilent { get; set; }
        /// <summary>
        /// 12/24小时
        /// </summary>
        public string TimeFormat { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            AccessEmail = Data.GetString("accessemail");
            CensorEmail = Data.GetString("censoremail");
            CensoruserName = Data.GetString("censorusername");
            DateFormat = Data.GetString("dateformat");
            Doublee = Data.GetBool("doublee");
            TimeoffSet = Data.GetInt("timeoffset");
            PmLimit1Day = Data.GetInt("pmlimit1day");
            PmFloodCtrl = Data.GetInt("pmfloodctrl");
            PmCenter = Data.GetBool("pmcenter");
            SendPmSeccode = Data.GetBool("sendpmseccode");
            PmSendRegDays = Data.GetInt("pmsendregdays");
            MailDefault = Data.GetString("maildefault");
            MailSend = Data.GetString("mailsend");
            MailServer = Data.GetString("mailserver");
            MailPort = Data.GetInt("mailport");
            MailAuth = Data.GetString("mailauth");
            MailFrom = Data.GetString("mailfrom");
            MailAuthUserName = Data.GetString("mailauth_username");
            MailAuthPassWord = Data.GetString("mailauth_password");
            MailDelimiter = Data.GetString("maildelimiter");
            MailUserName = Data.GetString("mailusername");
            MailSilent = Data.GetString("mailsilent");
            TimeFormat = Data.GetString("timeformat");
        }
    }
}
