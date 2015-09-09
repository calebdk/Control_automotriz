using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlCarros
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://twitter.com/calebDK");
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control_Automotriz logearme = new Control_Automotriz();

            this.Hide();
        }
    }
}
