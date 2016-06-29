using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Chummer.Backend.Datastructures;

namespace Chummer.Backend.Character_Creation
{
	public abstract class AbstractCharacterSetupInfo : INotifyPropertyChanged
	{
        public abstract CharacterBuildMethod BuildMethod { get; set; }

		//User options always "visible"
		/// <summary>
		/// How much karma does the player have for construction
		/// </summary>
		public abstract int Karma { get; set; }
		
		/// <summary>
		/// How much base nuyen does the player have for construction
		/// </summary>
		public abstract int BonusNuyen { get; set; }

		/// <summary>
		/// What is the max rating of gear the player can aquire
		/// </summary>
		public abstract int MaxRating { get; set; }

		/// <summary>
		/// Ignore the rules related to creating a character?
		/// </summary>
		public abstract bool IgnoreRules { get; set; }

		public abstract GuidItem SelectedCategory { get; set; }
		public abstract GuidItem SelectedMetatype { get; set; }
		public abstract GuidItem SelectedMetavarian { get; set; }

		public abstract IReadOnlyCollection<GuidItem> CategoryList { get; }
		public abstract IReadOnlyCollection<GuidItem> MetatypeList { get; }
		public abstract IReadOnlyCollection<GuidItem> MetavariantList { get; }
		
		public abstract GuidItem SelectedGameplayOption { get; set; }
		public abstract IReadOnlyCollection<GuidItem> GameplayOptionList { get; }

		public event PropertyChangedEventHandler PropertyChanged;

		// List of actions required to implement
		protected abstract IEnumerable<CharacterSetupAction> SetupActions();

		private List<CharacterSetupAction> GetAllActions()
		{
			List<CharacterSetupAction> actions = SetupActions().ToList();

			actions.Add(new BaseSetupAction(Karma, BonusNuyen, MaxRating, IgnoreRules));

			return actions;
		}

		public CompiledCharacterSetupInfo Compile()
		{
			return new CompiledCharacterSetupInfo(GetAllActions());
		}

	    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	    {
	        PropertyChanged?.Invoke(this, e);
	    }
	}
}
