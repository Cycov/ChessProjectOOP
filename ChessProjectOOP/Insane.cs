using System;
using System.Drawing;

namespace ChessProjectOOP
{
    class Insane : Piece, IDisposable
    {
        public Insane(OwnerTypes owner, PiecePosition position) : base(owner,position)
        {
            Type = PieceTypes.Insane;
            name = "Insane";

            if (owner == OwnerTypes.Black)
                Picture = new Bitmap(Properties.Resources.BlackInsane);
            else
                Picture = new Bitmap(Properties.Resources.WhiteInsane);

        }
        public override void Dispose()
        {
            Picture.Dispose();
        }

        public override void Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
            if (Math.Abs(newPosition.Column - Position.Column) == Math.Abs(newPosition.Row - Position.Row))
            {
                //Begin tracing to see if collides with any other pieces
                

                Position = newPosition;
                return;
            }
            throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
        }
    }
}
