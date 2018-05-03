namespace libDicogsDesktopControls.Controls
{
    sealed partial class DiscogsReleaseControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelVideos = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelGoToUrl = new System.Windows.Forms.LinkLabel();
            this.labelLabel = new System.Windows.Forms.Label();
            this.linkLabelLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelVideos
            // 
            this.flowLayoutPanelVideos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelVideos.AutoScroll = true;
            this.flowLayoutPanelVideos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelVideos.Location = new System.Drawing.Point(179, 48);
            this.flowLayoutPanelVideos.Name = "flowLayoutPanelVideos";
            this.flowLayoutPanelVideos.Size = new System.Drawing.Size(590, 338);
            this.flowLayoutPanelVideos.TabIndex = 1;
            // 
            // linkLabelGoToUrl
            // 
            this.linkLabelGoToUrl.AutoSize = true;
            this.linkLabelGoToUrl.Location = new System.Drawing.Point(3, 221);
            this.linkLabelGoToUrl.Name = "linkLabelGoToUrl";
            this.linkLabelGoToUrl.Size = new System.Drawing.Size(88, 13);
            this.linkLabelGoToUrl.TabIndex = 3;
            this.linkLabelGoToUrl.TabStop = true;
            this.linkLabelGoToUrl.Text = "view in browser";
            this.linkLabelGoToUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoToUrlLinkClicked);
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.Location = new System.Drawing.Point(6, 257);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(32, 13);
            this.labelLabel.TabIndex = 4;
            this.labelLabel.Text = "label";
            // 
            // linkLabelLabel
            // 
            this.linkLabelLabel.AutoSize = true;
            this.linkLabelLabel.Location = new System.Drawing.Point(3, 270);
            this.linkLabelLabel.Name = "linkLabelLabel";
            this.linkLabelLabel.Size = new System.Drawing.Size(60, 13);
            this.linkLabelLabel.TabIndex = 5;
            this.linkLabelLabel.TabStop = true;
            this.linkLabelLabel.Text = "labelname";
            this.linkLabelLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLabelLinkClicked);
            // 
            // DiscogsReleaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.linkLabelLabel);
            this.Controls.Add(this.labelLabel);
            this.Controls.Add(this.linkLabelGoToUrl);
            this.Controls.Add(this.flowLayoutPanelVideos);
            this.Name = "DiscogsReleaseControl";
            this.Size = new System.Drawing.Size(772, 389);
            this.Type = "release";
            this.Controls.SetChildIndex(this.flowLayoutPanelVideos, 0);
            this.Controls.SetChildIndex(this.linkLabelGoToUrl, 0);
            this.Controls.SetChildIndex(this.labelLabel, 0);
            this.Controls.SetChildIndex(this.linkLabelLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelVideos;
        private System.Windows.Forms.LinkLabel linkLabelGoToUrl;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.LinkLabel linkLabelLabel;
    }
}
