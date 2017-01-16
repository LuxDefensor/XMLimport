using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLimport
{
    public partial class formTest: Form
    {
        List<CheckBox> list;
        public formTest()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            Model m = new Model(s.Server, s.Database, s.UserName, s.Password, s.Season);
            Tuple<string, string> x = m.FullSubdevice(textBox1.Text);
        }
    }
}
