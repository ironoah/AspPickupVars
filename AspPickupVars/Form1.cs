using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace AspPickupVars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            string[] selected = new string[3];
            string[] pickupName = { "name=\"(?<name>.+?)\"", "        public string ", "  { get; set; }\r\n" };
            string[] pickupValue = { "<%=(?<name>.+?)%>", "ViewBag.", ";\r\n" };
            if (radioButton1.Checked)
            {
                selected[0] = pickupName[0];
                selected[1] = pickupName[1];
                selected[2] = pickupName[2];
            } else
            {
                selected[0] = pickupValue[0];
                selected[1] = pickupValue[1];
                selected[2] = pickupValue[2];
            }

            Regex re = new Regex(selected[0], RegexOptions.IgnoreCase
                                       | RegexOptions.Singleline);

            List<string> vars = new List<string>();

            for (Match m = re.Match(txtBefore.Text); m.Success; m = m.NextMatch())
            {
                vars.Add(selected[1] + m.Groups["name"].Value + selected[2]);
            }
            // sort and distinct        
            string[] fix = vars.Distinct().OrderBy(i => i).ToArray();

            txtAfter.Text = String.Join("", fix);
        }

        private void txtBefore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A) {
                txtBefore.SelectAll();
            }
        }
        private void txtAfter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A) {
                txtAfter.SelectAll();
            }
        }
    }
}
