using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    class Horse : Piece, IDisposable
    {
        public Horse(OwnerTypes owner, PiecePosition position) : base(owner,position)
        {
            Type = PieceTypes.Horse;
            name = "Horse";

            if (owner == OwnerTypes.Black)
                Picture = new Bitmap(Properties.Resources.BlackHorse);
            else
                Picture = new Bitmap(Properties.Resources.WhiteHorse);

        }
        public override void Dispose()
        {
            Picture.Dispose();
        }

        public override List<PiecePosition> GetPossibileMoves( ChessTableSquare[,] table)
        {
            List<PiecePosition> moves = new List<PiecePosition>();
            return moves;
        }
    
        public override void ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
           
        }

        public override void Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
            //Check for for each of the 8 possibile moves by checking some argument first
            //For example the first move is bottom left, condition is row changed by 2, then if column changed by 1
            //Because the first part of an if (_&&_) is executed first, it suits perfectly
            if (Math.Abs(newPosition.Row - Position.Row) == 2 && Math.Abs(newPosition.Column - Position.Column) == 1)
            {
                Position = newPosition;
                return;
            }
            if (Math.Abs(newPosition.Row - Position.Row) == 1 && Math.Abs(newPosition.Column - Position.Column) == 2)
            {
                Position = newPosition;
                return;
            }

            throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
        }

    }
}
