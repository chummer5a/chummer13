using System;
using Chummer.Backend._Character;

namespace Chummer.Backend.Character_Creation
{
	internal class BaseSetupAction : CharacterSetupAction
	{
		private bool ignoreRules;
		private int karma;
		private int maxRating;
		private int nuyen;
		private CharacterSetupAction _characterSetupActionImplementation;

		public BaseSetupAction(int karma, int nuyen, int maxRating, bool ignoreRules)
		{
			this.karma = karma;
			this.nuyen = nuyen;
			this.maxRating = maxRating;
			this.ignoreRules = ignoreRules;
		}

		public override void Apply(ICharacter character)
		{
			throw new NotImplementedException();
		}

		public override void Remove(ICharacter character)
		{
			throw new NotImplementedException();
		}

		internal override bool Equals(CharacterSetupAction other)
		{
			throw new NotImplementedException();
		}
	}
}