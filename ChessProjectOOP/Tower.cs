using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    class Tower : Piece
    {
        public Tower(OwnerTypes owner, PiecePosition position) : base(owner,position)
        {
            Type = PieceTypes.Tower;
            name = "Tower";

            if (owner == OwnerTypes.Black)
                Picture = new Bitmap(Properties.Resources.BlackTower);
            else
                Picture = new Bitmap(Properties.Resources.WhiteTower);

        }
        public override void Dispose()
        {
            Picture.Dispose();
        }

        public override List<PiecePosition> GetPossibileMoves(ChessTableSquare[,] table)
        {
            List<PiecePosition> moves = new List<PiecePosition>();

            for (int i = Position.Row + 1; i < table.GetLength(1); i++)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column, i);
                    ValidateMove(newPos, table, 1);
                    moves.Add(newPos);
                }
                catch { }
            }

            for (int i = Position.Row - 1; i > 0; i--)
            {
                try
                {
                    var newPos = new PiecePosition(Position.Column, i);
                    ValidateMove(newPos, table, 2);
                    moves.Add(newPos);
                }
                catch { }
            }

            for (int i = (int)Position.Column + 1; i < table.GetLength(0); i++)
            {
                try
                {
                    var newPos = new PiecePosition((EColumn)i, Position.Row);
                    ValidateMove(newPos, table, 3);
                    moves.Add(newPos);
                }
                catch { }
            }

            for (int i = (int)Position.Column - 1; i > 0; i--)
            {
                try
                {
                    var newPos = new PiecePosition((EColumn)i, Position.Row);
                    ValidateMove(newPos, table, 4);
                    moves.Add(newPos);
                }
                catch { }
            }
            return moves;
        }

        public override void ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
            base.ValidateMove(newPosition, table, direction);


            if (direction == 0 && Position.Row != newPosition.Row && Position.Column != newPosition.Column)
                throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            
            //Colision rules
            if ((direction == 0 || direction ==  1) && newPosition.Row > Position.Row)
            {
                for (int i = Position.Row + 1; i < newPosition.Row; i++) //up-down
                    if (!table[(int)Position.Column - 1, i - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }
            if ((direction == 0 || direction == 2) && newPosition.Row < Position.Row)
            {
                for (int i = Position.Row - 1; i > newPosition.Row; i--) //up-down
                    if (!table[(int)Position.Column - 1, i - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }

            if ((direction == 0 || direction == 3) && (int)newPosition.Column > (int)Position.Column)
            {
                for (int i = (int)Position.Column + 1; i < (int)newPosition.Column; i++)
                    if (!table[i - 1, Position.Row - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }
            if ((direction == 0 || direction == 4) && (int)newPosition.Column < (int)Position.Column)
            {
                for (int i = (int)Position.Column - 1; i > (int)newPosition.Column; i--)
                    if (!table[i - 1, Position.Row - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }
        }

        public override void Move(PiecePosition newPosition, ChessTableSquare[,] table)
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
