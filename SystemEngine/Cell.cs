using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemEngine
{
    public class Cell
    {
        private int m_Row;
        private int m_Col;
        private Pawn m_PawnOnCell;

        public Cell(int i_Row, int i_Col, Pawn i_PawnOnCell = null)
        {
            m_Row = i_Row;
            m_Col = i_Col;
            m_PawnOnCell = i_PawnOnCell;
        }

        public Pawn PawnOnCell
        {
            get { return m_PawnOnCell; }
            set { m_PawnOnCell = value; }
        }

        public int Row
        {
            get { return m_Row; }
            set { m_Row = value; }
        }
        public int Col
        {
            get { return m_Col; }
            set { m_Col = value; }
        }
    }
}
