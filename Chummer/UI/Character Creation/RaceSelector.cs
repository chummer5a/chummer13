using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Chummer.Backend.Character_Creation;
using Chummer.Backend.Datastructures;

namespace Chummer.UI.Character_Creation
{
    public partial class RaceSelector : UserControl
    {
	    private Gate gate = new Gate();
        private AbstractCharacterSetupInfo _setupInfo;
        public RaceSelector()
        {
            InitializeComponent();
			

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
			cboCategory.ValueMember = "Guid";
			cboCategory.DisplayMember = "DisplayName";
			cboCategory.DataSource = value.CategoryList;
			
			lstMetatypes.ValueMember = "Guid";
			lstMetatypes.DisplayMember = "DisplayName";
			lstMetatypes.DataSource = value.MetatypeList;


			lstMetavariants.ValueMember = "Guid";
			lstMetavariants.DisplayMember = "DisplayName";
			lstMetavariants.DataSource = value.MetavariantList;
            
            value.PropertyChanged += ValueOnPropertyChanged;

            
        }

	    private void ValueOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
	    {
		    using (gate.Lock())
		    {
			    if (propertyChangedEventArgs.PropertyName == nameof(AbstractCharacterSetupInfo.MetatypeList))
			    {
				    lstMetatypes.DataSource = null;
					lstMetatypes.ValueMember = "Guid";
					lstMetatypes.DisplayMember = "DisplayName";
					lstMetatypes.DataSource = _setupInfo.MetatypeList;
				    lstMetatypes.SelectedItem = _setupInfo.SelectedMetatype;
			    }
			    if (propertyChangedEventArgs.PropertyName == nameof(AbstractCharacterSetupInfo.MetavariantList))
			    {
					lstMetavariants.DataSource = null;
					lstMetavariants.ValueMember = "Guid";
					lstMetavariants.DisplayMember = "DisplayName";
					lstMetavariants.DataSource = _setupInfo.MetavariantList;
					lstMetavariants.SelectedItem = _setupInfo.SelectedMetavariant;
				}

			    if (propertyChangedEventArgs.PropertyName == nameof(AbstractCharacterSetupInfo.CategoryList))
			    {
				    cboCategory.DataSource = null;
					cboCategory.ValueMember = "Guid";
					cboCategory.DisplayMember = "DisplayName";
					cboCategory.DataSource = _setupInfo.CategoryList;
				    cboCategory.SelectedItem = _setupInfo.SelectedCategory;
				    //cboCategory.ResetBindings();
			    }

			    if (propertyChangedEventArgs.PropertyName == nameof(AbstractCharacterSetupInfo.SelectedMetatype))
			    {
				    lstMetatypes.SelectedItem = _setupInfo.SelectedMetatype;
			    }

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
            if (_setupInfo != null && !gate.Locked)
            {
                _setupInfo.SelectedCategory = (GuidItem) cboCategory.SelectedItem;
            }
        }

        private void lstMetatypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_setupInfo != null && !gate.Locked)
            {
                _setupInfo.SelectedMetatype = (GuidItem)lstMetatypes.SelectedItem;
            }
        }

		private void lstMetavariants_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_setupInfo != null && !gate.Locked)
			{
				_setupInfo.SelectedMetavariant = (GuidItem) lstMetavariants.SelectedItem;
			}
		}
	}
}
