using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Chummer.Backend.Data.Items;
using Chummer.Backend.Data.Sources.Xml;
using Chummer.Backend.Datastructures;

namespace Chummer.Backend.Character_Creation
{
	public class PriorityBasedCharacterSetupInfo : AbstractCharacterSetupInfo
	{
	    private readonly ICreationData _dataSource;
	    private int _karma;
		private int _bonusNuyen;
		private int _maxRating;
		private bool _ignoreRules;

	    private readonly PriorityTable _priorityTableImplentation;

		private readonly OptionListWrapper<GuidItem> _category = new OptionListWrapper<GuidItem>();
		private readonly OptionListWrapper<GuidItem> _metatype = new OptionListWrapper<GuidItem>();
		private readonly OptionListWrapper<GuidItem> _metavariant = new OptionListWrapper<GuidItem>();

		private readonly OptionListWrapper<GuidItem> _gameplayOption = new OptionListWrapper<GuidItem>();
	    private int _sumToTenValue = 10;
	    private CharacterBuildMethod _buildMethod;
	    private IReadOnlyList<MetatypeData.AttributesData> _attributes;

	    public int SumToTenValue
	    {
	        get { return _sumToTenValue; }
	        set { MaybeNotifyChanged(ref _sumToTenValue, value); }
	    }

	    internal PriorityBasedCharacterSetupInfo(ICreationData dataSource)
		{
            _dataSource = dataSource;

            
            _category.CollectionChanged += CategoryOnCollectionChanged;
            _category.SelectedItemChangedEvent += CategoryOnSelectedItemChangedEvent;

            _metatype.CollectionChanged += MetatypeOnCollectionChanged;
            _metatype.SelectedItemChangedEvent += MetatypeOnSelectedItemChangedEvent;

            _metavariant.CollectionChanged += MetavariantOnCollectionChanged;
            _metavariant.SelectedItemChangedEvent += MetavariantOnSelectedItemChangedEvent;

            _gameplayOption.CollectionChanged += GameplayOptionOnCollectionChanged;
            _gameplayOption.SelectedItemChangedEvent += GameplayOptionOnSelectedItemChangedEvent;

            
            
            foreach (GameplayOptionData data in _dataSource.GameplayOption)
            {
                GuidItem item = new GuidItem(data.DisplayName, data.ItemId);
                _gameplayOption.Add(item);

                if (data.Default)
                {
                    _gameplayOption.SelectedItem = item;
                }
            }

            _priorityTableImplentation = new PriorityTable(_dataSource, this, true);
            _priorityTableImplentation.HeritageOptions.SelectedItemChangedEvent += selected =>
            {
                UpdateMetatypes();
                NotifyChanged(nameof(SelectedHeritage));
            };
            _priorityTableImplentation.AttributesOptions.SelectedItemChangedEvent += selected =>
            {
                NotifyChanged(nameof(SelectedAttributes));
            };
            _priorityTableImplentation.TalentOptions.SelectedItemChangedEvent += selected =>
            {
                NotifyChanged(nameof(SelectedTalent));
            };
            _priorityTableImplentation.SkillsOptions.SelectedItemChangedEvent += selected =>
            {
                NotifyChanged(nameof(SelectedSkills));
            };
            _priorityTableImplentation.ResourcesOptions.SelectedItemChangedEvent += selected =>
            {
                NotifyChanged(nameof(SelectedResources));
            };

		    UpdateMetatypes();//_category.AddRange(_dataSource.Categories);

        }

        private void UpdateMetatypes()
	    {
            //this would be somewhat easy to change to get all selected. 
	        List<HeritageData> pickData = HeritagesList();

			//All possible metatype/variants at current pick
	        List<MetatypeData> metatypeData = pickData.Select(x => _dataSource.Metatypes[x.Metatype])
		        .ToList();

			_category.ReplaceWith(_dataSource.Categories.Where(x => metatypeData.Any(m => m.Categoryid == x.Guid)));

			_metatype.ReplaceWith(
	            metatypeData				
				// top level (type not variant) and part of the selected category
				.Where(m => m.Parrent == Guid.Empty && m.Categoryid == SelectedCategory.Guid) 
				.Select(x => new GuidItem(x.DisplayName, x.Id)));

	        

	        //Update metavariants that is visible (rmbr "None") 
	        //Make OptionWraper more inteligent about events and make sure things don't update more often than required
	        //throw new NotImplementedException();
	    }

	    private List<HeritageData> HeritagesList()
	    {
			//select the list of metatype/variants picks (not the metatype data) available to the current priority selection.
	        return _dataSource.Picks[_dataSource.PriorityEntries[SelectedHeritage.Guid].PickId].Heritages;
	    }

	    private void GameplayOptionOnSelectedItemChangedEvent(GuidItem selected)
	    {
	        GameplayOptionData option = _dataSource.GameplayOption[selected.Guid];
	        Karma = option.Karma;
	        MaxRating = option.MaxAvailability;
            NotifyChanged(nameof(SelectedGameplayOption));
	    }

	    private void GameplayOptionOnCollectionChanged(object collection, NotifyCollectionChangedEventArgs e)
	    {
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(GameplayOptionList)));
        }

        private void MetavariantOnSelectedItemChangedEvent(GuidItem selected)
	    {
            NotifyChanged(nameof(SelectedMetavariant));
	        throw new NotImplementedException();
	    }

	    private void MetavariantOnCollectionChanged(object collection, NotifyCollectionChangedEventArgs e)
	    {
	        OnPropertyChanged(new PropertyChangedEventArgs(nameof(MetavariantList)));
        }

	    private void MetatypeOnSelectedItemChangedEvent(GuidItem selected)
	    {
            NotifyChanged(nameof(SelectedMetatype));
	        //throw new NotImplementedException();
            if(selected == null)
				return;
	        

	        MetatypeData data = _dataSource.Metatypes[selected.Guid];
	        _attributes = data.Attributes;
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Attributes)));
	    }

	    private void MetatypeOnCollectionChanged(object collection, NotifyCollectionChangedEventArgs e)
	    {
	        OnPropertyChanged(new PropertyChangedEventArgs(nameof(MetatypeList)));
	    }

	    private void CategoryOnSelectedItemChangedEvent(GuidItem selected)
	    {
            NotifyChanged(nameof(SelectedCategory));
            //_metatype.ReplaceWith(_dataSource.Metatypes.Where(metatype => metatype.Categoryid == selected.Guid).Select(m => new GuidItem(m.DisplayName, m.Id)));
	        UpdateMetatypes();
	    }

	    private void CategoryOnCollectionChanged(object collection, NotifyCollectionChangedEventArgs e)
	    {
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(CategoryList)));
        }

        public override CharacterBuildMethod BuildMethod
	    {
	        get { return _buildMethod; }
	        set { _buildMethod = value; }
	    }

	    public override int Karma
		{
			get { return _karma; }
			set { MaybeNotifyChanged(ref _karma, value); }
		}

		public override int BonusNuyen
		{
			get { return _bonusNuyen; }
			set { MaybeNotifyChanged(ref _bonusNuyen, value); }
		}

		public override int MaxRating
		{
			get { return _maxRating; }
			set { MaybeNotifyChanged(ref _maxRating, value); }
		}

		public override bool IgnoreRules
		{
			get { return _ignoreRules; }
			set { MaybeNotifyChanged(ref _ignoreRules, value); }
		}

		public override GuidItem SelectedCategory
		{
			get { return _category.SelectedItem; }
		    set
		    {
		        if ((_category.SelectedItem == null && value != null) ||
                    (_category.SelectedItem != null && value == null) ||
                    (_category.SelectedItem != null && value != null && !value.Equals(_category.SelectedItem)))
                {
                    _category.SelectedItem = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedCategory)));
                }
            }
		}

		public override GuidItem SelectedMetatype
		{
			get { return _metatype.SelectedItem; }
		    set
		    {
                if ((_metatype.SelectedItem == null && value != null) ||
                    (_metatype.SelectedItem != null && value == null) ||
                    (_metatype.SelectedItem != null && value != null && !value.Equals(_metatype.SelectedItem)))
                {
                    _metatype.SelectedItem = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedMetatype)));
                }
            }
		}

		public override GuidItem SelectedMetavariant
		{
			get { return _metavariant.SelectedItem; }
		    set
		    {
		        if ((_metavariant.SelectedItem == null && value != null) ||
		            (_metavariant.SelectedItem != null && value == null) ||
		            (_metavariant.SelectedItem != null && value != null && !value.Equals(_metavariant.SelectedItem)))
		        {
		            _metavariant.SelectedItem = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedMetavariant)));
		        }
		    }
		}

		public override IReadOnlyCollection<GuidItem> CategoryList => _category.ReadOnly;

		public override IReadOnlyCollection<GuidItem> MetatypeList => _metatype.ReadOnly;

		public override IReadOnlyCollection<GuidItem> MetavariantList => _metavariant.ReadOnly;

		public override GuidItem SelectedGameplayOption
		{
			get { return _gameplayOption.SelectedItem; }
			set { _gameplayOption.SelectedItem = value; }
		}

		public override IReadOnlyCollection<GuidItem> GameplayOptionList => _gameplayOption.ReadOnly;

	    internal override IReadOnlyList<MetatypeData.AttributesData> Attributes
	    {
	        get { return _attributes; }
	    }

	    public GuidItem SelectedHeritage
	    {
            get { return _priorityTableImplentation.HeritageOptions.SelectedItem; }
	        set { _priorityTableImplentation.HeritageOptions.SelectedItem = value; }
	    }

	    public IReadOnlyCollection<GuidItem> HeritageList => _priorityTableImplentation.HeritageOptions.ReadOnly;

        public GuidItem SelectedAttributes
        {
            get { return _priorityTableImplentation.AttributesOptions.SelectedItem; }
            set { _priorityTableImplentation.AttributesOptions.SelectedItem = value; }
        }

        public IReadOnlyCollection<GuidItem> AttributesList => _priorityTableImplentation.AttributesOptions.ReadOnly;

        public GuidItem SelectedTalent
        {
            get { return _priorityTableImplentation.TalentOptions.SelectedItem; }
            set { _priorityTableImplentation.TalentOptions.SelectedItem = value; }
        }

        public IReadOnlyCollection<GuidItem> TalentList => _priorityTableImplentation.TalentOptions.ReadOnly;

        public GuidItem SelectedSkills
        {
            get { return _priorityTableImplentation.SkillsOptions.SelectedItem; }
            set { _priorityTableImplentation.SkillsOptions.SelectedItem = value; }
        }

        public IReadOnlyCollection<GuidItem> SkillsList => _priorityTableImplentation.SkillsOptions.ReadOnly;

        public GuidItem SelectedResources
        {
            get { return _priorityTableImplentation.ResourcesOptions.SelectedItem; }
            set { _priorityTableImplentation.ResourcesOptions.SelectedItem = value; }
        }

        public IReadOnlyCollection<GuidItem> ResourcesList => _priorityTableImplentation.ResourcesOptions.ReadOnly;

        protected override IEnumerable<CharacterSetupAction> SetupActions()
		{
			throw new System.NotImplementedException();
		}

	    private void MaybeNotifyChanged<T>(ref T own, T value, [CallerMemberName] string name = "")
	    {
	        if ((own == null && value != null) || (own != null && value == null) || (own != null && value != null && !value.Equals(own))) 
	        {
                own = value;
                OnPropertyChanged(new PropertyChangedEventArgs(name));
	        }
	    }

	    private void NotifyChanged([CallerMemberName] string name = "")
	    {
            OnPropertyChanged(new PropertyChangedEventArgs(name));
        }
    }
}