using System;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 不良词语Model
    /// </summary>
    public class UcBadWord : UcItemReceiveBase<UcBadWord>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcBadWord(string xml)
            : base(xml)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcBadWord(XmlNode xml)
            : base(xml)
        { }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public string Admin { get; set; }
        /// <summary>
        /// 查找字符串
        /// </summary>
        public string Find { get; set; }
        /// <summary>
        /// 替换字符串
        /// </summary>
        public string Replacement { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            Id = Data.GetInt("id");
            Admin = Data.GetString("admin");
            Find = Data.GetString("find");
            Replacement = Data.GetString("replacement");
            CheckForSuccess("id");
        }
    }
}
