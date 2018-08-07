namespace RelativeShortcut
{
	partial class OptionShellForm
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
			this.AddShellBtn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.DelShellBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// AddShellBtn
			// 
			this.AddShellBtn.Location = new System.Drawing.Point(6, 18);
			this.AddShellBtn.Name = "AddShellBtn";
			this.AddShellBtn.Size = new System.Drawing.Size(139, 23);
			this.AddShellBtn.TabIndex = 0;
			this.AddShellBtn.Text = "シェル統合";
			this.AddShellBtn.UseVisualStyleBackColor = true;
			this.AddShellBtn.Click += new System.EventHandler(this.AddShellBtn_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.DelShellBtn);
			this.groupBox1.Controls.Add(this.AddShellBtn);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(177, 105);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "シェル統合";
			// 
			// DelShellBtn
			// 
			this.DelShellBtn.Location = new System.Drawing.Point(6, 47);
			this.DelShellBtn.Name = "DelShellBtn";
			this.DelShellBtn.Size = new System.Drawing.Size(139, 23);
			this.DelShellBtn.TabIndex = 1;
			this.DelShellBtn.Text = "シェル統合　解除";
			this.DelShellBtn.UseVisualStyleBackColor = true;
			this.DelShellBtn.Click += new System.EventHandler(this.DelShellBtn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(151, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "※この項目は即反映されます。";
			// 
			// OptionShellForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 361);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "OptionShellForm";
			this.Text = "シェル統合";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button AddShellBtn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button DelShellBtn;
		private System.Windows.Forms.Label label1;
	}
}