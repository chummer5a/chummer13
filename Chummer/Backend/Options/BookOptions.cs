using System.Collections.Generic;
using System.Linq;
using Chummer.Datastructures;
using Chummer.UI.Options.ControlGenerators;

namespace Chummer.Backend.Options
{
    public class BookOptions
    {
        public Dictionary<string, OptionGroup> Books { get; }
        public Dictionary<string, OptionDictionaryEntryProxy<string, bool>> BookEnabled { get; }

        public BookOptions(List<OptionItem> bookOptions)
        {
            BookEnabled = bookOptions.OfType<OptionGroup>()
                .Select(x => x.Children.OfType<OptionDictionaryEntryProxy<string, bool>>().First())
                .ToDictionary(x => x.Key);

            Books = bookOptions.OfType<OptionGroup>()
                .ToDictionary(x => x.Children.OfType<OptionDictionaryEntryProxy<string, bool>>().First().Key);
        }
    }
}