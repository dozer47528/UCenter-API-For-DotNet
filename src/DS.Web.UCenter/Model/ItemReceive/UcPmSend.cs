namespace DS.Web.UCenter
{
    /// <summary>
    /// 短信发送Model
    /// </summary>
    public class UcPmSend
    {
        /// <summary>
        /// 短信Id
        /// </summary>
        public int PmId { get; private set; }

        /// <summary>
        /// 发送结果
        /// </summary>
        public PmSendResult Result
        {
            get { return PmId > 0 ? PmSendResult.Success : (PmSendResult)PmId; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcPmSend(string xml)
        {
            var result = 0;
            int.TryParse(xml, out result);
            PmId = result;
        }
    }

}
