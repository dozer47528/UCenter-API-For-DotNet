using System.Collections.Generic;

namespace DS.Web.UCenter.Client
{
    ///<summary>
    /// UcApi Client
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    ///</summary>
    public interface IUcClient
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <param name="email">Email</param>
        /// <param name="questionId">登陆问题</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        UcUserRegister UserRegister(string userName, string passWord, string email, int questionId = 0, string answer = "");

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userName">用户名/Uid/Email</param>
        /// <param name="passWord">密码</param>
        /// <param name="loginMethod">登录方式</param>
        /// <param name="checkques">需要登陆问题</param>
        /// <param name="questionId">问题ID</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        UcUserLogin UserLogin(string userName, string passWord, LoginMethod loginMethod = LoginMethod.UserName, bool checkques = false, int questionId = 0, string answer = "");

        /// <summary>
        /// 得到用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        UcUserInfo UserInfo(string userName);

        /// <summary>
        /// 得到用户信息
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        UcUserInfo UserInfo(int uid);

        /// <summary>
        /// 更新用户信息
        /// 更新资料需验证用户的原密码是否正确，除非指定 ignoreoldpw 为 1。
        /// 如果只修改 Email 不修改密码，可让 newpw 为空；
        /// 同理如果只修改密码不修改 Email，可让 email 为空。
        /// </summary>
        /// <returns></returns>
        UcUserEdit UserEdit(string userName, string oldPw, string newPw, string email, bool ignoreOldPw = false, int questionId = 0, string answer = "");

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        bool UserDelete(params int[] uid);

        /// <summary>
        /// 删除用户头像
        /// </summary>
        /// <param name="uid">Uid</param>
        void UserDeleteAvatar(params int[] uid);

        /// <summary>
        /// 同步登陆
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns>同步登陆的 Html 代码</returns>
        string UserSynlogin(int uid);

        /// <summary>
        /// 同步登出
        /// </summary>
        /// <returns>同步登出的 Html 代码</returns>
        string UserSynLogout();

        /// <summary>
        /// 检查 Email 格式
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns></returns>
        UcUserCheckEmail UserCheckEmail(string email);

        /// <summary>
        /// 增加受保护用户
        /// </summary>
        /// <param name="admin">操作管理员</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        bool UserAddProtected(string admin, params string[] userName);

        /// <summary>
        /// 删除受保护用户
        /// </summary>
        /// <param name="admin">操作管理员</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        bool UserDeleteProtected(string admin, params string[] userName);

        /// <summary>
        /// 得到受保护用户
        /// </summary>
        /// <returns></returns>
        UcUserProtecteds UserGetProtected();

        /// <summary>
        /// 合并用户
        /// </summary>
        /// <param name="oldUserName">老用户名</param>
        /// <param name="newUserName">新用户名</param>
        /// <param name="uid">Uid</param>
        /// <param name="passWord">密码</param>
        /// <param name="email">Email</param>
        /// <returns></returns>
        UcUserMerge UserMerge(string oldUserName, string newUserName, int uid, string passWord, string email);

        /// <summary>
        /// 移除重名用户记录
        /// </summary>
        /// <param name="userName">用户名</param>
        void UserMergeRemove(string userName);

        /// <summary>
        /// 得到用户积分
        /// </summary>
        /// <param name="appId">应用程序Id</param>
        /// <param name="uid">Uid</param>
        /// <param name="credit">积分编号</param>
        /// <returns></returns>
        int UserGetCredit(int appId, int uid, int credit);

        /// <summary>
        /// 检查新消息
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        UcPmCheckNew PmCheckNew(int uid);

        /// <summary>
        /// 发送短消息
        /// </summary>
        /// <param name="fromUid">发件人用户 ID，0 为系统消息</param>
        /// <param name="replyPmId">回复的消息 ID，0:发送新的短消息，大于 0:回复指定的短消息</param>
        /// <param name="subject">消息标题</param>
        /// <param name="message">消息内容</param>
        /// <param name="msgTo">收件人ID</param>
        /// <returns></returns>
        UcPmSend PmSend(int fromUid, int replyPmId, string subject, string message, params int[] msgTo);

        /// <summary>
        /// 发送短消息
        /// </summary>
        /// <param name="fromUid">发件人用户 ID，0 为系统消息</param>
        /// <param name="replyPmId">回复的消息 ID，0:发送新的短消息，大于 0:回复指定的短消息</param>
        /// <param name="subject">消息标题</param>
        /// <param name="message">消息内容</param>
        /// <param name="msgTo">收件人用户名</param>
        /// <returns></returns>
        UcPmSend PmSend(int fromUid, int replyPmId, string subject, string message, params string[] msgTo);

        /// <summary>
        /// 删除短消息
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="folder">文件夹</param>
        /// <param name="pmIds">短消息ID</param>
        /// <returns>删除的数量</returns>
        int PmDelete(int uid, PmDeleteFolder folder, params int[] pmIds);

        /// <summary>
        /// 删除会话
        /// </summary>
        /// <param name="uid">发件人</param>
        /// <param name="toUids">收件人</param>
        /// <returns>删除的数量</returns>
        int PmDelete(int uid, params int[] toUids);

        /// <summary>
        /// 修改阅读状态
        /// </summary>
        /// <param name="uid">发件人</param>
        /// <param name="toUids">收件人</param>
        /// <param name="pmIds">短消息ID</param>
        /// <param name="readStatus">阅读状态</param>
        void PmReadStatus(int uid, int toUids, int pmIds = 0, ReadStatus readStatus = ReadStatus.Readed);

        /// <summary>
        /// 修改阅读状态
        /// </summary>
        /// <param name="uid">发件人</param>
        /// <param name="toUids">收件人数组</param>
        /// <param name="pmIds">短消息ID数组</param>
        /// <param name="readStatus">阅读状态</param>
        void PmReadStatus(int uid, IEnumerable<int> toUids, IEnumerable<int> pmIds, ReadStatus readStatus = ReadStatus.Readed);

        /// <summary>
        /// 获取短消息列表
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="page">当前页编号，默认值 1</param>
        /// <param name="pageSize">每页最大条目数，默认值 10</param>
        /// <param name="folder">短消息所在的文件夹</param>
        /// <param name="filter">过滤方式</param>
        /// <param name="msgLen">截取短消息内容文字的长度，0 为不截取，默认值 0</param>
        /// <returns></returns>
        UcPmList PmList(int uid, int page = 1, int pageSize = 10, PmReadFolder folder = PmReadFolder.NewBox, PmReadFilter filter = PmReadFilter.NewPm, int msgLen = 0);

        /// <summary>
        /// 获取短消息内容
        /// 本接口函数用于返回指定用户的指定消息 ID 的消息，返回的数据中包含针对这个消息的回复。
        /// 如果指定 touid 参数，那么短消息将列出所有 uid 和 touid 之间的短消息，daterange 可以指定返回消息的日期范围。
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="pmId">短消息ID</param>
        /// <param name="toUid">收件人ID</param>
        /// <param name="dateRange">日期范围</param>
        /// <returns></returns>
        UcPmView PmView(int uid, int pmId, int toUid = 0, DateRange dateRange = DateRange.Today);

        /// <summary>
        /// 获取单条短消息内容
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="type">类型</param>
        /// <param name="pmId">短消息ID</param>
        /// <returns></returns>
        UcPm PmViewNode(int uid, ViewType type = ViewType.Specified, int pmId = 0);

        /// <summary>
        /// 忽略未读消息提示
        /// </summary>
        /// <param name="uid">Uid</param>
        void PmIgnore(int uid);

        /// <summary>
        /// 得到黑名单
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        UcPmBlacklsGet PmBlacklsGet(int uid);

        /// <summary>
        /// 设置黑名单为禁止所有人（清空原数据）
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        bool PmBlacklsSetAll(int uid);

        /// <summary>
        /// 设置黑名单（清空原数据）
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="userName">黑名单用户名</param>
        /// <returns></returns>
        bool PmBlacklsSet(int uid, params string[] userName);

        /// <summary>
        /// 添加黑名单为禁止所有人
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        bool PmBlacklsAddAll(int uid);

        /// <summary>
        /// 增加黑名单
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="userName">黑名单用户名</param>
        /// <returns></returns>
        bool PmBlacklsAdd(int uid, params string[] userName);

        /// <summary>
        /// 删除黑名单中的禁止所有人
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        void PmBlacklsDeleteAll(int uid);

        /// <summary>
        /// 删除黑名单
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="userName">黑名单用户名</param>
        void PmBlacklsDelete(int uid, params string[] userName);

        /// <summary>
        /// 增加好友
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="friendId">好友ID</param>
        /// <param name="comment">备注</param>
        /// <returns></returns>
        bool FriendAdd(int uid, int friendId, string comment = "");

        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="friendIds">好友ID</param>
        /// <returns></returns>
        bool FriendDelete(int uid, params int[] friendIds);

        /// <summary>
        /// 获取好友总数
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="direction">方向</param>
        /// <returns>好友数目</returns>
        int FriendTotalNum(int uid, FriendDirection direction = FriendDirection.All);

        /// <summary>
        /// 好友列表
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="page">当前页编号</param>
        /// <param name="pageSize">每页最大条目数</param>
        /// <param name="totalNum">好友总数</param>
        /// <param name="direction">方向</param>
        /// <returns></returns>
        UcFriends FriendList(int uid, int page = 1, int pageSize = 10, int totalNum = 10, FriendDirection direction = FriendDirection.All);

        /// <summary>
        /// 积分兑换请求
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="from">原积分</param>
        /// <param name="to">目标积分</param>
        /// <param name="toAppId">目标应用ID</param>
        /// <param name="amount">积分数额</param>
        /// <returns></returns>
        bool CreditExchangeRequest(int uid, int from, int to, int toAppId, int amount);

        ///<summary>
        /// 修改头像
        ///</summary>
        ///<param name="uid">Uid</param>
        ///<param name="type"></param>
        ///<returns></returns>
        string Avatar(int uid, AvatarType type = AvatarType.Virtual);

        /// <summary>
        /// 得到头像地址
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="size">大小</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        string AvatarUrl(int uid,AvatarSize size,AvatarType type = AvatarType.Virtual);

        /// <summary>
        /// 检查头像是否存在
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool AvatarCheck(int uid, AvatarSize size = AvatarSize.Middle, AvatarType type = AvatarType.Virtual);

        /// <summary>
        /// 获取标签数据
        /// </summary>
        /// <param name="tagName">标签名</param>
        /// <param name="number">应用程序ID对应的数量</param>
        /// <returns></returns>
        UcTags TagGet(string tagName, IEnumerable<KeyValuePair<string, string>> number);

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="icon">图标类型，如：thread、post、video、goods、reward、debate、blog、album、comment、wall、friend</param>
        /// <param name="uid">Uid</param>
        /// <param name="userName">用户名</param>
        /// <param name="titleTemplate">标题模板</param>
        /// <param name="titleData">标题数据数组</param>
        /// <param name="bodyTemplate">内容模板</param>
        /// <param name="bodyData">模板数据</param>
        /// <param name="bodyGeneral">相同事件合并时用到的数据：特定的数组，只有两项：name、link，保留</param>
        /// <param name="targetIds">保留</param>
        /// <param name="images">相关图片的 URL 和链接地址。一个图片地址，一个链接地址</param>
        /// <returns></returns>
        int FeedAdd(FeedIcon icon, int uid, string userName, string titleTemplate, string titleData, string bodyTemplate, string bodyData, string bodyGeneral, string targetIds, params string[] images);

        /// <summary>
        /// 得到Feed
        /// </summary>
        /// <param name="limit">数量限制</param>
        /// <returns></returns>
        UcFeeds FeedGet(int limit);

        /// <summary>
        /// 得到应用列表
        /// </summary>
        /// <returns></returns>
        UcApps AppList();

        /// <summary>
        /// 添加邮件到队列
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="message">内容</param>
        /// <param name="uids">Uid</param>
        /// <returns></returns>
        UcMailQueue MailQueue(string subject, string message,params int[] uids);

        /// <summary>
        /// 添加邮件到队列
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="message">内容</param>
        /// <param name="emails">目标Email</param>
        /// <returns></returns>
        UcMailQueue MailQueue(string subject, string message, params string[] emails);

        /// <summary>
        /// 添加邮件到队列
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="message">内容</param>
        /// <param name="uids">Uid</param>
        /// <param name="emails">目标email</param>
        /// <returns></returns>
        UcMailQueue MailQueue(string subject, string message, int[] uids, string[] emails);

        /// <summary>
        /// 添加邮件到队列
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="message">内容</param>
        /// <param name="fromMail">发信人，可选参数，默认为空，uc后台设置的邮件来源作为发信人地址</param>
        /// <param name="charset">邮件字符集，可选参数，默认为gbk</param>
        /// <param name="htmlOn">是否是html格式的邮件，可选参数，默认为FALSE，即文本邮件</param>
        /// <param name="level">邮件级别，可选参数，默认为1，数字大的优先发送，取值为0的时候立即发送，邮件不入队列</param>
        /// <param name="uids">Uid</param>
        /// <param name="emails">目标email</param>
        /// <returns></returns>
        UcMailQueue MailQueue(string subject,string message,string fromMail,string charset,bool htmlOn,int level,int[] uids,string[] emails);
    }
}