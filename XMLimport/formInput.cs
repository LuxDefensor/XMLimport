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
    public partial class formInput : Form
    {

        public formInput()
        {
            InitializeComponent();
        }

        public formInput(string prompt)
            :this()
        {
            this.Text = prompt;
        }

        public formInput(object defaultValue, string prompt)
            :this(prompt)
        {
            txtInput.Text = defaultValue.ToString();
        }

        public string InputValue
        {
        get
            {
                return txtInput.Text;
            }
        }
    }
}
