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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeFrmMain));
            this.dLFMain = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.cLBC_left = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.cLBC_left)).BeginInit();
            this.SuspendLayout();
            // 
            // dLFMain
            // 
            this.dLFMain.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.dLFMain.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // cLBC_left
            // 
            resources.ApplyResources(this.cLBC_left, "cLBC_left");
            this.cLBC_left.Name = "cLBC_left";
            // 
            // DeFrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cLBC_left);
            this.LookAndFeel.SkinName = "Office 2013";
            this.Name = "DeFrmMain";
            ((System.ComponentModel.ISupportInitialize)(this.cLBC_left)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel dLFMain;
        private DevExpress.XtraEditors.CheckedListBoxControl cLBC_left;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}