using System.Linq;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 项目基类
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class UcItemReceiveBase<T> : UcItemBase
        where T : UcItemReceiveBase<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        protected UcItemReceiveBase(string xml)
        {
            initialize(xml);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        protected UcItemReceiveBase(XmlNode xml)
        {
            initialize(xml);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="xml">参数</param>
        private void initialize(string xml)
        {
            try
            {
                unSerialize(xml);
                Success = true;
            }
            catch
            {
                Success = false;
            }
            finally
            {
                SetProperty();
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="xml">数据</param>
        private void initialize(XmlNode xml)
        {
            try
            {
                getItems(xml);
                Success = true;
            }
            catch
            {
                Success = false;
            }
            finally
            {
                SetProperty();
            }
        }

        /// <summary>
        /// 得到UCenter项目
        /// </summary>
        /// <param name="node">节点</param>
        private void getItems(XmlNode node)
        {
            foreach (XmlNode xn in node.ChildNodes)
            {
                if (xn.Attributes != null) Data.Add(xn.Attributes["id"].Value, xn.InnerText);
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="xml">XML</param>
        /// <param name="rootNodeName">根目录</param>
        /// <returns></returns>
        private void unSerialize(string xml, string rootNodeName = "root")
        {
            var document = new XmlDocument();
            document.LoadXml(xml);
            var node = document.SelectSingleNode(rootNodeName);
            getItems(node);
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        protected abstract void SetProperty();

        /// <summary>
        /// 检查是否成功
        /// </summary>
        /// <param name="keys">必要的参数</param>
        protected void CheckForSuccess(params string[] keys)
        {
            if (keys.Any(key => !Data.Contains(key))) Success = false;
        }
    }
}