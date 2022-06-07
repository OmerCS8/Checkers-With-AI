using System;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class FormWelcome : Form
    {
        private FormProperties m_FormProperties;
        private FormRules m_FormRules;
        public FormWelcome()
        {
            InitializeComponent();
            m_FormProperties = new FormProperties();
            m_FormRules = new FormRules();
        }

        private void buttonRules_Click(object sender, EventArgs e)
        {
            m_FormRules.ShowDialog();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_FormProperties.ShowDialog();
            this.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}