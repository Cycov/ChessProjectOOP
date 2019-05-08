using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    public class PiecePosition
    {
        public EColumn Column { get; set; }
        public int Row { get; set; }

        public PiecePosition(int column, int row) : this((EColumn)column, row)
        {

        }

        public PiecePosition(EColumn column, int row)
        {
            if (row < 1 || row > 8)
            {
                throw new ArgumentOutOfRangeException("row", row, "The row can not be less than 1 or bigger than 8.");
            }

            Column = column;
            Row = row;
        }
        public PiecePosition(PiecePosition position)
        {
            Column = position.Column;
            Row = position.Row;
        }
        public PiecePosition(string position)
        {
            try
            {
                Column = (EColumn)Enum.Parse(typeof(EColumn), position[0].ToString());
                Row = int.Parse(position[1].ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("The position is not in the correct format <column><row>", nameof(position), ex);
            }
        }

        public override string ToString()
        {
            return Column.ToString() + (9 - Row).ToString();
        }
        public string ToString(bool real)
        {
            if (real)
                return ToString();
            else
                return Column.ToString() + Row.ToString();
        }
        public override bool Equals(object obj)
        {
            PiecePosition pos = obj as PiecePosition;
            if (pos.Column == Column && pos.Row == Row)
                return true;
            else
                return false;
        }
    }
}
