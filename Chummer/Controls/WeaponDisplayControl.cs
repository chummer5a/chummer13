using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chummer.Backend.Equipment;

namespace Chummer.Controls
{
	public partial class WeaponDisplayControl : UserControl
	{
		public WeaponDisplayControl(ToolTip tipTooltip)
		{
			InitializeComponent();
			tipTooltip.SetToolTip(chkWeaponAccessoryInstalled, LanguageManager.Instance.GetString("Tip_WeaponInstalled"));
			MoveControls();
		}

		/// <summary>
		/// Adjust the positioning of controls for localisation purposes. 
		/// </summary>
		private void MoveControls()
		{
			int intWidth = 0;
			//Get the highest width of the descriptive labels for the first column.
			intWidth = Math.Max(lblWeaponNameLabel.Width, lblWeaponCategoryLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponDamageLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponReachLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponAvailLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponSourceLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponSlotsLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponAccuracyLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponDicePoolLabel.Width);
			
			//Apply the width for the object labels for the first column.
			lblWeaponName.Left = lblWeaponNameLabel.Left + intWidth + 6;
			lblWeaponCategory.Left = lblWeaponCategoryLabel.Left + intWidth + 6;
			lblWeaponDamage.Left = lblWeaponDamageLabel.Left + intWidth + 6;
			lblWeaponReach.Left = lblWeaponReachLabel.Left + intWidth + 6;
			lblWeaponAvail.Left = lblWeaponAvailLabel.Left + intWidth + 6;
			lblWeaponSource.Left = lblWeaponSourceLabel.Left + intWidth + 6;
			lblWeaponSlots.Left = lblWeaponSlotsLabel.Left + intWidth + 6;
			lblWeaponAccuracy.Left = lblWeaponAccuracyLabel.Left + intWidth + 6;

			//Get the highest width of the object labels in the first column. Used for the second column.
			intWidth = Math.Max(lblWeaponName.Right, lblWeaponCategory.Right);
			intWidth = Math.Max(intWidth, lblWeaponDamage.Right);
			intWidth = Math.Max(intWidth, lblWeaponReach.Right);
			intWidth = Math.Max(intWidth, lblWeaponAvail.Right);
			intWidth = Math.Max(intWidth, lblWeaponSource.Right);
			intWidth = Math.Max(intWidth, lblWeaponSlots.Right);
			intWidth = Math.Max(intWidth, lblWeaponAccuracy.Right);

			//Apply the left position for the second column's labels.
			lblWeaponRCLabel.Left = intWidth + 30;
			lblWeaponModeLabel.Left = intWidth + 30;
			lblWeaponCostLabel.Left = intWidth + 30;
			lblWeaponAPLabel.Left = intWidth + 30;
			lblWeaponAmmoLabel.Left = intWidth + 30;
			lblWeaponConcealLabel.Left = intWidth + 30;
			lblWeaponDicePoolLabel.Left = intWidth + 30;
			chkWeaponAccessoryInstalled.Left = intWidth + 30;
			chkIncludedInWeapon.Left = intWidth + 30;

			//Get the highest width of the descriptive labels in the second column.
			intWidth = Math.Max(lblWeaponNameLabel.Width, lblWeaponCategoryLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponDamageLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponReachLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponAvailLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponSourceLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponSlotsLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponAccuracyLabel.Width);
			intWidth = Math.Max(intWidth, lblWeaponDicePoolLabel.Width);

			//Apply the left position for the second column's labels.
			lblWeaponRC.Left = lblWeaponRCLabel.Left + intWidth + 20;
			lblWeaponMode.Left = lblWeaponModeLabel.Left + intWidth + 20;
			lblWeaponCost.Left = lblWeaponCostLabel.Left + intWidth + 20;
			lblWeaponAP.Left = lblWeaponAPLabel.Left + intWidth + 20;
			lblWeaponAmmo.Left = lblWeaponAmmoLabel.Left + intWidth + 20;
			lblWeaponConceal.Left = lblWeaponConcealLabel.Left + intWidth + 20;
			lblWeaponDicePool.Left = lblWeaponDicePoolLabel.Left + intWidth + 20;
			chkWeaponAccessoryInstalled.Left = lblWeaponConcealLabel.Left;
			chkIncludedInWeapon.Left = lblWeaponConcealLabel.Left;

		}


		/// <summary>
		/// Refresh the information for the currently displayed Weapon.
		/// </summary>
		public void RefreshSelectedWeapon(Weapon objWeapon, Character _objCharacter, CommonFunctions _objFunctions, CharacterOptions _objOptions, ToolTip tipTooltip)
		{
				if (objWeapon == null)
					return;

				// If this is a Cyberweapon, grab the STR of the limb.
				int intUseSTR = 0;
				if (objWeapon.Cyberware)
				{
					foreach (Cyberware objCyberware in _objCharacter.Cyberware)
					{
						foreach (Cyberware objPlugin in objCyberware.Children)
						{
							if (objPlugin.WeaponID == objWeapon.InternalId)
							{
								intUseSTR = objCyberware.TotalStrength;
								break;
							}
						}
					}
				}
				lblWeaponName.Text = objWeapon.DisplayNameShort;
				lblWeaponCategory.Text = objWeapon.DisplayCategory;
				string strBook = _objOptions.LanguageBookShort(objWeapon.Source);
				string strPage = objWeapon.Page;
				lblWeaponSource.Text = strBook + " " + strPage;
				tipTooltip.SetToolTip(lblWeaponSource, _objOptions.LanguageBookLong(objWeapon.Source) + " " + LanguageManager.Instance.GetString("String_Page") + " " + objWeapon.Page);
				chkWeaponAccessoryInstalled.Enabled = false;
				chkIncludedInWeapon.Enabled = false;
				chkIncludedInWeapon.Checked = false;

				// Show the Weapon Ranges.
				lblWeaponRangeShort.Text = objWeapon.RangeShort;
				lblWeaponRangeMedium.Text = objWeapon.RangeMedium;
				lblWeaponRangeLong.Text = objWeapon.RangeLong;
				lblWeaponRangeExtreme.Text = objWeapon.RangeExtreme;
				lblWeaponAvail.Text = objWeapon.TotalAvail;
				lblWeaponCost.Text = String.Format("{0:###,###,##0¥}", objWeapon.TotalCost);
				lblWeaponConceal.Text = objWeapon.CalculatedConcealability();
				lblWeaponDamage.Text = objWeapon.CalculatedDamage(intUseSTR);
				lblWeaponAccuracy.Text = objWeapon.TotalAccuracy.ToString();
				lblWeaponRC.Text = objWeapon.TotalRC;
				lblWeaponAP.Text = objWeapon.TotalAP;
				lblWeaponReach.Text = objWeapon.TotalReach.ToString();
				lblWeaponMode.Text = objWeapon.CalculatedMode;
				lblWeaponAmmo.Text = objWeapon.CalculatedAmmo();
				lblWeaponSlots.Text = objWeapon.AccessoryMounts;
				lblWeaponDicePool.Text = objWeapon.DicePool;
				tipTooltip.SetToolTip(lblWeaponDicePool, objWeapon.DicePoolTooltip);
				tipTooltip.SetToolTip(lblWeaponRC, objWeapon.RCToolTip);
		}
		public void lblWeaponSource_Click(object sender, EventArgs e)
		{
			CommonFunctions _objFunctions = new CommonFunctions();
			_objFunctions.OpenPDF(lblWeaponSource.Text);
		}
	}
}
