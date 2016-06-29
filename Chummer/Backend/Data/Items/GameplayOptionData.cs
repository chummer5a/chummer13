using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chummer.Backend.Data.Items
{
    public class GameplayOptionData
    {
        public Guid ItemId { get; set; }
        public string DisplayName { get; set; }
        public int Karma { get; set; }
        public int MaxAvailability { get; set; }
        public int MaxNuyen { get; set; }
        public int ContactMultiplier { get; set; }
        public bool Default { get; set; }
    }
}
