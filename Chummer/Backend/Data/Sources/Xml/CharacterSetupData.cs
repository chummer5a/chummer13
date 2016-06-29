using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Chummer.Backend.Data.Items;

namespace Chummer.Backend.Data.Sources.Xml
{
    class CharacterSetupData
    {
        public static CharacterSetupData Instance { get; } = new CharacterSetupData();

        public CharacterSetupData()
        {
            XmlDocument document = XmlManager.Instance.Load("gameplayoptions.xml");

            GameplayOption = new DataList<GameplayOptionData>(
                document.SelectNodes("/chummer/gameplayoptions/gameplayoption")
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
        }

        public DataList<GameplayOptionData> GameplayOption { get; }
    }
}
