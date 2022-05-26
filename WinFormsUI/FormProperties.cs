using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace WinFormsUI
{
    public partial class FormProperties : Form
    {
        public FormProperties()
        {
            InitializeComponent();
        }

        private void checkBoxWantPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonEasy.Enabled = !checkBoxWantPlayer2.Checked;
            radioButtonMedium.Enabled = !checkBoxWantPlayer2.Checked;
            radioButtonHard.Enabled = !checkBoxWantPlayer2.Checked;
            textBoxSecondPlayer.Enabled = checkBoxWantPlayer2.Checked;
            textBoxSecondPlayer.Text = "Computer";
        }
    }
}
