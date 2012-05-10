using DS.Web.UCenter.Client;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 用户修改Model
    /// </summary>
    public class UcUserEdit
    {
        /// <summary>
        /// 修改结果
        /// </summary>
        public UserEditResult Result { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcUserEdit(string xml)
        {
            var result = 0;
            int.TryParse(xml, out result);
            Result = (UserEditResult)result;
        }
    }

}
