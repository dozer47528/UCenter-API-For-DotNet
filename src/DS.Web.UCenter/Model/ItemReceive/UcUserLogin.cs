using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 用户登陆Model
    /// </summary>
    public class UcUserLogin:UcItemReceiveBase<UcUserLogin>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcUserLogin(string xml)
            : base(xml)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcUserLogin(XmlNode xml)
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
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// 是否有重复的名称
        /// </summary>
        public bool HasSameName { get; set; }
        /// <summary>
        /// 登陆结果
        /// </summary>
        public LoginResult Result
        {
            get { return Uid > 0 ? LoginResult.Success : (LoginResult) Uid; }
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            Uid = Data.GetInt("0");
            UserName = Data.GetString("1");
            PassWord = Data.GetString("2");
            Mail = Data.GetString("3");
            HasSameName = Data.GetBool("4");
            CheckForSuccess("0");
        }
    }

}
