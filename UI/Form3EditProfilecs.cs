using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form3EditProfilecs : Form
    {
        public Form3EditProfilecs()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           this.Hide();
           FormPopUpProfile Form = new FormPopUpProfile();
           Form.ShowDialog();
        }
    }
}
