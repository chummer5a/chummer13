using System;

namespace Chummer.Backend.Data.Items
{
    public class PriorityTableEntryData
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Category { get; set; }
        public int Sort { get; set; }
        public Guid PickId { get; set; }
    }
}