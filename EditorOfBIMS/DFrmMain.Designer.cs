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
            this.iLBC_Left = new DevExpress.XtraEditors.ImageListBoxControl();
            this.dLF_Main = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.pE_Rigth = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.iLBC_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pE_Rigth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // iLBC_Left
            // 
            this.iLBC_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.iLBC_Left.Location = new System.Drawing.Point(0, 0);
            this.iLBC_Left.Name = "iLBC_Left";
            this.iLBC_Left.Size = new System.Drawing.Size(184, 466);
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
            // pE_Rigth
            // 
            this.pE_Rigth.Dock = System.Windows.Forms.DockStyle.Right;
            this.pE_Rigth.Location = new System.Drawing.Point(202, 0);
            this.pE_Rigth.Name = "pE_Rigth";
            this.pE_Rigth.Size = new System.Drawing.Size(680, 466);
            this.pE_Rigth.TabIndex = 1;
            this.pE_Rigth.DragDrop += new System.Windows.Forms.DragEventHandler(this.pE_Rigth_DragDrop);
            this.pE_Rigth.DragEnter += new System.Windows.Forms.DragEventHandler(this.pE_Rigth_DragEnter);
            this.pE_Rigth.Paint += new System.Windows.Forms.PaintEventHandler(this.pE_Rigth_Paint);
            // 
            // DFrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 466);
            this.Controls.Add(this.pE_Rigth);
            this.Controls.Add(this.iLBC_Left);
            this.Name = "DFrmMain";
            this.Text = "DFrmMain";
            this.Load += new System.EventHandler(this.DFrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iLBC_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pE_Rigth.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ImageListBoxControl iLBC_Left;
        private DevExpress.LookAndFeel.DefaultLookAndFeel dLF_Main;
        private DevExpress.XtraEditors.PictureEdit pE_Rigth;

    }
}