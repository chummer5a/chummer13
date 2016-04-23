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
	public partial class VehicleWeaponControl : UserControl
	{
		public VehicleWeaponControl()
		{
			InitializeComponent();
		}

		#region Properties
		public String Accuracy
		{
			get { return this.lblVehicleWeaponControlAccuracy.Text; }
			set { this.lblVehicleWeaponControlAccuracy.Text = value; }
		}
		public String Damage
		{
			get { return this.lblVehicleWeaponControlDamage.Text; }
			set { this.lblVehicleWeaponControlDamage.Text = value; }
		}
		public String AP
		{
			get { return this.lblVehicleWeaponControlAP.Text; }
			set { this.lblVehicleWeaponControlAP.Text = value; }
		}
		public String Mode
		{
			get { return this.lblVehicleWeaponControlMode.Text; }
			set { this.lblVehicleWeaponControlMode.Text = value; }
		}
		public String RC
		{
			get { return this.lblVehicleWeaponControlRC.Text; }
			set { this.lblVehicleWeaponControlRC.Text = value; }
		}
		public String Ammo
		{
			get { return this.lblVehicleWeaponControlAmmo.Text; }
			set { this.lblVehicleWeaponControlAmmo.Text = value; }
		}
		public String Rating
		{
			get { return this.lblVehicleWeaponControlRating.Text; }
			set { this.lblVehicleWeaponControlRating.Text = value; }
		}
		public String DicePool
		{
			get { return this.lblVehicleWeaponControlDicePool.Text; }
			set { this.lblVehicleWeaponControlDicePool.Text = value; }
		}
		public String RangeShort
		{
			get { return this.lblVehicleWeaponControlRangeShort.Text; }
			set { this.lblVehicleWeaponControlRangeShort.Text = value; }
		}
		public String RangeMedium
		{
			get { return this.lblVehicleWeaponControlRangeMedium.Text; }
			set { this.lblVehicleWeaponControlRangeMedium.Text = value; }
		}
		public String RangeLong
		{
			get { return this.lblVehicleWeaponControlRangeLong.Text; }
			set { this.lblVehicleWeaponControlRangeLong.Text = value; }
		}
		public String RangeExtreme
		{
			get { return this.lblVehicleWeaponControlRangeExtreme.Text; }
			set { this.lblVehicleWeaponControlRangeExtreme.Text = value; }
		}
		public Boolean IsInstalled
		{
			get { return this.chkVehicleWeaponControlInstalled.Checked; }
			set { this.chkVehicleWeaponControlInstalled.Checked = value; }
		}
		#endregion
	}
}
