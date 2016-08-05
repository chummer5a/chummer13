using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chummer.Backend.Datastructures
{
	class OptionListWrapper<T> : IList<T>
	{
		private readonly List<T> _listImplementation;
		private IReadOnlyList<T> _readonlyLazy;
		private T _selectedItem;

		public delegate void SelectedChanged(T selected);
		public delegate void ListChanged();

		public event SelectedChanged SelectedItemChangedEvent;
		public event ListChanged ListChangedEvent;


		public T SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				if (Contains(value))
				{
					_selectedItem = value;
					SelectedItemChangedEvent?.Invoke(value);
				}
				else
				{
					throw new InvalidOperationException("This item does not exist in the collection of options");
				}
			}
		}

		public IReadOnlyList<T> ReadOnly => _readonlyLazy ?? (_readonlyLazy = _listImplementation.AsReadOnly());

		public OptionListWrapper() : this(new List<T>())
		{
			
		}

		public OptionListWrapper(List<T> inner)
		{
			_listImplementation = inner;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _listImplementation.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable) _listImplementation).GetEnumerator();
		}

		public void Add(T item)
		{
			_listImplementation.Add(item);
			ListChangedEvent?.Invoke();
		}

	    public void AddRange(IEnumerable<T> items)
	    {
            _listImplementation.AddRange(items);
            ListChangedEvent?.Invoke();
        }

		public void Clear()
		{
			_listImplementation.Clear();
			ListChangedEvent?.Invoke();
		}

	    public void ReplaceWith(IEnumerable<T> items)
	    {
	        _listImplementation.Clear();
	        _listImplementation.AddRange(items);

            _selectedItem = default(T); //Not sure if first would be better
            ListChangedEvent?.Invoke();
            SelectedItemChangedEvent?.Invoke(_selectedItem);
	    }

		public bool Contains(T item)
		{
			return _listImplementation.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			_listImplementation.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			bool sucess = _listImplementation.Remove(item);
			ListChangedEvent?.Invoke();

			return sucess;
		}

		public int Count
		{
			get { return _listImplementation.Count; }
		}

		public bool IsReadOnly => (_listImplementation as IList<T>).IsReadOnly;

		public int IndexOf(T item)
		{
			return _listImplementation.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			_listImplementation.Insert(index, item);
			ListChangedEvent?.Invoke();
		}

		public void RemoveAt(int index)
		{
			_listImplementation.RemoveAt(index);
			ListChangedEvent?.Invoke();
		}

		public T this[int index]
		{
			get { return _listImplementation[index]; }
			set
			{
				_listImplementation[index] = value;
				ListChangedEvent?.Invoke();
			}
		}
	}
}
