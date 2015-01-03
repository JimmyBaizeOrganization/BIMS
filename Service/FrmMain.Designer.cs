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
            this.mdataGridView = new System.Windows.Forms.DataGridView();
            this.buildingNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floorNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devicType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.during = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.textBox_building = new System.Windows.Forms.TextBox();
            this.label_building = new System.Windows.Forms.Label();
            this.textBox_floor = new System.Windows.Forms.TextBox();
            this.label_floor = new System.Windows.Forms.Label();
            this.textBox_deviceNum = new System.Windows.Forms.TextBox();
            this.label_deviceNum = new System.Windows.Forms.Label();
            this.textBox_type = new System.Windows.Forms.TextBox();
            this.label_type = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mopenFileDialog
            // 
            this.mopenFileDialog.FileName = "openFileDialog";
            // 
            // bt_OpenFile
            // 
            this.bt_OpenFile.Location = new System.Drawing.Point(891, 13);
            this.bt_OpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.bt_OpenFile.Name = "bt_OpenFile";
            this.bt_OpenFile.Size = new System.Drawing.Size(112, 34);
            this.bt_OpenFile.TabIndex = 0;
            this.bt_OpenFile.Text = "打开文件";
            this.bt_OpenFile.UseVisualStyleBackColor = true;
            this.bt_OpenFile.Click += new System.EventHandler(this.bt_OpenFile_Click);
            // 
            // mdataGridView
            // 
            this.mdataGridView.AllowUserToOrderColumns = true;
            this.mdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buildingNum,
            this.floorNum,
            this.deviceNum,
            this.devicType,
            this.ip,
            this.port,
            this.during});
            this.mdataGridView.Location = new System.Drawing.Point(379, 87);
            this.mdataGridView.Name = "mdataGridView";
            this.mdataGridView.RowTemplate.Height = 30;
            this.mdataGridView.Size = new System.Drawing.Size(799, 521);
            this.mdataGridView.TabIndex = 1;
            // 
            // buildingNum
            // 
            this.buildingNum.HeaderText = "楼号";
            this.buildingNum.Name = "buildingNum";
            // 
            // floorNum
            // 
            this.floorNum.HeaderText = "楼层号";
            this.floorNum.Name = "floorNum";
            // 
            // deviceNum
            // 
            this.deviceNum.HeaderText = "设备号";
            this.deviceNum.Name = "deviceNum";
            // 
            // devicType
            // 
            this.devicType.HeaderText = "设备型号";
            this.devicType.Name = "devicType";
            // 
            // ip
            // 
            this.ip.HeaderText = "ip号";
            this.ip.Name = "ip";
            // 
            // port
            // 
            this.port.HeaderText = "端口号";
            this.port.Name = "port";
            // 
            // during
            // 
            this.during.HeaderText = "采集间隔";
            this.during.Name = "during";
            // 
            // mcheckedListBox
            // 
            this.mcheckedListBox.FormattingEnabled = true;
            this.mcheckedListBox.Items.AddRange(new object[] {
            "楼号",
            "楼层号",
            "设备号",
            "设备型号"});
            this.mcheckedListBox.Location = new System.Drawing.Point(56, 69);
            this.mcheckedListBox.Name = "mcheckedListBox";
            this.mcheckedListBox.Size = new System.Drawing.Size(237, 142);
            this.mcheckedListBox.TabIndex = 2;
            // 
            // textBox_building
            // 
            this.textBox_building.Location = new System.Drawing.Point(193, 271);
            this.textBox_building.Name = "textBox_building";
            this.textBox_building.Size = new System.Drawing.Size(100, 28);
            this.textBox_building.TabIndex = 3;
            // 
            // label_building
            // 
            this.label_building.AutoSize = true;
            this.label_building.Location = new System.Drawing.Point(77, 274);
            this.label_building.Name = "label_building";
            this.label_building.Size = new System.Drawing.Size(44, 18);
            this.label_building.TabIndex = 4;
            this.label_building.Text = "楼号";
            // 
            // textBox_floor
            // 
            this.textBox_floor.Location = new System.Drawing.Point(193, 331);
            this.textBox_floor.Name = "textBox_floor";
            this.textBox_floor.Size = new System.Drawing.Size(100, 28);
            this.textBox_floor.TabIndex = 3;
            // 
            // label_floor
            // 
            this.label_floor.AutoSize = true;
            this.label_floor.Location = new System.Drawing.Point(77, 334);
            this.label_floor.Name = "label_floor";
            this.label_floor.Size = new System.Drawing.Size(62, 18);
            this.label_floor.TabIndex = 4;
            this.label_floor.Text = "楼层号";
            // 
            // textBox_deviceNum
            // 
            this.textBox_deviceNum.Location = new System.Drawing.Point(193, 380);
            this.textBox_deviceNum.Name = "textBox_deviceNum";
            this.textBox_deviceNum.Size = new System.Drawing.Size(100, 28);
            this.textBox_deviceNum.TabIndex = 3;
            // 
            // label_deviceNum
            // 
            this.label_deviceNum.AutoSize = true;
            this.label_deviceNum.Location = new System.Drawing.Point(77, 383);
            this.label_deviceNum.Name = "label_deviceNum";
            this.label_deviceNum.Size = new System.Drawing.Size(62, 18);
            this.label_deviceNum.TabIndex = 4;
            this.label_deviceNum.Text = "设备号";
            // 
            // textBox_type
            // 
            this.textBox_type.Location = new System.Drawing.Point(193, 433);
            this.textBox_type.Name = "textBox_type";
            this.textBox_type.Size = new System.Drawing.Size(100, 28);
            this.textBox_type.TabIndex = 3;
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(77, 436);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(80, 18);
            this.label_type.TabIndex = 4;
            this.label_type.Text = "设备型号";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 521);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "筛选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 521);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 46);
            this.button2.TabIndex = 5;
            this.button2.Text = "全部";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 699);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.label_deviceNum);
            this.Controls.Add(this.label_floor);
            this.Controls.Add(this.label_building);
            this.Controls.Add(this.textBox_type);
            this.Controls.Add(this.textBox_deviceNum);
            this.Controls.Add(this.textBox_floor);
            this.Controls.Add(this.textBox_building);
            this.Controls.Add(this.mcheckedListBox);
            this.Controls.Add(this.mdataGridView);
            this.Controls.Add(this.bt_OpenFile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog mopenFileDialog;
        private System.Windows.Forms.Button bt_OpenFile;
        private System.Windows.Forms.DataGridView mdataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn floorNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn devicType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn port;
        private System.Windows.Forms.DataGridViewTextBoxColumn during;
        private System.Windows.Forms.CheckedListBox mcheckedListBox;
        private System.Windows.Forms.TextBox textBox_building;
        private System.Windows.Forms.Label label_building;
        private System.Windows.Forms.TextBox textBox_floor;
        private System.Windows.Forms.Label label_floor;
        private System.Windows.Forms.TextBox textBox_deviceNum;
        private System.Windows.Forms.Label label_deviceNum;
        private System.Windows.Forms.TextBox textBox_type;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;


    }
}

