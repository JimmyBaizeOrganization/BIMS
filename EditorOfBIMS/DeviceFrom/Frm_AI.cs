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
    public partial class Frm_AI : Form
    {
        AIBean bean;
        public Frm_AI(AIBean b)
        {
            InitializeComponent();
            bean = b;
           // checkBox_Run.DataBindings.Add("Checked", bean, "useing");
            checkBox_Run.Checked = bean.useing;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bean.useing = checkBox_Run.Checked;
            if (bean.useing)
            {
                if (textBox2.Text == "" || textBox1.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("如果启用该设备，则必须填入图片,公式，数据描述");
                    return;
                }
                else
                {
                    bean.imagePath = textBox2.Text;
                    bean.function = textBox1.Text;
                    bean.detail = textBox3.Text;
                    bean.mixVaule = textBox5.Text;
                    bean.maxVaule = textBox4.Text;
                }
            }
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    textBox2.Text = "wenduji.png";
                    textBox1.Text = "25*(x-1)";
                    textBox3.Text = "温度:x摄氏度";
                    break;
            }
        }
    }
}
