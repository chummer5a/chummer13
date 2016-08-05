using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chummer.Backend.Character_Creation;

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
                }
            }
        }

        private void SetupInfoOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(AbstractCharacterSetupInfo.Attributes))
            {
                attributeDisplay.SetContents(_setupInfo.Attributes);
            }

            //if (propertyChangedEventArgs.PropertyName == nameof(AbstractCharacterSetupInfo.SelectedMetatype))
            //{

                //}
                //else if(propertyChangedEventArgs.PropertyName == nameof(AbstractCharacterSetupInfo.SelectedMetavariant))
                //{ }

        }
    }
}
