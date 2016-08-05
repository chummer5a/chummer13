using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chummer.Backend.Character_Creation;
using Chummer.Backend.Datastructures;

namespace Chummer.UI.Character_Creation
{
    public partial class PriorityBuildSelector : UserControl
    {
        private PriorityBasedCharacterSetupInfo _setupInfo;

        public PriorityBuildSelector()
        {
            InitializeComponent();

        }

        public PriorityBasedCharacterSetupInfo SetupInfo
        {
            get { return _setupInfo; }
            set
            {
                if(_setupInfo != null) _setupInfo.PropertyChanged -= SetupInfoOnPropertyChanged;
                raceSelector1.SetupInfo = value;
                _setupInfo = value;

                if (_setupInfo != null)
                {
                    _setupInfo.PropertyChanged += SetupInfoOnPropertyChanged;
                    attributeDisplay.SetContents(_setupInfo.Attributes);

                    cboHeritage.SelectedIndexChanged -= cboHeritage_SelectedIndexChanged;
                    cboAttributes.SelectedIndexChanged -= cboAttributes_SelectedIndexChanged;
                    cboTalent.SelectedIndexChanged -= cboTalent_SelectedIndexChanged;
                    cboSkills.SelectedIndexChanged -= cboSkills_SelectedIndexChanged;
                    cboResources.SelectedIndexChanged -= cboResources_SelectedIndexChanged;
                    
                    


                    cboHeritage.ValueMember = "Guid";
                    cboHeritage.DisplayMember = "DisplayName";
                    cboHeritage.DataSource = _setupInfo.HeritageList;

                    cboAttributes.ValueMember = "Guid";
                    cboAttributes.DisplayMember = "DisplayName";
                    cboAttributes.DataSource = _setupInfo.AttributesList;

                    cboTalent.ValueMember = "Guid";
                    cboTalent.DisplayMember = "DisplayName";
                    cboTalent.DataSource = _setupInfo.TalentList;

                    cboSkills.ValueMember = "Guid";
                    cboSkills.DisplayMember = "DisplayName";
                    cboSkills.DataSource = _setupInfo.SkillsList;

                    cboResources.ValueMember = "Guid";
                    cboResources.DisplayMember = "DisplayName";
                    cboResources.DataSource = _setupInfo.ResourcesList;

                    cboHeritage.SelectedItem = _setupInfo.SelectedHeritage;
                    cboAttributes.SelectedItem = _setupInfo.SelectedAttributes;
                    cboTalent.SelectedItem = _setupInfo.SelectedTalent;
                    cboSkills.SelectedItem = _setupInfo.SelectedSkills;
                    cboResources.SelectedItem = _setupInfo.SelectedResources;

                    cboHeritage.SelectedIndexChanged += cboHeritage_SelectedIndexChanged;
                    cboAttributes.SelectedIndexChanged += cboAttributes_SelectedIndexChanged;
                    cboTalent.SelectedIndexChanged += cboTalent_SelectedIndexChanged;
                    cboSkills.SelectedIndexChanged += cboSkills_SelectedIndexChanged;
                    cboResources.SelectedIndexChanged += cboResources_SelectedIndexChanged;



                }
            }
        }

        private void SetupInfoOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(AbstractCharacterSetupInfo.Attributes):
                    attributeDisplay.SetContents(_setupInfo.Attributes);
                    break;
                case nameof(PriorityBasedCharacterSetupInfo.SelectedHeritage):
                    cboHeritage.SelectedItem = _setupInfo.SelectedHeritage;
                    break;
                case nameof(PriorityBasedCharacterSetupInfo.SelectedAttributes):
                    cboAttributes.SelectedItem = _setupInfo.SelectedAttributes;
                    break;
                case nameof(PriorityBasedCharacterSetupInfo.SelectedTalent):
                    cboTalent.SelectedItem = _setupInfo.SelectedTalent;
                    break;
                case nameof(PriorityBasedCharacterSetupInfo.SelectedSkills):
                    cboSkills.SelectedItem = _setupInfo.SelectedSkills;
                    break;
                case nameof(PriorityBasedCharacterSetupInfo.SelectedResources):
                    cboResources.SelectedItem = _setupInfo.SelectedResources;
                    break;
            }
            //if (args.PropertyName == nameof(AbstractCharacterSetupInfo.SelectedMetatype))
            //{

            //}
            //else if(args.PropertyName == nameof(AbstractCharacterSetupInfo.SelectedMetavariant))
            //{ }
        }

        //something clever can probably be done here to turn those 5 into one. IDK
        private void cboHeritage_SelectedIndexChanged(object sender, EventArgs e)
        {
            _setupInfo.SelectedHeritage = (GuidItem)cboHeritage.SelectedItem;
        }

        private void cboAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _setupInfo.SelectedAttributes = (GuidItem)cboAttributes.SelectedItem;
        }

        private void cboTalent_SelectedIndexChanged(object sender, EventArgs e)
        {
            _setupInfo.SelectedTalent = (GuidItem)cboTalent.SelectedItem;
        }

        private void cboSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            _setupInfo.SelectedSkills = (GuidItem)cboSkills.SelectedItem;
        }

        private void cboResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            _setupInfo.SelectedResources = (GuidItem)cboResources.SelectedItem;
        }
    }
}
