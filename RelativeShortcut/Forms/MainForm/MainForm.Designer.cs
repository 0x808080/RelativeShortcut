namespace RelativeShortcut
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if( disposing && (components != null) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ツールTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OptionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.SysBtn = new System.Windows.Forms.Button();
			this.InfoBtn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.WarningBtn = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.StripStatusCPU = new System.Windows.Forms.ToolStripStatusLabel();
			this.StripProgressCPU = new System.Windows.Forms.ToolStripProgressBar();
			this.StripStatusMemory = new System.Windows.Forms.ToolStripStatusLabel();
			this.StripProgressMemory = new System.Windows.Forms.ToolStripProgressBar();
			this.StripStatusHDD = new System.Windows.Forms.ToolStripStatusLabel();
			this.StripProgressHDD = new System.Windows.Forms.ToolStripProgressBar();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.ツールTToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1280, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ファイルFToolStripMenuItem
			// 
			this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitStripMenuItem});
			this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
			this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
			// 
			// ExitStripMenuItem
			// 
			this.ExitStripMenuItem.Name = "ExitStripMenuItem";
			this.ExitStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.ExitStripMenuItem.Text = "終了(&Q)";
			this.ExitStripMenuItem.Click += new System.EventHandler(this.ExitStripMenuItem_Click);
			// 
			// ツールTToolStripMenuItem
			// 
			this.ツールTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionStripMenuItem});
			this.ツールTToolStripMenuItem.Name = "ツールTToolStripMenuItem";
			this.ツールTToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.ツールTToolStripMenuItem.Text = "編集(&E)";
			// 
			// OptionStripMenuItem
			// 
			this.OptionStripMenuItem.Name = "OptionStripMenuItem";
			this.OptionStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.OptionStripMenuItem.Text = "設定&O";
			this.OptionStripMenuItem.Click += new System.EventHandler(this.OptionToolStripMenuItem_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(143, 93);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Size = new System.Drawing.Size(1125, 602);
			this.splitContainer1.SplitterDistance = 846;
			this.splitContainer1.TabIndex = 3;
			// 
			// SysBtn
			// 
			this.SysBtn.BackColor = System.Drawing.SystemColors.Control;
			this.SysBtn.Location = new System.Drawing.Point(7, 18);
			this.SysBtn.Name = "SysBtn";
			this.SysBtn.Size = new System.Drawing.Size(119, 80);
			this.SysBtn.TabIndex = 4;
			this.SysBtn.Text = "システム";
			this.SysBtn.UseVisualStyleBackColor = false;
			this.SysBtn.Click += new System.EventHandler(this.SysBtn_Click);
			// 
			// InfoBtn
			// 
			this.InfoBtn.BackColor = System.Drawing.SystemColors.Control;
			this.InfoBtn.Location = new System.Drawing.Point(7, 104);
			this.InfoBtn.Name = "InfoBtn";
			this.InfoBtn.Size = new System.Drawing.Size(119, 80);
			this.InfoBtn.TabIndex = 4;
			this.InfoBtn.Text = "情報";
			this.InfoBtn.UseVisualStyleBackColor = false;
			this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.WarningBtn);
			this.groupBox1.Controls.Add(this.InfoBtn);
			this.groupBox1.Controls.Add(this.SysBtn);
			this.groupBox1.Location = new System.Drawing.Point(5, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(132, 668);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// WarningBtn
			// 
			this.WarningBtn.BackColor = System.Drawing.SystemColors.Control;
			this.WarningBtn.Location = new System.Drawing.Point(7, 190);
			this.WarningBtn.Name = "WarningBtn";
			this.WarningBtn.Size = new System.Drawing.Size(119, 80);
			this.WarningBtn.TabIndex = 4;
			this.WarningBtn.Text = "異常";
			this.WarningBtn.UseVisualStyleBackColor = false;
			this.WarningBtn.Click += new System.EventHandler(this.WarningBtn_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatusLabel1,
            this.StripStatusCPU,
            this.StripProgressCPU,
            this.StripStatusMemory,
            this.StripProgressMemory,
            this.StripStatusHDD,
            this.StripProgressHDD});
			this.statusStrip1.Location = new System.Drawing.Point(0, 698);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1280, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StripStatusLabel1
			// 
			this.StripStatusLabel1.AutoSize = false;
			this.StripStatusLabel1.Name = "StripStatusLabel1";
			this.StripStatusLabel1.Size = new System.Drawing.Size(120, 17);
			this.StripStatusLabel1.Text = "通信状態：未接続";
			// 
			// StripStatusCPU
			// 
			this.StripStatusCPU.Name = "StripStatusCPU";
			this.StripStatusCPU.Size = new System.Drawing.Size(77, 17);
			this.StripStatusCPU.Text = "　CPU使用率";
			// 
			// StripProgressCPU
			// 
			this.StripProgressCPU.Name = "StripProgressCPU";
			this.StripProgressCPU.Size = new System.Drawing.Size(100, 16);
			// 
			// StripStatusMemory
			// 
			this.StripStatusMemory.Name = "StripStatusMemory";
			this.StripStatusMemory.Size = new System.Drawing.Size(112, 17);
			this.StripStatusMemory.Text = "　メモリ使用量XXMB";
			// 
			// StripProgressMemory
			// 
			this.StripProgressMemory.Name = "StripProgressMemory";
			this.StripProgressMemory.Size = new System.Drawing.Size(100, 16);
			// 
			// StripStatusHDD
			// 
			this.StripStatusHDD.Name = "StripStatusHDD";
			this.StripStatusHDD.Size = new System.Drawing.Size(80, 17);
			this.StripStatusHDD.Text = "　HDD使用率";
			// 
			// StripProgressHDD
			// 
			this.StripProgressHDD.Name = "StripProgressHDD";
			this.StripProgressHDD.Size = new System.Drawing.Size(100, 16);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 720);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "0000";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ツールTToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OptionStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button SysBtn;
		private System.Windows.Forms.Button InfoBtn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button WarningBtn;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel StripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem ExitStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel StripStatusCPU;
		private System.Windows.Forms.ToolStripProgressBar StripProgressCPU;
		private System.Windows.Forms.ToolStripStatusLabel StripStatusMemory;
		private System.Windows.Forms.ToolStripProgressBar StripProgressMemory;
		private System.Windows.Forms.ToolStripStatusLabel StripStatusHDD;
		private System.Windows.Forms.ToolStripProgressBar StripProgressHDD;
	}
}

