using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Xml;

namespace EditorOfBIMS
{
    public partial class DXFrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DXFrmMain()
        {
            InitializeComponent();
        }

        private void bBI_Sumbit_ItemClick(object sender, ItemClickEventArgs e)
        {
            XmlDocument xmldoc;
            XmlNode xmlnode;
            XmlElement xmlelem;

            //生成一个XML文件
             xmldoc = new XmlDocument();
            //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>
             XmlDeclaration xmldecl;
            xmldecl = xmldoc.CreateXmlDeclaration("1.0", "gb2312", null);
            xmldoc.AppendChild(xmldecl);
            //加入一个根元素
            xmlelem = xmldoc.CreateElement("", "Employees", "");
            xmldoc.AppendChild(xmlelem);
            //加入另外一个元素
            for (int i = 1; i < 3; i++)
            {

                XmlNode root = xmldoc.SelectSingleNode("Employees");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Node");//创建一个<Node>节点 
                xe1.SetAttribute("genre", "李赞红");//设置该节点genre属性 
                xe1.SetAttribute("ISBN", "2-3631-4");//设置该节点ISBN属性

                XmlElement xesub1 = xmldoc.CreateElement("title");
                xesub1.InnerText = "CS从入门到精通";//设置文本节点 
                xe1.AppendChild(xesub1);//添加到<Node>节点中 
                XmlElement xesub2 = xmldoc.CreateElement("author");
                xesub2.InnerText = "候捷";
                xe1.AppendChild(xesub2);
                XmlElement xesub3 = xmldoc.CreateElement("price");
                xesub3.InnerText = "58.3";
                xe1.AppendChild(xesub3);

                root.AppendChild(xe1);//添加到<Employees>节点中 
            }
            //保存创建好的XML文档
            
            xmldoc.Save("data.xml");
        }
    }
}