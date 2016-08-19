using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chummer.Backend.Datastructures
{
	class Gate
	{
		private List<GateLocker> _locks = new List<GateLocker>();
		public bool Locked => _locks.Count != 0;

		public IDisposable Lock()
		{
			GateLocker l =  new GateLocker(this);
			_locks.Add(l);
			return l;
		}

		private class GateLocker : IDisposable
		{
			private readonly Gate _gate;

			internal GateLocker(Gate gate)
			{
				_gate = gate;
			}

			public void Dispose()
			{
				_gate._locks.Remove(this);
			}
		}
	}
}
