namespace Chummer
{
	partial class VehicleControl
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Mods");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Gear");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Addons", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
			this.pnlVehicleBaseStats = new System.Windows.Forms.Panel();
			this.lblRiggerSeats = new System.Windows.Forms.Label();
			this.lblRiggerSeatsLabel = new System.Windows.Forms.Label();
			this.lblRiggerSensor = new System.Windows.Forms.Label();
			this.lblRiggerSensorLabel = new System.Windows.Forms.Label();
			this.lblRiggerPilot = new System.Windows.Forms.Label();
			this.lblRiggerPilotLabel = new System.Windows.Forms.Label();
			this.lblRiggerArmor = new System.Windows.Forms.Label();
			this.lblRiggerArmorLabel = new System.Windows.Forms.Label();
			this.lblRiggerBody = new System.Windows.Forms.Label();
			this.lblRiggerBodyLabel = new System.Windows.Forms.Label();
			this.lblRiggerSpeed = new System.Windows.Forms.Label();
			this.lblRiggerSpeedLabel = new System.Windows.Forms.Label();
			this.lblRiggerAccel = new System.Windows.Forms.Label();
			this.lblRiggerAccelLabel = new System.Windows.Forms.Label();
			this.lblRiggerHandling = new System.Windows.Forms.Label();
			this.lblRiggerHandlingLabel = new System.Windows.Forms.Label();
			this.tabVehicleWeapons = new System.Windows.Forms.TabControl();
			this.lstVehicleSoftware = new System.Windows.Forms.ListBox();
			this.treVehicleAddons = new Chummer.helpers.TreeView();
			this.pnlVehicleBaseStats.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlVehicleBaseStats
			// 
			this.pnlVehicleBaseStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerSeats);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerSeatsLabel);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerSensor);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerSensorLabel);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerPilot);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerPilotLabel);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerArmor);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerArmorLabel);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerBody);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerBodyLabel);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerSpeed);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerSpeedLabel);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerAccel);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerAccelLabel);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerHandling);
			this.pnlVehicleBaseStats.Controls.Add(this.lblRiggerHandlingLabel);
			this.pnlVehicleBaseStats.Location = new System.Drawing.Point(239, 3);
			this.pnlVehicleBaseStats.MinimumSize = new System.Drawing.Size(429, 0);
			this.pnlVehicleBaseStats.Name = "pnlVehicleBaseStats";
			this.pnlVehicleBaseStats.Size = new System.Drawing.Size(429, 32);
			this.pnlVehicleBaseStats.TabIndex = 2;
			// 
			// lblRiggerSeats
			// 
			this.lblRiggerSeats.Location = new System.Drawing.Point(373, 13);
			this.lblRiggerSeats.Name = "lblRiggerSeats";
			this.lblRiggerSeats.Size = new System.Drawing.Size(40, 13);
			this.lblRiggerSeats.TabIndex = 212;
			this.lblRiggerSeats.Text = "[Seats]";
			this.lblRiggerSeats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRiggerSeatsLabel
			// 
			this.lblRiggerSeatsLabel.AutoSize = true;
			this.lblRiggerSeatsLabel.Location = new System.Drawing.Point(373, 0);
			this.lblRiggerSeatsLabel.Name = "lblRiggerSeatsLabel";
			this.lblRiggerSeatsLabel.Size = new System.Drawing.Size(34, 13);
			this.lblRiggerSeatsLabel.TabIndex = 211;
			this.lblRiggerSeatsLabel.Tag = "Label_Seats";
			this.lblRiggerSeatsLabel.Text = "Seats";
			// 
			// lblRiggerSensor
			// 
			this.lblRiggerSensor.Location = new System.Drawing.Point(321, 13);
			this.lblRiggerSensor.Name = "lblRiggerSensor";
			this.lblRiggerSensor.Size = new System.Drawing.Size(46, 13);
			this.lblRiggerSensor.TabIndex = 210;
			this.lblRiggerSensor.Text = "[Sensor]";
			this.lblRiggerSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRiggerSensorLabel
			// 
			this.lblRiggerSensorLabel.AutoSize = true;
			this.lblRiggerSensorLabel.Location = new System.Drawing.Point(321, 0);
			this.lblRiggerSensorLabel.Name = "lblRiggerSensorLabel";
			this.lblRiggerSensorLabel.Size = new System.Drawing.Size(40, 13);
			this.lblRiggerSensorLabel.TabIndex = 209;
			this.lblRiggerSensorLabel.Tag = "Label_Sensor";
			this.lblRiggerSensorLabel.Text = "Sensor";
			// 
			// lblRiggerPilot
			// 
			this.lblRiggerPilot.Location = new System.Drawing.Point(271, 13);
			this.lblRiggerPilot.Name = "lblRiggerPilot";
			this.lblRiggerPilot.Size = new System.Drawing.Size(33, 13);
			this.lblRiggerPilot.TabIndex = 204;
			this.lblRiggerPilot.Text = "[Pilot]";
			this.lblRiggerPilot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRiggerPilotLabel
			// 
			this.lblRiggerPilotLabel.AutoSize = true;
			this.lblRiggerPilotLabel.Location = new System.Drawing.Point(271, 0);
			this.lblRiggerPilotLabel.Name = "lblRiggerPilotLabel";
			this.lblRiggerPilotLabel.Size = new System.Drawing.Size(27, 13);
			this.lblRiggerPilotLabel.TabIndex = 203;
			this.lblRiggerPilotLabel.Tag = "Label_Pilot";
			this.lblRiggerPilotLabel.Text = "Pilot";
			// 
			// lblRiggerArmor
			// 
			this.lblRiggerArmor.Location = new System.Drawing.Point(217, 13);
			this.lblRiggerArmor.Name = "lblRiggerArmor";
			this.lblRiggerArmor.Size = new System.Drawing.Size(40, 13);
			this.lblRiggerArmor.TabIndex = 208;
			this.lblRiggerArmor.Text = "[Armor]";
			this.lblRiggerArmor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRiggerArmorLabel
			// 
			this.lblRiggerArmorLabel.AutoSize = true;
			this.lblRiggerArmorLabel.Location = new System.Drawing.Point(217, 0);
			this.lblRiggerArmorLabel.Name = "lblRiggerArmorLabel";
			this.lblRiggerArmorLabel.Size = new System.Drawing.Size(34, 13);
			this.lblRiggerArmorLabel.TabIndex = 207;
			this.lblRiggerArmorLabel.Tag = "Label_Armor";
			this.lblRiggerArmorLabel.Text = "Armor";
			// 
			// lblRiggerBody
			// 
			this.lblRiggerBody.Location = new System.Drawing.Point(174, 13);
			this.lblRiggerBody.Name = "lblRiggerBody";
			this.lblRiggerBody.Size = new System.Drawing.Size(37, 13);
			this.lblRiggerBody.TabIndex = 206;
			this.lblRiggerBody.Text = "[Body]";
			this.lblRiggerBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRiggerBodyLabel
			// 
			this.lblRiggerBodyLabel.AutoSize = true;
			this.lblRiggerBodyLabel.Location = new System.Drawing.Point(174, 0);
			this.lblRiggerBodyLabel.Name = "lblRiggerBodyLabel";
			this.lblRiggerBodyLabel.Size = new System.Drawing.Size(31, 13);
			this.lblRiggerBodyLabel.TabIndex = 205;
			this.lblRiggerBodyLabel.Tag = "Label_Body";
			this.lblRiggerBodyLabel.Text = "Body";
			// 
			// lblRiggerSpeed
			// 
			this.lblRiggerSpeed.Location = new System.Drawing.Point(77, 13);
			this.lblRiggerSpeed.Name = "lblRiggerSpeed";
			this.lblRiggerSpeed.Size = new System.Drawing.Size(44, 13);
			this.lblRiggerSpeed.TabIndex = 202;
			this.lblRiggerSpeed.Text = "[Speed]";
			this.lblRiggerSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRiggerSpeedLabel
			// 
			this.lblRiggerSpeedLabel.AutoSize = true;
			this.lblRiggerSpeedLabel.Location = new System.Drawing.Point(77, 0);
			this.lblRiggerSpeedLabel.Name = "lblRiggerSpeedLabel";
			this.lblRiggerSpeedLabel.Size = new System.Drawing.Size(38, 13);
			this.lblRiggerSpeedLabel.TabIndex = 201;
			this.lblRiggerSpeedLabel.Tag = "Label_Speed";
			this.lblRiggerSpeedLabel.Text = "Speed";
			// 
			// lblRiggerAccel
			// 
			this.lblRiggerAccel.Location = new System.Drawing.Point(131, 13);
			this.lblRiggerAccel.Name = "lblRiggerAccel";
			this.lblRiggerAccel.Size = new System.Drawing.Size(40, 13);
			this.lblRiggerAccel.TabIndex = 200;
			this.lblRiggerAccel.Text = "[Accel]";
			this.lblRiggerAccel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRiggerAccelLabel
			// 
			this.lblRiggerAccelLabel.AutoSize = true;
			this.lblRiggerAccelLabel.Location = new System.Drawing.Point(131, 0);
			this.lblRiggerAccelLabel.Name = "lblRiggerAccelLabel";
			this.lblRiggerAccelLabel.Size = new System.Drawing.Size(34, 13);
			this.lblRiggerAccelLabel.TabIndex = 199;
			this.lblRiggerAccelLabel.Tag = "Label_Accel";
			this.lblRiggerAccelLabel.Text = "Accel";
			// 
			// lblRiggerHandling
			// 
			this.lblRiggerHandling.Location = new System.Drawing.Point(3, 13);
			this.lblRiggerHandling.Name = "lblRiggerHandling";
			this.lblRiggerHandling.Size = new System.Drawing.Size(55, 13);
			this.lblRiggerHandling.TabIndex = 198;
			this.lblRiggerHandling.Text = "[Handling]";
			this.lblRiggerHandling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRiggerHandlingLabel
			// 
			this.lblRiggerHandlingLabel.AutoSize = true;
			this.lblRiggerHandlingLabel.Location = new System.Drawing.Point(3, 0);
			this.lblRiggerHandlingLabel.Name = "lblRiggerHandlingLabel";
			this.lblRiggerHandlingLabel.Size = new System.Drawing.Size(49, 13);
			this.lblRiggerHandlingLabel.TabIndex = 197;
			this.lblRiggerHandlingLabel.Tag = "Label_Handling";
			this.lblRiggerHandlingLabel.Text = "Handling";
			// 
			// tabVehicleWeapons
			// 
			this.tabVehicleWeapons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tabVehicleWeapons.Location = new System.Drawing.Point(0, 335);
			this.tabVehicleWeapons.Name = "tabVehicleWeapons";
			this.tabVehicleWeapons.SelectedIndex = 0;
			this.tabVehicleWeapons.Size = new System.Drawing.Size(671, 129);
			this.tabVehicleWeapons.TabIndex = 3;
			// 
			// lstVehicleSoftware
			// 
			this.lstVehicleSoftware.FormattingEnabled = true;
			this.lstVehicleSoftware.Location = new System.Drawing.Point(3, 221);
			this.lstVehicleSoftware.Name = "lstVehicleSoftware";
			this.lstVehicleSoftware.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstVehicleSoftware.Size = new System.Drawing.Size(232, 108);
			this.lstVehicleSoftware.Sorted = true;
			this.lstVehicleSoftware.TabIndex = 35;
			// 
			// treVehicleAddons
			// 
			this.treVehicleAddons.AllowDrop = true;
			this.treVehicleAddons.HideSelection = false;
			this.treVehicleAddons.Location = new System.Drawing.Point(3, 3);
			this.treVehicleAddons.Name = "treVehicleAddons";
			treeNode1.Checked = true;
			treeNode1.Name = "nodRiggerAddonsMods";
			treeNode1.Text = "Mods";
			treeNode2.Name = "nodRiggerAddonsGear";
			treeNode2.Text = "Gear";
			treeNode3.Name = "nodRiggerAddonsRoot";
			treeNode3.Tag = "";
			treeNode3.Text = "Addons";
			this.treVehicleAddons.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
			this.treVehicleAddons.ShowNodeToolTips = true;
			this.treVehicleAddons.ShowRootLines = false;
			this.treVehicleAddons.Size = new System.Drawing.Size(232, 212);
			this.treVehicleAddons.TabIndex = 33;
			// 
			// VehicleControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lstVehicleSoftware);
			this.Controls.Add(this.treVehicleAddons);
			this.Controls.Add(this.tabVehicleWeapons);
			this.Controls.Add(this.pnlVehicleBaseStats);
			this.MinimumSize = new System.Drawing.Size(671, 0);
			this.Name = "VehicleControl";
			this.Size = new System.Drawing.Size(671, 464);
			this.pnlVehicleBaseStats.ResumeLayout(false);
			this.pnlVehicleBaseStats.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlVehicleBaseStats;
		private System.Windows.Forms.Label lblRiggerSeats;
		private System.Windows.Forms.Label lblRiggerSeatsLabel;
		private System.Windows.Forms.Label lblRiggerSensor;
		private System.Windows.Forms.Label lblRiggerSensorLabel;
		private System.Windows.Forms.Label lblRiggerPilot;
		private System.Windows.Forms.Label lblRiggerPilotLabel;
		private System.Windows.Forms.Label lblRiggerArmor;
		private System.Windows.Forms.Label lblRiggerArmorLabel;
		private System.Windows.Forms.Label lblRiggerBody;
		private System.Windows.Forms.Label lblRiggerBodyLabel;
		private System.Windows.Forms.Label lblRiggerSpeed;
		private System.Windows.Forms.Label lblRiggerSpeedLabel;
		private System.Windows.Forms.Label lblRiggerAccel;
		private System.Windows.Forms.Label lblRiggerAccelLabel;
		private System.Windows.Forms.Label lblRiggerHandling;
		private System.Windows.Forms.Label lblRiggerHandlingLabel;
		private System.Windows.Forms.TabControl tabVehicleWeapons;
		private helpers.TreeView treVehicleAddons;
		private System.Windows.Forms.ListBox lstVehicleSoftware;
	}
}
