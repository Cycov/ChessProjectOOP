using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    class Queen : Piece, IDisposable
    {
        public Queen(OwnerTypes owner, PiecePosition position) : base(owner,position)
        {
            Type = PieceTypes.Queen;
            name = "Queen";

            if (owner == OwnerTypes.Black)
                Picture = new Bitmap(Properties.Resources.BlackQueen);
            else
                Picture = new Bitmap(Properties.Resources.WhiteQueen);

        }
        public override void Dispose()
        {
            Picture.Dispose();
        }

        public override void Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
            if (Math.Abs(newPosition.Column - Position.Column) == Math.Abs(newPosition.Row - Position.Row))
            {
                Position = newPosition;
                return;
            }
            if (newPosition.Row == Position.Row && newPosition.Column != Position.Column)
            {
                Position = newPosition;
                return;
            }

            if (newPosition.Column == Position.Column && newPosition.Row != Position.Row)
            {
                Position = newPosition;
                return;
            }

            throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
        }
    }
}
