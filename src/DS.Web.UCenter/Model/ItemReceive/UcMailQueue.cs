using DS.Web.UCenter.Client;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 邮件Model
    /// </summary>
    public class UcMailQueue
    {
        /// <summary>
        /// 修改结果
        /// </summary>
        public bool Result { get; private set; }
        /// <summary>
        /// 邮件Id
        /// </summary>
        public int MailId { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcMailQueue(string xml)
        {
            int result;
            Result = false;
            if (!int.TryParse(xml, out result)) return;
            MailId = result;
            Result = true;
        }
    }

}
