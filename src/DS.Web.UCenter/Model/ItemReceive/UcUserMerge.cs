using DS.Web.UCenter.Client;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 用户合并Model
    /// </summary>
    public class UcUserMerge
    {
        /// <summary>
        /// Uid
        /// </summary>
        public int Uid { get; private set; }
        /// <summary>
        /// 合并结果
        /// </summary>
        public UserMergeResult Result
        {
            get { return Uid > 0 ? UserMergeResult.Success : (UserMergeResult)Uid; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcUserMerge(string xml)
        {
            var result = 0;
            int.TryParse(xml, out result);
            Uid = result;
        }
    }


}
