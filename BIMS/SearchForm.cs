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
        private BeanNode selectNode;
        private class BeanNode : TreeNode
        {
            public BaseBean bean;
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
                if (treeView.Nodes.ContainsKey(b.DeviceType))
                 {
                     ///去前面已经添加了这个分类，则在这个分支下添加一个BeanNode                
                         //(new BeanNode(b.DeviceType,b));
                 }
                 else
                 {
                    //以前没有添加这个分类 ，则 这次添加上去
                    //treeView.Nodes.Find()
                     treeView.Nodes.Add(b.DeviceType, b.DeviceType);
                 }
                treeView.Nodes[treeView.Nodes.IndexOfKey(b.DeviceType)].Nodes.Add(new BeanNode(b.NikeName,b));
               // treeView.Nodes[treeView.Nodes.IndexOfKey(b.DeviceType)].Nodes.Add(b.NikeName, b.NikeName);
                     //[0].Nodes.Add((new BeanNode(b.DeviceType, b)));
           }
           
        }



        private void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (treeView.SelectedNode.Level == 1)
            {
                BeanNode bn = (BeanNode)treeView.SelectedNode;
                selectNode = bn;
         
                string[] field = selectNode.bean.getDataBaseField();
                //Console.WriteLine(field.ToString());
                dataGridView.Columns.Clear();
                dataGridView.Columns.Add("时间", "时间");
                for (int i = 0; i < field.Length; i++)
                {
                    dataGridView.Columns.Add(field[i], field[i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            

        }
    }
}
