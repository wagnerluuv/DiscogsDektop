namespace libDicogsDesktopControls.Controls
{
    partial class DiscogsArtistControl
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
            this.linkLabelViewInbrowser = new System.Windows.Forms.LinkLabel();
            this.dataGridViewReleases = new System.Windows.Forms.DataGridView();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelRelease = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReleases)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelViewInbrowser
            // 
            this.linkLabelViewInbrowser.AutoSize = true;
            this.linkLabelViewInbrowser.Location = new System.Drawing.Point(3, 221);
            this.linkLabelViewInbrowser.Name = "linkLabelViewInbrowser";
            this.linkLabelViewInbrowser.Size = new System.Drawing.Size(88, 13);
            this.linkLabelViewInbrowser.TabIndex = 13;
            this.linkLabelViewInbrowser.TabStop = true;
            this.linkLabelViewInbrowser.Text = "view in browser";
            this.linkLabelViewInbrowser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelViewInbrowserLinkClicked);
            // 
            // dataGridViewReleases
            // 
            this.dataGridViewReleases.AllowUserToAddRows = false;
            this.dataGridViewReleases.AllowUserToDeleteRows = false;
            this.dataGridViewReleases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReleases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewReleases.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewReleases.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewReleases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReleases.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewReleases.Location = new System.Drawing.Point(179, 77);
            this.dataGridViewReleases.MultiSelect = false;
            this.dataGridViewReleases.Name = "dataGridViewReleases";
            this.dataGridViewReleases.ReadOnly = true;
            this.dataGridViewReleases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReleases.Size = new System.Drawing.Size(625, 157);
            this.dataGridViewReleases.TabIndex = 10;
            this.dataGridViewReleases.SelectionChanged += new System.EventHandler(this.dataGridViewReleasesSelectionChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(285, 48);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 12;
            this.buttonSearch.Text = "search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearchClick);
            // 
            // panelRelease
            // 
            this.panelRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRelease.Location = new System.Drawing.Point(3, 240);
            this.panelRelease.Name = "panelRelease";
            this.panelRelease.Size = new System.Drawing.Size(801, 224);
            this.panelRelease.TabIndex = 11;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(179, 48);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 22);
            this.textBoxSearch.TabIndex = 9;
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchKeyPress);
            // 
            // DiscogsArtistControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelViewInbrowser);
            this.Controls.Add(this.dataGridViewReleases);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.panelRelease);
            this.Controls.Add(this.textBoxSearch);
            this.Name = "DiscogsArtistControl";
            this.Size = new System.Drawing.Size(807, 467);
            this.Controls.SetChildIndex(this.textBoxSearch, 0);
            this.Controls.SetChildIndex(this.panelRelease, 0);
            this.Controls.SetChildIndex(this.buttonSearch, 0);
            this.Controls.SetChildIndex(this.dataGridViewReleases, 0);
            this.Controls.SetChildIndex(this.linkLabelViewInbrowser, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReleases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelViewInbrowser;
        private System.Windows.Forms.DataGridView dataGridViewReleases;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Panel panelRelease;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}
