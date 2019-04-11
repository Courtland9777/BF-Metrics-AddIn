namespace BfMetricsAddIn.QuickReportNS
{
    partial class QuickReportWindow
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
            this.btnOkay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNumberOfNewborns = new System.Windows.Forms.TextBox();
            this.tbExclusivityRate = new System.Windows.Forms.TextBox();
            this.tbInitiationRate = new System.Windows.Forms.TextBox();
            this.tbSkinToSkin = new System.Windows.Forms.TextBox();
            this.tbOneHourFeeding = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(155, 292);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 0;
            this.btnOkay.Text = "Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.BtnOkay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "One Hour Feeding";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Skin to Skin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Initiation Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Exclusivity Rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Number of Newborns";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNumberOfNewborns);
            this.groupBox1.Controls.Add(this.tbExclusivityRate);
            this.groupBox1.Controls.Add(this.tbInitiationRate);
            this.groupBox1.Controls.Add(this.tbSkinToSkin);
            this.groupBox1.Controls.Add(this.tbOneHourFeeding);
            this.groupBox1.Controls.Add(this.tbDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 244);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Month Data";
            // 
            // tbNumberOfNewborns
            // 
            this.tbNumberOfNewborns.Location = new System.Drawing.Point(225, 198);
            this.tbNumberOfNewborns.Name = "tbNumberOfNewborns";
            this.tbNumberOfNewborns.ReadOnly = true;
            this.tbNumberOfNewborns.Size = new System.Drawing.Size(100, 20);
            this.tbNumberOfNewborns.TabIndex = 12;
            this.tbNumberOfNewborns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbExclusivityRate
            // 
            this.tbExclusivityRate.Location = new System.Drawing.Point(225, 164);
            this.tbExclusivityRate.Name = "tbExclusivityRate";
            this.tbExclusivityRate.ReadOnly = true;
            this.tbExclusivityRate.Size = new System.Drawing.Size(100, 20);
            this.tbExclusivityRate.TabIndex = 11;
            this.tbExclusivityRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbInitiationRate
            // 
            this.tbInitiationRate.Location = new System.Drawing.Point(225, 130);
            this.tbInitiationRate.Name = "tbInitiationRate";
            this.tbInitiationRate.ReadOnly = true;
            this.tbInitiationRate.Size = new System.Drawing.Size(100, 20);
            this.tbInitiationRate.TabIndex = 10;
            this.tbInitiationRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSkinToSkin
            // 
            this.tbSkinToSkin.Location = new System.Drawing.Point(225, 96);
            this.tbSkinToSkin.Name = "tbSkinToSkin";
            this.tbSkinToSkin.ReadOnly = true;
            this.tbSkinToSkin.Size = new System.Drawing.Size(100, 20);
            this.tbSkinToSkin.TabIndex = 9;
            this.tbSkinToSkin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOneHourFeeding
            // 
            this.tbOneHourFeeding.Location = new System.Drawing.Point(225, 62);
            this.tbOneHourFeeding.Name = "tbOneHourFeeding";
            this.tbOneHourFeeding.ReadOnly = true;
            this.tbOneHourFeeding.Size = new System.Drawing.Size(100, 20);
            this.tbOneHourFeeding.TabIndex = 8;
            this.tbOneHourFeeding.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(225, 28);
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(100, 20);
            this.tbDate.TabIndex = 7;
            this.tbDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // QuickReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 342);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOkay);
            this.Name = "QuickReportWindow";
            this.Text = "QuickReportWindow";
            this.Load += new System.EventHandler(this.QuickReportWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNumberOfNewborns;
        private System.Windows.Forms.TextBox tbExclusivityRate;
        private System.Windows.Forms.TextBox tbInitiationRate;
        private System.Windows.Forms.TextBox tbSkinToSkin;
        private System.Windows.Forms.TextBox tbOneHourFeeding;
        private System.Windows.Forms.TextBox tbDate;
    }
}