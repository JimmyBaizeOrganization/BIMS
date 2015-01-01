namespace Service
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bt_OpenFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mopenFileDialog
            // 
            this.mopenFileDialog.FileName = "openFileDialog";
            // 
            // bt_OpenFile
            // 
            this.bt_OpenFile.Location = new System.Drawing.Point(138, 56);
            this.bt_OpenFile.Name = "bt_OpenFile";
            this.bt_OpenFile.Size = new System.Drawing.Size(75, 23);
            this.bt_OpenFile.TabIndex = 0;
            this.bt_OpenFile.Text = "打开文件";
            this.bt_OpenFile.UseVisualStyleBackColor = true;
            this.bt_OpenFile.Click += new System.EventHandler(this.bt_OpenFile_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 466);
            this.Controls.Add(this.bt_OpenFile);
            this.Name = "Frm_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog mopenFileDialog;
        private System.Windows.Forms.Button bt_OpenFile;


    }
}

