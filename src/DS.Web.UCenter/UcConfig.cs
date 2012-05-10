using System.Collections.Generic;
using System.Configuration;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 配置
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// </summary>
    public static class UcConfig
    {
        private static IDictionary<string, string> _items;
        private static IDictionary<string,string> Items{get { return _items ?? (_items = new Dictionary<string, string>()); }}

        /// <summary>
        /// 读取键值，并作缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        private static string getValueTemp(string key)
        {
            if (!Items.ContainsKey(key)) Items.Add(key, ConfigurationManager.AppSettings[key]);
            return Items[key];
        }

        /// <summary>
        /// 得到配置
        /// </summary>
        /// <param name="key">KEY</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="checkEmpty">是否检查是否为空</param>
        /// <exception cref="ConfigurationErrorsException">配置信息丢失错误</exception>
        /// <returns>字符串类型</returns>
        private static string getStringValue(string key, string defaultValue = "", bool checkEmpty = false)
        {
            var str = getValueTemp(key);
            if (checkEmpty && string.IsNullOrEmpty(str))
                throw new ConfigurationErrorsException(string.Format("缺少 {0} 的配置信息", key));
            return string.IsNullOrEmpty(str) ? defaultValue : str.Trim();
        }

        /// <summary>
        /// 得到配置
        /// </summary>
        /// <param name="key">KEY</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="checkEmpty">是否检查是否为空</param>
        /// <exception cref="ConfigurationErrorsException">配置信息丢失错误</exception>
        /// <returns>bool类型</returns>
        private static bool getBoolValue(string key, bool defaultValue = false, bool checkEmpty = false)
        {
            var str = getValueTemp(key);
            if (checkEmpty && string.IsNullOrEmpty(str))
                throw new ConfigurationErrorsException(string.Format("缺少 {0} 的配置信息", key));
            bool result;
            return bool.TryParse(str,out result) ? result : defaultValue;
        }

        /// <summary>
        /// 得到配置
        /// </summary>
        /// <param name="key">KEY</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="checkEmpty">是否检查是否为空</param>
        /// <exception cref="ConfigurationErrorsException">配置信息丢失错误</exception>
        /// <returns>int类型</returns>
        private static int getIntValue(string key, int defaultValue = 0, bool checkEmpty = false)
        {
            var str = getValueTemp(key);
            if (checkEmpty && string.IsNullOrEmpty(str))
                throw new ConfigurationErrorsException(string.Format("缺少 {0} 的配置信息", key));
            int result;
            return int.TryParse(str, out result) ? result : defaultValue;
        }


        /// <summary>
        /// 客户端版本
        /// </summary>
        public static string UcClientVersion
        {
            get { return getStringValue("UC_CLIENT_VERSION", "1.5.2"); }
        }
        /// <summary>
        /// 发行时间
        /// </summary>
        public static string UcClientRelease
        {
            get { return getStringValue("UC_CLIENT_RELEASE", "20101001"); }
        }
        /// <summary>
        /// 是否允许删除用户
        /// </summary>
        public static bool ApiDeleteUser
        {
            get { return getBoolValue("API_DELETEUSER",true); }
        }
        /// <summary>
        /// 是否允许重命名用户
        /// </summary>
        public static bool ApiRenameUser
        {
            get { return getBoolValue("API_RENAMEUSER", true); }
        }
        /// <summary>
        /// 是否允许得到标签
        /// </summary>
        public static bool ApiGetTag
        {
            get { return getBoolValue("API_GETTAG", true); }
        }
        /// <summary>
        /// 是否允许同步登录
        /// </summary>
        public static bool ApiSynLogin
        {
            get { return getBoolValue("API_SYNLOGIN", true); }
        }
        /// <summary>
        /// 是否允许同步登出
        /// </summary>
        public static bool ApiSynLogout
        {
            get { return getBoolValue("API_SYNLOGOUT", true); }
        }
        /// <summary>
        /// 是否允许更改密码
        /// </summary>
        public static bool ApiUpdatePw
        {
            get { return getBoolValue("API_UPDATEPW", true); }
        }
        /// <summary>
        /// 是否允许更新关键字
        /// </summary>
        public static bool ApiUpdateBadWords
        {
            get { return getBoolValue("API_UPDATEBADWORDS", true); }
        }
        /// <summary>
        /// 是否允许更新域名解析缓存
        /// </summary>
        public static bool ApiUpdateHosts
        {
            get { return getBoolValue("API_UPDATEHOSTS", true); }
        }
        /// <summary>
        /// 是否允许更新应用列表
        /// </summary>
        public static bool ApiUpdateApps
        {
            get { return getBoolValue("API_UPDATEAPPS", true); }
        }
        /// <summary>
        /// 是否允许更新客户端缓存
        /// </summary>
        public static bool ApiUpdateClient
        {
            get { return getBoolValue("API_UPDATECLIENT", true); }
        }
        /// <summary>
        /// 是否允许更新用户积分
        /// </summary>
        public static bool ApiUpdateCredit
        {
            get { return getBoolValue("API_UPDATECREDIT", true); }
        }
        /// <summary>
        /// 是否允许向UCenter提供积分设置
        /// </summary>
        public static bool ApiGetCreditSettings
        {
            get { return getBoolValue("API_GETCREDITSETTINGS", true); }
        }
        /// <summary>
        /// 是否允许获取用户的某项积分
        /// </summary>
        public static bool ApiGetCredit
        {
            get { return getBoolValue("API_GETCREDIT", true); }
        }
        /// <summary>
        /// 是否允许更新应用积分设置
        /// </summary>
        public static bool ApiUpdateCreditSettings
        {
            get { return getBoolValue("API_UPDATECREDITSETTINGS", true); }
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        public static string ApiReturnSucceed
        {
            get { return getStringValue("API_RETURN_SUCCEED","1"); }
        }
        /// <summary>
        /// 返回失败
        /// </summary>
        public static string ApiReturnFailed
        {
            get { return getStringValue("API_RETURN_FAILED","-1"); }
        }
        /// <summary>
        /// 返回禁用
        /// </summary>
        public static string ApiReturnForbidden
        {
            get { return getStringValue("API_RETURN_FORBIDDEN","-2"); }
        }


        /// <summary>
        /// 与 UCenter 的通信密钥, 要与 UCenter 保持一致
        /// </summary>
        public static string UcKey
        {
            get { return getStringValue("UC_KEY", checkEmpty: true); }
        }

        /// <summary>
        /// UCenter地址
        /// </summary>
        public static string UcApi
        {
            get
            {
                var str = getStringValue("UC_API", checkEmpty: true);
                if (!str.EndsWith("/")) str = str + "/";
                return str;
            }
        }

        /// <summary>
        /// 默认编码
        /// </summary>
        public static string UcCharset
        {
            get
            {
                return getStringValue("UC_CHARSET",checkEmpty:true);
            }
        }

        /// <summary>
        /// UCenter IP
        /// </summary>
        public static string UcIp
        {
            get
            {
                return getStringValue("UC_IP");
            }
        }

        /// <summary>
        /// 应用ID
        /// </summary>
        public static string UcAppid
        {
            get { return getStringValue("UC_APPID", checkEmpty: true); }
        }
    }
}

