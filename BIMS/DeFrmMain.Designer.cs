namespace BIMS
{
    partial class DeFrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeFrmMain));
            this.dLFMain = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mpanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button_Home = new System.Windows.Forms.PictureBox();
            this.Button_Maintenance = new System.Windows.Forms.PictureBox();
            this.Button_Sum = new System.Windows.Forms.PictureBox();
            this.Button_Help = new System.Windows.Forms.PictureBox();
            this.Button_Locked = new System.Windows.Forms.PictureBox();
            this.Button_Close = new System.Windows.Forms.PictureBox();
            this.Button_Setting = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.VScroll_self = new System.Windows.Forms.PictureBox();
            this.VScroll_main = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Maintenance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Sum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Locked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VScroll_self)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VScroll_main)).BeginInit();
            this.SuspendLayout();
            // 
            // dLFMain
            // 
            this.dLFMain.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.dLFMain.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // mpanel
            // 
            resources.ApplyResources(this.mpanel, "mpanel");
            this.mpanel.BackColor = System.Drawing.Color.White;
            this.mpanel.Name = "mpanel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::BIMS.Properties.Resources.banner_png;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Button_Home
            // 
            this.Button_Home.BackColor = System.Drawing.Color.Transparent;
            this.Button_Home.BackgroundImage = global::BIMS.Properties.Resources.button1_;
            resources.ApplyResources(this.Button_Home, "Button_Home");
            this.Button_Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Home.Name = "Button_Home";
            this.Button_Home.TabStop = false;
            this.Button_Home.Click += new System.EventHandler(this.Button_Home_Click);
            this.Button_Home.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Home_MouseDown);
            this.Button_Home.MouseEnter += new System.EventHandler(this.Button_Home_MouseEnter);
            this.Button_Home.MouseLeave += new System.EventHandler(this.Button_Home_MouseLeave);
            this.Button_Home.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Home_MouseUp);
            // 
            // Button_Maintenance
            // 
            this.Button_Maintenance.BackColor = System.Drawing.Color.Transparent;
            this.Button_Maintenance.BackgroundImage = global::BIMS.Properties.Resources.button3_;
            resources.ApplyResources(this.Button_Maintenance, "Button_Maintenance");
            this.Button_Maintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Maintenance.Name = "Button_Maintenance";
            this.Button_Maintenance.TabStop = false;
            this.Button_Maintenance.Click += new System.EventHandler(this.Button_Maintenance_Click);
            this.Button_Maintenance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Maintenance_MouseDown);
            this.Button_Maintenance.MouseEnter += new System.EventHandler(this.Button_Maintenance_MouseEnter);
            this.Button_Maintenance.MouseLeave += new System.EventHandler(this.Button_Maintenance_MouseLeave);
            this.Button_Maintenance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Maintenance_MouseUp);
            // 
            // Button_Sum
            // 
            this.Button_Sum.BackColor = System.Drawing.Color.Transparent;
            this.Button_Sum.BackgroundImage = global::BIMS.Properties.Resources.button4_;
            resources.ApplyResources(this.Button_Sum, "Button_Sum");
            this.Button_Sum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Sum.Name = "Button_Sum";
            this.Button_Sum.TabStop = false;
            this.Button_Sum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Button_Sum_MouseClick);
            this.Button_Sum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Sum_MouseDown);
            this.Button_Sum.MouseEnter += new System.EventHandler(this.Button_Sum_MouseEnter);
            this.Button_Sum.MouseLeave += new System.EventHandler(this.Button_Sum_MouseLeave);
            this.Button_Sum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Sum_MouseUp);
            // 
            // Button_Help
            // 
            this.Button_Help.BackColor = System.Drawing.Color.Transparent;
            this.Button_Help.BackgroundImage = global::BIMS.Properties.Resources.button5_;
            resources.ApplyResources(this.Button_Help, "Button_Help");
            this.Button_Help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Help.Name = "Button_Help";
            this.Button_Help.TabStop = false;
            this.Button_Help.Click += new System.EventHandler(this.Button_Help_Click);
            this.Button_Help.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Help_MouseDown);
            this.Button_Help.MouseEnter += new System.EventHandler(this.Button_Help_MouseEnter);
            this.Button_Help.MouseLeave += new System.EventHandler(this.Button_Help_MouseLeave);
            this.Button_Help.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Help_MouseUp);
            // 
            // Button_Locked
            // 
            this.Button_Locked.BackColor = System.Drawing.Color.Transparent;
            this.Button_Locked.BackgroundImage = global::BIMS.Properties.Resources.button6_;
            resources.ApplyResources(this.Button_Locked, "Button_Locked");
            this.Button_Locked.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Locked.Name = "Button_Locked";
            this.Button_Locked.TabStop = false;
            this.Button_Locked.Click += new System.EventHandler(this.Button_Locked_Click);
            this.Button_Locked.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Locked_MouseDown);
            this.Button_Locked.MouseEnter += new System.EventHandler(this.Button_Locked_MouseEnter);
            this.Button_Locked.MouseLeave += new System.EventHandler(this.Button_Locked_MouseLeave);
            this.Button_Locked.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Locked_MouseUp);
            // 
            // Button_Close
            // 
            this.Button_Close.BackColor = System.Drawing.Color.Transparent;
            this.Button_Close.BackgroundImage = global::BIMS.Properties.Resources.button7_;
            resources.ApplyResources(this.Button_Close, "Button_Close");
            this.Button_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.TabStop = false;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            this.Button_Close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Close_MouseDown);
            this.Button_Close.MouseEnter += new System.EventHandler(this.Button_Close_MouseEnter);
            this.Button_Close.MouseLeave += new System.EventHandler(this.Button_Close_MouseLeave);
            this.Button_Close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Close_MouseUp);
            // 
            // Button_Setting
            // 
            this.Button_Setting.BackColor = System.Drawing.Color.Transparent;
            this.Button_Setting.BackgroundImage = global::BIMS.Properties.Resources.button2_;
            resources.ApplyResources(this.Button_Setting, "Button_Setting");
            this.Button_Setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Setting.Name = "Button_Setting";
            this.Button_Setting.TabStop = false;
            this.Button_Setting.Click += new System.EventHandler(this.Button_Setting_Click);
            this.Button_Setting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Setting_MouseDown);
            this.Button_Setting.MouseEnter += new System.EventHandler(this.Button_Setting_MouseEnter);
            this.Button_Setting.MouseLeave += new System.EventHandler(this.Button_Setting_MouseLeave);
            this.Button_Setting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Setting_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::BIMS.Properties.Resources.user_self_;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImage = global::BIMS.Properties.Resources.background;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.BackgroundImage = global::BIMS.Properties.Resources.导航条;
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // VScroll_self
            // 
            this.VScroll_self.BackColor = System.Drawing.Color.White;
            this.VScroll_self.BackgroundImage = global::BIMS.Properties.Resources.scroll_bar_self_;
            resources.ApplyResources(this.VScroll_self, "VScroll_self");
            this.VScroll_self.Name = "VScroll_self";
            this.VScroll_self.TabStop = false;
            // 
            // VScroll_main
            // 
            this.VScroll_main.BackColor = System.Drawing.Color.White;
            this.VScroll_main.BackgroundImage = global::BIMS.Properties.Resources.scroll_bar_main_;
            resources.ApplyResources(this.VScroll_main, "VScroll_main");
            this.VScroll_main.Name = "VScroll_main";
            this.VScroll_main.TabStop = false;
            this.VScroll_main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VScroll_main_MouseDown);
            this.VScroll_main.MouseEnter += new System.EventHandler(this.VScroll_main_MouseEnter);
            this.VScroll_main.MouseLeave += new System.EventHandler(this.VScroll_main_MouseLeave);
            this.VScroll_main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VScroll_main_MouseMove);
            // 
            // DeFrmMain
            // 
            this.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("DeFrmMain.Appearance.BackColor")));
            this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.VScroll_main);
            this.Controls.Add(this.VScroll_self);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.Button_Setting);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Button_Locked);
            this.Controls.Add(this.Button_Help);
            this.Controls.Add(this.Button_Sum);
            this.Controls.Add(this.Button_Maintenance);
            this.Controls.Add(this.Button_Home);
            this.Controls.Add(this.mpanel);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Office 2013";
            this.Name = "DeFrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DeFrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Maintenance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Sum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Locked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VScroll_self)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VScroll_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel dLFMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel mpanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Button_Home;
        private System.Windows.Forms.PictureBox Button_Maintenance;
        private System.Windows.Forms.PictureBox Button_Sum;
        private System.Windows.Forms.PictureBox Button_Help;
        private System.Windows.Forms.PictureBox Button_Locked;
        private System.Windows.Forms.PictureBox Button_Close;
        private System.Windows.Forms.PictureBox Button_Setting;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox VScroll_self;
        private System.Windows.Forms.PictureBox VScroll_main;
    }
}