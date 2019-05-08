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

        public override List<PiecePosition> GetPossibileMoves(ChessTableSquare[,] table)
        {
            List<PiecePosition> moves = new List<PiecePosition>();

            if (Position.Row + 1 <= 8)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column, Position.Row + 1); //0-up
                    ValidateMove(newPos, table, 1);
                    moves.Add(newPos);
                }
                catch { }
            }

            if (Position.Row - 1 >= 1)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column, Position.Row - 1); //0-down
                    ValidateMove(newPos, table, 2);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column + 1 <= 8)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column + 1, Position.Row); //up-0
                    ValidateMove(newPos, table, 3);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column - 1 >= 1)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column - 1, Position.Row); //down-0
                    ValidateMove(newPos, table, 4);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column + 1 <= 8 && Position.Row + 1 <= 8)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column + 1, Position.Row + 1); //up-up
                    ValidateMove(newPos, table, 5);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column + 1 >= 1 && Position.Row + 1 <= 8)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column - 1, Position.Row + 1); //down-up
                    ValidateMove(newPos, table, 6);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column + 1 <= 8 && Position.Row + 1 >= 1)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column + 1, Position.Row - 1); //up-down
                    ValidateMove(newPos, table, 7);
                    moves.Add(newPos);
                }
                catch { }
            }

            if ((int)Position.Column + 1 >= 1 && Position.Row + 1 >= 1)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column - 1, Position.Row - 1); //down-down
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


            // TODO: sah-mat

            if (direction == 0 && Position.Row != newPosition.Row && Position.Column != newPosition.Column)
                throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
        }

        public override bool Move(PiecePosition newPosition, ChessTableSquare[,] table)
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
