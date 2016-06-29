using System.Collections.Generic;
using System.Linq;
using Chummer.Backend._Character;

namespace Chummer.Backend.Character_Creation
{
	public class CompiledCharacterSetupInfo
	{
		private List<CharacterSetupAction> _actions;

		internal CompiledCharacterSetupInfo(List<CharacterSetupAction> actions)
		{
			_actions = actions;
		}

		internal void ApplyTo(ICharacter character)
		{
			List<CharacterSetupAction> oldActions = character?.SetupInfo._actions ?? new List<CharacterSetupAction>();

			List<CharacterSetupAction> applyActions = _actions.Except(oldActions).ToList();
			List<CharacterSetupAction> removeActions = oldActions.Except(_actions).ToList();

			foreach (CharacterSetupAction action in removeActions)
			{
				action.Remove(character);
			}

			foreach (CharacterSetupAction action in applyActions)
			{
				action.Apply(character);
			}
		}
	}
}