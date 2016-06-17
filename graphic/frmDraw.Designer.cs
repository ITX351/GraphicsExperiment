namespace graphic
{
    partial class frmDraw
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.OperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OperationToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(717, 25);
            this.mnuMain.TabIndex = 0;
            // 
            // OperationToolStripMenuItem
            // 
            this.OperationToolStripMenuItem.Name = "OperationToolStripMenuItem";
            this.OperationToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.OperationToolStripMenuItem.Text = "变换";
            this.OperationToolStripMenuItem.Click += new System.EventHandler(this.OperationToolStripMenuItem_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(648, 25);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(23, 12);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "X: ";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(648, 46);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 12);
            this.lblY.TabIndex = 2;
            this.lblY.Text = "Y:";
            // 
            // frmDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 460);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmDraw";
            this.Text = "Draw";
            this.Load += new System.EventHandler(this.frmDraw_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmDraw_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmDraw_MouseMove);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem OperationToolStripMenuItem;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
    }
}

