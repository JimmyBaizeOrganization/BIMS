using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace EditorOfBIMS.DeviceFrom
{
    public partial class Frm_DI : Form
    {
        DIBean bean;
        public Frm_DI(DIBean b)
        {
            InitializeComponent();
            bean = b;
           
            checkBox_Run.Checked = bean.useing;

            textBox2.Text= bean.imagePath ;
            
              textBox3.Text=bean.detail;
            
             textBox6.Text=bean.sort ;
             textBox1.Text = bean.imageClosePath;
             textBox4.Text = bean.NikeName;
             if (bean.normalVaule)
             {
                  radioButton1.Checked = true;
                  radioButton2.Checked = false;
             }
             else
             {
                 radioButton2.Checked = true;
                 radioButton1.Checked = false;
             }           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bean.useing = checkBox_Run.Checked;
            bean.NikeName = textBox4.Text;
            if (bean.useing)
            {
                if (textBox2.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox6.Text == "" )
                {
                    MessageBox.Show("如果启用该设备，则必须填入图片，数据描述");
                    bean.useing = false;
                }
                else
                {
                    bean.imagePath = textBox2.Text;
                  
                    bean.detail = textBox3.Text;
                    bean.imageClosePath = textBox1.Text;
                    bean.sort = textBox6.Text;
                    bean.normalVaule = radioButton1.Checked;
                }
            }
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    textBox2.Text = "lighton.png";                   
                    textBox3.Text = "开关";
                    textBox1.Text = "lightoff.png";
                    textBox6.Text = "电灯状态:";
                    break;
            }
        }
    }
}
