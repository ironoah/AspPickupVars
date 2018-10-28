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
            string strBuff = "";

            Regex re = new Regex("<%=(?<varname>.*?)%>", RegexOptions.IgnoreCase
                                       | RegexOptions.Singleline);

            List<string> vars = new List<string>();

            for (Match m = re.Match(txtBefore.Text); m.Success; m = m.NextMatch())
            {
                vars.Add("ViewBag." + m.Groups["varname"].Value + ";\r\n");
            }
            // sort and distinct        
            string[] fix = vars.Distinct().OrderBy(i => i).ToArray();

            txtAfter.Text = String.Join("", fix);
        }

        private void txtBefore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                txtBefore.SelectAll();
        }
        private void txtAfter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                txtAfter.SelectAll();
        }
    }
}
