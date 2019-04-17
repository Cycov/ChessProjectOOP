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

        public override void Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
            if (Position.Row != newPosition.Row && Position.Column != newPosition.Column)
                throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));

            //Colision rules
            if (newPosition.Row > Position.Row)
            {
                for (int i = Position.Row + 1; i < newPosition.Row; i++) //up-down
                    if (!table[(int)Position.Column - 1, i - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }
            else
            {
                for (int i = Position.Row - 1; i > newPosition.Row; i--) //up-down
                    if (!table[(int)Position.Column - 1, i - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }

            if ((int)newPosition.Column > (int)Position.Column)
            {
                for (int i = (int)Position.Column + 1; i < (int)newPosition.Column; i++)
                    if (!table[i - 1, Position.Row - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }
            else
            {
                for (int i = (int)Position.Column - 1; i > (int)newPosition.Column; i--)
                    if (!table[i - 1, Position.Row - 1].IsEmpty)
                        throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
            }

            Position = newPosition;
        }
    }
}
