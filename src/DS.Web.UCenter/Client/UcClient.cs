using System.Collections.Generic;
using System.Text;

namespace DS.Web.UCenter.Client
{
    /// <summary>
    /// UCenter Client
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// </summary>
    public class UcClient : UcClientBase, IUcClient
    {
        #region UserModel
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <param name="email">Email</param>
        /// <param name="questionId">登陆问题</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        public UcUserRegister UserRegister(string userName, string passWord, string email, int questionId = 0, string answer = "")
        {
            var args = new Dictionary<string, string>
                           {
                               {"username", userName},
                               {"password", passWord},
                               {"email", email},
                               {"questionid", questionId.ToString()},
                               {"answer", answer}
                           };
            return new UcUserRegister(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionRegister));
        }

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
        public UcUserLogin UserLogin(string userName, string passWord, LoginMethod loginMethod = LoginMethod.UserName, bool checkques = false, int questionId = 0, string answer = "")
        {
            var args = new Dictionary<string, string>
                           {
                               {"username", userName},
                               {"password", passWord},
                               {"isuid", ((int) loginMethod).ToString()},
                               {"checkques", checkques ? "1" : "0"},
                               {"questionid", questionId.ToString()},
                               {"answer", answer}
                           };
            return new UcUserLogin(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionLogin));
        }

        /// <summary>
        /// 得到用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public UcUserInfo UserInfo(string userName)
        {
            return userInfo(userName,InfoMethod.UserName);
        }

        /// <summary>
        /// 得到用户信息
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        public UcUserInfo UserInfo(int uid)
        {
            return userInfo(uid.ToString(), InfoMethod.Uid);
        }

        /// <summary>
        /// 得到用户信息
        /// </summary>
        /// <param name="userName">用户名/Uid</param>
        /// <param name="infoMethod">查询方式</param>
        /// <returns></returns>
        private UcUserInfo userInfo(string userName, InfoMethod infoMethod)
        {
            var args = new Dictionary<string, string>
                           {
                               {"username", userName},
                               {"isuid", ((int) infoMethod).ToString()}
                           };
            return new UcUserInfo(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionInfo));
        }

        /// <summary>
        /// 更新用户信息
        /// 更新资料需验证用户的原密码是否正确，除非指定 ignoreoldpw 为 1。
        /// 如果只修改 Email 不修改密码，可让 newpw 为空；
        /// 同理如果只修改密码不修改 Email，可让 email 为空。
        /// </summary>
        /// <returns></returns>
        public UcUserEdit UserEdit(string userName, string oldPw, string newPw, string email, bool ignoreOldPw = false, int questionId = 0, string answer = "")
        {
            var args = new Dictionary<string, string>
                           {
                               {"username", userName},
                               {"oldpw", oldPw},
                               {"newpw", newPw},
                               {"email", email},
                               {"ignoreoldpw", ignoreOldPw ? "1" : "0"},
                               {"questionid", questionId.ToString()},
                               {"answer", answer}
                           };
            return new UcUserEdit(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionEdit));
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        public bool UserDelete(params int[] uid)
        {
            var args = new Dictionary<string, string>();
            addArray(args, "uid", uid);
            return toBool(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionDelete));
        }



        /// <summary>
        /// 删除用户头像
        /// </summary>
        /// <param name="uid">Uid</param>
        public void UserDeleteAvatar(params int[] uid)
        {
            var args = new Dictionary<string, string>();
            addArray(args, "uid", uid);
            SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionDeleteAvatar);
        }

        /// <summary>
        /// 同步登陆
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns>同步登陆的 Html 代码</returns>
        public string UserSynlogin(int uid)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()}
                           };
            return SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionSynLogin);
        }

        /// <summary>
        /// 同步登出
        /// </summary>
        /// <returns>同步登出的 Html 代码</returns>
        public string UserSynLogout()
        {
            var args = new Dictionary<string, string>();
            return SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionSynLogout);
        }

        /// <summary>
        /// 检查 Email 格式
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns></returns>
        public UcUserCheckEmail UserCheckEmail(string email)
        {
            var args = new Dictionary<string, string>
                           {
                               {"email", email}
                           };
            return new UcUserCheckEmail(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionCheckEmail));
        }

        /// <summary>
        /// 增加受保护用户
        /// </summary>
        /// <param name="admin">操作管理员</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool UserAddProtected(string admin, params string[] userName)
        {
            var args = new Dictionary<string, string>
                           {
                               {"admin", admin}
                           };
            addArray(args, "username", userName);
            return toBool(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionAddProtected));
        }

        /// <summary>
        /// 删除受保护用户
        /// </summary>
        /// <param name="admin">操作管理员</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool UserDeleteProtected(string admin, params string[] userName)
        {
            var args = new Dictionary<string, string>
                           {
                               {"admin", admin}
                           };
            addArray(args, "username", userName);
            return toBool(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionDeleteProtected));
        }

        /// <summary>
        /// 得到受保护用户
        /// </summary>
        /// <returns></returns>
        public UcUserProtecteds UserGetProtected()
        {
            var args = new Dictionary<string, string>();
            return new UcUserProtecteds(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionGetProtected));
        }

        /// <summary>
        /// 合并用户
        /// </summary>
        /// <param name="oldUserName">老用户名</param>
        /// <param name="newUserName">新用户名</param>
        /// <param name="uid">Uid</param>
        /// <param name="passWord">密码</param>
        /// <param name="email">Email</param>
        /// <returns></returns>
        public UcUserMerge UserMerge(string oldUserName, string newUserName, int uid, string passWord, string email)
        {
            var args = new Dictionary<string, string>
                           {
                               {"oldusername", oldUserName},
                               {"newusername", newUserName},
                               {"uid", uid.ToString()},
                               {"password", passWord},
                               {"email", email}
                           };
            return new UcUserMerge(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionMerge));
        }

        /// <summary>
        /// 移除重名用户记录
        /// </summary>
        /// <param name="userName">用户名</param>
        public void UserMergeRemove(string userName)
        {
            var args = new Dictionary<string, string>
                           {
                               {"username", userName}
                           };
            SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionMergeRemove);

        }

        /// <summary>
        /// 得到用户积分
        /// </summary>
        /// <param name="appId">应用程序Id</param>
        /// <param name="uid">Uid</param>
        /// <param name="credit">积分编号</param>
        /// <returns></returns>
        public int UserGetCredit(int appId, int uid, int credit)
        {
            int result;
            var args = new Dictionary<string, string>
                           {
                               {"appid", appId.ToString()},
                               {"uid", uid.ToString()},
                               {"credit", credit.ToString()}
                           };
            int.TryParse(SendArgs(args, UcUserModelName.ModelName, UcUserModelName.ActionGetCredit), out result);
            return result;
        }
        #endregion

        #region PmModel
        /// <summary>
        /// 检查新消息
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        public UcPmCheckNew PmCheckNew(int uid)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"more","3"}
                           };
            return new UcPmCheckNew(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionCheckNew));
        }

        /// <summary>
        /// 发送短消息
        /// </summary>
        /// <param name="fromUid">发件人用户 ID，0 为系统消息</param>
        /// <param name="replyPmId">回复的消息 ID，0:发送新的短消息，大于 0:回复指定的短消息</param>
        /// <param name="subject">消息标题</param>
        /// <param name="message">消息内容</param>
        /// <param name="msgTo">收件人ID</param>
        /// <returns></returns>
        public UcPmSend PmSend(int fromUid, int replyPmId, string subject, string message, params int[] msgTo)
        {
            return pmSend(fromUid, string.Join(",", intToString(msgTo)), subject, message, replyPmId);
        }

        /// <summary>
        /// 发送短消息
        /// </summary>
        /// <param name="fromUid">发件人用户 ID，0 为系统消息</param>
        /// <param name="replyPmId">回复的消息 ID，0:发送新的短消息，大于 0:回复指定的短消息</param>
        /// <param name="subject">消息标题</param>
        /// <param name="message">消息内容</param>
        /// <param name="msgTo">收件人用户名</param>
        /// <returns></returns>
        public UcPmSend PmSend(int fromUid, int replyPmId, string subject, string message, params string[] msgTo)
        {
            return pmSend(fromUid, string.Join(",", msgTo), subject, message, replyPmId, SendMethod.UserName);
        }

        /// <summary>
        /// 发送短消息
        /// </summary>
        /// <param name="fromUid">发件人用户 ID，0 为系统消息</param>
        /// <param name="msgTo">收件人用户名 / 用户 ID，多个用逗号分割，默认为ID</param>
        /// <param name="subject">消息标题</param>
        /// <param name="message">消息内容</param>
        /// <param name="replyPmId">回复的消息 ID，0:(默认值) 发送新的短消息，大于 0:回复指定的短消息</param>
        /// <param name="sendMethod">msgto 参数类型</param>
        /// <returns></returns>
        private UcPmSend pmSend(int fromUid, string msgTo, string subject, string message, int replyPmId = 0, SendMethod sendMethod = SendMethod.Uid)
        {
            var args = new Dictionary<string, string>
                           {
                               {"fromuid", fromUid.ToString()},
                               {"msgto",msgTo},
                               {"subject",subject},
                               {"message",message},
                               {"replypid",replyPmId.ToString()},
                               {"isusername",((int)sendMethod).ToString()}
                           };
            return new UcPmSend(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionSend));
        }

        /// <summary>
        /// 删除短消息
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="folder">文件夹</param>
        /// <param name="pmIds">短消息ID</param>
        /// <returns>删除的数量</returns>
        public int PmDelete(int uid, PmDeleteFolder folder, params int[] pmIds)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"folder",folder.ToString().ToLower()}
                           };
            addArray(args, "pmids", pmIds);
            return toInt(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionDelete));
        }

        /// <summary>
        /// 删除会话
        /// </summary>
        /// <param name="uid">发件人</param>
        /// <param name="toUids">收件人</param>
        /// <returns>删除的数量</returns>
        public int PmDelete(int uid, params int[] toUids)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()}
                           };
            addArray(args, "touids", toUids);
            return toInt(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionDeleteUser));
        }



        /// <summary>
        /// 修改阅读状态
        /// </summary>
        /// <param name="uid">发件人</param>
        /// <param name="toUids">收件人</param>
        /// <param name="pmIds">短消息ID</param>
        /// <param name="readStatus">阅读状态</param>
        public void PmReadStatus(int uid, int toUids, int pmIds = 0, ReadStatus readStatus = ReadStatus.Readed)
        {
            PmReadStatus(uid, new[] { toUids }, new[] { pmIds }, readStatus);
        }


        /// <summary>
        /// 修改阅读状态
        /// </summary>
        /// <param name="uid">发件人</param>
        /// <param name="toUids">收件人数组</param>
        /// <param name="pmIds">短消息ID数组</param>
        /// <param name="readStatus">阅读状态</param>
        public void PmReadStatus(int uid, IEnumerable<int> toUids, IEnumerable<int> pmIds, ReadStatus readStatus = ReadStatus.Readed)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"status",((int)readStatus).ToString()}
                           };
            addArray(args, "uids", toUids);
            addArray(args, "pmids", pmIds);
            SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionReadStatus);
        }


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
        public UcPmList PmList(int uid, int page = 1, int pageSize = 10, PmReadFolder folder = PmReadFolder.NewBox, PmReadFilter filter = PmReadFilter.NewPm, int msgLen = 0)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"page", page.ToString()},
                               {"pagesize", pageSize.ToString()},
                               {"folder", folder.ToString().ToLower()},
                               {"filter",filter.ToString().ToLower()},
                               {"msglen", msgLen.ToString()}
                           };
            return new UcPmList(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionList));
        }


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
        public UcPmView PmView(int uid, int pmId, int toUid = 0, DateRange dateRange = DateRange.Today)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"pmid", pmId.ToString()},
                               {"touid", toUid.ToString()},
                               {"daterange", ((int)dateRange).ToString()}
                           };
            return new UcPmView(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionView));
        }

        /// <summary>
        /// 获取单条短消息内容
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="type">类型</param>
        /// <param name="pmId">短消息ID</param>
        /// <returns></returns>
        public UcPm PmViewNode(int uid, ViewType type = ViewType.Specified, int pmId = 0)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"type", ((int)type).ToString()},
                               {"pmid", pmId.ToString()}
                           };
            return new UcPm(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionViewNode));
        }

        /// <summary>
        /// 忽略未读消息提示
        /// </summary>
        /// <param name="uid">Uid</param>
        public void PmIgnore(int uid)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()}
                           };
            SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionIgnore);
        }



        /// <summary>
        /// 得到黑名单
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        public UcPmBlacklsGet PmBlacklsGet(int uid)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()}
                           };
            return new UcPmBlacklsGet(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionBlacklsGet));
        }


        /// <summary>
        /// 设置黑名单为禁止所有人（清空原数据）
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        public bool PmBlacklsSetAll(int uid)
        {
            return PmBlacklsSet(uid, "{ALL}");
        }

        /// <summary>
        /// 设置黑名单（清空原数据）
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="userName">黑名单用户名</param>
        /// <returns></returns>
        public bool PmBlacklsSet(int uid, params string[] userName)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"username",string.Join(",",userName)}
                           };
            return toBool(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionBlacklsSet));
        }

        /// <summary>
        /// 添加黑名单为禁止所有人
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        public bool PmBlacklsAddAll(int uid)
        {
            return PmBlacklsAdd(uid, "{ALL}");
        }


        /// <summary>
        /// 增加黑名单
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="userName">黑名单用户名</param>
        /// <returns></returns>
        public bool PmBlacklsAdd(int uid, params string[] userName)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()}
                           };
            addArray(args, "username", userName);
            return toBool(SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionBlacklsAdd));
        }

        /// <summary>
        /// 删除黑名单中的禁止所有人
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <returns></returns>
        public void PmBlacklsDeleteAll(int uid)
        {
            PmBlacklsDelete(uid, "{ALL}");
        }

        /// <summary>
        /// 删除黑名单
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="userName">黑名单用户名</param>
        public void PmBlacklsDelete(int uid, params string[] userName)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()}
                           };
            addArray(args, "username", userName);
            SendArgs(args, UcPmModelName.ModelName, UcPmModelName.ActionBlacklsDelete);
        }
        #endregion

        #region FriendMode
        /// <summary>
        /// 增加好友
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="friendId">好友ID</param>
        /// <param name="comment">备注</param>
        /// <returns></returns>
        public bool FriendAdd(int uid, int friendId, string comment = "")
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"friendid", friendId.ToString()},
                               {"comment", comment}
                           };
            return toBool(SendArgs(args, UcFriendModelName.ModelName, UcFriendModelName.ActionAdd));
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="friendIds">好友ID</param>
        /// <returns></returns>
        public bool FriendDelete(int uid, params int[] friendIds)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()}
                           };
            addArray(args, "friendids", friendIds);
            return toBool(SendArgs(args, UcFriendModelName.ModelName, UcFriendModelName.ActionDelete));
        }

        /// <summary>
        /// 获取好友总数
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="direction">方向</param>
        /// <returns>好友数目</returns>
        public int FriendTotalNum(int uid, FriendDirection direction = FriendDirection.All)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"direction",((int)direction).ToString()}
                           };
            return toInt(SendArgs(args, UcFriendModelName.ModelName, UcFriendModelName.ActionTotalNum));
        }


        /// <summary>
        /// 好友列表
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="page">当前页编号</param>
        /// <param name="pageSize">每页最大条目数</param>
        /// <param name="totalNum">好友总数</param>
        /// <param name="direction">方向</param>
        /// <returns></returns>
        public UcFriends FriendList(int uid, int page = 1, int pageSize = 10, int totalNum = 10, FriendDirection direction = FriendDirection.All)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"page", page.ToString()},
                               {"pagesize", pageSize.ToString()},
                               {"totalnum", totalNum.ToString()},
                               {"direction",((int)direction).ToString()}
                           };
            return new UcFriends(SendArgs(args, UcFriendModelName.ModelName, UcFriendModelName.ActionList));
        }
        #endregion

        #region CreditModel
        /// <summary>
        /// 积分兑换请求
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="from">原积分</param>
        /// <param name="to">目标积分</param>
        /// <param name="toAppId">目标应用ID</param>
        /// <param name="amount">积分数额</param>
        /// <returns></returns>
        public bool CreditExchangeRequest(int uid, int from, int to, int toAppId, int amount)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"from", from.ToString()},
                               {"to", to.ToString()},
                               {"toappid", toAppId.ToString()},
                               {"amount", amount.ToString()}
                           };
            return toBool(SendArgs(args, UcCreditModelName.ModelName, UcCreditModelName.ActionExchangeRequest));
        }
        #endregion

        #region Avatar

        ///<summary>
        /// 修改头像
        ///</summary>
        ///<param name="uid">Uid</param>
        ///<param name="type"></param>
        ///<returns></returns>
        public string Avatar(int uid, AvatarType type = AvatarType.Virtual)
        {
            var args = new Dictionary<string, string>
                           {
                                {"uid" ,uid.ToString()}
                            };
            var input = GetInput(args);
            var movie = string.Format("{0}images/camera.swf?inajax=1&appid={1}&input={2}&agent={3}&ucapi={4}&avatartype={5}", UcConfig.UcApi, UcConfig.UcAppid, input, UcUtility.Md5(UcUtility.GetUserAgent()), UcUtility.PhpUrlEncode(UcConfig.UcApi.Replace("http://", "")), type.ToString().ToLower());
            return getFlashPlayerCode(movie);
        }

        /// <summary>
        /// 得到头像地址
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="size">大小</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public string AvatarUrl(int uid,AvatarSize size,AvatarType type = AvatarType.Virtual)
        {
            return string.Format("{0}avatar.php?uid={1}&type={2}&size={3}", UcConfig.UcApi, uid,
                                 type.ToString().ToLower(), size.ToString().ToLower());
        }

        /// <summary>
        /// 检查头像是否存在
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool AvatarCheck(int uid, AvatarSize size = AvatarSize.Middle, AvatarType type = AvatarType.Virtual)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uid", uid.ToString()},
                               {"size", size.ToString().ToLower()},
                               {"type", type.ToString().ToLower()},
                               {"check_file_exists", "1"}
                           };
            return toBool(SendGet(UcConfig.UcApi + "avatar.php", args));
        }

        #endregion

        #region TagModel
        /// <summary>
        /// 获取标签数据
        /// </summary>
        /// <param name="tagName">标签名</param>
        /// <param name="number">应用程序ID对应的数量</param>
        /// <returns></returns>
        public UcTags TagGet(string tagName, IEnumerable<KeyValuePair<string, string>> number)
        {
            var args = new Dictionary<string, string>
                           {
                               {"tagname", tagName}
                           };
            foreach (var n in number)
            {
                args.Add(n.Key, n.Value);
            }
            return new UcTags(SendArgs(args, UcTagModelName.ModelName, UcTagModelName.ActionGet));
        }
        #endregion

        #region FeedModel
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
        public int FeedAdd(FeedIcon icon, int uid, string userName, string titleTemplate, string titleData, string bodyTemplate, string bodyData, string bodyGeneral, string targetIds, params string[] images)
        {
            var args = new Dictionary<string, string>
                           {
                               {"icon", icon.ToString().ToLower()},
                               {"uid",uid.ToString()},
                               {"username",userName},
                               {"title_template",titleTemplate},
                               {"title_data",titleData},
                               {"body_template",bodyTemplate},
                               {"body_data",bodyData},
                               {"body_general",bodyGeneral},
                               {"target_ids",targetIds}
                           };

            var length = images.Length;
            if ( length% 2 == 0)
            {
                var url = new string[length/2];
                var link = new string[length / 2];
                for(var k=0;k<length;k+=2)
                {
                    url[k/2] = images[k];
                    link[k/2] = images[k + 1];
                }
                addArray(args, "url", url);
                addArray(args, "link", link);
            }

            return toInt(SendArgs(args, UcFeedModelName.ModelName, UcFeedModelName.ActionAdd));
        }

        /// <summary>
        /// 得到Feed
        /// </summary>
        /// <param name="limit">数量限制</param>
        /// <returns></returns>
        public UcFeeds FeedGet(int limit)
        {
            var args = new Dictionary<string, string>
                           {
                               {"limit", limit.ToString()}
                           };
            return new UcFeeds(SendArgs(args, UcFeedModelName.ModelName, UcFeedModelName.ActionGet));
        }
        #endregion

        #region AppModel
        /// <summary>
        /// 得到应用列表
        /// </summary>
        /// <returns></returns>
        public UcApps AppList()
        {
            var args = new Dictionary<string, string>();
            return new UcApps(SendArgs(args, UcAppModelName.ModelName, UcAppModelName.ActionList));
        }
        #endregion

        #region MailMode

        /// <summary>
        /// 添加邮件到队列
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="message">内容</param>
        /// <param name="uids">Uid</param>
        /// <returns></returns>
        public UcMailQueue MailQueue(string subject, string message,params int[] uids)
        {
            return MailQueue(subject, message, "", "gbk", false, 1, uids, new string[0]);
        }

        /// <summary>
        /// 添加邮件到队列
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="message">内容</param>
        /// <param name="emails">目标email</param>
        /// <returns></returns>
        public UcMailQueue MailQueue(string subject, string message, params string[] emails)
        {
            return MailQueue(subject, message, "", "gbk", false, 1, new int[0], emails);
        }

        /// <summary>
        /// 添加邮件到队列
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="message">内容</param>
        /// <param name="uids">Uid</param>
        /// <param name="emails">目标email</param>
        /// <returns></returns>
        public UcMailQueue MailQueue(string subject, string message, int[] uids, string[] emails)
        {
            return MailQueue(subject, message, "", "gbk", false, 1, uids, emails);
        }

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
        public UcMailQueue MailQueue(string subject,string message,string fromMail,string charset,bool htmlOn,int level,int[] uids,string[] emails)
        {
            var args = new Dictionary<string, string>
                           {
                               {"uids", string.Join(",",intToString(uids))},
                               {"emails", string.Join(",",emails)},
                               {"subject",subject},
                               {"message", message},
                               {"frommail", fromMail},
                               {"charset", charset},
                               {"htmlon", htmlOn?"1":"0"},
                               {"level", level.ToString()}
                           };
            return new UcMailQueue(SendArgs(args, UcMailModelName.ModelName, UcMailModelName.ActionAdd));
        }
        #endregion
        #region 函数
        private string getFlashPlayerCode(string movie)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0\" width=\"447\" height=\"477\" id=\"mycamera\" align=\"middle\">");
            sb.AppendLine("<param name=\"allowScriptAccess\" value=\"always\" />");
            sb.AppendLine("<param name=\"scale\" value=\"exactfit\" />");
            sb.AppendLine("<param name=\"wmode\" value=\"transparent\" />");
            sb.AppendLine("<param name=\"quality\" value=\"high\" />");
            sb.AppendLine("<param name=\"bgcolor\" value=\"#ffffff\" />");
            sb.AppendLine("<param name=\"movie\" value=\"{0}\" />");
            sb.AppendLine("<param name=\"menu\" value=\"false\" />");
            sb.AppendLine("<embed src=\"{0}\" quality=\"high\" bgcolor=\"#ffffff\" width=\"447\" height=\"477\" name=\"mycamera\" align=\"middle\" allowScriptAccess=\"always\" allowFullScreen=\"false\" scale=\"exactfit\"  wmode=\"transparent\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />");
            sb.AppendLine("</object>");
            return string.Format(sb.ToString(), movie);
        }


        /// <summary>
        /// Int数组转换为String数组
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private string[] intToString(int[] data)
        {
            var result = new string[data.Length];
            for (var k = 0; k < data.Length; k++)
            {
                result[k] = data[k].ToString();
            }
            return result;
        }

 
        /// <summary>
        /// 添加数组
        /// </summary>
        /// <param name="args">参数结合</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        private void addArray(IDictionary<string, string> args, string key, IEnumerable<int> value)
        {
            var index = 0;
            foreach (var v in value)
            {
                args.Add(string.Format("{0}[{1}]", key, index++), v.ToString());
            }
        }

        /// <summary>
        /// 添加数组
        /// </summary>
        /// <param name="args">参数结合</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        private void addArray(IDictionary<string, string> args, string key, IEnumerable<string> value)
        {
            var index = 0;
            foreach (var v in value)
            {
                args.Add(string.Format("{0}[{1}]", key, index++), v);
            }
        }

        /// <summary>
        /// 转到到Bool
        /// </summary>
        /// <param name="input">判断为true的条件：大于0，或者为非空、非"false"的字符串</param>
        /// <returns></returns>
        private bool toBool(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return result > 0 ? true : false;
            }
            if (input.ToLower() == "false" || string.IsNullOrEmpty(input)) return false;
            return true;
        }

        /// <summary>
        /// 转换到Int
        /// </summary>
        /// <param name="input">原数据</param>
        /// <returns></returns>
        private int toInt(string input)
        {
            int result;
            int.TryParse(input, out result);
            return result;
        }
        #endregion
    }
}