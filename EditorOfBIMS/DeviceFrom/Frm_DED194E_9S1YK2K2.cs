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

namespace EditorOfBIMS
{
    public partial class Frm_DED194E_9S1YK2K2 : Form
    {
        private Bean_DED194E_9S1YK2K2 bean;
        public Frm_DED194E_9S1YK2K2(Bean_DED194E_9S1YK2K2 b)
        {
            InitializeComponent();
            bean = b;
            InitInfo();
        }

        private void InitInfo()
        {
            textBox_address.Text = bean.SlaveNum.ToString();
            textBox_bound.Text = bean.Baud.ToString();
            
            textBox_IP.Text = bean.Ip;
            textBox_Port.Text = bean.Port.ToString();
            textBox_shebeihao.Text = bean.DeviceNum.ToString();
            textBox_time.Text = bean.During.ToString();
            tb_Sort.Text = bean.Sort;
            tb_beizhu.Text = bean.Beizhu;
            textBox1.Text = bean.NikeName;
        }

        private void button_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            
            bean.SlaveNum =  int.Parse(textBox_address.Text );
            bean.Baud =  int.Parse(textBox_bound.Text) ;       
            bean.Ip = textBox_IP.Text ;
            bean.Port =  int.Parse(textBox_Port.Text);
            bean.DeviceNum = int.Parse(textBox_shebeihao.Text);
            bean.During = int.Parse(textBox_time.Text);
            bean.Sort = tb_Sort.Text;
            bean.Beizhu=tb_beizhu.Text ;
            bean.NikeName = textBox1.Text;
            //MessageBox.Show("成功保存");
            this.Close();
        }




    }
}
