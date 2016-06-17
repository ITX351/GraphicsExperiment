namespace graphic
{
    partial class frmOperation
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
            this.rdbX = new System.Windows.Forms.RadioButton();
            this.rdbY = new System.Windows.Forms.RadioButton();
            this.rdbO = new System.Windows.Forms.RadioButton();
            this.rdbMove = new System.Windows.Forms.RadioButton();
            this.rdbRotate = new System.Windows.Forms.RadioButton();
            this.rdbRatio = new System.Windows.Forms.RadioButton();
            this.txtMoveX = new System.Windows.Forms.TextBox();
            this.txtMoveY = new System.Windows.Forms.TextBox();
            this.txtRotate = new System.Windows.Forms.TextBox();
            this.txtRatioX = new System.Windows.Forms.TextBox();
            this.txtRatioY = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbX
            // 
            this.rdbX.AutoSize = true;
            this.rdbX.Location = new System.Drawing.Point(12, 12);
            this.rdbX.Name = "rdbX";
            this.rdbX.Size = new System.Drawing.Size(65, 16);
            this.rdbX.TabIndex = 0;
            this.rdbX.TabStop = true;
            this.rdbX.Text = "X轴对称";
            this.rdbX.UseVisualStyleBackColor = true;
            // 
            // rdbY
            // 
            this.rdbY.AutoSize = true;
            this.rdbY.Location = new System.Drawing.Point(12, 43);
            this.rdbY.Name = "rdbY";
            this.rdbY.Size = new System.Drawing.Size(65, 16);
            this.rdbY.TabIndex = 1;
            this.rdbY.TabStop = true;
            this.rdbY.Text = "Y轴对称";
            this.rdbY.UseVisualStyleBackColor = true;
            // 
            // rdbO
            // 
            this.rdbO.AutoSize = true;
            this.rdbO.Location = new System.Drawing.Point(12, 74);
            this.rdbO.Name = "rdbO";
            this.rdbO.Size = new System.Drawing.Size(71, 16);
            this.rdbO.TabIndex = 2;
            this.rdbO.TabStop = true;
            this.rdbO.Text = "原点对称";
            this.rdbO.UseVisualStyleBackColor = true;
            // 
            // rdbMove
            // 
            this.rdbMove.AutoSize = true;
            this.rdbMove.Location = new System.Drawing.Point(12, 105);
            this.rdbMove.Name = "rdbMove";
            this.rdbMove.Size = new System.Drawing.Size(47, 16);
            this.rdbMove.TabIndex = 3;
            this.rdbMove.TabStop = true;
            this.rdbMove.Text = "平移";
            this.rdbMove.UseVisualStyleBackColor = true;
            // 
            // rdbRotate
            // 
            this.rdbRotate.AutoSize = true;
            this.rdbRotate.Location = new System.Drawing.Point(12, 136);
            this.rdbRotate.Name = "rdbRotate";
            this.rdbRotate.Size = new System.Drawing.Size(47, 16);
            this.rdbRotate.TabIndex = 4;
            this.rdbRotate.TabStop = true;
            this.rdbRotate.Text = "旋转";
            this.rdbRotate.UseVisualStyleBackColor = true;
            // 
            // rdbRatio
            // 
            this.rdbRatio.AutoSize = true;
            this.rdbRatio.Location = new System.Drawing.Point(12, 167);
            this.rdbRatio.Name = "rdbRatio";
            this.rdbRatio.Size = new System.Drawing.Size(47, 16);
            this.rdbRatio.TabIndex = 5;
            this.rdbRatio.TabStop = true;
            this.rdbRatio.Text = "缩放";
            this.rdbRatio.UseVisualStyleBackColor = true;
            // 
            // txtMoveX
            // 
            this.txtMoveX.Location = new System.Drawing.Point(111, 100);
            this.txtMoveX.Name = "txtMoveX";
            this.txtMoveX.Size = new System.Drawing.Size(52, 21);
            this.txtMoveX.TabIndex = 6;
            // 
            // txtMoveY
            // 
            this.txtMoveY.Location = new System.Drawing.Point(183, 100);
            this.txtMoveY.Name = "txtMoveY";
            this.txtMoveY.Size = new System.Drawing.Size(52, 21);
            this.txtMoveY.TabIndex = 7;
            // 
            // txtRotate
            // 
            this.txtRotate.Location = new System.Drawing.Point(111, 135);
            this.txtRotate.Name = "txtRotate";
            this.txtRotate.Size = new System.Drawing.Size(52, 21);
            this.txtRotate.TabIndex = 6;
            // 
            // txtRatioX
            // 
            this.txtRatioX.Location = new System.Drawing.Point(111, 167);
            this.txtRatioX.Name = "txtRatioX";
            this.txtRatioX.Size = new System.Drawing.Size(52, 21);
            this.txtRatioX.TabIndex = 6;
            // 
            // txtRatioY
            // 
            this.txtRatioY.Location = new System.Drawing.Point(183, 167);
            this.txtRatioY.Name = "txtRatioY";
            this.txtRatioY.Size = new System.Drawing.Size(52, 21);
            this.txtRatioY.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(208, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 35);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(278, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 35);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(367, 266);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMoveY);
            this.Controls.Add(this.txtRatioY);
            this.Controls.Add(this.txtRatioX);
            this.Controls.Add(this.txtRotate);
            this.Controls.Add(this.txtMoveX);
            this.Controls.Add(this.rdbRatio);
            this.Controls.Add(this.rdbRotate);
            this.Controls.Add(this.rdbMove);
            this.Controls.Add(this.rdbO);
            this.Controls.Add(this.rdbY);
            this.Controls.Add(this.rdbX);
            this.Name = "frmOperation";
            this.Text = "frmOperation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbX;
        private System.Windows.Forms.RadioButton rdbY;
        private System.Windows.Forms.RadioButton rdbO;
        private System.Windows.Forms.RadioButton rdbMove;
        private System.Windows.Forms.RadioButton rdbRotate;
        private System.Windows.Forms.RadioButton rdbRatio;
        private System.Windows.Forms.TextBox txtMoveX;
        private System.Windows.Forms.TextBox txtMoveY;
        private System.Windows.Forms.TextBox txtRotate;
        private System.Windows.Forms.TextBox txtRatioX;
        private System.Windows.Forms.TextBox txtRatioY;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}