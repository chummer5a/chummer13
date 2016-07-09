using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Chummer.Backend.Character_Creation;
using Chummer.Backend.Data.Items;

namespace Chummer.Backend.Data.Sources.Xml
{
    class CharacterSetupData
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
                        Default = element != null && (element.InnerText == "yes")
                    };
                })
                .ToDictionary(x => x.ItemId));

            XmlDocument priority = XmlManager.Instance.Load("priorities.xml");

            PriorityEntries = new DataList<PriorityTableEntryData>(
                priority.SelectNodes("/chummer/priorities/prioritiy")
                .OfType<XmlNode>()
                .Select(node =>
                {
                    return new PriorityTableEntryData
                    {
                        ItemId = Guid.Parse(node["id"].InnerText),
                        Name = node["name"].Attributes["translate"]?.InnerText ?? node["name"].InnerText,
                        Value = int.Parse(node["value"].InnerText.Split(',').Last()),
                        Category = node["category"].InnerText
                    };
                }).ToDictionary(x => x.ItemId));
        }

        public DataList<GameplayOptionData> GameplayOption { get; }

        public DataList<PriorityTableEntryData> PriorityEntries { get; }
    }
}
