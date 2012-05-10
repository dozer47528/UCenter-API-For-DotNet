namespace DS.Web.UCenter
{
    /// <summary>
    /// 积分设置Model
    /// </summary>
    public class UcCreditSettingReturn:UcItemReturnBase
    {
        /// <summary>
        /// 积分名字
        /// </summary>
        public string CreditName { get; set; }
        /// <summary>
        /// 积分单位
        /// </summary>
        public string CreditUnit { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="creditName">积分名字</param>
        /// <param name="creditUnit">积分单位</param>
        public UcCreditSettingReturn(string creditName, string creditUnit)
        {
            CreditName = creditName;
            CreditUnit = creditUnit;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetItems()
        {
            Data.Add("0", CreditName);
            Data.Add("1", CreditUnit);
        }

    }
}
