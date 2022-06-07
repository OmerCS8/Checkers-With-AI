using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemEngine;
using static SystemEngine.ArtificialIntelligence;
using static SystemEngine.Player;

namespace WinFormsUI
{
    public partial class FormProperties : Form
    {

        private int m_BoardSize;
        private string m_FirstPlayerName;
        private string m_SecondPlayerName;
        private ePlayerType m_RivalType;
        private eComputerLevel m_Difficulty;

        public FormProperties()
        {
            InitializeComponent();
            this.textBoxFirstPlayer.Leave += new System.EventHandler(textBoxesPlayers_Leave);
            this.textBoxSecondPlayer.Leave += new System.EventHandler(textBoxesPlayers_Leave);
            initializeRadioButtonsListeners();
            m_BoardSize = radioButtonSize6X6.Checked ? 6 : (radioButtonSize8X8.Checked ? 8 : 10);
            m_Difficulty = radioButtonEasy.Checked ? eComputerLevel.Easy
                               : (radioButtonMedium.Checked ? eComputerLevel.Medium : eComputerLevel.Hard);
            m_RivalType = checkBoxWantPlayer2.Checked? ePlayerType.Human : ePlayerType.Computer;
            m_FirstPlayerName = textBoxFirstPlayer.Text;
            m_SecondPlayerName = textBoxSecondPlayer.Text;
        }

        private void initializeRadioButtonsListeners()
        {
            this.radioButtonEasy.CheckedChanged += new System.EventHandler(radioButtonDifficulty_CheckedChanged);
            this.radioButtonHard.CheckedChanged += new System.EventHandler(radioButtonDifficulty_CheckedChanged);
            this.radioButtonMedium.CheckedChanged += new System.EventHandler(radioButtonDifficulty_CheckedChanged);
            this.radioButtonSize6X6.CheckedChanged += new System.EventHandler(radioButtonsSize_CheckedChanged);
            this.radioButtonSize8X8.CheckedChanged += new System.EventHandler(radioButtonsSize_CheckedChanged);
            this.radioButton10X10.CheckedChanged += new System.EventHandler(radioButtonsSize_CheckedChanged);
        }

        private void checkBoxWantPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonEasy.Enabled = !checkBoxWantPlayer2.Checked;
            radioButtonMedium.Enabled = !checkBoxWantPlayer2.Checked;
            radioButtonHard.Enabled = !checkBoxWantPlayer2.Checked;
            textBoxSecondPlayer.Enabled = checkBoxWantPlayer2.Checked;
            textBoxSecondPlayer.Text = "Computer";
            m_RivalType = checkBoxWantPlayer2.Checked ? ePlayerType.Human : ePlayerType.Computer;
        }

        private void textBoxFirstPlayer_TextChanged(object sender, EventArgs e)
        {
            m_FirstPlayerName = textBoxFirstPlayer.Text;
        }

        private void textBoxSecondPlayer_TextChanged(object sender, EventArgs e)
        {
            m_SecondPlayerName = textBoxSecondPlayer.Text;
        }

        private void undoTextBoxTextIfEmpty(TextBox i_TextBox)
        {
            if(string.IsNullOrWhiteSpace(i_TextBox.Text))
            {
                MessageBox.Show("Player name can not be empty, returning to previous name.");
                i_TextBox.Undo();
                i_TextBox.ClearUndo();
            }
        }

        private void textBoxesPlayers_Leave(object sender, EventArgs e)
        {
            undoTextBoxTextIfEmpty((TextBox)sender);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            FormCheckersGame checkersForm = new FormCheckersGame(
                m_BoardSize, m_Difficulty, m_FirstPlayerName, m_SecondPlayerName, m_RivalType);
            this.Hide();
            checkersForm.ShowDialog();
        }

        private void radioButtonsSize_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = radioButtonSize6X6.Checked ? 6 : (radioButtonSize8X8.Checked ? 8 : 10);
        }

        private void radioButtonDifficulty_CheckedChanged(object sender, EventArgs e)
        {
            m_Difficulty = radioButtonEasy.Checked ? eComputerLevel.Easy
                               : (radioButtonMedium.Checked ? eComputerLevel.Medium : eComputerLevel.Hard);
        }
    }
}
