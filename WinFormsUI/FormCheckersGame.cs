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
    public partial class FormCheckersGame : Form
    {
        private readonly Checkers r_CheckersGame;
        internal class CheckersCell : PictureBox
        {
            public int Row { get; set; }
            public int Column { get; set; }

            public CheckersCell(int i_Row, int i_Col, int i_CellSize)
            {
                Row = i_Row;
                Column = i_Col;
                this.Size = new Size(i_CellSize, i_CellSize);
            }
        }

        internal class CheckersPawm : PictureBox
        {
            public int Row { get; set; }
            public int Column { get; set; }

            public CheckersPawm(int i_Row, int i_Col, int i_CellSize)
            {
                Row = i_Row;
                Column = i_Col;
                this.Size = new Size((int)(i_CellSize * 0.9), (int)(i_CellSize * 0.9));
            }
        }

        public FormCheckersGame(int i_BoardSize, eComputerLevel i_Difficulty,
            string i_FirstPlayerName, string i_SecondPlayerName, ePlayerType i_RivalType)
        {
            int cellSize = i_BoardSize == 6? 100 : i_BoardSize == 8 ? 80 : 70;

            InitializeComponent();
            r_CheckersGame = new Checkers(
                i_FirstPlayerName, i_SecondPlayerName, i_RivalType, i_BoardSize, i_Difficulty);
            setScoreLables(i_FirstPlayerName, i_SecondPlayerName);
            setBoardAndFitScreenSize(i_BoardSize, cellSize);
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
        }

        private void setBoardAndFitScreenSize(int size, int i_CellSize)
        {
            panelBoard.Size = new Size(size * i_CellSize + 100, size * i_CellSize + 100);
            this.Size = new Size(panelBoard.Width + 100, panelBoard.Height + 160);
            PanelScorePlayer1.Left = 50;
            PanelScorePlayer2.Left = this.Size.Width - PanelScorePlayer2.Width - 50;
            this.MinimumSize = this.Size;
            panelBoard.Left = 50;
            panelBoard.Top = PanelScorePlayer1.Top + PanelScorePlayer1.Height + 10;

            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    CheckersCell checkersCell = new CheckersCell(i, j, i_CellSize);
                    checkersCell.BackgroundImage = (Math.Abs(i-j))%2 == 0?
                        Properties.Resources.white_tile: Properties.Resources.black_tile;
                    checkersCell.Parent = panelBoard;
                    checkersCell.Location = new Point(j*checkersCell.Width + 50, i*checkersCell.Height + 50);
                    checkersCell.Show();

                    Pawn pownOnCell = r_CheckersGame.GameBoard.CellArray[i, j].PawnOnCell;
                    if(pownOnCell != null)
                    {
                        CheckersPawm checkersPawm = new CheckersPawm(i, j, i_CellSize);
                        checkersPawm.BackColor = Color.Transparent;
                        checkersPawm.Image = pownOnCell.PawnColor == ePlayerColor.Black ?
                            Properties.Resources.black_pawn : Properties.Resources.white_pawn;
                        checkersPawm.SizeMode = PictureBoxSizeMode.StretchImage;
                        checkersPawm.Parent = checkersCell;
                        checkersPawm.Location = new Point(
                            (i_CellSize - checkersPawm.Width) / 2, (i_CellSize - checkersPawm.Width) / 2);
                        checkersPawm.Show();
                    }
                }
            }

        }
    }
}
