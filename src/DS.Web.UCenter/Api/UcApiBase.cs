using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace DS.Web.UCenter.Api
{
    /// <summary>
    /// UcApi
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// </summary>
    public abstract class UcApiBase : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            Response = context.Response;
            Request = context.Request;
            Args = new UcRequestArguments(Request);
            if (!check()) return;
            switchAction();
        }

        #region 私有
        private HttpResponse Response { get; set; }
        private HttpRequest Request { get; set; }
        private IUcRequestArguments Args { get; set; }
        /// <summary>
        /// 检查合法性
        /// </summary>
        /// <returns></returns>
        private bool check()
        {
            if (Args.IsInvalidRequest)
            {
                writeEnd("Invalid Request");
            }
            if (Args.IsAuthracationExpiried)
            {
                writeEnd("Authracation has expiried");
            }
            return true;
        }
        private void writeEnd(string msg)
        {
            Response.Write(msg);
            Response.End();
        }
        private void writeEnd<T>(UcCollectionReturnBase<T> msg)
            where T : UcItemReturnBase
        {
            writeEnd(msg.ToString());
        }
        private void writeEnd(ApiReturn result)
        {
            var msg = result == ApiReturn.Success ? UcConfig.ApiReturnSucceed : UcConfig.ApiReturnFailed;
            Response.Write(msg);
            Response.End();
        }
        private void writeForbidden()
        {
            writeEnd(UcConfig.ApiReturnForbidden);
        }
        private void switchAction()
        {
            if (Args.Action == UcActions.Test)
            {
                test();
            }
            else if (Args.Action == UcActions.DeleteUser)
            {
                deleteUser();
            }
            else if (Args.Action == UcActions.RenameUser)
            {
                renameUser();
            }
            else if (Args.Action == UcActions.GetTag)
            {
                getTag();
            }
            else if (Args.Action == UcActions.SynLogin)
            {
                synLogin();
            }
            else if (Args.Action == UcActions.SynLogout)
            {
                synLogout();
            }
            else if (Args.Action == UcActions.UpdatePw)
            {
                updatePw();
            }
            else if (Args.Action == UcActions.UpdateBadWords)
            {
                updateBadWords();
            }
            else if (Args.Action == UcActions.UpdateHosts)
            {
                updateHosts();
            }
            else if (Args.Action == UcActions.UpdateApps)
            {
                updateApps();
            }
            else if (Args.Action == UcActions.UpdateClient)
            {
                updateClient();
            }
            else if (Args.Action == UcActions.UpdateCredit)
            {
                updateCredit();
            }
            else if (Args.Action == UcActions.GetCreditSettings)
            {
                getCreditSettings();
            }
            else if (Args.Action == UcActions.GetCredit)
            {
                getCredit();
            }
            else if (Args.Action == UcActions.UpdateCreditSettings)
            {
                updateCreditSettings();
            }
        }
        #endregion

        #region API实现
        private void test()
        {
            writeEnd(UcConfig.ApiReturnSucceed);
        }
        private void deleteUser()
        {
            if (!UcConfig.ApiDeleteUser) writeForbidden();
            var ids = Args.QueryString["ids"];
            var idArray = new List<int>();
            foreach (var id in ids.Split(','))
            {
                int idInt;
                if (int.TryParse(id, out idInt)) idArray.Add(idInt);
            }
            writeEnd(DeleteUser(idArray));
        }
        private void renameUser()
        {
            if (!UcConfig.ApiRenameUser) writeForbidden();
            int uid;
            int.TryParse(Args.QueryString["uid"], out uid);
            var oldusername = Args.QueryString["oldusername"];
            var newusername = Args.QueryString["newusername"];
            writeEnd(RenameUser(uid, oldusername, newusername));
        }
        private void getTag()
        {
            if (!UcConfig.ApiGetTag) writeForbidden();
            var tagName = Args.QueryString["id"];
            writeEnd(GetTag(tagName));
        }
        private void synLogin()
        {
            if (!UcConfig.ApiSynLogin) writeForbidden();
            Response.Headers.Add("P3P", "CP=\"CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR\"");
            int uid;
            int.TryParse(Args.QueryString["uid"], out uid);
            writeEnd(SynLogin(uid));
        }
        private void synLogout()
        {
            if (!UcConfig.ApiSynLogout) writeForbidden();
            Response.Headers.Add("P3P", "CP=\"CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR\"");
            writeEnd(SynLogout());
        }
        private void updatePw()
        {
            if (!UcConfig.ApiUpdatePw) writeForbidden();
            var username = Args.QueryString["username"];
            var password = Args.QueryString["password"];
            writeEnd(UpdatePw(username, password));
        }
        private void updateBadWords()
        {
            if (!UcConfig.ApiUpdateBadWords) writeForbidden();
            var badWords = new UcBadWords(Args.FormData);
            writeEnd(UpdateBadWords(badWords));
        }
        private void updateHosts()
        {
            if (!UcConfig.ApiUpdateHosts) writeForbidden();
            var hosts = new UcHosts(Args.FormData);
            writeEnd(UpdateHosts(hosts));
        }
        private void updateApps()
        {
            if (!UcConfig.ApiUpdateApps) writeForbidden();
            var apps = new UcApps(Args.FormData);
            writeEnd(UpdateApps(apps));
        }
        private void updateClient()
        {
            if (!UcConfig.ApiUpdateClient) writeForbidden();
            var client = new UcClientSetting(Args.FormData);
            writeEnd(UpdateClient(client));
        }
        private void updateCredit()
        {
            if (!UcConfig.ApiUpdateCredit) writeForbidden();
            int uid;
            int.TryParse(Args.QueryString["uid"], out uid);
            int credit;
            int.TryParse(Args.QueryString["credit"], out credit);
            int amount;
            int.TryParse(Args.QueryString["amount"], out amount);
            writeEnd(UpdateCredit(uid, credit, amount));
        }
        private void getCreditSettings()
        {
            if (!UcConfig.ApiGetCreditSettings) writeForbidden();
            writeEnd(GetCreditSettings());
        }
        private void getCredit()
        {
            if (!UcConfig.ApiGetCredit) writeForbidden();
            int uid;
            int.TryParse(Args.QueryString["uid"], out uid);
            int credit;
            int.TryParse(Args.QueryString["credit"], out credit);
            writeEnd(GetCredit(uid, credit));
        }
        private void updateCreditSettings()
        {
            if (!UcConfig.ApiUpdateCreditSettings) writeForbidden();
            var creditSettings = new UcCreditSettings(Args.FormData);
            writeEnd(UpdateCreditSettings(creditSettings));
        }
        #endregion

        #region 抽象方法
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids">Uid</param>
        /// <returns></returns>
        public abstract ApiReturn DeleteUser(IEnumerable<int> ids);
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="oldUserName">旧用户名</param>
        /// <param name="newUserName">新用户名</param>
        /// <returns></returns>
        public abstract ApiReturn RenameUser(int uid, string oldUserName, string newUserName);
        /// <summary>
        /// 得到标签
        /// </summary>
        /// <param name="tagName">标签名</param>
        /// <returns></returns>
        public abstract UcTagReturns GetTag(string tagName);
        /// <summary>
        /// 同步登陆
        /// </summary>
        /// <param name="uid">uid</param>
        /// <returns></returns>
        public abstract ApiReturn SynLogin(int uid);
        /// <summary>
        /// 同步登出
        /// </summary>
        /// <returns></returns>
        public abstract ApiReturn SynLogout();
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public abstract ApiReturn UpdatePw(string userName, string passWord);
        /// <summary>
        /// 更新不良词汇
        /// </summary>
        /// <param name="badWords">不良词汇</param>
        /// <returns></returns>
        public abstract ApiReturn UpdateBadWords(UcBadWords badWords);
        /// <summary>
        /// 更新Hosts
        /// </summary>
        /// <param name="hosts">Hosts</param>
        /// <returns></returns>
        public abstract ApiReturn UpdateHosts(UcHosts hosts);
        /// <summary>
        /// 更新App
        /// </summary>
        /// <param name="apps">App</param>
        /// <returns></returns>
        public abstract ApiReturn UpdateApps(UcApps apps);
        /// <summary>
        /// 更新UCenter设置
        /// </summary>
        /// <param name="client">UCenter设置</param>
        /// <returns></returns>
        public abstract ApiReturn UpdateClient(UcClientSetting client);
        /// <summary>
        /// 更新用户积分
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="credit">积分编号</param>
        /// <param name="amount">积分增减</param>
        /// <returns></returns>
        public abstract ApiReturn UpdateCredit(int uid, int credit, int amount);
        /// <summary>
        /// 得到积分设置
        /// </summary>
        /// <returns></returns>
        public abstract UcCreditSettingReturns GetCreditSettings();
        /// <summary>
        /// 得到积分
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="credit">积分编号</param>
        /// <returns></returns>
        public abstract ApiReturn GetCredit(int uid, int credit);
        /// <summary>
        /// 更新积分设置
        /// </summary>
        /// <param name="creditSettings">积分设置</param>
        /// <returns></returns>
        public abstract ApiReturn UpdateCreditSettings(UcCreditSettings creditSettings);
        #endregion
    }

    /// <summary>
    /// 返回类型
    /// </summary>
    public enum ApiReturn
    {
        /// <summary>
        /// 失败
        /// </summary>
        Failed,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
    }
}

