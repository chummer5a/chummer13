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
using System.Windows.Forms;
using System.Xml;
using Chummer.Backend.Character_Creation;
using Chummer.Backend.Data.Infrastructure;
using Chummer.Backend.Data.Items;

namespace Chummer.UI.Character_Creation
{
    public partial class frmSelectBuildMethod : Form
    {
        public AbstractCharacterSetupInfo SelectedCharacterSetupMethod => _buildInfoTypes[(string) cboBuildMethod.SelectedValue].SetupInfo;

        private readonly CharacterOptions _objOptions;
        private readonly IChummerDataSource<GameplayOptionData> _gameplayDataSource;
        private readonly IChummerDataSource<PriorityTableEntryData> _priorityTableEntryDataSource;
        private readonly Dictionary<string, BuildGroup> _buildInfoTypes;
		int intQualityLimits = 0;
	    int intNuyenBP = 0;

		#region Control Events
		public frmSelectBuildMethod(CharacterOptions objOptions, IChummerDataSource<GameplayOptionData> gameplayDataSource, IChummerDataSource<PriorityTableEntryData> priorityTableEntryDataSource)
        {
		    _objOptions = objOptions;
		    _gameplayDataSource = gameplayDataSource;
		    _priorityTableEntryDataSource = priorityTableEntryDataSource;
		    InitializeComponent();
            LanguageManager.Instance.Load(GlobalOptions.Instance.Language, this);

            toolTip1.SetToolTip(chkIgnoreRules, LanguageManager.Instance.GetString("Tip_SelectKarma_IgnoreRules"));

            //
            _buildInfoTypes = new Dictionary<string, BuildGroup>()
            {
                {"LifeModule", new BuildGroup(this, null, "String_SelectBP_LifeModuleSummary")},
                {
                    "Priority",
                    new BuildGroup(this,
                        new PriorityBasedCharacterSetupInfo(_gameplayDataSource, _priorityTableEntryDataSource) {BuildMethod = CharacterBuildMethod.Priority},
                        "String_SelectBP_PrioritySummary")
                },
                {"Karma", new BuildGroup(this, null, "String_SelectBP_KarmaSummary")},
                {
                    "SumtoTen",
                    new BuildGroup(this,
                        new PriorityBasedCharacterSetupInfo(_gameplayDataSource, _priorityTableEntryDataSource) {BuildMethod = CharacterBuildMethod.SumtoTen},
                        "String_SelectBP_PrioritySummary")
                },
            };

            // Populate the Build Method list.
            List<ListItem> lstBuildMethod = new List<ListItem>();
            if (GlobalOptions.Instance.LifeModuleEnabled)
	        {
		        lstBuildMethod.Add(ListItem.Auto("LifeModule", "String_LifeModule"));
			}

	        lstBuildMethod.Add(ListItem.Auto("Priority", "String_Priority"));
            lstBuildMethod.Add(ListItem.Auto("Karma", "String_Karma"));
            lstBuildMethod.Add(ListItem.Auto("SumtoTen", "String_SumtoTen"));

            //Setup databinding
            cboBuildMethod.ValueMember = "Value";
            cboBuildMethod.DisplayMember = "Name";
            cboBuildMethod.DataSource = lstBuildMethod;
            

            

            
            cboBuildMethod.SelectedValue = _objOptions.BuildMethod;
            
            //if (blnUseCurrentValues)
            //{
            //    cboBuildMethod.SelectedValue = "Karma";
            //    nudKarma.Value = objCharacter.BuildKarma;

            //    nudMaxAvail.Value = objCharacter.MaximumAvailability;

            //    cboBuildMethod.Enabled = false;
            //}
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
	        this.DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboBuildMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = _buildInfoTypes[(string)cboBuildMethod.SelectedValue];
            if (selected.SetupInfo == null) return;

            nudSumtoTen.Visible = selected.SetupInfo.BuildMethod == CharacterBuildMethod.SumtoTen;

            nudSumtoTen.DataBindings.Clear();
            nudKarma.DataBindings.Clear();
            nudMaxAvail.DataBindings.Clear();
            chkIgnoreRules.DataBindings.Clear();

            if (selected.SetupInfo.BuildMethod == CharacterBuildMethod.SumtoTen)
            {
                nudSumtoTen.DataBindings.Add("Value", selected.SetupInfo, nameof(PriorityBasedCharacterSetupInfo.SumToTenValue));
            }

            nudKarma.DataBindings.Add("Value", selected.SetupInfo, nameof(AbstractCharacterSetupInfo.Karma));
            nudMaxAvail.DataBindings.Add("Value", selected.SetupInfo, nameof(AbstractCharacterSetupInfo.MaxRating));

            selected.SetupInfo.BonusNuyen = 0;

            lblDescription.Text = selected.Description;

            cboGamePlay.ValueMember = "Guid";
            cboGamePlay.DisplayMember = "DisplayName";
            cboGamePlay.DataSource = selected.SetupInfo.GameplayOptionList;
        }

        private void frmSelectBuildMethod_Load(object sender, EventArgs e)
        {
            this.Height = cmdOK.Bottom + 40;
            cboBuildMethod_SelectedIndexChanged(this, e);
        }
        #endregion

        private void cboGamePlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load the Priority information.
            XmlDocument objXmlDocumentGameplayOption = XmlManager.Instance.Load("gameplayoptions.xml");
            XmlNode objXmlGameplayOption = objXmlDocumentGameplayOption.SelectSingleNode("/chummer/gameplayoptions/gameplayoption[name = \"" + cboGamePlay.Text + "\"]");
			nudMaxAvail.Value = Convert.ToInt32(objXmlGameplayOption["maxavailability"].InnerText);
			intQualityLimits = Convert.ToInt32(objXmlGameplayOption["karma"].InnerText);
	        intNuyenBP = Convert.ToInt32(objXmlGameplayOption["maxnuyen"].InnerText);
        }

        private class BuildGroup
        {
            private frmSelectBuildMethod parent;
            public AbstractCharacterSetupInfo SetupInfo { get; }

            public string Description { get; }

            public BuildGroup(frmSelectBuildMethod parent, AbstractCharacterSetupInfo setupInfo, string desc)
            {
                this.parent = parent;
                Description = LanguageManager.Instance.GetString(desc);
                this.SetupInfo = setupInfo;
            }
        }
    }
}