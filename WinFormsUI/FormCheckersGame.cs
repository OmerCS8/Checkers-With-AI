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
        private Cell? m_CurrentMoveSource = null;
        private readonly List<Cell> r_CurrentValidMovesDestinations = new List<Cell>();
        private readonly List<List<CellPictureBox>> r_UICells = new List<List<CellPictureBox>>();
        internal class CellPictureBox : PictureBox
        {
            public int Row { get; set; }
            public int Column { get; set; }

            public CellPictureBox(int i_Row, int i_Col, int i_CellSize)
            {
                Row = i_Row;
                Column = i_Col;
                this.Size = new Size(i_CellSize, i_CellSize);
            }
        }

        public FormCheckersGame(int i_BoardSize, eComputerLevel i_Difficulty,
            string i_FirstPlayerName, string i_SecondPlayerName, ePlayerType i_RivalType)
        {
            InitializeComponent();
            r_CheckersGame = new Checkers(
                i_FirstPlayerName, i_SecondPlayerName, i_RivalType, i_BoardSize, i_Difficulty);
            setScoreLabels(i_FirstPlayerName, i_SecondPlayerName);
            setBoardAndFitScreenSize(i_BoardSize);
            r_CheckersGame.MoveWasDone += move_Done;
            r_CheckersGame.GameEnded += miniGame_Ended;
            r_CheckersGame.PawnBecameKing += pawn_BecameKing;
        }

        private void setScoreLabels(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            labelNamePlayer1.Text = i_FirstPlayerName + ":";
            labelScorePlayer1.Left = labelNamePlayer1.Right;
            labelNamePlayer2.Text = i_SecondPlayerName + ":";
            labelScorePlayer2.Left = labelNamePlayer2.Right;
            int minPanelsWidth = Math.Max(labelNamePlayer1.Width + labelScorePlayer1.Width + 50,
                labelNamePlayer2.Width + labelScorePlayer2.Width + 50);
            PanelScorePlayer1.Width = PanelScorePlayer2.Width = Math.Max(minPanelsWidth, 200);
        }

        private void setBoardAndFitScreenSize(int i_BoardSize)
        {
            int cellSize = i_BoardSize == 6 ? 100 : i_BoardSize == 8 ? 80 : 70;
            int rowMark = 1;
            char colMark = 'A';

            fitScreenSizeToBoardSize(i_BoardSize, cellSize);

            for (int i = 0; i < i_BoardSize; i++)
            {
                r_UICells.Add(new List<CellPictureBox>());
                addRowColLabels(cellSize, rowMark, colMark, i, i_BoardSize);
                for (int j = 0; j < i_BoardSize; j++)
                {
                    addNewCellToBoard(i, j, cellSize);
                }

                rowMark++;
                colMark++;
            }
        }

        private void addNewCellToBoard(int i_Row, int i_Col, int i_CellSize)
        {
            CellPictureBox cellPictureBox = new CellPictureBox(i_Row, i_Col, i_CellSize);
            cellPictureBox.BackgroundImage = (Math.Abs(i_Row - i_Col)) % 2 == 0
                                               ? Properties.Resources.white_tile_small
                                               : Properties.Resources.black_tile_small;
            cellPictureBox.Location = new Point(i_Col * cellPictureBox.Width + 50, i_Row * cellPictureBox.Height + 50);
            cellPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            cellPictureBox.Padding = new Padding(5, 5, 5, 5);
            cellPictureBox.Click += cell_Clicked;
            cellPictureBox.MouseEnter += cell_MouseEnter;
            addPawnToCellIfNeeded(i_Row, i_Col, cellPictureBox);

            panelBoard.Controls.Add(cellPictureBox);
            r_UICells[i_Row].Add(cellPictureBox);
        }

        private void addPawnToCellIfNeeded(int i_Row, int i_Col, CellPictureBox i_CellPictureBox)
        {
            Pawn? pawnOnCell;

            pawnOnCell = r_CheckersGame.GameBoard.CellArray[i_Row, i_Col].PawnOnCell;
            if(pawnOnCell != null)
            {
                i_CellPictureBox.Image = pawnOnCell.PawnColor == ePlayerColor.Black
                                           ? Properties.Resources.black_pawn_small
                                           : Properties.Resources.white_pawn_small;
            }
        }

        private void fitScreenSizeToBoardSize(int i_Size, int i_CellSize)
        {
            panelBoard.Size = new Size(i_Size * i_CellSize + 100, i_Size * i_CellSize + 100);
            this.Size = new Size(panelBoard.Width + 100, panelBoard.Height + 160);
            PanelScorePlayer1.Left = 50;
            PanelScorePlayer2.Left = this.Size.Width - PanelScorePlayer2.Width - 50;
            this.MinimumSize = this.Size;
            panelBoard.Left = 50;
            panelBoard.Top = PanelScorePlayer1.Top + PanelScorePlayer1.Height + 10;
            pictureBoxArrowTurn.Left = PanelScorePlayer1.Right + 10;
        }

        private void addRowColLabels(
            int i_CellSize, int i_RowMark, char i_ColMark,  int i_RowColNumber, int i_BoardSize)
        {
            List<Label> labels = new List<Label>();

            for(int i = 0; i < 4; i++)
            {
                labels.Add(new Label());
                labels[i].Text = i < 2 ? i_RowMark.ToString() : i_ColMark.ToString();
                labels[i].AutoSize = true;
                labels[i].BackColor = Color.Transparent;
                labels[i].Font = new Font(labelNamePlayer1.Font.FontFamily, 15, FontStyle.Bold);
                labels[i].Parent = panelBoard;
            }

            labels[0].Location = new Point(
                i_RowMark == 10? 5 : 15,
                50 + (i_CellSize - labels[0].Width) / 2 + i_RowColNumber * (i_CellSize));
            labels[1].Location = new Point(
                i_RowMark == 10 ? 55 + i_CellSize * i_BoardSize : 65 + i_CellSize * i_BoardSize,
                50 + (i_CellSize - labels[1].Width) / 2 + i_RowColNumber * (i_CellSize));
            labels[2].Location = new Point(
                50 + (i_CellSize - labels[2].Width) / 2 + i_RowColNumber * (i_CellSize), 15);
            labels[3].Location = new Point(
                50 + (i_CellSize - labels[3].Width) / 2 + i_RowColNumber * (i_CellSize),
                65 + i_CellSize * i_BoardSize);
        }

        private void cell_Clicked(object? sender, EventArgs e)
        {
            GameMove gameMove;
            CellPictureBox? chosenUICell = sender as CellPictureBox;
            Cell chosenCell = r_CheckersGame.GameBoard.CellArray[chosenUICell.Row, chosenUICell.Column];

            if(r_CurrentValidMovesDestinations.Contains(chosenCell))
            {
                GameMove wantedMove = getWantedMove(chosenCell);
                
                r_CheckersGame.DoMoveAndCheckIfDoubleMoveIsNeeded(wantedMove);

                if(r_CheckersGame.GetPlayerInTurn().PlayerType == ePlayerType.Computer)
                {
                    TimerToStartComputerMove.Start();
                }
            }
            else if (chosenCell == m_CurrentMoveSource)
            {
                cancelChosenSourceCell(chosenUICell);
            }
            else if (m_CurrentMoveSource == null && isPossibleSourceCell(chosenCell))
            {
                chooseSourceCell(chosenCell, chosenUICell);
            }
        }

        private void move_Done(GameMove i_WantedMove, bool i_IsDoubleMoveNeeded)
        {
            getCellPictureBox(i_WantedMove.DestinationCell).Image = getCellPictureBox(i_WantedMove.SourceCell).Image;
            getCellPictureBox(i_WantedMove.SourceCell).Image = null;
            if(i_WantedMove.EatenPawn != null)
            {
                getCellPictureBox(i_WantedMove.EatenPawn.PawnCurrentCell).Image = null;
            }

            cancelChosenSourceCell(getCellPictureBox(i_WantedMove.SourceCell));
            if(i_IsDoubleMoveNeeded)
            {
                if(r_CheckersGame.GetPlayerInTurn().PlayerType == ePlayerType.Human)
                {
                    chooseSourceCell(i_WantedMove.DestinationCell, getCellPictureBox(i_WantedMove.DestinationCell));                    
                }
                else
                {
                    TimerToStartComputerMove.Start();
                }
            }
            else
            {
                switchTurn();
            }
        }

        private void pawn_BecameKing(Pawn i_Pawn)
        {
            getCellPictureBox(i_Pawn.PawnCurrentCell).Image = i_Pawn.PawnColor == ePlayerColor.Black
                                                                  ? Properties.Resources.black_king
                                                                  : Properties.Resources.white_king;
        }

        private GameMove getWantedMove(Cell i_ChosenCell)
        {
            GameMove wantedMove = null;

            foreach(GameMove possibleMove in m_CurrentMoveSource.PawnOnCell.PossibleMoves)
            {
                if(possibleMove.DestinationCell == i_ChosenCell)
                {
                    wantedMove = possibleMove;
                }
            }

            return wantedMove;
        }

        private void cancelChosenSourceCell(CellPictureBox i_ChosenCellPictureBox)
        {
            m_CurrentMoveSource = null;
            foreach(Cell destinationCell in r_CurrentValidMovesDestinations)
            {
                unMarkCell(getCellPictureBox(destinationCell));
            }

            r_CurrentValidMovesDestinations.Clear();
            unMarkCell(i_ChosenCellPictureBox);
        }

        private void chooseSourceCell(Cell i_ChosenCell, CellPictureBox i_ChosenCellPictureBox)
        {
            m_CurrentMoveSource = i_ChosenCell;
            updateCurrentValidMovesDestinations(i_ChosenCell);
            markCell(i_ChosenCellPictureBox);
            foreach(Cell destinationCell in r_CurrentValidMovesDestinations)
            {
                markCell(getCellPictureBox(destinationCell));
            }
        }

        private CellPictureBox getCellPictureBox(Cell i_Cell)
        {
            return r_UICells[i_Cell.Row][i_Cell.Col]; 
        }

        private void unMarkCell(CellPictureBox i_CellPictureBoxToUnMark)
        {
            i_CellPictureBoxToUnMark.BackgroundImage = Properties.Resources.black_tile_small;
            i_CellPictureBoxToUnMark.MouseLeave += cell_MouseLeave;
            i_CellPictureBoxToUnMark.MouseEnter += cell_MouseEnter;
            i_CellPictureBoxToUnMark.Cursor = Cursors.Default;
        }

        private void markCell(CellPictureBox i_CellPictureBoxToMark)
        {
            i_CellPictureBoxToMark.BackgroundImage = Properties.Resources.black_tile_hilight;
            i_CellPictureBoxToMark.MouseLeave -= cell_MouseLeave;
            i_CellPictureBoxToMark.MouseEnter -= cell_MouseEnter;
            i_CellPictureBoxToMark.Cursor = Cursors.Hand;
        }

        private void updateCurrentValidMovesDestinations(Cell i_ChosenCell)
        {
            List<GameMove> possibleMovesList = r_CheckersGame.GetPlayerInTurn().CheckIfHaveEatingMoves()
                                               ? i_ChosenCell.PawnOnCell.GetPossibleEatingMoves()
                                               : i_ChosenCell.PawnOnCell.PossibleMoves;

            foreach (GameMove move in possibleMovesList)
            {
                r_CurrentValidMovesDestinations.Add(move.DestinationCell);
            }
        }

        private void switchTurn()
        {
            if (r_CheckersGame.GetPlayerInTurn().PlayerColor == ePlayerColor.White)
            {
                pictureBoxArrowTurn.Left = PanelScorePlayer1.Right + 10;
            }
            else
            {
                pictureBoxArrowTurn.Left = PanelScorePlayer2.Left - pictureBoxArrowTurn.Width - 10;
            }

            pictureBoxArrowTurn.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        private void miniGame_Ended(Player? i_Winner, int i_FirstPlayerScore, int i_SecondPlayerScore)
        {
            StringBuilder winnerMessage = new StringBuilder();
            string caption = "Game over";
            DialogResult doesWantAnotherRound;

            labelScorePlayer1.Text = i_FirstPlayerScore.ToString();
            labelScorePlayer2.Text = i_SecondPlayerScore.ToString();
            if (i_Winner == null)
            {
                winnerMessage.AppendLine("The game has ended with a draw!");
            }
            else
            {
                winnerMessage.AppendFormat("the game is over, the Winner is {0}!{1}", 
                    i_Winner.PlayerName, Environment.NewLine);
            }

            winnerMessage.AppendLine("Another round?");
            doesWantAnotherRound = MessageBox.Show(winnerMessage.ToString(), caption, MessageBoxButtons.YesNo);
            if(doesWantAnotherRound == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                reloadNewGame();
            }
        }

        private void reloadNewGame()
        {
            Player playerInTurn = r_CheckersGame.GetPlayerInTurn();

            r_CheckersGame.ReloadNewGame();
            for (int i = 0; i < r_CheckersGame.GameBoard.NumOfRows; i++)
            {
                for (int j = 0; j < r_CheckersGame.GameBoard.NumOfCols; j++)
                {
                    r_UICells[i][j].Image = null;
                    addPawnToCellIfNeeded(i, j, r_UICells[i][j]);
                }
            }

            m_CurrentMoveSource = null;
            r_CurrentValidMovesDestinations.Clear();
            if(r_CheckersGame.GetPlayerInTurn() != playerInTurn)
            {
                switchTurn();
            }
        }

        private void cell_MouseEnter(object? sender, EventArgs e)
        {
            CellPictureBox? hoveredUICell = sender as CellPictureBox;
            Cell hoveredCell = r_CheckersGame.GameBoard.CellArray[hoveredUICell.Row, hoveredUICell.Column];

            if (m_CurrentMoveSource == null && isPossibleSourceCell(hoveredCell))
            {
                hoveredUICell.Cursor = Cursors.Hand;
                hoveredUICell.BackgroundImage = Properties.Resources.black_tile_hilight;
                hoveredUICell.MouseLeave += new EventHandler(cell_MouseLeave);
            }
        }

        private bool isPossibleSourceCell(Cell i_Cell)
        {
            return i_Cell.PawnOnCell != null &&
                   r_CheckersGame.GetPlayerInTurn().PlayerType != ePlayerType.Computer &&
                   i_Cell.PawnOnCell.PawnColor == r_CheckersGame.GetPlayerInTurn().PlayerColor &&
                   r_CheckersGame.GetPlayerInTurn().GetPossibleMoveCellsOfPlayer().Contains(i_Cell);
        }

        private void cell_MouseLeave(object? sender, EventArgs e)
        {
            (sender as CellPictureBox).Cursor = Cursors.Default;
            (sender as CellPictureBox).BackgroundImage = Properties.Resources.black_tile_small;
            (sender as CellPictureBox).MouseLeave -= cell_MouseLeave;
        }

        private void TimerComputerThinking_Tick(object sender, EventArgs e)
        {
            TimerToStartComputerMove.Stop();
            r_CheckersGame.DoMoveAndCheckIfDoubleMoveIsNeeded();
        }
    }
}