using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemEngine
{
    public class Player
    {
        public enum ePlayerType
        {
            Human,
            Computer
        }

        public enum ePlayerColor
        {
            Black,
            White
        }

        private readonly string r_Name;
        private List<Pawn> m_PawnsArr;
        private ePlayerType m_PlayerType;
        private readonly ePlayerColor r_PlayerColor;
        private bool m_IsPlayerTurn;
        private List<GameMove> m_PlayedMovesHistory;
        private int m_Points;

        public Player(ePlayerType i_PlayerType, ePlayerColor i_PlayerColor, string i_Name = "Computer")
        {
            m_PlayerType = i_PlayerType;
            r_PlayerColor = i_PlayerColor;
            m_IsPlayerTurn = i_PlayerColor == ePlayerColor.White; 
            r_Name = i_Name;
            m_PawnsArr = new List<Pawn>();
            m_PlayedMovesHistory = new List<GameMove>();
            m_Points = 0;
        }

        public void InitializePlayerPawns(Board i_Board)
        {
            int numOfPawnRows = (i_Board.NumOfRows / 2) - 1;
            int startingColumn;

            switch(r_PlayerColor)
            {
                case ePlayerColor.Black:
                    startingColumn = 1;
                    for(int i = 0; i < numOfPawnRows; i++)
                    {
                        addPawnsAtLine(i_Board, startingColumn, i);
                        startingColumn = startingColumn == 0 ? 1 : 0;
                    }

                    break;

                case ePlayerColor.White:
                    startingColumn = 0;
                    for (int i = i_Board.NumOfRows - 1; i >= i_Board.NumOfRows - numOfPawnRows; --i)
                    {
                        addPawnsAtLine(i_Board, startingColumn, i);
                        startingColumn = startingColumn == 0 ? 1 : 0;
                    }

                    break;
            }
        }

        private void addPawnsAtLine(Board i_Board, int i_StartingColumn, int i_Line)
        {
            for(int j = i_StartingColumn; j < i_Board.NumOfCols; j += 2)
            {
                m_PawnsArr.Add(new Pawn(i_Board.CellArray[i_Line, j],r_PlayerColor));
                i_Board.CellArray[i_Line, j].PawnOnCell = m_PawnsArr.Last();
            }
        }

        public ePlayerType PlayerType
        {
            get { return m_PlayerType; }
            set { m_PlayerType = value; }
        }

        public List<Pawn> PawnsArray
        {
            get { return m_PawnsArr; }
            set { m_PawnsArr = value; }
        }

        public List<GameMove> PlayedMovesHistory
        {
            get { return m_PlayedMovesHistory; }
            set { m_PlayedMovesHistory = value; }
        }

        public bool didPlayAnyMove()
        {
            return m_PlayedMovesHistory.Count > 0;
        }

        public bool IsPlayerTurn
        {
            get { return m_IsPlayerTurn; }
            set { m_IsPlayerTurn = value; }
        }

        public string PlayerName
        {
            get { return r_Name; }
        }

        public ePlayerColor PlayerColor
        {
            get { return r_PlayerColor; }
        }

        public int Points
        {
            get { return m_Points; }
            set { m_Points = value; }
        }

        public List<GameMove> GetPossibleMovesOfPlayer()
        {
            List<GameMove> possibleMoves = new List<GameMove>();

            foreach(Pawn pawn in m_PawnsArr)
            {
                foreach(GameMove move in pawn.PossibleMoves)
                {
                    possibleMoves.Add(move);
                }
            }

            return possibleMoves;
        }

        public List<GameMove> GetPossibleEatingMoves()
        {
            List<GameMove> possibleEatingMoves = new List<GameMove>();

            foreach(GameMove move in GetPossibleMovesOfPlayer())
            {
                if(move.EatenPawn != null)
                {
                    possibleEatingMoves.Add(move);
                }
            }

            return possibleEatingMoves;
        }

        public bool CheckIfHaveEatingMoves(Board i_Board)
        {
            return GetPossibleEatingMoves().Count > 0;
        }
    }
}
