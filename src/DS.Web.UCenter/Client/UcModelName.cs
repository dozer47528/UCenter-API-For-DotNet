namespace DS.Web.UCenter.Client
{
    /// <summary>
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// </summary>
    static internal class UcUserModelName
    {
        static public string ModelName { get { return "user"; } }
        static public string ActionRegister { get { return "register"; } }
        static public string ActionLogin { get { return "login"; } }
        static public string ActionInfo { get { return "get_user"; } }
        static public string ActionEdit { get { return "edit"; } }
        static public string ActionDelete { get { return "delete"; } }
        static public string ActionDeleteAvatar { get { return "deleteavatar"; } }
        static public string ActionSynLogin { get { return "synlogin"; } }
        static public string ActionSynLogout { get { return "synlogout"; } }
        static public string ActionCheckEmail { get { return "check_email"; } }
        static public string ActionAddProtected { get { return "addprotected"; } }
        static public string ActionDeleteProtected { get { return "deleteprotected"; } }
        static public string ActionGetProtected { get { return "getprotected"; } }
        static public string ActionMerge { get { return "merge"; } }
        static public string ActionMergeRemove { get { return "merge_remove"; } }
        static public string ActionGetCredit { get { return "getcredit"; } }
    }

    static internal class UcPmModelName
    {
        static public string ModelName { get { return "pm"; } }
        static public string ActionCheckNew { get { return "check_newpm"; } }
        static public string ActionSend { get { return "sendpm"; } }
        static public string ActionDelete { get { return "delete"; } }
        static public string ActionDeleteUser { get { return "deleteuser"; } }
        static public string ActionReadStatus { get { return "readstatus"; } }
        static public string ActionList { get { return "ls"; } }
        static public string ActionView { get { return "view"; } }
        static public string ActionViewNode { get { return "viewnode"; } }
        static public string ActionIgnore { get { return "ignore"; } }
        static public string ActionBlacklsGet { get { return "blackls_get"; } }
        static public string ActionBlacklsSet { get { return "blackls_set"; } }
        static public string ActionBlacklsAdd { get { return "blackls_add"; } }
        static public string ActionBlacklsDelete { get { return "blackls_delete"; } }
    }

    static internal class UcFriendModelName
    {
        static public string ModelName { get { return "friend"; } }
        static public string ActionAdd { get { return "add"; } }
        static public string ActionDelete { get { return "delete"; } }
        static public string ActionTotalNum { get { return "totalnum"; } }
        static public string ActionList { get { return "ls"; } }
    }

    static internal class UcCreditModelName
    {
        static public string ModelName { get { return "credit"; } }
        static public string ActionExchangeRequest { get { return "request"; } }
    }

    static internal class UcTagModelName
    {
        static public string ModelName { get { return "tag"; } }
        static public string ActionGet { get { return "gettag"; } }
    }

    static internal class UcFeedModelName
    {
        static public string ModelName { get { return "feed"; } }
        static public string ActionAdd { get { return "add"; } }
        static public string ActionGet { get { return "get"; } }
    }

    static internal class UcAppModelName
    {
        static public string ModelName { get { return "app"; } }
        static public string ActionList { get { return "ls"; } }
    }

    static internal class UcMailModelName
    {
        static public string ModelName { get { return "mail"; } }
        static public string ActionAdd { get { return "add"; } }

    }
}
