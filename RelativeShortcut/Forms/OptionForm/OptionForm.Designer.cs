namespace RelativeShortcut
{
	partial class OptionForm
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
			if( disposing && (components != null) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.OptionTreeView = new System.Windows.Forms.TreeView();
			this.NOBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.OptionTreeView);
			this.splitContainer1.Size = new System.Drawing.Size(584, 427);
			this.splitContainer1.SplitterDistance = 171;
			this.splitContainer1.TabIndex = 0;
			// 
			// OptionTreeView
			// 
			this.OptionTreeView.Location = new System.Drawing.Point(12, 12);
			this.OptionTreeView.Name = "OptionTreeView";
			this.OptionTreeView.Size = new System.Drawing.Size(156, 412);
			this.OptionTreeView.TabIndex = 0;
			this.OptionTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OptionTreeView1_AfterSelect);
			// 
			// NOBtn
			// 
			this.NOBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.NOBtn.Location = new System.Drawing.Point(497, 457);
			this.NOBtn.Name = "NOBtn";
			this.NOBtn.Size = new System.Drawing.Size(75, 23);
			this.NOBtn.TabIndex = 1;
			this.NOBtn.Text = "キャンセル";
			this.NOBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.Location = new System.Drawing.Point(416, 457);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 2;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// OptionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 492);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.NOBtn);
			this.Controls.Add(this.splitContainer1);
			this.Name = "OptionForm";
			this.Text = "オプション";
			this.Load += new System.EventHandler(this.OptionForm_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView OptionTreeView;
		private System.Windows.Forms.Button NOBtn;
		private System.Windows.Forms.Button OKBtn;
	}
}