using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chummer.Backend.Character_Creation;

namespace Chummer.UI.Character_Creation
{
    public partial class frmPriorityBuildForm : Form
    {
        private readonly PriorityBasedCharacterSetupInfo _setup;

        public frmPriorityBuildForm(PriorityBasedCharacterSetupInfo setup)
        {
            _setup = setup;
            InitializeComponent();

            priorityBuildSelector1.SetupInfo = setup;
        }
    }
}
