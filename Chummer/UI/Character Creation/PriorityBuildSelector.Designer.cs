namespace Chummer.UI.Character_Creation
{
    partial class PriorityBuildSelector
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
            this.attributeDisplay = new Chummer.UI.Character_Creation.MetatypeAttributeDisplay();
            this.raceSelector1 = new Chummer.UI.Character_Creation.RaceSelector();
            this.SuspendLayout();
            // 
            // attributeDisplay
            // 
            this.attributeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attributeDisplay.Location = new System.Drawing.Point(173, 209);
            this.attributeDisplay.Name = "attributeDisplay";
            this.attributeDisplay.Size = new System.Drawing.Size(355, 122);
            this.attributeDisplay.TabIndex = 1;
            // 
            // raceSelector1
            // 
            this.raceSelector1.Location = new System.Drawing.Point(3, 177);
            this.raceSelector1.Name = "raceSelector1";
            this.raceSelector1.SetupInfo = null;
            this.raceSelector1.Size = new System.Drawing.Size(164, 273);
            this.raceSelector1.TabIndex = 0;
            // 
            // PriorityBuildSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.attributeDisplay);
            this.Controls.Add(this.raceSelector1);
            this.Name = "PriorityBuildSelector";
            this.Size = new System.Drawing.Size(531, 514);
            this.ResumeLayout(false);

        }

        #endregion

        private RaceSelector raceSelector1;
        private MetatypeAttributeDisplay attributeDisplay;
    }
}
