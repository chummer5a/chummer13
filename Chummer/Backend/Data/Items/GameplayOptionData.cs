using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chummer.Backend.Data.Items
{
	/// <summary>
	/// Specifies a possible gameplay option. 
	/// A gameplay option contains a list of priorities, an availability limit 
	/// and other related information that changes the powerlevel durring play
	/// </summary>
    public class GameplayOptionData
    {
        public Guid ItemId { get; set; }
        public string DisplayName { get; set; }
        public int Karma { get; set; }
        public int MaxAvailability { get; set; }
        public int MaxNuyen { get; set; }
        public int ContactMultiplier { get; set; }
        public bool Default { get; set; }
		public HashSet<Guid> PriorityTableEntries { get; set; }
    }
}
