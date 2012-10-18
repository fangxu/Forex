namespace Forex
{
    partial class ChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxShort = new System.Windows.Forms.PictureBox();
            this.pictureBoxLong = new System.Windows.Forms.PictureBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLong)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxShort);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxLong);
            this.splitContainer1.Size = new System.Drawing.Size(614, 162);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBoxShort
            // 
            this.pictureBoxShort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxShort.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxShort.Name = "pictureBoxShort";
            this.pictureBoxShort.Size = new System.Drawing.Size(303, 162);
            this.pictureBoxShort.TabIndex = 0;
            this.pictureBoxShort.TabStop = false;
            // 
            // pictureBoxLong
            // 
            this.pictureBoxLong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLong.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLong.Name = "pictureBoxLong";
            this.pictureBoxLong.Size = new System.Drawing.Size(310, 162);
            this.pictureBoxLong.TabIndex = 0;
            this.pictureBoxLong.TabStop = false;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 162);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartForm";
            this.ShowInTaskbar = false;
            this.Text = "ChartForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBoxShort;
        private System.Windows.Forms.PictureBox pictureBoxLong;


    }
}