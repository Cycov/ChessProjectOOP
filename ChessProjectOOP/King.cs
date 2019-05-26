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
                var newPos = new PiecePosition(Position.Column, Position.Row + 1); //0-up
                if (ValidateMove(newPos, table, 1))
                    moves.Add(newPos);
            }

            if (Position.Row - 1 >= 1)
            {
                var newPos = new PiecePosition(Position.Column, Position.Row - 1); //0-down
                if (ValidateMove(newPos, table, 2))
                    moves.Add(newPos);
            }

            if ((int)Position.Column + 1 <= 8)
            {
                var newPos = new PiecePosition(Position.Column + 1, Position.Row); //up-0
                if (ValidateMove(newPos, table, 3))
                    moves.Add(newPos);
            }

            if ((int)Position.Column - 1 >= 1)
            {
                var newPos = new PiecePosition(Position.Column - 1, Position.Row); //down-0
                if (ValidateMove(newPos, table, 4))
                    moves.Add(newPos);
            }

            if ((int)Position.Column + 1 <= 8 && Position.Row + 1 <= 8)
            {
                var newPos = new PiecePosition(Position.Column + 1, Position.Row + 1); //up-up
                if (ValidateMove(newPos, table, 5))
                    moves.Add(newPos);
            }

            if ((int)Position.Column + 1 >= 1 && Position.Row + 1 <= 8)
            {
                var newPos = new PiecePosition(Position.Column - 1, Position.Row + 1); //down-up
                if (ValidateMove(newPos, table, 6))
                    moves.Add(newPos);
            }

            if ((int)Position.Column + 1 <= 8 && Position.Row - 1 >= 1)
            {
                var newPos = new PiecePosition(Position.Column + 1, Position.Row - 1); //up-down
                if (ValidateMove(newPos, table, 7))
                    moves.Add(newPos);
            }

            if ((int)Position.Column - 1 >= 1 && Position.Row - 1 >= 1)
            {
                var newPos = new PiecePosition(Position.Column - 1, Position.Row - 1); //down-down
                if (ValidateMove(newPos, table, 8))
                    moves.Add(newPos);
            }

            return moves;
        }
        public override bool ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
            if (!base.ValidateMove(newPosition, table, direction))
                return false;


            // TODO: sah-mat

            if (direction == 0 && Position.Row != newPosition.Row && Position.Column != newPosition.Column)
                return true;

            return false;
        }

        public override bool Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
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
