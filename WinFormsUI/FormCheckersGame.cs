using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SystemEngine.ArtificialIntelligence;
using static SystemEngine.Player;

namespace WinFormsUI
{
    public partial class FormCheckersGame : Form
    {
        internal class CheckersCell : PictureBox
        {
            public int Row { get; set; }
            public int Column { get; set; }

            public CheckersCell(int i_Row, int i_Col)
            {
                Row = i_Row;
                Column = i_Col;
                this.Size = new Size(100, 100);
            }
        }

        public FormCheckersGame(int i_BoardSize, eComputerLevel m_Difficulty,
            string i_FirstPlayerName, string i_SecondPlayerName, ePlayerType m_RivalType)
        {
            InitializeComponent();
            setScoreLables(i_FirstPlayerName, i_SecondPlayerName);
            setBoard(i_BoardSize);
        }

        private void setScoreLables(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            labelNamePlayer1.Text = i_FirstPlayerName + ":";
            labelScorePlayer1.Left = labelNamePlayer1.Right + 5;
            labelNamePlayer2.Text = i_SecondPlayerName + ":";
            labelScorePlayer2.Left = labelNamePlayer2.Right + 5;
            int minPanelsWidth = Math.Max(labelNamePlayer1.Width + labelScorePlayer1.Width + 30,
                labelNamePlayer2.Width + labelScorePlayer2.Width + 35);
            PanelScorePlayer1.Width = PanelScorePlayer2.Width = Math.Max(minPanelsWidth, 200);
            PanelScorePlayer2.Left = PanelScorePlayer1.Right + 10;
        }

        private void setBoard(int size)
        {
            panelBoard.Size = new Size(size*100,size*100);
            this.Size = new Size(panelBoard.Width+100,panelBoard.Height+200);
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    CheckersCell checkersCell = new CheckersCell(i, j);
                    checkersCell.BackgroundImage = (Math.Abs(i-j))%2 == 0?
                        Properties.Resources.white_tile: Properties.Resources.black_tile;
                    checkersCell.Parent = panelBoard;
                    checkersCell.Location = new Point(i*checkersCell.Width, j*checkersCell.Height);
                    checkersCell.Show();
                }
            }

        }
    }
}
