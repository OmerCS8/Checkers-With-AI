using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemEngine
{
    public class Pawn
    {
        private bool m_IsKing;
        private Cell m_PawnCurrentCell;
        private List<GameMove> m_PossibleMoves;
        private readonly Player.ePlayerColor r_PawnColor;

        public Pawn(Cell i_PawnCurrentCell, Player.ePlayerColor i_PawnColor)
        {
            m_PawnCurrentCell = i_PawnCurrentCell;
            r_PawnColor = i_PawnColor;
            m_IsKing = false;
            m_PossibleMoves = new List<GameMove>();
        }

        public bool IsKing
        {
            get { return m_IsKing; }
            set { m_IsKing = value; }
        }

        public List<GameMove> PossibleMoves
        {
            get { return m_PossibleMoves; }
        }

        public Cell PawnCurrentCell
        {
            get { return m_PawnCurrentCell; }
            set { m_PawnCurrentCell = value; }
        }

        public Player.ePlayerColor PawnColor
        {
            get { return r_PawnColor; }
        }

        public int GetPawnRow()
        {
            return m_PawnCurrentCell.Row;
        }

        public int GetPawnColl()
        {
            return m_PawnCurrentCell.Col;
        }

        public void GeneratePawnPossibleMoves(Board i_Board)
        {
            m_PossibleMoves.Clear();

            if(r_PawnColor == Player.ePlayerColor.Black || m_IsKing)
            {
                addPossibleMovesForPawnAtDirection(GameMove.K_Down, GameMove.K_Left, i_Board);
                addPossibleMovesForPawnAtDirection(GameMove.K_Down, GameMove.K_Right, i_Board);
            }

            if(r_PawnColor == Player.ePlayerColor.White || m_IsKing)
            {
                addPossibleMovesForPawnAtDirection(GameMove.K_Up, GameMove.K_Left, i_Board);
                addPossibleMovesForPawnAtDirection(GameMove.K_Up, GameMove.K_Right, i_Board);
            }
        }

        private void addPossibleMovesForPawnAtDirection(int i_rowDirection, int i_colDirection, Board i_Board)
        {
            Cell possibleMoveDest;
            Cell possibleEatDest;

            if(i_Board.TryGetCellAtPosition(GetPawnRow() + i_rowDirection, GetPawnColl() + i_colDirection, out possibleMoveDest))
            {
                if(possibleMoveDest.PawnOnCell == null)
                {
                    m_PossibleMoves.Add(new GameMove(m_PawnCurrentCell,possibleMoveDest));
                }
                else if(possibleMoveDest.PawnOnCell.PawnColor != r_PawnColor)
                {
                    if(i_Board.TryGetCellAtPosition( possibleMoveDest.Row + i_rowDirection,
                           possibleMoveDest.Col + i_colDirection, out possibleEatDest))
                    {
                        if(possibleEatDest.PawnOnCell == null)
                        {
                            m_PossibleMoves.Add(new GameMove(m_PawnCurrentCell, possibleEatDest, possibleMoveDest.PawnOnCell));
                        }
                    }
                }
            }
        }

        public List<GameMove> GetPossibleEatingMoves()
        {
            List<GameMove> possibleEatingMoves = new List<GameMove>();

            foreach(GameMove possibleMove in PossibleMoves)
            {
                if(possibleMove.EatenPawn != null)
                {
                    possibleEatingMoves.Add(possibleMove);
                }
            }

            return possibleEatingMoves;
        }
    }

}
