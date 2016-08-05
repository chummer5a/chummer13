using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Chummer.Backend.Data.Items;

namespace Chummer.UI.Character_Creation
{
    public partial class MetatypeAttributeDisplay : UserControl
    {
        private const int SizeWPx = 57;
        private const int SizeHPx = 37;
        public MetatypeAttributeDisplay()
        {
            InitializeComponent();
        }

        public void SetContents(IEnumerable<MetatypeData.AttributesData> contents)
        {
            if (contents == null)
            {
                ClearAfter(0);
                return;
            }
            int i = 0;
            foreach (MetatypeData.AttributesData data in contents)
            {
                Label bold, normal;
                CreateOrGet(out bold, out normal, i++);
                bold.Text = data.Short;
                normal.Text = $"{data.Min}/{data.Max}({data.Aug})";
            }

            ClearAfter(i);
            Arrange();
        }

        private void CreateOrGet(out Label bold, out Label normal, int index)
        {
            index *= 2; //working with pairs here

            for (; Controls.Count <= index;)
            {
                Controls.Add(new Label {Font = new Font(Font, FontStyle.Bold), Height = Font.Height, AutoSize = true});
                Controls.Add(new Label {AutoSize = true});
            }

            bold = (Label) Controls[index];
            normal = (Label) Controls[index + 1];

        }

        private void ClearAfter(int index)
        {
            index *= 2;
            for (int i = Controls.Count - 1; i >= index; i--)
            {
                Controls.RemoveAt(i); //Remove backwards as that is probably O(1) instead of O(n)
            }
            if(Controls.Count % 2 != 0) throw new Exception("SANITY CHECK FAILED!");
        }

        private void Arrange()
        {
            int workx = 0, worky = 0;
            for (int i = 0; i < Controls.Count; i += 2)
            {
                Controls[i].Location = new Point(workx, worky);
                Controls[i+1].Location = new Point(workx, worky + Controls[i].Height);

                workx += SizeWPx;
                if (workx + SizeWPx > Width)
                {
                    workx = 0;
                    worky += SizeHPx;
                }
            }
        }

        private void MetatypeAttributeDisplay_Resize(object sender, EventArgs e)
        {
            Arrange();
        }
    }
}
