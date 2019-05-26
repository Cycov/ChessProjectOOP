using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChessProjectOOP
{
    class Bishop : Piece, IDisposable
    {
        public Bishop(OwnerTypes owner, PiecePosition position) : base(owner,position)
        {
            Type = PieceTypes.Bishop;
            name = "Bishop";

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

            for (int i = (int)Position.Column + 1, j = Position.Row + 1; i <= 8 & j <= 8; i++, j++) //UP-UP
            {
                var newPos = new PiecePosition(i, j);
                if (ValidateMove(newPos, table, 1))
                    moves.Add(newPos);
            }

            for (int i = (int)Position.Column - 1, j = (int)Position.Row + 1; i >= 1 && j <= 8; i--, j++) //DOWN-left
            {
                var newPos = new PiecePosition(i, j);
                if (ValidateMove(newPos, table, 2))
                    moves.Add(newPos);
                else
                    break;
            }

            for (int i = (int)Position.Column + 1, j = (int)Position.Row - 1; i <= 8 & j > 1; i++, j--) //up-down
            {
                var newPos = new PiecePosition(i, j);
                if (ValidateMove(newPos, table, 3))
                    moves.Add(newPos);
            }

            for (int i = (int)Position.Column - 1, j = (int)Position.Row - 1; i >= 1 && j >= 1; i--, j--) //up-left
            {
                var newPos = new PiecePosition(i, j);
                if (ValidateMove(newPos, table, 4))
                    moves.Add(newPos);
                else
                    break;
            }
            return moves;
        }
        public override bool ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
            if (!base.ValidateMove(newPosition, table, direction))
                return false;


            if (direction == 0 && Position.Row != newPosition.Row && Position.Column != newPosition.Column)
                return false;

            //Colision rules
            if ((direction == 0 || direction == 1) && (int)newPosition.Column < (int)Position.Column && (int)newPosition.Row < (int)Position.Row)
            {
                for (int i = (int)Position.Column + 1, j = (int)Position.Row + 1; i < (int)newPosition.Column & j < (int)newPosition.Row; i++, j++)
                    if (!table[i + 1, j + 1].IsEmpty)
                        return false;
                    else
                        return true;
            }

            if ((direction == 0 || direction == 2) && (int)newPosition.Column < (int)Position.Column && (int)newPosition.Row > (int)Position.Row)
            {
                for (int i = (int)Position.Column - 1, j = (int)Position.Row + 1; i >= (int)Position.Column & j <= (int)newPosition.Row; i--, j++)
                {
                    if (!table[i - 1, j - 1].IsEmpty)
                        return false;
                }
                return true;
            }

            if ((direction == 0 || direction == 3) && (int)newPosition.Column > (int)Position.Column && (int)newPosition.Row < (int)Position.Row)
            {
                for (int i = (int)Position.Column + 1, j = (int)Position.Row - 1; i <= (int)newPosition.Column & j > (int)newPosition.Row; i++, j--)
                {
                    if (!table[i + 1, j - 1].IsEmpty)
                        return false;
                }
                return true;
            }

            if ((direction == 0 || direction == 4) && (int)newPosition.Column < (int)Position.Column && (int)newPosition.Row < (int)Position.Row)
            {
                for (int i = (int)Position.Column - 1, j = (int)Position.Row - 1; i >= (int)Position.Column & j >= (int)newPosition.Row; i--, j--)
                {
                    if (!table[i - 1, j - 1].IsEmpty)
                        return false;
                }
                return true;
            }

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
