using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Chummer.Backend.Datastructures
{
	class OptionListWrapper<T> : IList<T>, INotifyCollectionChanged
	{
		private readonly List<T> _listImplementation;
		private IReadOnlyList<T> _readonlyLazy;
		private T _selectedItem;

		public delegate void SelectedChanged(T selected);
		public delegate void ListChanged();

		public event SelectedChanged SelectedItemChangedEvent;
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public T SelectedItem
		{
		    get
		    {
                return _selectedItem;
		    }
            set
			{
			    if (_listImplementation.Contains(value))
			    {
			        _selectedItem = value;
                    SelectedItemChangedEvent?.Invoke(value);
			    }
			    else
			    {
			        throw new InvalidOperationException("Value not in list of Values");
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
		    int count = _listImplementation.Count;
            _listImplementation.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new List<T> {item}));
		    if (count == 0)
		    {
		        SelectedItem = _listImplementation[0];
                SelectedItemChangedEvent?.Invoke(SelectedItem);
		    }
        }

        public void AddRange(IEnumerable<T> items)
        {
	        var item2 = items.ToList();
            int count = _listImplementation.Count;
            _listImplementation.AddRange(item2);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item2));
            if (count == 0)
            {
                SelectedItem = _listImplementation[0];
                SelectedItemChangedEvent?.Invoke(SelectedItem);
            }

        }

		public void Clear()
		{
            _listImplementation.Clear();
            _selectedItem = default(T);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            SelectedItemChangedEvent?.Invoke(SelectedItem);

		}

		public void ReplaceWith(IEnumerable<T> items)
	    {
			var oldItems = new List<T>(_listImplementation);
			var newItems = new List<T>(items);
            _listImplementation.Clear();
            _listImplementation.AddRange(newItems);
            
            if (!_listImplementation.Contains(_selectedItem))
            {
                FindNewSelected();
            }
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItems, oldItems));
        }

	    private void FindNewSelected()
	    {
	        if (_listImplementation.Count > 0)
	        {
	            SelectedItem = _listImplementation[0];
	            SelectedItemChangedEvent?.Invoke(SelectedItem);
	        }
	        else
	        {
	            _selectedItem = default(T);
	            SelectedItemChangedEvent?.Invoke(_selectedItem);
	        }
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
		    bool same = (item != null && item.Equals(SelectedItem)) || (item == null && SelectedItem == null);
		    bool ret = _listImplementation.Remove(item);
            if(same) FindNewSelected();

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new List<T> {item}));
            return ret;
		}

		public int Count => _listImplementation.Count;

		public bool IsReadOnly => (_listImplementation as IList<T>).IsReadOnly;
		
		public int IndexOf(T item)
		{
			return _listImplementation.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
            _listImplementation.Insert(index, item);
		    if (_listImplementation.Count == 1)
		    {
		        SelectedItem = _listImplementation[0];
                SelectedItemChangedEvent?.Invoke(SelectedItem);
		    }
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new List<T> {item}, index));

		}

        public void RemoveAt(int index)
		{
            throw new NotImplementedException();

        }

		public T this[int index]
		{
			get { return _listImplementation[index]; }
			set
			{
                throw new NotImplementedException();

            }
        }

		
		
		
	}
}
