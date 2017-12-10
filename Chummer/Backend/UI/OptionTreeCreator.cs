using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chummer.Backend.Options;
using Chummer.Classes;
using Chummer.Datastructures;
using Chummer.UI.Options.ControlGenerators;

namespace Chummer.Backend.UI
{
    class OptionTreeCreator
    {
        public static readonly List<IOptionWinFromControlFactory> ControlFactories = new List<IOptionWinFromControlFactory>()
        {
            new CheckBoxOptionFactory(),
            new NumericUpDownOptionFactory(),
            new BookOptionFactory(),
            new PathSelectiorFactory(),
            new DropDownFactory(),
            new StringControlFactory()
        };

        static readonly OptionExtractor Extactor = new OptionExtractor(
                new List<Predicate<OptionItem>>(
                    ControlFactories.Select
                        <IOptionWinFromControlFactory, Predicate<OptionItem>>
                        (x => x.IsSupported)));

        private readonly Lazy<AbstractOptionTree> GlobalOptionsTree;

        public IReadOnlyList<OptionItem> LoadedItems => _loadedItems;
        private readonly List<OptionItem> _loadedItems = new List<OptionItem>();

        public OptionTreeCreator()
        {
            GlobalOptionsTree = new Lazy<AbstractOptionTree>(GenerateGlobalOptions);
        }

        public AbstractOptionTree GenerateOptionTree(bool forSingleOptions)
        {
            if (forSingleOptions)
                return GenerateSingleOption(GlobalOptions.Default);
            else
                return GenerateMultiOptions();
        }

        private AbstractOptionTree GenerateMultiOptions()
        {
            throw new NotImplementedException();
        }

        private AbstractOptionTree GenerateSingleOption(CharacterOptions options)
        {

            DummyOptionTree rootTree = new DummyOptionTree("root");
            rootTree.AddChild(GenerateCharacterOptions(options));
            rootTree.AddChild(GlobalOptionsTree.Value);


            return rootTree;
        }

        private AbstractOptionTree GenerateBookOption(CharacterOptions bookEnabledSource)
        {
            List<OptionItem> bookOptions = Extactor.BookOptions(bookEnabledSource, GlobalOptions.Instance);
            _loadedItems.AddRange(bookOptions);
            return new BookNode(new BookOptions(bookOptions));
        }

        private AbstractOptionTree GenerateGlobalOptions()
        {
            SimpleTree<OptionRenderItem> rawtree = Extactor.Extract(GlobalOptions.Instance);
            if (rawtree.Children.Count != 1) Utils.BreakIfDebug();

            _loadedItems.AddRange(rawtree.DepthFirstEnumerator().Cast<OptionItem>());
            return ConvertToWinFormTree(rawtree.Children[0]);
        }

        private readonly Dictionary<CharacterOptions, SimpleOptionTree> _characterOptionsCache = new Dictionary<CharacterOptions, SimpleOptionTree>();
        private AbstractOptionTree GenerateCharacterOptions(CharacterOptions options)
        {
            SimpleOptionTree characterTree;
            if (_characterOptionsCache.TryGetValue(options, out characterTree))
                return characterTree;

            SimpleTree<OptionRenderItem> rawtree = Extactor.Extract(options);
            if(rawtree.Children.Count != 1) Utils.BreakIfDebug(); 
            characterTree = ConvertToWinFormTree(rawtree.Children[0]);

            characterTree.InsertChild(0, GenerateBookOption(options));
            //baseTreee.Children.Insert(1, GenerateCustomDataDictonaries(option));  //TODO: create after merge with custom data


            _loadedItems.AddRange(rawtree.DepthFirstEnumerator().OfType<OptionItem>());

            _characterOptionsCache[options] = characterTree;


            return characterTree;
        }

        private static SimpleOptionTree ConvertToWinFormTree(SimpleTree<OptionRenderItem> tree)
        {
            SimpleOptionTree so = new SimpleOptionTree(tree.Tag.ToString(), new List<OptionRenderItem>(tree.Leafs), ControlFactories);

            foreach (SimpleOptionTree child in tree.Children.Select(ConvertToWinFormTree))
            {
                so.AddChild(child);
            }
            
            return so;
        }

    }
}
