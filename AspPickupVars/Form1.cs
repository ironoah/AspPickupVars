using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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

            for (Match m = re.Match(txtBefore.Text); m.Success; m = m.NextMatch())
            {
                strBuff += "ViewBag." + m.Groups["varname"].Value + ";\r\n";
            }
            txtAfter.Text = strBuff.TrimEnd();
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
