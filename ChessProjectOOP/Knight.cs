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

            for (int i = (int)Position.Column + 1, j = (int)Position.Row + 1; i < 8 & j < 8; i++, j++) //UP-UP
            {
                try
                {
                    var newPos = new PiecePosition(i, j);
                    ValidateMove(newPos, table, 5);
                    moves.Add(newPos);
                }
                catch { }
            }

            for (int i = (int)Position.Column - 1, j = (int)Position.Row + 1; i > 1 & j < 8; i--, j++) //DOWN-UP
            {
                try
                {
                    var newPos = new PiecePosition(i, j);
                    ValidateMove(newPos, table, 6);
                    moves.Add(newPos);
                }
                catch { }
            }

            for (int i = (int)Position.Column + 1, j = (int)Position.Row - 1; i < 8 & j > 1; i++, j--) //up-down
            {
                try
                {
                    var newPos = new PiecePosition(i, j);
                    ValidateMove(newPos, table, 7);
                    moves.Add(newPos);
                }
                catch { }
            }

            for (int i = (int)Position.Column - 1, j = (int)Position.Row - 1; i > 1 & j > 1; i--, j--) //down-down
            {
                try
                {
                    var newPos = new PiecePosition(i, j);
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

            if (direction == 0 && Position.Row != newPosition.Row && Position.Column != newPosition.Column)
                throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));

            //Colision rules
            if ((direction == 0 || direction == 5) && (int)newPosition.Column > (int)Position.Column && (int)newPosition.Row > (int)Position.Row)
            {
                for (int i = (int)Position.Column + 1, j = (int)Position.Row + 1; i < 8 & j < 8; i++, j++)
                    if (!table[i + 1, j + 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }

            if ((direction == 0 || direction == 6) && (int)newPosition.Column < (int)Position.Column && (int)newPosition.Row > (int)Position.Row)
            {
                for (int i = (int)Position.Column - 1, j = (int)Position.Row + 1; i > 1 & j < 8; i--, j++)
                    if (!table[i - 1, j + 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }

            if ((direction == 0 || direction == 7) && (int)newPosition.Column > (int)Position.Column && (int)newPosition.Row < (int)Position.Row)
            {
                for (int i = (int)Position.Column + 1, j = (int)Position.Row - 1; i < 8 & j > 1; i++, j--)
                    if (!table[i + 1, j - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }

            if ((direction == 0 || direction == 8) && (int)newPosition.Column < (int)Position.Column && (int)newPosition.Row < (int)Position.Row)
            {
                for (int i = (int)Position.Column - 1, j = (int)Position.Row - 1; i > 1 & j > 1; i--, j--)
                    if (!table[i - 1, j - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }

        }

        public override bool Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
            try
            {
                ValidateMove(newPosition, table);
                Position = newPosition;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
