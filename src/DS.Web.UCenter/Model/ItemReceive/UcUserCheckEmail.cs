using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 检查右键Model
    /// </summary>
    public class UcUserCheckEmail
    {
        /// <summary>
        /// 检查结果
        /// </summary>
        public UserCheckEmailResult Result { get;private set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcUserCheckEmail(string xml)
        {
            var result = 0;
            int.TryParse(xml, out result);
            Result = (UserCheckEmailResult)result;
        }
    }


}
