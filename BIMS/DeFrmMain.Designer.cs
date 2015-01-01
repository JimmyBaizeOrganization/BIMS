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
            this.cLBC_left = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mpanel = new System.Windows.Forms.Panel();
            this.mtableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button_Home = new System.Windows.Forms.PictureBox();
            this.Button_Document = new System.Windows.Forms.PictureBox();
            this.Button_Sum = new System.Windows.Forms.PictureBox();
            this.Button_Help = new System.Windows.Forms.PictureBox();
            this.Button_Locked = new System.Windows.Forms.PictureBox();
            this.Button_Close = new System.Windows.Forms.PictureBox();
            this.Button_Setting = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cLBC_left)).BeginInit();
            this.mpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Document)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Sum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Locked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Setting)).BeginInit();
            this.SuspendLayout();
            // 
            // dLFMain
            // 
            this.dLFMain.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.dLFMain.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // cLBC_left
            // 
            this.cLBC_left.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("cLBC_left.Appearance.BackColor")));
            this.cLBC_left.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.cLBC_left, "cLBC_left");
            this.cLBC_left.Name = "cLBC_left";
            this.cLBC_left.SelectedIndexChanged += new System.EventHandler(this.cLBC_left_SelectedIndexChanged);
            // 
            // mpanel
            // 
            this.mpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.mpanel.Controls.Add(this.mtableLayoutPanel);
            resources.ApplyResources(this.mpanel, "mpanel");
            this.mpanel.Name = "mpanel";
            this.mpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mpanel_Paint);
            // 
            // mtableLayoutPanel
            // 
            resources.ApplyResources(this.mtableLayoutPanel, "mtableLayoutPanel");
            this.mtableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mtableLayoutPanel.Name = "mtableLayoutPanel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Button_Home
            // 
            this.Button_Home.BackColor = System.Drawing.Color.Transparent;
            this.Button_Home.BackgroundImage = global::BIMS.Properties.Resources.coin__1_;
            resources.ApplyResources(this.Button_Home, "Button_Home");
            this.Button_Home.Name = "Button_Home";
            this.Button_Home.TabStop = false;
            this.Button_Home.Click += new System.EventHandler(this.Button_Home_Click);
            // 
            // Button_Document
            // 
            this.Button_Document.BackColor = System.Drawing.Color.Transparent;
            this.Button_Document.BackgroundImage = global::BIMS.Properties.Resources.coin__2_;
            resources.ApplyResources(this.Button_Document, "Button_Document");
            this.Button_Document.Name = "Button_Document";
            this.Button_Document.TabStop = false;
            // 
            // Button_Sum
            // 
            this.Button_Sum.BackColor = System.Drawing.Color.Transparent;
            this.Button_Sum.BackgroundImage = global::BIMS.Properties.Resources.coin__3_;
            resources.ApplyResources(this.Button_Sum, "Button_Sum");
            this.Button_Sum.Name = "Button_Sum";
            this.Button_Sum.TabStop = false;
            // 
            // Button_Help
            // 
            this.Button_Help.BackColor = System.Drawing.Color.Transparent;
            this.Button_Help.BackgroundImage = global::BIMS.Properties.Resources.coin__4_;
            resources.ApplyResources(this.Button_Help, "Button_Help");
            this.Button_Help.Name = "Button_Help";
            this.Button_Help.TabStop = false;
            this.Button_Help.Click += new System.EventHandler(this.Button_Help_Click);
            // 
            // Button_Locked
            // 
            this.Button_Locked.BackColor = System.Drawing.Color.Transparent;
            this.Button_Locked.BackgroundImage = global::BIMS.Properties.Resources.coin__5_;
            resources.ApplyResources(this.Button_Locked, "Button_Locked");
            this.Button_Locked.Name = "Button_Locked";
            this.Button_Locked.TabStop = false;
            // 
            // Button_Close
            // 
            this.Button_Close.BackColor = System.Drawing.Color.Transparent;
            this.Button_Close.BackgroundImage = global::BIMS.Properties.Resources.coin__6_;
            resources.ApplyResources(this.Button_Close, "Button_Close");
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.TabStop = false;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // Button_Setting
            // 
            this.Button_Setting.BackColor = System.Drawing.Color.Transparent;
            this.Button_Setting.BackgroundImage = global::BIMS.Properties.Resources.coin__7_;
            resources.ApplyResources(this.Button_Setting, "Button_Setting");
            this.Button_Setting.Name = "Button_Setting";
            this.Button_Setting.TabStop = false;
            // 
            // DeFrmMain
            // 
            this.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("DeFrmMain.Appearance.BackColor")));
            this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.Button_Setting);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Button_Locked);
            this.Controls.Add(this.Button_Help);
            this.Controls.Add(this.Button_Sum);
            this.Controls.Add(this.Button_Document);
            this.Controls.Add(this.Button_Home);
            this.Controls.Add(this.mpanel);
            this.Controls.Add(this.cLBC_left);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Office 2013";
            this.Name = "DeFrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DeFrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cLBC_left)).EndInit();
            this.mpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Document)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Sum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Locked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Setting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel dLFMain;
        private DevExpress.XtraEditors.CheckedListBoxControl cLBC_left;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel mpanel;
        private System.Windows.Forms.TableLayoutPanel mtableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Button_Home;
        private System.Windows.Forms.PictureBox Button_Document;
        private System.Windows.Forms.PictureBox Button_Sum;
        private System.Windows.Forms.PictureBox Button_Help;
        private System.Windows.Forms.PictureBox Button_Locked;
        private System.Windows.Forms.PictureBox Button_Close;
        private System.Windows.Forms.PictureBox Button_Setting;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}