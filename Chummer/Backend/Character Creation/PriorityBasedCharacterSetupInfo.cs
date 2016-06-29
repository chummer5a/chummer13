using System.Collections.Generic;
using Chummer.Backend.Datastructures;

namespace Chummer.Backend.Character_Creation
{
	class PriorityBasedCharacterSetupInfo : AbstractCharacterSetupInfo
	{
		private int _karma;
		private int _nuyen;
		private int _maxRating;
		private bool _ignoreRules;

		private readonly OptionListWrapper<GuidItem> _category = new OptionListWrapper<GuidItem>();
		private OptionListWrapper<GuidItem> _metatype = new OptionListWrapper<GuidItem>();
		private OptionListWrapper<GuidItem> _metavariant = new OptionListWrapper<GuidItem>();

		private OptionListWrapper<GuidItem> _gameplayOption = new OptionListWrapper<GuidItem>();

		public PriorityBasedCharacterSetupInfo()
		{
			
		}

		public override int Karma
		{
			get { return _karma; }
			set { _karma = value; }
		}

		public override int Nuyen
		{
			get { return _nuyen; }
			set { _nuyen = value; }
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
	}
}