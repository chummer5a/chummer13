using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Chummer.Backend.Data.Infrastructure;
using Chummer.Backend.Data.Items;
using Chummer.Backend.Datastructures;

namespace Chummer.Backend.Character_Creation
{
	class PriorityBasedCharacterSetupInfo : AbstractCharacterSetupInfo
	{
	    private readonly IChummerDataSource<GameplayOptionData> _gameplayOptionDataSource;
	    private int _karma;
		private int _bonusNuyen;
		private int _maxRating;
		private bool _ignoreRules;

		private readonly OptionListWrapper<GuidItem> _category = new OptionListWrapper<GuidItem>();
		private readonly OptionListWrapper<GuidItem> _metatype = new OptionListWrapper<GuidItem>();
		private readonly OptionListWrapper<GuidItem> _metavariant = new OptionListWrapper<GuidItem>();

		private readonly OptionListWrapper<GuidItem> _gameplayOption = new OptionListWrapper<GuidItem>();
	    private int _sumToTenValue = 10;
	    private CharacterBuildMethod _buildMethod;

	    public int SumToTenValue
	    {
	        get { return _sumToTenValue; }
	        set { MaybeNotifyChanged(ref _sumToTenValue, value); }
	    }

	    public PriorityBasedCharacterSetupInfo(IChummerDataSource<GameplayOptionData> gameplayOptionDataSource)
		{
            _category.ListChangedEvent += CategoryOnListChangedEvent;
            _category.SelectedItemChangedEvent += CategoryOnSelectedItemChangedEvent;

            _metatype.ListChangedEvent += MetatypeOnListChangedEvent;
            _metatype.SelectedItemChangedEvent += MetatypeOnSelectedItemChangedEvent;

            _metavariant.ListChangedEvent += MetavariantOnListChangedEvent;
            _metavariant.SelectedItemChangedEvent += MetavariantOnSelectedItemChangedEvent;

            _gameplayOption.ListChangedEvent += GameplayOptionOnListChangedEvent;
            _gameplayOption.SelectedItemChangedEvent += GameplayOptionOnSelectedItemChangedEvent;




            _gameplayOptionDataSource = gameplayOptionDataSource;

		    foreach (GameplayOptionData data in _gameplayOptionDataSource)
		    {
		        GuidItem item = new GuidItem(data.DisplayName, data.ItemId);
                _gameplayOption.Add(item);

		        if (data.Default)
		        {
		            _gameplayOption.SelectedItem = item;
		        }
		    }


		}

	    private void GameplayOptionOnSelectedItemChangedEvent(GuidItem selected)
	    {
	        throw new NotImplementedException();
	    }

	    private void GameplayOptionOnListChangedEvent()
	    {
	        throw new NotImplementedException();
	    }

	    private void MetavariantOnSelectedItemChangedEvent(GuidItem selected)
	    {
	        throw new NotImplementedException();
	    }

	    private void MetavariantOnListChangedEvent()
	    {
	        throw new NotImplementedException();
	    }

	    private void MetatypeOnSelectedItemChangedEvent(GuidItem selected)
	    {
	        throw new NotImplementedException();
	    }

	    private void MetatypeOnListChangedEvent()
	    {
	        throw new NotImplementedException();
	    }

	    private void CategoryOnSelectedItemChangedEvent(GuidItem selected)
	    {
	        throw new NotImplementedException();
	    }

	    private void CategoryOnListChangedEvent()
	    {
	        throw new NotImplementedException();
	    }

	    public override CharacterBuildMethod BuildMethod
	    {
	        get { return _buildMethod; }
	        set { _buildMethod = value; }
	    }

	    public override int Karma
		{
			get { return _karma; }
			set { _karma = value; }
		}

		public override int BonusNuyen
		{
			get { return _bonusNuyen; }
			set { _bonusNuyen = value; }
		}

		public override int MaxRating
		{
			get { return _maxRating; }
			set { _maxRating = value; }
		}

		public override bool IgnoreRules
		{
			get { return _ignoreRules; }
			set { _ignoreRules = value; }
		}

		public override GuidItem SelectedCategory
		{
			get { return _category.SelectedItem; }
			set { _category.SelectedItem = value; }
		}

		public override GuidItem SelectedMetatype
		{
			get { return _metatype.SelectedItem; }
			set { _metatype.SelectedItem = value; }
		}

		public override GuidItem SelectedMetavarian
		{
			get { return _metavariant.SelectedItem; }
			set { _metavariant.SelectedItem = value; }
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

    }
}