using System;
using System.Collections.Generic;

namespace Chummer.Backend.Data.Infrastructure
{
    public interface IChummerDataSource<out T> : IEnumerable<T>
    {
        T this[Guid key] { get; }
    }
}
