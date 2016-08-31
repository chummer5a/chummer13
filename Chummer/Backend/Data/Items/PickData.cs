using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chummer.Backend.Data.Items
{
	/*
	 * A quick note about how this is organized. (Should really be in its own 
	 * file, but i will place it here so it is somewhere, instead of not writing 
	 * any documentation at all.
	 * To be honest, i was close to not writing any documentation at all, but 
	 * after forgetting how it works after not working on this a little while,
	 * i decided to save future me some time. (Write code like the next person
	 * to read it is a murderous psyophat that knows where you live)
	 * Future me definetly knows where i live...
	 * 
	 * The root element of pick data is the gameplayoption. They are located in
	 * gameplayoptions.xml at time of writing, but i might merge that and 
	 * priorities.xml into either a SQLite db or a charactercreation.xml
	 * For most cases, the gameplayoption will be standard. For an example of
	 * gameplay options see in the crb on page 64 right side or the alternate
	 * campaings on page 350-351
	 * 
	 * Most importantly it contains a list (well hashset) of picks
	 *  public HashSet<Guid> PriorityTableEntries { get; set; }
	 * This contains a set of GUIDs (5x5 in sane cases, but others might work)
	 * Each of those GUID's matches the id of a PriorityTableEntryData
	 * The priority table is then build from those entries.
	 * This aproach was chosen due to the large amount of gameplayoptions in crb
	 * that matches each other except for one/few tables/entries changed.
	 * It would be possible to just copy paste the data, but why do that...
	 * 
	 * Each PriorityTableEntryData then contains a name to be displayed (not
	 * translated yet) a sorting field that they are sorted after and a value
	 * to determine their value (ABCDE picks) or sum to ten value
	 * 
	 * It also contains another GUID to a pickdata
	 * 
	 * This PickData is where the actual data is stored.
	 * It contains a list of Metatypes (guids to metatypes.xml) possible and 
	 *  how expensive they are to chose
	 * How many Attribute points the player has
	 * Free Skill(group) points
	 * Nuyen
	 * Qualities (guids to qualities.xml) (metatypes contain yet another set)
	 * Skill(groups) (guids to skills.xml) to Pick and their level
	 *
	 * 
	 */
	class PickData
    {
        public PickData(Guid id, List<HeritageData> heritages, int attributes, List<TalentData> talents, List< SkillPickData> skills, int nuyen)
        {
            Id = id;
            Heritages = heritages ?? new List<HeritageData>();
	        Attributes = attributes;
	        Talents = talents ?? new List<TalentData>();
			Skills = skills?? new List<SkillPickData>();
	        Nuyen = nuyen;
        }

		/// <summary>
		/// Id of the pick. Used to identitfy it if any specific priority table contains it. Also used for saving and retriving the same pick later
		/// </summary>
        public Guid Id { get; }

		/// <summary>
		/// Metatypes possible to pick from this 
		/// </summary>
        public List<HeritageData> Heritages { get; }
	    public int Attributes { get; }
	    public List<Guid> Qualities;
	    public List<TalentData> Talents;
	    public List<SkillPickData> Skills;
	    public int Nuyen { get; }

    }

	internal class TalentData
	{
		
	}

	internal class SkillPickData
	{
		
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
