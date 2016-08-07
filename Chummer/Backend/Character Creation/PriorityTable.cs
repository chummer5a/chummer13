using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Chummer.Backend.Data.Items;
using Chummer.Backend.Data.Sources.Xml;
using Chummer.Backend.Datastructures;

namespace Chummer.Backend.Character_Creation
{
    class PriorityTable
    {
        public OptionListWrapper<GuidItem> ResourcesOptions { get; } = new OptionListWrapper<GuidItem>();
        public OptionListWrapper<GuidItem> SkillsOptions { get; } = new OptionListWrapper<GuidItem>();
        public OptionListWrapper<GuidItem> TalentOptions { get; } = new OptionListWrapper<GuidItem>();
        public OptionListWrapper<GuidItem> AttributesOptions { get; } = new OptionListWrapper<GuidItem>();
        public OptionListWrapper<GuidItem> HeritageOptions { get; } = new OptionListWrapper<GuidItem>();

        private readonly OptionListWrapper<GuidItem>[] _allOptions;
        private readonly Dictionary<Guid, int> _guidCostMap = new Dictionary<Guid, int>();
        private readonly List<int> _selected =  new List<int>{4, 3, 2, 1, 0};
        private readonly ICreationData _data;
        private readonly PriorityBasedCharacterSetupInfo _setup;
        private readonly bool _priority;
        private bool _active = true;
        public int Sum => _selected.Sum();

        
        public PriorityTable(ICreationData data, PriorityBasedCharacterSetupInfo setup, bool priority)
        {
            _data = data;
            _setup = setup;
            _priority = priority;

            _setup.PropertyChanged += SetupOnPropertyChanged;

            _allOptions = new[] { HeritageOptions, AttributesOptions, TalentOptions, SkillsOptions, ResourcesOptions };
            SetupTable(_data);

            HeritageOptions.SelectedItemChangedEvent += new InnerData(this, 0).ListChanged;
            AttributesOptions.SelectedItemChangedEvent += new InnerData(this, 1).ListChanged;
            TalentOptions.SelectedItemChangedEvent += new InnerData(this, 2).ListChanged;
            SkillsOptions.SelectedItemChangedEvent += new InnerData(this, 3).ListChanged;
            ResourcesOptions.SelectedItemChangedEvent += new InnerData(this, 4).ListChanged;

            _active = false;

        }

        class _pair
        {
            public GuidItem Item;
            public List<GuidItem> List = new List<GuidItem>();
            public int I;
        }

        private void SetupTable(ICreationData data)
        {
            _guidCostMap.Clear();

            var gameplayguid = _setup.SelectedGameplayOption.Guid;
            var option = _data.GameplayOption[gameplayguid];
            Dictionary<string, _pair> things = new Dictionary<string, _pair>
            {
                {"Heritage", new _pair {I = 4} },
                { "Attributes", new _pair{I = 3}},
                { "Talent", new _pair{I = 2}},
                { "Skills", new _pair{I = 1}},
                { "Resources", new _pair{I = 0}}
            };

            foreach (PriorityTableEntryData entry in
                    data.PriorityEntries
                    .Where(x => option.Entries.Contains(x.ItemId))
                    .OrderByDescending(x => x.Sort))
            {
                GuidItem item = new GuidItem(entry.Name, entry.ItemId);
                _pair p = things[entry.Category];
                p.List.Add(item);
                if (p.I == entry.Value)
                {
                    p.Item = item;
                }
                _guidCostMap.Add(entry.ItemId, entry.Value);
            }

            var v = things.OrderByDescending(x => x.Value.I).Select(x => x.Value).ToList();
            for (int i = 0; i < 5; i++)
            {
                _allOptions[i].ReplaceWith(v[i].List);
                _allOptions[i].SelectedItem = v[i].Item;
            }

        }

        private void SetupOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(PriorityBasedCharacterSetupInfo.SelectedGameplayOption))
            {
                try
                {
                    _active = true;
                    SetupTable(_data);
                }
                finally
                {
                    _active = false;
                }
            }
        }

        class InnerData
        {
            private readonly PriorityTable _self;
            private readonly int _index;

            public InnerData(PriorityTable self, int index)
            {
                this._self = self;
                _index = index;
            }

            public void ListChanged(GuidItem selected)
            {
                if (_self._active) return;
                _self._active = true;
                try
                {
                    if (_self._priority)
                    {
                        int oldCost = _self._selected[_index];
                        int newCost = _self._guidCostMap[selected.Guid]; //cost of new selected option at _index
                        int newIndex = _self._selected.IndexOf(newCost); //index of option with same cost

                        _self._selected[newIndex] = oldCost;
                        _self._selected[_index] = newCost;

                        var other = _self._allOptions[newIndex];
                        var otherNewSelection = other.ReadOnly.First(x => _self._guidCostMap[x.Guid] == oldCost);
                        other.SelectedItem = otherNewSelection;

                        return;  
                    }

                }
                finally
                {
                    _self._active = false;
                }
                throw new NotImplementedException();
            }
        }
    }
}
