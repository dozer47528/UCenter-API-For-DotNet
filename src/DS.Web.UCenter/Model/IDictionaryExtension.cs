using System;
using System.Collections;

namespace DS.Web.UCenter
{
    /// <summary>   
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// </summary>
    static class DictionaryExtension
    {

        /// <summary>
        /// 得到Int
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public int GetInt(this IDictionary data, string key)
        {
            var result = default(int);
            if (data != null) if (data.Contains(key)) int.TryParse(data[key].ToString(), out result);
            return result;
        }


        /// <summary>
        /// 得到String
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public string GetString(this IDictionary data, string key)
        {
            var result = string.Empty;
            if (data != null) if (data.Contains(key)) result = data[key].ToString();
            return result;
        }


        /// <summary>
        /// 得到Bool
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        static public bool GetBool(this IDictionary data, string key, string compare = "1")
        {
            var result = default(bool);
            if (data != null) if (data.Contains(key)) result = (data[key].ToString() == compare);
            return result;
        }


        /// <summary>
        /// 得到DateTime
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public DateTime GetDateTime(this IDictionary data, string key)
        {
            var result = default(DateTime);
            if (data != null) if (data.Contains(key)) result = UcUtility.PhpTimeToDateTime(long.Parse(data[key].ToString()));
            return result;
        }


        /// <summary>
        /// 得到Double
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public double GetDouble(this IDictionary data, string key)
        {
            var result = default(double);
            if (data != null) if (data.Contains(key)) double.TryParse(data[key].ToString(), out result);
            return result;
        }


        /// <summary>
        /// 得到Hashtable
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public Hashtable GetHashtable(this IDictionary data, string key)
        {
            var result = default(Hashtable);
            if (data != null) if (data.Contains(key)) if (data[key] is Hashtable) result = (Hashtable)data[key];
            return result;
        }
    }
}
