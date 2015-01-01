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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cLBC_left)).BeginInit();
            this.mpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.mtableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mtableLayoutPanel.Name = "mtableLayoutPanel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // DeFrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.mpanel);
            this.Controls.Add(this.cLBC_left);
            this.Controls.Add(this.pictureBox1);
            this.LookAndFeel.SkinName = "Office 2013";
            this.Name = "DeFrmMain";
            this.Load += new System.EventHandler(this.DeFrmMain_Load);
            this.Resize += new System.EventHandler(this.DeFrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.cLBC_left)).EndInit();
            this.mpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel dLFMain;
        private DevExpress.XtraEditors.CheckedListBoxControl cLBC_left;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel mpanel;
        private System.Windows.Forms.TableLayoutPanel mtableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}