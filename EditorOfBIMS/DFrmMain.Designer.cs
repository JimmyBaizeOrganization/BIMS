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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DFrmMain));
            this.iLBC_Left = new DevExpress.XtraEditors.ImageListBoxControl();
            this.dLF_Main = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.PanRight = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tb_Open = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.BackgroundButton = new System.Windows.Forms.ToolStripButton();
            this.b_sumbit = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mfolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tb_buildingname = new System.Windows.Forms.TextBox();
            this.tb_floornum = new System.Windows.Forms.TextBox();
            this.bt_selectPath = new System.Windows.Forms.Button();
            this.tb_path = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.iLBC_Left)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iLBC_Left
            // 
            this.iLBC_Left.Location = new System.Drawing.Point(0, 92);
            this.iLBC_Left.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iLBC_Left.Name = "iLBC_Left";
            this.iLBC_Left.Size = new System.Drawing.Size(237, 809);
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
            this.PanRight.Location = new System.Drawing.Point(246, 92);
            this.PanRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanRight.Name = "PanRight";
            this.PanRight.Size = new System.Drawing.Size(1188, 809);
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
            this.tb_Open,
            this.toolStripButton1,
            this.BackgroundButton,
            this.b_sumbit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1434, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tb_Open
            // 
            this.tb_Open.Image = ((System.Drawing.Image)(resources.GetObject("tb_Open.Image")));
            this.tb_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_Open.Name = "tb_Open";
            this.tb_Open.Size = new System.Drawing.Size(74, 28);
            this.tb_Open.Text = "打开";
            this.tb_Open.Click += new System.EventHandler(this.tb_Open_Click);
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
            // b_sumbit
            // 
            this.b_sumbit.Image = ((System.Drawing.Image)(resources.GetObject("b_sumbit.Image")));
            this.b_sumbit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_sumbit.Name = "b_sumbit";
            this.b_sumbit.Size = new System.Drawing.Size(110, 28);
            this.b_sumbit.Text = "保存配置";
            this.b_sumbit.Click += new System.EventHandler(this.b_sumbit_Click);
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
            // mfolderBrowserDialog
            // 
            this.mfolderBrowserDialog.Description = "选择一个配置存储路径";
            // 
            // mopenFileDialog
            // 
            this.mopenFileDialog.FileName = "openFileDialog1";
            // 
            // tb_buildingname
            // 
            this.tb_buildingname.Location = new System.Drawing.Point(159, 48);
            this.tb_buildingname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_buildingname.Name = "tb_buildingname";
            this.tb_buildingname.Size = new System.Drawing.Size(148, 28);
            this.tb_buildingname.TabIndex = 3;
            // 
            // tb_floornum
            // 
            this.tb_floornum.Location = new System.Drawing.Point(513, 51);
            this.tb_floornum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_floornum.Name = "tb_floornum";
            this.tb_floornum.Size = new System.Drawing.Size(148, 28);
            this.tb_floornum.TabIndex = 4;
            // 
            // bt_selectPath
            // 
            this.bt_selectPath.Location = new System.Drawing.Point(1284, 48);
            this.bt_selectPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_selectPath.Name = "bt_selectPath";
            this.bt_selectPath.Size = new System.Drawing.Size(132, 34);
            this.bt_selectPath.TabIndex = 5;
            this.bt_selectPath.Text = "选择生成路径";
            this.bt_selectPath.UseVisualStyleBackColor = true;
            this.bt_selectPath.Click += new System.EventHandler(this.bt_selectPath_Click);
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(866, 48);
            this.tb_path.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(408, 28);
            this.tb_path.TabIndex = 6;
            // 
            // DFrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 899);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.bt_selectPath);
            this.Controls.Add(this.tb_floornum);
            this.Controls.Add(this.tb_buildingname);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PanRight);
            this.Controls.Add(this.iLBC_Left);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DFrmMain";
            this.Text = "DFrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DFrmMain_FormClosing);
            this.Load += new System.EventHandler(this.DFrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DFrmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iLBC_Left)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ImageListBoxControl iLBC_Left;
        private DevExpress.LookAndFeel.DefaultLookAndFeel dLF_Main;
        private System.Windows.Forms.Panel PanRight;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton BackgroundButton;
        private System.Windows.Forms.FolderBrowserDialog mfolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog mopenFileDialog;
        private System.Windows.Forms.ToolStripButton b_sumbit;
        private System.Windows.Forms.TextBox tb_buildingname;
        private System.Windows.Forms.TextBox tb_floornum;
        private System.Windows.Forms.Button bt_selectPath;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.ToolStripButton tb_Open;

    }
}