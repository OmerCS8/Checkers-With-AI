using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemEngine
{
    public class GameMove
    {
        private readonly Cell r_SourceCell;
        private readonly Cell r_DestinationCell;
        private Pawn m_EatenPawn;
        public const int K_Left = -1;
        public const int K_Right = 1;
        public const int K_Up = -1;
        public const int K_Down = 1;

        public GameMove(Cell i_SourceCell, Cell i_DestinationCell, Pawn i_EatenPawn = null)
        {
            r_SourceCell = i_SourceCell;
            r_DestinationCell = i_DestinationCell;
            m_EatenPawn = i_EatenPawn;
        }

        public Cell SourceCell
        {
            get { return r_SourceCell; }
        }

        public Cell DestinationCell
        {
            get { return r_DestinationCell; }
        }

        public Pawn EatenPawn
        {
            get { return m_EatenPawn; }
            set { m_EatenPawn = value; }
        }
    }
}
