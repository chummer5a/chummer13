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

        private void SetupTable(ICreationData data)
        {
            foreach (var optionList in _allOptions)
            {
                optionList.Clear();
            }
            _guidCostMap.Clear();

            var gameplayguid = _setup.SelectedGameplayOption.Guid;
            var option = _data.GameplayOption[gameplayguid];
            var temp =
                data.PriorityEntries.Where(x => option.Entries.Contains(x.ItemId));
            foreach (PriorityTableEntryData entry in temp)
            {
                GuidItem item;
                switch (entry.Category)
                {
                    case "Heritage":
                        item = new GuidItem(entry.Name, entry.ItemId);
                        HeritageOptions.Add(item);
                        if (_selected[0] == entry.Value)
                        {
                            HeritageOptions.SelectedItem = item;
                        }
                        break;
                    case "Attributes":
                        item = new GuidItem(entry.Name, entry.ItemId);
                        AttributesOptions.Add(item);
                        if (_selected[1] == entry.Value)
                        {
                            AttributesOptions.SelectedItem = item;
                        }
                        break;
                    case "Talent":
                        item = new GuidItem(entry.Name, entry.ItemId);
                        TalentOptions.Add(item);
                        if (_selected[2] == entry.Value)
                        {
                            TalentOptions.SelectedItem = item;
                        }
                        break;
                    case "Skills":
                        item = new GuidItem(entry.Name, entry.ItemId);
                        SkillsOptions.Add(item);
                        if (_selected[3] == entry.Value)
                        {
                            SkillsOptions.SelectedItem = item;
                        }
                        break;
                    case "Resources":
                        item = new GuidItem(entry.Name, entry.ItemId);
                        ResourcesOptions.Add(item);
                        if (_selected[4] == entry.Value)
                        {
                            ResourcesOptions.SelectedItem = item;
                        }
                        break;
                    default:
                        Utils.BreakIfDebug();
                        break;
                }

                _guidCostMap.Add(entry.ItemId, entry.Value);
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
