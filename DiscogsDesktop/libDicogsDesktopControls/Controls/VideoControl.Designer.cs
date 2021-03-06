﻿namespace libDicogsDesktopControls.Controls
{
    sealed partial class VideoControl
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
            this.components = new System.ComponentModel.Container();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonPlayVideo = new System.Windows.Forms.Button();
            this.buttonOpenUrl = new System.Windows.Forms.Button();
            this.buttonPlayAudio = new System.Windows.Forms.Button();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.progressBarLoading = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(141, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(44, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "title";
            // 
            // buttonPlayVideo
            // 
            this.buttonPlayVideo.Enabled = false;
            this.buttonPlayVideo.FlatAppearance.BorderSize = 0;
            this.buttonPlayVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayVideo.Image = global::libDicogsDesktopControls.Properties.Resources.clapperboard;
            this.buttonPlayVideo.Location = new System.Drawing.Point(49, 3);
            this.buttonPlayVideo.Name = "buttonPlayVideo";
            this.buttonPlayVideo.Size = new System.Drawing.Size(40, 37);
            this.buttonPlayVideo.TabIndex = 3;
            this.toolTipInfo.SetToolTip(this.buttonPlayVideo, "play video");
            this.buttonPlayVideo.UseVisualStyleBackColor = true;
            this.buttonPlayVideo.Click += new System.EventHandler(this.buttonPlayVideoClick);
            // 
            // buttonOpenUrl
            // 
            this.buttonOpenUrl.FlatAppearance.BorderSize = 0;
            this.buttonOpenUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenUrl.Image = global::libDicogsDesktopControls.Properties.Resources.link;
            this.buttonOpenUrl.Location = new System.Drawing.Point(95, 3);
            this.buttonOpenUrl.Name = "buttonOpenUrl";
            this.buttonOpenUrl.Size = new System.Drawing.Size(40, 37);
            this.buttonOpenUrl.TabIndex = 2;
            this.toolTipInfo.SetToolTip(this.buttonOpenUrl, "open link");
            this.buttonOpenUrl.UseVisualStyleBackColor = true;
            this.buttonOpenUrl.Click += new System.EventHandler(this.buttonOpenUrlClick);
            // 
            // buttonPlayAudio
            // 
            this.buttonPlayAudio.Enabled = false;
            this.buttonPlayAudio.FlatAppearance.BorderSize = 0;
            this.buttonPlayAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayAudio.Image = global::libDicogsDesktopControls.Properties.Resources.headphones;
            this.buttonPlayAudio.Location = new System.Drawing.Point(3, 3);
            this.buttonPlayAudio.Name = "buttonPlayAudio";
            this.buttonPlayAudio.Size = new System.Drawing.Size(40, 37);
            this.buttonPlayAudio.TabIndex = 1;
            this.toolTipInfo.SetToolTip(this.buttonPlayAudio, "play audio");
            this.buttonPlayAudio.UseVisualStyleBackColor = true;
            this.buttonPlayAudio.Click += new System.EventHandler(this.buttonPlayAudioClick);
            // 
            // progressBarLoading
            // 
            this.progressBarLoading.Location = new System.Drawing.Point(0, 0);
            this.progressBarLoading.Name = "progressBarLoading";
            this.progressBarLoading.Size = new System.Drawing.Size(132, 10);
            this.progressBarLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarLoading.TabIndex = 4;
            // 
            // VideoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarLoading);
            this.Controls.Add(this.buttonPlayVideo);
            this.Controls.Add(this.buttonOpenUrl);
            this.Controls.Add(this.buttonPlayAudio);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "VideoControl";
            this.Size = new System.Drawing.Size(1561, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonPlayAudio;
        private System.Windows.Forms.Button buttonOpenUrl;
        private System.Windows.Forms.Button buttonPlayVideo;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.ProgressBar progressBarLoading;
    }
}
