using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace BIMS
{
    public partial class SearchForm : Form
    {
        Hashtable beans;
        private class BeanNode : TreeNode
        {
            BaseBean bean;
            public BeanNode(string text,BaseBean b):base(
                text)
            {
                bean = b;
            }
        }
        public SearchForm(Hashtable ht)
        {
            InitializeComponent();
            beans = ht;
            
            foreach (DictionaryEntry de in beans)
            {
                
                BaseBean b = (BaseBean)de.Value;
                 if(treeView.Nodes.ContainsKey(b.Sort))
                 {
                     ///去前面已经添加了这个分类，则在这个分支下添加一个BeanNode                
                         //(new BeanNode(b.DeviceType,b));
                 }
                 else
                 {
                    //以前没有添加这个分类 ，则 这次添加上去
                    //treeView.Nodes.Find()
                     treeView.Nodes.Add( new TreeNode(b.Sort));
                 }
                TreeNode[] aa =  treeView.Nodes.Find(b.Sort, true);
                Console.WriteLine(aa);
                     //[0].Nodes.Add((new BeanNode(b.DeviceType, b)));
        
              
               
                
            }
           
        }
    }
}
