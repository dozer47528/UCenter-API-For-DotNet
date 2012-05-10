using System;

namespace DS.Web.UCenter
{
    /// <summary>
    /// TagModel
    /// </summary>
    public class UcTagReturn : UcItemReturnBase
    {
        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 作者ID
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="subject">主题</param>
        /// <param name="authorid">作者ID</param>
        /// <param name="author">作者</param>
        /// <param name="time">时间</param>
        /// <param name="url">地址</param>
        /// <param name="image">图片</param>
        public UcTagReturn(string subject, int authorid, string author, DateTime time, string url, string image)
        {
            Subject = subject;
            AuthorId = authorid;
            Author = author;
            Time = time;
            Url = url;
            Image = image;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetItems()
        {
            Data.Add("name", Subject);
            Data.Add("uid", AuthorId);
            Data.Add("username", Author);
            Data.Add("dateline", Time);
            Data.Add("url", Url);
            Data.Add("image", Image);
        }
    }
}
