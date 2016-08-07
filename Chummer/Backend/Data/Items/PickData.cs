using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chummer.Backend.Data.Items
{
    class PickData
    {
        public PickData(Guid id, List<HeritageData> heritages)
        {
            Id = id;
            Heritages = heritages;
        }

        public Guid Id { get; }
        public List<HeritageData> Heritages { get; }
    }

    internal class HeritageData
    {
        public HeritageData(Guid metatype, int specialPoints, int karmaCost)
        {
            Metatype = metatype;
            SpecialPoints = specialPoints;
            KarmaCost = karmaCost;
        }

        public Guid Metatype { get; }
        public int SpecialPoints { get; }
        public int KarmaCost { get; }
    }
}
