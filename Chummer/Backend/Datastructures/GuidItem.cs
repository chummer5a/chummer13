using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Chummer.Backend.Datastructures
{
    [DebuggerDisplay("{DisplayName}")]
	public class GuidItem
	{
		public GuidItem(string displayName) : this(displayName, Guid.NewGuid())
		{ }

		public GuidItem(string displayName, Guid guid)
		{
			DisplayName = displayName;
			Guid = guid;
		}

		public string DisplayName { get; }
		public Guid Guid { get; }

	    public override bool Equals(object obj)
	    {
	        return obj is GuidItem && ((GuidItem) obj).Guid == Guid;

	    }
	}
}
