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
    public partial class RaceSelector : UserControl
    {
        private AbstractCharacterSetupInfo _setupInfo;
        public RaceSelector()
        {
            InitializeComponent();


            cboCategory.ValueMember = "Guid";
            cboCategory.DisplayMember = "DisplayName";
            lstMetatypes.ValueMember = "Guid";
            lstMetatypes.DisplayMember = "DisplayName";
            

           
        }

        public AbstractCharacterSetupInfo SetupInfo
        {
            get { return _setupInfo; }
            set
            {
                if (_setupInfo != null) RemoveBindings(_setupInfo);

                if (value != null) SetBindings(value);
                _setupInfo = value;
            }
        }

        private void SetBindings(AbstractCharacterSetupInfo value)
        {
            //cboCategory.ValueMember = "Guid";
            //cboCategory.DisplayMember = "DisplayName";
            cboCategory.DataSource = value.CategoryList;
            cboCategory.ResetBindings();
            //lstMetatypes.ValueMember = "Guid";
            //lstMetatypes.DisplayMember = "DisplayName";
            lstMetatypes.DataSource = value.MetatypeList;
            //lstMetatypes.ResetBindings();

            value.PropertyChanged += ValueOnPropertyChanged;

            
        }

        private void ValueOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(AbstractCharacterSetupInfo.MetatypeList))
            {
                lstMetatypes.DataSource = new List<GuidItem>(); //As it is sorta kinda same list, change to other to force update (nfi why it skips)
                lstMetatypes.DataSource = _setupInfo.MetatypeList;
            }

            if (propertyChangedEventArgs.PropertyName == nameof(AbstractCharacterSetupInfo.CategoryList))
            {
                cboCategory.DataSource = new List<GuidItem>();
                cboCategory.DataSource = _setupInfo.CategoryList;
                cboCategory.ResetBindings();
            }

        }

        private void RemoveBindings(AbstractCharacterSetupInfo setupInfo)
        {
            cboCategory.DataSource = null;
            cboCategory.Items.Clear();
            lstMetatypes.DataSource = null;
            lstMetatypes.Items.Clear();

            setupInfo.PropertyChanged -= ValueOnPropertyChanged;

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_setupInfo != null)
            {
                _setupInfo.SelectedCategory = (GuidItem) cboCategory.SelectedItem;
            }
        }

        private void lstMetatypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_setupInfo != null)
            {
                _setupInfo.SelectedMetatype = (GuidItem)lstMetatypes.SelectedItem;
            }
        }
    }
}
