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
            if ((int)Position.Column + 2 < 8  && Position.Row + 1 < 8 )
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column + 2, Position.Row + 1);
                    ValidateMove(newPos, table, 1);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column + 2 < 8  && Position.Row - 1 < 1)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column + 2, Position.Row - 1);
                    ValidateMove(newPos, table, 2);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column - 2 < 1 && Position.Row + 1 < 8 )
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column - 2, Position.Row + 1);
                    ValidateMove(newPos, table, 3);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column - 2 < 1 && Position.Row - 1 >= 1)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column - 2, Position.Row - 1);
                    ValidateMove(newPos, table, 4);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column + 1 < 8  && Position.Row + 2 < 8 )
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column + 1, Position.Row + 2);
                    ValidateMove(newPos, table, 5);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column + 1 < 8  && Position.Row - 2 >= 1)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column + 1, Position.Row - 2);
                    ValidateMove(newPos, table, 6);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column - 1 >= 1 && Position.Row + 2 < 8 )
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column - 1, Position.Row + 2);
                    ValidateMove(newPos, table, 7);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column - 1 >= 1 && Position.Row - 2 >= 1)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column - 1, Position.Row - 2);
                    ValidateMove(newPos, table, 8);
                    moves.Add(newPos);
                }
                catch { }
            }
            return moves;
        }
    
        public override bool ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
            base.ValidateMove(newPosition, table, direction);
        }

        public override bool Move(PiecePosition newPosition, ChessTableSquare[,] table)
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
