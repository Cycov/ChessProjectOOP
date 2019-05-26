using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    class Knight : Piece, IDisposable
    {
        public Knight(OwnerTypes owner, PiecePosition position) : base(owner, position)
        {
            Type = PieceTypes.Knight;
            name = "Knight";

            if (owner == OwnerTypes.Black)
                Picture = new Bitmap(Properties.Resources.BlackHorse);
            else
                Picture = new Bitmap(Properties.Resources.WhiteHorse);

        }
        public override void Dispose()
        {
            Picture.Dispose();
        }

        public override List<PiecePosition> GetPossibileMoves(ChessTableSquare[,] table)
        {
            List<PiecePosition> moves = new List<PiecePosition>();
            if ((int)Position.Column + 2 < 8 && Position.Row + 1 < 8)
            {

                var newPos = new PiecePosition(Position.Column + 2, Position.Row + 1);
                if (ValidateMove(newPos, table, 1))
                    moves.Add(newPos);

            }

            if ((int)Position.Column + 2 < 8 && Position.Row > 1)
            {
                var newPos = new PiecePosition(Position.Column + 2, Position.Row - 1);
                if (ValidateMove(newPos, table, 2))
                    moves.Add(newPos);
            }

            if ((int)Position.Column - 2 > 1 && Position.Row + 1 < 8)
            {
                var newPos = new PiecePosition(Position.Column - 2, Position.Row + 1);
                if (ValidateMove(newPos, table, 3))
                    moves.Add(newPos);
            }

            if ((int)Position.Column - 2 < 1 && Position.Row - 1 >= 1)
            {
                var newPos = new PiecePosition(Position.Column - 2, Position.Row - 1);
                if (ValidateMove(newPos, table, 4))
                    moves.Add(newPos);
            }

            if ((int)Position.Column + 1 <= 8 && Position.Row + 2 < 8)
            {
                var newPos = new PiecePosition(Position.Column + 1, Position.Row + 2);
                if (ValidateMove(newPos, table, 5))
                    moves.Add(newPos);
            }

            if ((int)Position.Column + 1 <= 8 && Position.Row - 2 >= 1)
            {
                var newPos = new PiecePosition(Position.Column + 1, Position.Row - 2);
                if (ValidateMove(newPos, table, 6))
                    moves.Add(newPos);
            }

            if ((int)Position.Column - 1 >= 1 && Position.Row + 2 < 8)
            {
                var newPos = new PiecePosition(Position.Column - 1, Position.Row + 2);
                if (ValidateMove(newPos, table, 7))
                    moves.Add(newPos);
            }

            if ((int)Position.Column - 1 >= 1 && Position.Row - 2 >= 1)
            {
                var newPos = new PiecePosition(Position.Column - 1, Position.Row - 2);
                if (ValidateMove(newPos, table, 8))
                    moves.Add(newPos);
            }
            return moves;
        }

        public override bool ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
            if (!base.ValidateMove(newPosition, table, direction))
                return false;


            if (direction == 0 && Position.Row == newPosition.Row && Position.Column == newPosition.Column)
                return false;

            if ((direction == 0 || direction == 1) && 
                newPosition.Row == Position.Row + 1 && newPosition.Column == Position.Column + 2)
            {
                return true;
            }

            if ((direction == 0 || direction == 2) && 
                newPosition.Row == Position.Row - 1 && newPosition.Column == Position.Column + 2)
            {
                        return true;
            }

            if ((direction == 0 || direction == 3) && 
                newPosition.Row == Position.Row + 1 && newPosition.Column == Position.Column - 2)
            {
                return true;
            }

            if ((direction == 0 || direction == 4) &&
                newPosition.Row == Position.Row - 1 && newPosition.Column == Position.Column - 2)
            {
                return true;
            }

            if ((direction == 0 || direction == 5) &&
                newPosition.Row == Position.Row + 2 && newPosition.Column == Position.Column + 1)
            {
                return true;
            }

            if ((direction == 0 || direction == 6) &&
                newPosition.Row == Position.Row - 2 && newPosition.Column == Position.Column + 1)
            {
                return true;
            }

            if ((direction == 0 || direction == 7) &&
                newPosition.Row == Position.Row + 2 && newPosition.Column == Position.Column - 1)
            {
                return true;
            }

            if ((direction == 0 || direction == 8) &&
                newPosition.Row == Position.Row - 2 && newPosition.Column == Position.Column - 1)
            {
                return true;
            }
            return false;
        }

        public override bool Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
            //Check for for each of the 8 possibile moves by checking some argument first
            //For example the first move is bottom left, condition is row changed by 2, then if column changed by 1
            //Because the first part of an if (_&&_) is executed first, it suits perfectly
            if (ValidateMove(newPosition, table))
            {
                Position = newPosition;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
