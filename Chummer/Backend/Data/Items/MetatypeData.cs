using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chummer.Backend.Data.Items
{
    public class MetatypeData
    {
        public MetatypeData(Guid id, Guid parrent, string displayName, int karma, Guid categoryid, string walk, string run, string sprint, string source, int page, IEnumerable<AttributesData> attributes)
        {
            Id = id;
            DisplayName = displayName;
            Karma = karma;
            Categoryid = categoryid;
            Walk = walk;
            Run = run;
            Sprint = sprint;
            Source = source;
            Page = page;
	        Parrent = parrent;
	        Attributes = attributes.ToList().AsReadOnly();
        }

        public Guid Id { get; }
        public Guid Parrent { get; }
        public string DisplayName { get; }
        public int Karma { get; }
        public Guid Categoryid { get; }
        public string Walk { get; }
        public string Run { get; }
        public string Sprint { get; }
        //public string Bonus { get; set; }
        public string Source { get; }
        public int Page { get; }
		public List<Guid> Qualities;
		public IReadOnlyList<AttributesData> Attributes { get; }

        public class AttributesData
        {
            public AttributesData(string name, string s, int min, int max, int aug)
            {
                Name = name;
                Min = min;
                Max = max;
                Aug = aug;
                Short = s;
            }

            public string Name { get; }
            public string Short { get; }
            public int Min { get; }
            public int Max { get; }
            public int Aug { get; }
        }
    }
}
