﻿using Oracle.DataAccess.Client;
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

namespace BIMS
{
    public partial class Frm_DED194E_9S1YK2K2 : Form
    {
        Bean_DED194E_9S1YK2K2 bean;

        decimal[] dataVaule;
        public Frm_DED194E_9S1YK2K2(decimal[] dv,Bean_DED194E_9S1YK2K2 b)
        {
            InitializeComponent();
            dataVaule = dv;
            bean = b;
            timer.Interval = bean.During/2;
            timer.Start();
            timer_Tick(null, null);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //using (OracleConnection conn = new OracleConnection(OracleTools.connString))
            //{
            //    OracleCommand cmd = new OracleCommand(scmd, conn);
            //    conn.Open();
            //    OracleDataReader mOracleDataReader = cmd.ExecuteReader();
            //    while (mOracleDataReader.Read())
            //    {
            //       textBox_V.Text =  mOracleDataReader["VOLTAGE"].ToString();
            //       textBox_A.Text = mOracleDataReader["VOLTAGE"].ToString();
            //       textBox_V.Text = mOracleDataReader["VOLTAGE"].ToString();
            //       textBox_V.Text = mOracleDataReader["VOLTAGE"].ToString();
            //       textBox_V.Text = mOracleDataReader["VOLTAGE"].ToString();
            //       textBox_V.Text = mOracleDataReader["VOLTAGE"].ToString();
            //       textBox_V.Text = mOracleDataReader["VOLTAGE"].ToString();
            //    }
            //}
            textBox_V.Text = dataVaule[0].ToString();
            textBox_A.Text = dataVaule[1].ToString();
            textBox_YouGongW.Text = dataVaule[3].ToString();
            textBox_WuGongW.Text = dataVaule[4].ToString();
            textBox_F.Text = dataVaule[6].ToString();
            textBox_Ainput.Text = dataVaule[8].ToString();
            textBox_ShiZaiW.Text = dataVaule[5].ToString();
            textBox_WYinShu.Text = dataVaule[7].ToString();
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //String cmd = "select CREAT_TIME,VOLTAGE,I,STATE,P,Q,S,FREQ,PF,DCVAL from DED194E_9S1YK2K2";
            //SearchForm frm = new SearchForm(bean.getDataBaseField(), cmd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String cmd = "select CREAT_TIME,VOLTAGE,I,STATE,P,Q,S,FREQ,PF,DCVAL from DED194E_9S1YK2K2";
            //SearchForm frm = new SearchForm(bean.getDataBaseField(), cmd);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            String cmd = @"select CREAT_TIME,VOLTAGE,I,STATE,P,Q,S,FREQ,PF,DCVAL from DED194E_9S1YK2K2 where  DEVICE_GUID ='"+bean.getBeanKey()+"'   ";
            SearchForm frm = new SearchForm(bean.getDataBaseField(), cmd);
            frm.Show();
            frm.Focus();
        }


    }
}
