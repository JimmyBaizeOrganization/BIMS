﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorOfBIMS
{
    public class BaseDevice : PictureBox
    {
        private Point mouse_offset = new Point();
        private Panel mPanel;
        private ContextMenuStrip mContextMenuStrip;

        public Panel MPanel
        {
            get { return mPanel; }
            set { mPanel = value; }
        }
        public BaseDevice()
            : base()
        {
            mContextMenuStrip = new ContextMenuStrip();
            mContextMenuStrip.Items.Add("删除");
            this.ContextMenuStrip = mContextMenuStrip;

            this.MouseMove += new MouseEventHandler(Common_MouseMove);
            this.MouseDown += new MouseEventHandler(Common_MouseDown);
            this.MouseClick += new MouseEventHandler(Common_MouseClick);
            this.mContextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(Common_CancelClick);

        }
        private void Common_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                control.Left = control.Left + e.X - mouse_offset.X;
                control.Top = control.Top + e.Y - mouse_offset.Y;

            }
        }
        private void Common_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(e.X, e.Y);
        }

        private void Common_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Control)
            {
                foreach (PictureBox c in mPanel.Controls)
                {
                    c.BorderStyle = BorderStyle.None;
                }
            }

            BorderStyle = BorderStyle.FixedSingle;
        }

        private void Common_CancelClick(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
    }
    public class ElectricityGauge : BaseDevice
    {
        public ElectricityGauge()
        {

        }

    }
}
