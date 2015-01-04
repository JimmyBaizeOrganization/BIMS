using Oracle.DataAccess.Client;
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


        private OracleDataReader mOracleDataReader;
        public Frm_DED194E_9S1YK2K2(OracleDataReader od)
        {
            InitializeComponent();
            mOracleDataReader = od;

            textBox_V.DataBindings.Add("Text", mOracleDataReader, "VOLTAGE");
        }


    }
}
