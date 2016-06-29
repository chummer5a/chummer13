using Chummer.Backend._Character;

namespace Chummer.Backend.Character_Creation
{
	public abstract class CharacterSetupAction
	{
		public abstract void Apply(ICharacter character);
		public abstract void Remove(ICharacter character);

		internal abstract bool Equals(CharacterSetupAction other);

	}
}