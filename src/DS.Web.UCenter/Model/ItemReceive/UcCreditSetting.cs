using System;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 积分设置Model
    /// </summary>
    public class UcCreditSetting : UcItemReceiveBase<UcCreditSetting>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcCreditSetting(string xml)
            : base(xml)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcCreditSetting(XmlNode xml)
            : base(xml)
        { }

        /// <summary>
        /// 积分兑换的目标应用程序 ID
        /// </summary>
        public int AppIdDesc { get; set; }
        /// <summary>
        /// 积分兑换的目标积分编号
        /// </summary>
        public int CreditDesc { get; set; }
        /// <summary>
        /// 积分兑换的源积分编号
        /// </summary>
        public int CreditSrce { get; set; }
        /// <summary>
        /// 积分名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 积分单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 积分兑换比率
        /// </summary>
        public double Ratio { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            AppIdDesc = Data.GetInt("appiddesc");
            CreditDesc = Data.GetInt("creditdesc");
            CreditSrce = Data.GetInt("creditsrc");
            Title = Data.GetString("title");
            Unit = Data.GetString("unit");
            Ratio = Data.GetDouble("ratio");
            CheckForSuccess("appiddesc");
        }
    }
}
