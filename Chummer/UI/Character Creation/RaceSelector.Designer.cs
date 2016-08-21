namespace Chummer.UI.Character_Creation
{
    partial class RaceSelector
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
			this.cboCategory = new System.Windows.Forms.ComboBox();
			this.lstMetatypes = new System.Windows.Forms.ListBox();
			this.lstMetavariants = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// cboCategory
			// 
			this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCategory.FormattingEnabled = true;
			this.cboCategory.Location = new System.Drawing.Point(0, 0);
			this.cboCategory.Name = "cboCategory";
			this.cboCategory.Size = new System.Drawing.Size(164, 21);
			this.cboCategory.TabIndex = 7;
			this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
			// 
			// lstMetatypes
			// 
			this.lstMetatypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstMetatypes.FormattingEnabled = true;
			this.lstMetatypes.Location = new System.Drawing.Point(0, 27);
			this.lstMetatypes.Name = "lstMetatypes";
			this.lstMetatypes.Size = new System.Drawing.Size(164, 121);
			this.lstMetatypes.TabIndex = 8;
			this.lstMetatypes.SelectedIndexChanged += new System.EventHandler(this.lstMetatypes_SelectedIndexChanged);
			// 
			// lstMetavariants
			// 
			this.lstMetavariants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstMetavariants.FormattingEnabled = true;
			this.lstMetavariants.Location = new System.Drawing.Point(0, 148);
			this.lstMetavariants.Name = "lstMetavariants";
			this.lstMetavariants.Size = new System.Drawing.Size(164, 147);
			this.lstMetavariants.TabIndex = 9;
			this.lstMetavariants.SelectedIndexChanged += new System.EventHandler(this.lstMetavariants_SelectedIndexChanged);
			// 
			// RaceSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lstMetavariants);
			this.Controls.Add(this.lstMetatypes);
			this.Controls.Add(this.cboCategory);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "RaceSelector";
			this.Size = new System.Drawing.Size(164, 295);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ListBox lstMetatypes;
		private System.Windows.Forms.ListBox lstMetavariants;
	}
}
