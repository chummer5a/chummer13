using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Chummer.Backend;
using Chummer.Backend.Attributes.OptionAttributes;
using Chummer.Backend.Options;
using Chummer.Backend.UI;
using Chummer.Classes;
using Chummer.Datastructures;
using Chummer.UI.Options;
using Chummer.UI.Options.ControlGenerators;
using Microsoft.Win32;

namespace Chummer
{
	public partial class frmNewOptions : Form
	{
	    private Control _currentVisibleControl;
	    private List<OptionItem> _searchList = null;
	    private Lazy<OptionRender> _sharedRender;
	    private OptionTreeCreator _treeHandler = new OptionTreeCreator();


        public frmNewOptions()
		{
			InitializeComponent();

            Load += OnLoad;
		}

	    private void OnLoad(object sender, EventArgs eventArgs)
	    {
            
            AbstractOptionTree rawTree = _treeHandler.GenerateOptionTree(true);
	        
	        PopulateTree(treeView1.Nodes, rawTree);
            _sharedRender = new Lazy<OptionRender>(() =>
            {
                OptionRender c = new OptionRender { Factories = OptionTreeCreator.ControlFactories };
                Controls.Add(c);
                SetupControl(c);

                return c;
            });


            MaybeSpawnAndMakeVisible(treeView1.Nodes[0].Nodes[0]);
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];

            textBox1.TextChanged += SearchBoxChanged;

	        

            LanguageManager.Instance.Load(GlobalOptions.Instance.Language, this);

            textBox1.WatermarkText = LanguageManager.Instance.GetString("String_Search");
        }

	    private void SearchBoxChanged(object sender, EventArgs args)
	    {
	        if (_currentVisibleControl != null) _currentVisibleControl.Visible = false;

	        string searchfor = textBox1.Text;
	        /*if (keyPressEventArgs.KeyChar != '\b')
	        {
	            searchfor = textBox1.Text + keyPressEventArgs.KeyChar;
	        }
	        else if (textBox1.TextLength == 0)
	        {
	            MaybeSpawnAndMakeVisible(treeView1.SelectedNode);
	            return;
	        }
	        else
	        {
	            searchfor = textBox1.Text.Substring(0, textBox1.TextLength - 1);
	        }*/


	        if (string.IsNullOrWhiteSpace(searchfor) || _searchList == null)
	        {
	            MaybeSpawnAndMakeVisible(treeView1.SelectedNode);
	            return;
	        }

	        List<OptionRenderItem> hits = _searchList
	            .Where(x => x.SearchStrings().Any(y => CultureInfo.InvariantCulture.CompareInfo.IndexOf(y, searchfor, CompareOptions.IgnoreCase) >= 0))
	            .Take(20)
                .Select<OptionItem, OptionRenderItem>(x => x)
	            .ToList();

	        if (hits.Count > 0)
	        {
	            _sharedRender.Value.SetContents(hits);


	            _currentVisibleControl = _sharedRender.Value;
	            _currentVisibleControl.Visible = true;
	        }
	        else
	        {
	            _currentVisibleControl = _sharedRender.Value;
	        }
	    }

	    

	    private void MaybeSpawnAndMakeVisible(TreeNode selectedNode)
	    {
	        AbstractOptionTree tree = (AbstractOptionTree) selectedNode.Tag;
	        if (_currentVisibleControl != null) _currentVisibleControl.Visible = false;
            
            
            SimpleOptionTree simpleOptionTree = tree as SimpleOptionTree;
	        if (simpleOptionTree != null)
	        {
	            _sharedRender.Value.SetContents(simpleOptionTree.Items);
                _currentVisibleControl = _sharedRender.Value;

	        }
            else
	        {
	            _currentVisibleControl = tree.ControlLazy();

	            if (_currentVisibleControl.Parent == null)
	            {
	                SetupControl(_currentVisibleControl);
	                Controls.Add(_currentVisibleControl);
	            }
#if DEBUG
	            else if (_currentVisibleControl.Parent != this)
	            {
	                Utils.BreakIfDebug();
	            }
#endif
	        }
	        _currentVisibleControl.Visible = true;

	        while (tree != null)
	        {
	            if (tree.SearchList != null)
	                _searchList = tree.SearchList;

	            tree = tree.Parent;
	        }
	    }

	    private void SetupControl(Control c)
	    {
	        c.Location = new Point(treeView1.Right,0);
	        c.Height = treeView1.Bottom;
	        c.Width = treeView1.Parent.Width - treeView1.Right - SystemInformation.VerticalScrollBarWidth;
	        c.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
	    }

	    private void PopulateTree(TreeNodeCollection collection, AbstractOptionTree tree)
	    {
	        foreach (AbstractOptionTree child in tree.Children)
	        {
	            TreeNode n = collection.Add(child.Name); //TODO: Should probably hit LanguageManager
	            n.Tag = child;
                PopulateTree(n.Nodes, child);
	        }
	    }

	    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MaybeSpawnAndMakeVisible(e.Node);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (OptionItem item in _treeHandler.LoadedItems)
            {
                item.Save();
            }
            
            GlobalOptions.SaveCharacterOption(GlobalOptions.Default);
            GlobalOptions.SaveGlobalOptions();

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (OptionItem item in _treeHandler.LoadedItems)
            {
                item.Reload();
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {

            //TODO: Very much bad code, but right now i cannot figure out how to just make every optionItem be updated to default value
            //TODO: Do for more stuff (GlobalOptions won't be affected by this)
            CharacterOptions def = new CharacterOptions(GlobalOptions.Default.FileName);

            foreach (FieldInfo field in typeof(CharacterOptions).GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                field.SetValue(GlobalOptions.Default, field.GetValue(def));
            }

            GlobalOptions.SaveCharacterOption(GlobalOptions.Default);

            Close();
        }
    }
}
