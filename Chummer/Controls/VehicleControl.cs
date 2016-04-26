/*  This file is part of Chummer5a.
 *
 *  Chummer5a is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Chummer5a is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Chummer5a.  If not, see <http://www.gnu.org/licenses/>.
 *
 *  You can obtain the full source code for Chummer5a at
 *  https://github.com/chummer5a/chummer5a
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chummer
{
	public partial class VehicleControl : UserControl
	{
		private Guid _guiID = new Guid();

		public VehicleControl()
		{
			InitializeComponent();

		}

		#region Properties
		/// <summary>
		/// Internal identifier which will be used to identify this Vehicle.
		/// </summary>
		public string InternalId
		{
			get
			{
				return _guiID.ToString();
			}
			set
			{
				_guiID = Guid.Parse(value);
			}
		}

		public string Accel
		{
			get { return lblRiggerAccel.Text; }
			set { lblRiggerAccel.Text = value; }
		}
		public string Speed
		{
			get { return lblRiggerSpeed.Text; }
			set { lblRiggerSpeed.Text = value; }
		}
		public string Sensor
		{
			get { return lblRiggerSensor.Text; }
			set { lblRiggerSensor.Text = value; }
		}
		public string Pilot
		{
			get { return lblRiggerPilot.Text; }
			set { lblRiggerPilot.Text = value; }
		}
		public string Armor
		{
			get { return lblRiggerArmor.Text; }
			set { lblRiggerArmor.Text = value; }
		}
		public string Body
		{
			get { return lblRiggerBody.Text; }
			set { lblRiggerBody.Text = value; }
		}
		public string Seats
		{
			get { return lblRiggerSeats.Text; }
			set { lblRiggerSeats.Text = value; }
		}
		public string Handling
		{
			get { return lblRiggerHandling.Text; }
			set { lblRiggerHandling.Text = value; }
		}
		#endregion

		#region Controls

		public bool EnableVehicleBaseStats
		{
			get
			{
				return (pnlVehicleBaseStats.Visible);
			}
			set
			{
				pnlVehicleBaseStats.Visible = value;
			}
		}

		public Panel VehicleBaseStats
		{
			get
			{
				return (pnlVehicleBaseStats);
			}
		}

		public TabControl VehicleWeapons
		{
			get
			{
				return (tabVehicleWeapons);
			}
		}
		public TreeView AddonsTree
		{
			get
			{
				return (treVehicleAddons);
			}
		}

		public ListBox Software
		{
			get
			{
				return (lstVehicleSoftware);
			}
		}


		#endregion

	}
}
