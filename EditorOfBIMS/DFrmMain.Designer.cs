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
            this.PanRight = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.iLBC_Left)).BeginInit();
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
            // PanRight
            // 
            this.PanRight.AllowDrop = true;
            this.PanRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanRight.Location = new System.Drawing.Point(184, 0);
            this.PanRight.Name = "PanRight";
            this.PanRight.Size = new System.Drawing.Size(698, 466);
            this.PanRight.TabIndex = 1;
            this.PanRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanRight_DragDrop);
            this.PanRight.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanRight_DragEnter);
            // 
            // DFrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 466);
            this.Controls.Add(this.PanRight);
            this.Controls.Add(this.iLBC_Left);
            this.Name = "DFrmMain";
            this.Text = "DFrmMain";
            this.Load += new System.EventHandler(this.DFrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iLBC_Left)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ImageListBoxControl iLBC_Left;
        private DevExpress.LookAndFeel.DefaultLookAndFeel dLF_Main;
        private System.Windows.Forms.Panel PanRight;

    }
}