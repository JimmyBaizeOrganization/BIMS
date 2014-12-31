namespace EditorOfBIMS
{
    partial class DFrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DFrmMain));
            this.iLBC_Left = new DevExpress.XtraEditors.ImageListBoxControl();
            this.dLF_Main = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.PanRight = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.BackgroundButton = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mfolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.iLBC_Left)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iLBC_Left
            // 
            this.iLBC_Left.Location = new System.Drawing.Point(0, 92);
            this.iLBC_Left.Margin = new System.Windows.Forms.Padding(4);
            this.iLBC_Left.Name = "iLBC_Left";
            this.iLBC_Left.Size = new System.Drawing.Size(237, 507);
            this.iLBC_Left.TabIndex = 0;
            this.iLBC_Left.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.iLBC_Left_DrawItem);
            this.iLBC_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.iLBC_Left_MouseDown);
            this.iLBC_Left.MouseHover += new System.EventHandler(this.iLBC_Left_MouseHover);
            // 
            // dLF_Main
            // 
            this.dLF_Main.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.dLF_Main.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // PanRight
            // 
            this.PanRight.AllowDrop = true;
            this.PanRight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PanRight.Location = new System.Drawing.Point(237, 92);
            this.PanRight.Margin = new System.Windows.Forms.Padding(4);
            this.PanRight.Name = "PanRight";
            this.PanRight.Size = new System.Drawing.Size(897, 507);
            this.PanRight.TabIndex = 1;
            this.PanRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanRight_DragDrop);
            this.PanRight.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanRight_DragEnter);
            this.PanRight.Paint += new System.Windows.Forms.PaintEventHandler(this.PanRight_Paint);
            this.PanRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanRight_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1,
            this.BackgroundButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1134, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(142, 28);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(74, 28);
            this.toolStripButton1.Text = "删除";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // BackgroundButton
            // 
            this.BackgroundButton.Image = ((System.Drawing.Image)(resources.GetObject("BackgroundButton.Image")));
            this.BackgroundButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackgroundButton.Name = "BackgroundButton";
            this.BackgroundButton.Size = new System.Drawing.Size(74, 28);
            this.BackgroundButton.Text = "背景";
            this.BackgroundButton.Click += new System.EventHandler(this.BackgroundButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(503, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 32);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // mopenFileDialog
            // 
            this.mopenFileDialog.FileName = "openFileDialog1";
            // 
            // DFrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 599);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PanRight);
            this.Controls.Add(this.iLBC_Left);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DFrmMain";
            this.Text = "DFrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DFrmMain_FormClosing);
            this.Load += new System.EventHandler(this.DFrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DFrmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iLBC_Left)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ImageListBoxControl iLBC_Left;
        private DevExpress.LookAndFeel.DefaultLookAndFeel dLF_Main;
        private System.Windows.Forms.Panel PanRight;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton BackgroundButton;
        private System.Windows.Forms.FolderBrowserDialog mfolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog mopenFileDialog;

    }
}