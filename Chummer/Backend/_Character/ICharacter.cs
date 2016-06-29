using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chummer.Backend.Character_Creation;

namespace Chummer.Backend._Character
{
	public interface ICharacter
	{
		CompiledCharacterSetupInfo SetupInfo { get; set; }
	}
}
