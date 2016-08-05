using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Chummer.Backend.Character_Creation;
using Chummer.Backend.Data.Items;
using Chummer.Backend.Datastructures;

namespace Chummer.Backend.Data.Sources.Xml
{
    class CharacterSetupData : ICreationData
    {
        public static CharacterSetupData Instance { get; } = new CharacterSetupData();

        public CharacterSetupData()
        {
            XmlDocument gameplayoptions = XmlManager.Instance.Load("gameplayoptions.xml");

            GameplayOption = new DataList<GameplayOptionData>(
                gameplayoptions.SelectNodes("/chummer/gameplayoptions/gameplayoption")
                .OfType<XmlNode>()
                .Select(x => 
                {
                    XmlElement element = x["default"];
                    return new GameplayOptionData
                    {
                        ItemId = Guid.Parse(x["id"].InnerText),
                        DisplayName = x["name"].Attributes["translate"]?.InnerText ?? x["name"].InnerText,
                        Karma = int.Parse(x["karma"].InnerText),
                        MaxAvailability = int.Parse(x["maxavailability"].InnerText),
                        MaxNuyen = int.Parse(x["contactmultiplier"].InnerText),
                        Default = x.TryCheckValue("default", "yes"),
                        Entries = new HashSet<Guid>(x["entries"].ChildNodes.OfType<XmlElement>().Select(q => Guid.Parse(q.InnerText)))
                    };
                })
                .ToDictionary(x => x.ItemId));

            XmlDocument priority = XmlManager.Instance.Load("priorities.xml");

            PriorityEntries = new DataList<PriorityTableEntryData>(
                priority.SelectNodes("/chummer/priorities/priority")
                .OfType<XmlNode>()
                .Select(node =>
                {
                    return new PriorityTableEntryData
                    {
                        ItemId = Guid.Parse(node["id"].InnerText),
                        Name = node["name"].Attributes["translate"]?.InnerText ?? node["name"].InnerText,
                        Value = int.Parse(node["value"].InnerText.Split(',').Last()),
                        Sort = int.Parse(node["sort"].InnerText),
                        Category = node["category"].InnerText,
                    };
                }).ToDictionary(x => x.ItemId));


            XmlDocument metatypes = XmlManager.Instance.Load("metatypes.xml");

            Metatypes =
                new DataList<MetatypeData>(metatypes.SelectNodes("/chummer/races/race").OfType<XmlNode>().Select(
                    node =>
                        new MetatypeData(Guid.Parse(node["id"].InnerText),
                            node["name"].Attributes["translate"]?.InnerText ?? node["name"].InnerText,
                            int.Parse(node["karma"].InnerText), Guid.Parse(node["categoryid"].InnerText),
                            node["walk"].InnerText,
                            node["run"].InnerText, node["sprint"].InnerText, node["source"].InnerText,
                            int.Parse(node["page"].InnerText),
                            node["attributes"].ChildNodes.OfType<XmlNode>()
                                .Select(
                                    child =>
                                        new MetatypeData.AttributesData(
                                            child["name"].Attributes["translate"]?.InnerText ?? child["name"].InnerText,
                                            child["short"].Attributes["translate"]?.InnerText ??
                                            child["short"].InnerText,
                                            int.Parse(child["min"].InnerText),
                                            int.Parse(child["max"].InnerText),
                                            int.Parse(child["aug"].InnerText)))
                            )
                    ).ToDictionary(x => x.Id));

            Categories = new DataList<GuidItem>(metatypes.SelectNodes("/chummer/categories/category")
                    .OfType<XmlNode>()
                    .Select(
                        node =>
                            new GuidItem(node["name"].Attributes["translate"]?.InnerText ?? node["name"].InnerText,
                                Guid.Parse(node["id"].InnerText))).ToDictionary(x => x.Guid));


        }

        public DataList<GameplayOptionData> GameplayOption { get; }

        public DataList<PriorityTableEntryData> PriorityEntries { get; }

        public DataList<GuidItem> Categories { get; }

        public DataList<MetatypeData> Metatypes { get; }
    }

    interface ICreationData
    {
        DataList<GameplayOptionData> GameplayOption { get; }

        DataList<PriorityTableEntryData> PriorityEntries { get; }

        DataList<GuidItem> Categories { get; }

        DataList<MetatypeData> Metatypes { get; }


    }
}
