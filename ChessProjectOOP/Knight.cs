using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChessProjectOOP
{
    class Knight : Piece, IDisposable
    {
        public Knight(OwnerTypes owner, PiecePosition position) : base(owner,position)
        {
            Type = PieceTypes.Insane;
            name = "Knight";

            if (owner == OwnerTypes.Black)
                Picture = new Bitmap(Properties.Resources.BlackInsane);
            else
                Picture = new Bitmap(Properties.Resources.WhiteInsane);

        }
        public override void Dispose()
        {
            Picture.Dispose();
        }

        public override List<PiecePosition> GetPossibileMoves(ChessTableSquare[,] table)
        {
            List<PiecePosition> moves = new List<PiecePosition>();
            return moves;
        }
        public override void ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
           
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
