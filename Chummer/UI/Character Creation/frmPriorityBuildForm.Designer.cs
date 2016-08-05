namespace Chummer.UI.Character_Creation
{
    partial class frmPriorityBuildForm
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
            this.priorityBuildSelector1 = new Chummer.UI.Character_Creation.PriorityBuildSelector();
            this.SuspendLayout();
            // 
            // priorityBuildSelector1
            // 
            this.priorityBuildSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priorityBuildSelector1.Location = new System.Drawing.Point(0, 0);
            this.priorityBuildSelector1.Name = "priorityBuildSelector1";
            this.priorityBuildSelector1.Size = new System.Drawing.Size(478, 467);
            this.priorityBuildSelector1.TabIndex = 0;
            // 
            // frmPriorityBuildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 467);
            this.Controls.Add(this.priorityBuildSelector1);
            this.Name = "frmPriorityBuildForm";
            this.Text = "frmPriorityBuildForm";
            this.ResumeLayout(false);

        }

        #endregion

        private PriorityBuildSelector priorityBuildSelector1;
    }
}