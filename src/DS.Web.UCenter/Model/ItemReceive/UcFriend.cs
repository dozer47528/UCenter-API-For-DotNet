using System;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 好友Model
    /// </summary>
    public class UcFriend : UcItemReceiveBase<UcFriend>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcFriend(string xml)
            : base(xml)
        {}
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        public UcFriend(XmlNode xml)
            : base(xml)
        {}

        /// <summary>
        /// 用户 ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 好友用户 ID
        /// </summary>
        public int FriendId { get; set; }
        /// <summary>
        /// 方向
        /// </summary>
        public FriendDirection Direction { get; set; }
        /// <summary>
        /// 好友用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected override void SetProperty()
        {
            Uid = Data.GetInt("uid");
            FriendId = Data.GetInt("friendid");
            Direction = (FriendDirection)Data.GetInt("direction");
            UserName = Data.GetString("username");
            CheckForSuccess("uid", "friendid");
        }
    }
}
