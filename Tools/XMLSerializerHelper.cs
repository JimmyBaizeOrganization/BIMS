﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Tools
{
    public class XMLSerializerHelper
    {
   
    /// <summary>
        /// 将指定的对象序列化为XML文件或二进制文件并返回执行状态。
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="path">保存路径</param>
        /// <param name="isBinaryFile">序列化后生成的文件类型是否为二进制文件，true为二进制文件，否则为xml文件或文本文件</param>
        /// <returns>返回执行状态</returns>
        public static bool Serialize(Object o, string path, bool isBinaryFile)
        {
            bool flag = false;
            try
            {
                if (isBinaryFile)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        formatter.Serialize(stream, o);
                        flag = true;
                    }
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(o.GetType());
                    using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
                    {
                        writer.Formatting = Formatting.Indented;
                        XmlSerializerNamespaces n = new XmlSerializerNamespaces();
                        n.Add("", "");
                        serializer.Serialize(writer, o, n);
                        flag = true;
                    }
                }
            }
            catch { flag = false; }
            return flag;
        }

        /// <summary>
        /// 将指定的对象序列化为XML格式的字符串并返回。
        /// </summary>
        /// <param name="o">待序列化的对象</param>
        /// <returns>返回序列化后的字符串</returns>
        public static string Serialize(Object o)
        {
            string xml = "";
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                using (MemoryStream mem = new MemoryStream())
                {
                    using (XmlTextWriter writer = new XmlTextWriter(mem, Encoding.UTF8))
                    {
                        writer.Formatting = Formatting.Indented;
                        XmlSerializerNamespaces n = new XmlSerializerNamespaces();
                        n.Add("", "");
                        serializer.Serialize(writer, o, n);

                        mem.Seek(0, SeekOrigin.Begin);
                        using (StreamReader reader = new StreamReader(mem))
                        {
                            xml = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch { xml = ""; }
            return xml;
        }

        /// <summary>
        /// 从指定的文件中反序列化出对应的对象并返回。
        /// </summary>
        /// <param name="t">要反序列化的对象类型</param>
        /// <param name="path">文件路径</param>
        /// <param name="isBinaryFile">反序列化的文件类型是否为二进制文件，true为二进制文件，否则为xml文件或文本文件</param>
        /// <returns>返回Object</returns>
        public static object Deserialize(Type t, string path, bool isBinaryFile)
        {
            Object o = null;
            try
            {
                if (!isBinaryFile)
                {
                    XmlSerializer serializer = new XmlSerializer(t);
                    using (XmlTextReader reader = new XmlTextReader(path))
                    {
                        o = serializer.Deserialize(reader);
                    }
                }
                else
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        o = formatter.Deserialize(stream);
                    }
                }
            }
            catch { o = null; }
            return o;
        }

        /// <summary>
        /// 将指定的xml格式的字符反序列化为对应的对象并返回。
        /// </summary>
        /// <param name="t">对象的类型</param>
        /// <param name="xml">待反序列化的xml格式的字符的内容</param>
        /// <returns>返回对应的对象</returns>
        public static Object Deserialize(Type t, string xml)
        {
            Object o = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(t);
                using (MemoryStream mem = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    o = serializer.Deserialize(mem);
                }
            }
            catch { o = null; }
            return o;
        }

        /// <summary>
        /// 将指定的对象序列化为XML文件，并返回执行状态。
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="path">生成的文件名称</param>
        /// <returns>返回执行状态</returns>
        public static bool XmlSerialize(Object o, string path)
        {
            return XMLSerializerHelper.Serialize(o, path, false);
        }

        /// <summary>
        /// 将指定XML文件，反序列化为对应的对象并返回。
        /// </summary>
        /// <param name="t">对象的类型</param>
        /// <param name="path">XML文件路径</param>
        /// <returns>返回对象</returns>
        public static Object XmlDeserialize(Type t, string path)
        {
            return XMLSerializerHelper.Deserialize(t, path, false);
        }

        /// <summary>
        /// 将指定的对象序列化为二进制文件，并返回执行状态。
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="path">生成的文件名称</param>
        /// <returns>返回执行状态</returns>
        public static bool BinarySerialize(Object o, string path)
        {
            return XMLSerializerHelper.Serialize(o, path, true);
        }

        /// <summary>
        /// 将指定二进制文件，反序列化为对应的对象并返回。
        /// </summary>
        /// <param name="t">对象的类型</param>
        /// <param name="path">XML文件路径</param>
        /// <returns>返回对象</returns>
        public static Object BinaryDeserialize(Type t, string path)
        {
            return XMLSerializerHelper.Deserialize(t, path, true);
        }
    }
}
