using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemEngine
{
    public class Board
    {
        private int m_NumOfRows;
        private int m_NumOfCols;
        private Cell[,] m_CellArray;

        public Board(int i_NumOfRows, int i_NumOfCols)
        {
            m_NumOfRows = i_NumOfRows;
            m_NumOfCols = i_NumOfCols;
            m_CellArray = new Cell[m_NumOfRows, m_NumOfCols];
            initializeBoard();
        }

        private void initializeBoard()
        {
            for(int i = 0; i < m_NumOfRows; i++)
            {
                for(int j = 0; j < m_NumOfCols; j++)
                {
                    m_CellArray[i, j] = new Cell(i, j);
                }
            }
        }

        public void ClearAllPawnsOnCells()
        {
            for(int i = 0; i < m_NumOfRows; i++)
            {
                for(int j = 0; j < m_NumOfCols; j++)
                {
                    m_CellArray[i, j].PawnOnCell = null;
                }
            }
        }

        public int NumOfRows
        {
            get { return m_NumOfRows; }
            set { m_NumOfRows = value; }
        }

        public int NumOfCols
        {
            get { return m_NumOfCols; }
            set { m_NumOfCols = value; }
        }

        public Cell[,] CellArray
        {
            get { return m_CellArray; }
            set { m_CellArray = value; }
        }

        public bool TryGetCellAtPosition(int row, int col, out Cell o_CellAtPos)
        {
            o_CellAtPos = null;
            bool isCellInBoard = (row >= 0 && row < m_NumOfRows) && (col >= 0 && col < m_NumOfCols);

            if(isCellInBoard)
            {
                o_CellAtPos = CellArray[row, col];
            }

            return isCellInBoard;
        }
        public bool CheckIfPawnAtKingRow(Pawn i_Pawn)
        {
            return (i_Pawn.PawnColor == Player.ePlayerColor.White && i_Pawn.PawnCurrentCell.Row == 0)
                   || (i_Pawn.PawnColor == Player.ePlayerColor.Black && i_Pawn.PawnCurrentCell.Row == m_NumOfRows - 1);
        }
        
        public bool CheckIfPawnAtStartRow(Pawn i_Pawn)
        {
            return (i_Pawn.PawnColor == Player.ePlayerColor.White && i_Pawn.PawnCurrentCell.Row == m_NumOfRows - 1)
                   || (i_Pawn.PawnColor == Player.ePlayerColor.Black && i_Pawn.PawnCurrentCell.Row == 0);
        }

        public bool CheckIfPawnAtMiddleBoard(Pawn i_Pawn)
        {
            int spaceBetweenMiddleAndEdge = NumOfRows / 4;

            return i_Pawn.PawnCurrentCell.Row >= spaceBetweenMiddleAndEdge
                   && i_Pawn.PawnCurrentCell.Row <= NumOfRows - spaceBetweenMiddleAndEdge
                   && i_Pawn.PawnCurrentCell.Col >= spaceBetweenMiddleAndEdge
                   && i_Pawn.PawnCurrentCell.Col <= NumOfCols - spaceBetweenMiddleAndEdge;

        }

        public bool CheckIfCellAtKingRow(Cell i_Cell, Player.ePlayerColor i_Color)
        {
            return (i_Color == Player.ePlayerColor.White && i_Cell.Row == 0)
                   || (i_Color == Player.ePlayerColor.Black && i_Cell.Row == m_NumOfRows - 1);
        }
    }
}
