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
    public partial class formSelect : Form
    {
        public string Result
        {
        get
            {
                return cboOptions.Text;
            }
        }


        public formSelect()
        {
            InitializeComponent();
        }

        public formSelect(string title) : this()
        {
            this.Text = title;
        }

        public formSelect(string[] lines) : this()
        {
            cboOptions.Items.AddRange(lines);
        }

        public formSelect(string title,string[] lines):this(lines)
        {
            this.Text = title;
        }
    }
}
