using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chummer.Backend.Datastructures
{
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
	}
}
