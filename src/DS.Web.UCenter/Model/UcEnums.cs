namespace DS.Web.UCenter
{
    /// <summary>
    /// 登录方式
    /// </summary>
    public enum LoginMethod
    {
        /// <summary>
        /// 使用用户名
        /// </summary>
        UserName = 0,
        /// <summary>
        /// 使用Uid
        /// </summary>
        Uid = 1,
        /// <summary>
        /// 使用邮箱
        /// </summary>
        Mail = 2,
    }

    /// <summary>
    /// 查询方式
    /// </summary>
    public enum InfoMethod
    {
        /// <summary>
        /// 使用用户名
        /// </summary>
        UserName = 0,
        /// <summary>
        /// 使用Uid
        /// </summary>
        Uid = 1,
    }

    /// <summary>
    /// 发送方式
    /// </summary>
    public enum SendMethod
    {
        /// <summary>
        /// Uid
        /// </summary>
        Uid= 0,
        /// <summary>
        /// 用户名
        /// </summary>
        UserName = 1,
    }

    /// <summary>
    /// 短消息文件夹
    /// </summary>
    public enum PmDeleteFolder
    {
        /// <summary>
        /// 发件箱
        /// </summary>
        InBox,
        /// <summary>
        /// 收件箱
        /// </summary>
        OutBox,
    }

    /// <summary>
    /// 短消息文件夹
    /// </summary>
    public enum PmReadFolder
    {
        /// <summary>
        /// 新建项
        /// </summary>
        NewBox,
        /// <summary>
        /// 发件箱
        /// </summary>
        InBox,
        /// <summary>
        /// 收件箱
        /// </summary>
        OutBox,
    }

    /// <summary>
    /// 短消息过滤器
    /// </summary>
    public enum PmReadFilter
    {
        /// <summary>
        /// 未读消息，folder 为 inbox 和 outbox 时使用
        /// </summary>
        NewPm,
        /// <summary>
        /// 系统消息，folder 为 inbox 时使用
        /// </summary>
        SystemPm,
        /// <summary>
        /// 公共消息，folder 为 inbox 时使用
        /// </summary>
        AnnouncePm,
    }


    /// <summary>
    /// 阅读状态
    /// </summary>
    public enum ReadStatus
    {
        /// <summary>
        /// 已读
        /// </summary>
        Readed = 0,
        /// <summary>
        /// 未读
        /// </summary>
        New = 1,
    }

    /// <summary>
    /// 消息的类型
    /// </summary>
    public enum ViewType
    {
        /// <summary>
        /// 获取指定单条消息
        /// </summary>
        Specified =0,
        /// <summary>
        /// 获取指定用户发的最后单条消息
        /// </summary>
        LastOutput =1,
        /// <summary>
        /// 获取指定用户收的最后单条消息
        /// </summary>
        LastInput =2,
    }

    /// <summary>
    /// 日期范围
    /// </summary>
    public enum DateRange
    {
        /// <summary>
        /// 今天
        /// </summary>
        Today = 1,
        /// <summary>
        /// 昨天
        /// </summary>
        Yestarday = 2,
        /// <summary>
        /// 前天
        /// </summary>
        TheDayBeforeYesterday = 3,
        /// <summary>
        /// 上周
        /// </summary>
        LastWeek = 4,
        /// <summary>
        /// 更早
        /// </summary>
        Earlier = 5,
    }

    /// <summary>
    /// 好友方向
    /// </summary>
    public enum FriendDirection
    {
        /// <summary>
        /// 指定用户的全部好友
        /// </summary>
        All = 0,
        /// <summary>
        /// 正向，指定用户添加的好友，但没被对方添加
        /// </summary>
        Forward =1,
        /// <summary>
        /// 反向，指定用户被哪些用户添加为好友，但没被对方添加
        /// </summary>
        Reverse =2,
        /// <summary>
        /// 双向，互相添加为好友
        /// </summary>
        Both =3,
    }


    /// <summary>
    /// 合并结果
    /// </summary>
    public enum UserMergeResult
    {
        /// <summary>
        /// 返回用户 ID，表示用户注册成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 用户名不合法
        /// </summary>
        UserNameIllegal = -1,
        /// <summary>
        /// 包含不允许注册的词语
        /// </summary>
        ContainsInvalidWords = -2,
        /// <summary>
        /// 用户名已经存在
        /// </summary>
        UserNameExists = -3,
    }

    /// <summary>
    /// 邮箱检查结果
    /// </summary>
    public enum UserCheckEmailResult
    {
        /// <summary>
        /// Email 正确
        /// </summary>
        Success = 1,
        /// <summary>
        /// Email 格式有误
        /// </summary>
        IncorrectEmailFormat = -4,
        /// <summary>
        /// Email 不允许注册
        /// </summary>
        EmailNotAllowed = -5,
        /// <summary>
        /// 该 Email 已经被注册
        /// </summary>
        EmailHasBeenRegistered = -6,
    }


    /// <summary>
    /// 修改结果
    /// </summary>
    public enum UserEditResult
    {
        /// <summary>
        /// 更新成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 没有做任何修改
        /// </summary>
        DoNotEdited = 0,
        /// <summary>
        /// 旧密码错误
        /// </summary>
        PassWordError = -1,
        /// <summary>
        /// Email 格式有误
        /// </summary>
        IncorrectEmailFormat = -4,
        /// <summary>
        /// Email 不允许注册
        /// </summary>
        EmailNotAllowed = -5,
        /// <summary>
        /// 该 Email 已经被注册
        /// </summary>
        EmailHasBeenRegistered = -6,
        /// <summary>
        /// 没有做任何修改
        /// </summary>
        EditedNothing = -7,
        /// <summary>
        /// 该用户受保护无权限更改
        /// </summary>
        UserIsProtected = -8,
    }


    /// <summary>
    /// 登陆结果
    /// </summary>
    public enum LoginResult
    {
        /// <summary>
        /// 返回用户 ID，表示用户登录成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 用户不存在，或者被删除
        /// </summary>
        NotExist = -1,
        /// <summary>
        /// 密码错
        /// </summary>
        PassWordError = -2,
        /// <summary>
        /// 安全提问错
        /// </summary>
        QuestionError = -3,
    }


    /// <summary>
    /// 注册结果
    /// </summary>
    public enum RegisterResult
    {
        /// <summary>
        /// 返回用户 ID，表示用户注册成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 用户名不合法
        /// </summary>
        UserNameIllegal = -1,
        /// <summary>
        /// 包含不允许注册的词语
        /// </summary>
        ContainsInvalidWords = -2,
        /// <summary>
        /// 用户名已经存在
        /// </summary>
        UserNameExists = -3,
        /// <summary>
        /// Email 格式有误
        /// </summary>
        IncorrectEmailFormat = -4,
        /// <summary>
        /// Email 不允许注册
        /// </summary>
        EmailNotAllowed = -5,
        /// <summary>
        /// 该 Email 已经被注册
        /// </summary>
        EmailHasBeenRegistered = -6,
    }


    /// <summary>
    /// 短信发送结果
    /// </summary>
    public enum PmSendResult
    {
        /// <summary>
        /// 发送成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 发送失败
        /// </summary>
        Failed = 0,
        /// <summary>
        /// 超出了24小时最大允许发送短消息数目
        /// </summary>
        BeyondMaxNumber = -1,
        /// <summary>
        /// 不满足两次发送短消息最短间隔
        /// </summary>
        SendTooFast = -2,
        /// <summary>
        /// 不能给非好友批量发送短消息
        /// </summary>
        CanNotBatchSendMsg = -3,
        /// <summary>
        /// 目前还不能使用发送短消息功能（注册多少日后才可以使用发短消息限制）
        /// </summary>
        CanNotSendNow = -4,
    }

    /// <summary>
    /// 头像类型
    /// </summary>
    public enum AvatarType
    {
        /// <summary>
        /// 虚拟头像
        /// </summary>
        Virtual,
        /// <summary>
        /// 真实头像
        /// </summary>
        Real,
    }


    /// <summary>
    /// 头像大小
    /// </summary>
    public enum AvatarSize
    {
        /// <summary>
        /// 大
        /// </summary>
        Big,
        /// <summary>
        /// 中
        /// </summary>
        Middle,
        /// <summary>
        /// 小
        /// </summary>
        Small,
    }

    /// <summary>
    /// 图标
    /// </summary>
    public enum FeedIcon
    {
        /// <summary>
        /// 
        /// </summary>
        Thread,
        /// <summary>
        /// 
        /// </summary>
        Post,
        /// <summary>
        /// 
        /// </summary>
        Video,
        /// <summary>
        /// 
        /// </summary>
        Goods,
        /// <summary>
        /// 
        /// </summary>
        Reward,
        /// <summary>
        /// 
        /// </summary>
        Debate,
        /// <summary>
        /// 
        /// </summary>
        Blog,
        /// <summary>
        /// 
        /// </summary>
        Album,
        /// <summary>
        /// 
        /// </summary>
        Comment,
        /// <summary>
        /// 
        /// </summary>
        Wall,
        /// <summary>
        /// 
        /// </summary>
        Friend,
    }
}