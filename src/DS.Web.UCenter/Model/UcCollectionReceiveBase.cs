using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace DS.Web.UCenter
{
    /// <summary>
    /// 集合基类
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// </summary>
    /// <typeparam name="T">项目</typeparam>
    /// <typeparam name="TThis">基类</typeparam>
    public abstract class UcCollectionReceiveBase<T, TThis> : UcCollectionBase
        where T : UcItemReceiveBase<T>
        where TThis : UcCollectionReceiveBase<T, TThis>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">数据</param>
        protected UcCollectionReceiveBase(string xml)
        {
            initialize(xml);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="xml">数据</param>
        private void initialize(string xml)
        {
            try
            {
                unSerialize(xml);
            }
            catch { }
            finally
            {
                SetProperty();
            }
        }


        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="xml">XML</param>
        /// <returns></returns>
        private void unSerialize(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);
            if (document.DocumentElement == null) throw new XmlException("这不是一个Xml文档");
            var data = new Hashtable();
            unSerialize(data, document.DocumentElement);
            foreach (DictionaryEntry root in data)
            {
                if (root.Value is Hashtable)
                {
                    Data = (Hashtable)root.Value;
                    break;
                }
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data"></param>
        /// <param name="node"></param>
        private void unSerialize(IDictionary data, XmlNode node)
        {
            if (!node.FirstChild.HasChildNodes)
            {
                var key = getId(node);
                data.Add(key, node.InnerText);
            }
            else
            {
                var item = (T)Activator.CreateInstance(typeof(T), node);
                var key = getId(node);
                if (item.Success)
                {
                    data.Add(key, item);
                }
                else
                {
                    var dic = new Hashtable();
                    data.Add(key, dic);
                    foreach (XmlNode n in node.ChildNodes)
                    {
                        unSerialize(dic, n);
                    }
                }
            }
        }

        private string getId(XmlNode node)
        {
            return node.Attributes != null ? node.Attributes["id"].Value : Guid.NewGuid().ToString();
        }


        /// <summary>
        /// 设置属性
        /// </summary>
        protected virtual void SetProperty() { }

        /// <summary>
        /// 设置项目
        /// </summary>
        /// <param name="list"></param>
        protected void SetItems(IList<T> list)
        {
            SetItems(list, Data);
        }

        /// <summary>
        /// 设置项目
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        protected void SetItems(IList<T> list, IDictionary data)
        {
            if (data == null) return;
            foreach (DictionaryEntry entry in data)
            {
                if (!(entry.Value is T)) continue;
                var item = (T)entry.Value;
                if (item.Success) list.Add(item);
            }
        }
    }
}
