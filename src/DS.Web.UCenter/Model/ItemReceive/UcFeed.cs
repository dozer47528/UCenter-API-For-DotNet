using System;
using System.Collections.Generic;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// FeedModel
    /// </summary>
    public class UcFeed : UcItemReceiveBase<UcFeed>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcFeed(string xml)
            : base(xml)
        {}
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcFeed(XmlNode xml)
            : base(xml)
        { }

        /// <summary>
        /// 事件的 ID
        /// </summary>
        public int FeedId { get; set; }
        /// <summary>
        /// 所在应用的 ID
        /// </summary>
        public int AppId { get; set; }
        /// <summary>
        /// 事件的图标 thread、poll、reward 等
        /// </summary>
        public FeedIcon Icon { get; set; }
        /// <summary>
        /// 事件的发起人的用户 ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 发起人的用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 模板的 Hash 值，用来相同类型事件的合并，32位字符串，如:c95dbd9aa75862c841b627e1e9598fd5
        /// </summary>
        public string HashTemplate { get; set; }
        /// <summary>
        /// 数据的 Hash 值，用来相同类型事件的合并，32位字符串，如:c95dbd9aa75862c841b627e1e9598fd5
        /// </summary>
        public string HashData { get; set; }
        /// <summary>
        /// 标题模板
        /// </summary>
        public string TitleTemplate { get; set; }
        /// <summary>
        /// 标题数据
        /// </summary>
        public string TitleData { get; set; }
        /// <summary>
        /// 内容模板
        /// </summary>
        public string BodyTemplate { get; set; }
        /// <summary>
        /// 事件内容 HTML 格式，用 {xxx} 格式字符表示变量，如 {username}
        /// </summary>
        public string BodyData { get; set; }
        /// <summary>
        /// 保留
        /// </summary>
        public string BodyGeneral { get; set; }
        /// <summary>
        /// 图片链接对应图片地址
        /// </summary>
        private IDictionary<string, string> _images;
        /// <summary>
        /// 图片链接对应图片地址
        /// </summary>
        public IDictionary<string, string> Images { get { return _images ?? (_images = new Dictionary<string, string>()); } }
        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            FeedId = Data.GetInt("feedid");
            AppId = Data.GetInt("appid");
            var icon = Data.GetString("icon");
            icon = icon[0].ToString().ToUpper() + icon.Substring(1);
            Icon = (FeedIcon) Enum.Parse(typeof (FeedIcon), icon);
            Uid = Data.GetInt("uid");
            UserName = Data.GetString("username");
            Time = Data.GetDateTime("dateline");
            HashTemplate = Data.GetString("hash_template");
            HashData = Data.GetString("hash_data");
            TitleTemplate= Data.GetString("title_template");
            TitleData = Data.GetString("title_data");
            BodyTemplate = Data.GetString("body_template");
            BodyData = Data.GetString("body_data");
            BodyGeneral = Data.GetString("body_general");
            GetImages();

            CheckForSuccess("feedid");
        }

        /// <summary>
        /// 设置图片
        /// </summary>
        private void GetImages()
        {
            var index = 1;
            while (true)
            {
                var url = Data.GetString("image_" + index);
                var link = Data.GetString("image_" + index++ + "_link");
                if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(link)) break;
                Images.Add(url, link);
            }
        }
    }
}
