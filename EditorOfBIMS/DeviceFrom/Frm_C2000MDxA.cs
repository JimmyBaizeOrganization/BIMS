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
    public partial class Frm_C2000MDxA : Form
    {
       
        private Bean_C2000MDxA bean;
        public Frm_C2000MDxA(Bean_C2000MDxA b)
        {
            InitializeComponent();
            bean = b;

            textBox_address.Text = bean.SlaveNum.ToString();
            textBox_bound.Text = bean.Baud.ToString();
            textBox_IP.Text = bean.Ip;
            textBox_Port.Text = bean.Port.ToString();
            textBox_shebeihao.Text = bean.DeviceNum.ToString();
            textBox_time.Text = bean.During.ToString();
            tb_Sort.Text = bean.Sort;
            tb_beizhu.Text = bean.Beizhu;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            bean.SlaveNum = int.Parse(textBox_address.Text);
            bean.Baud = int.Parse(textBox_bound.Text);
            bean.Ip = textBox_IP.Text;
            bean.Port = int.Parse(textBox_Port.Text);
            bean.DeviceNum = int.Parse(textBox_shebeihao.Text);
            bean.During = int.Parse(textBox_time.Text);
            bean.Sort = tb_Sort.Text;
            bean.Beizhu = tb_beizhu.Text;
            //MessageBox.Show("成功保存");
            this.Close();
        }
    }
}
