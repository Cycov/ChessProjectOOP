using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    class King : Piece, IDisposable
    {
        public King(OwnerTypes owner, PiecePosition position) : base(owner,position)
        {
            Type = PieceTypes.King;
            name = "King";

            if (owner == OwnerTypes.Black)
                Picture = new Bitmap(Properties.Resources.BlackKing);
            else
                Picture = new Bitmap(Properties.Resources.WhiteKing);

        }
        public override void Dispose()
        {
            Picture.Dispose();
        }

        public override void Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
            if ((Math.Abs(newPosition.Column - Position.Column) == Math.Abs(newPosition.Row - Position.Row)) && Math.Abs(newPosition.Row - Position.Row) == 1)
            {
                Position = newPosition;
                return;
            }
            if ((newPosition.Row == Position.Row && newPosition.Column != Position.Column) && Math.Abs(newPosition.Column - Position.Column) == 1)
            {
                Position = newPosition;
                return;
            }

            if ((newPosition.Column == Position.Column && newPosition.Row != Position.Row) && Math.Abs(newPosition.Row - Position.Row) == 1)
            {
                Position = newPosition;
                return;
            }
            throw new IllegalMoveException(this, "Can not move to the new position: " + newPosition.ToString());
        }
    }
}
