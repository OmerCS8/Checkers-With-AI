namespace WinFormsUI
{
    public partial class FormWelcome : Form
    {
        private FormProperties m_FormProperties;
        public FormWelcome()
        {
            InitializeComponent();
            m_FormProperties = new FormProperties();
        }

        private void buttonRules_Click(object sender, EventArgs e)
        {

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