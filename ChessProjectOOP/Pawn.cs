using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    class Pawn : Piece, IDisposable
    {
        private bool canLeap = true;

        public Pawn(OwnerTypes owner, PiecePosition position) : base(owner,position)
        {
            Type = PieceTypes.Pawn;
            name = "Pawn";

            if (owner == OwnerTypes.Black)
                Picture = new Bitmap(Properties.Resources.BlackPawn);
            else
                Picture = new Bitmap(Properties.Resources.WhitePawn);

        }
        public override void Dispose()
        {
            Picture.Dispose();
        }

        public override void Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
            int modifier = (Owner == OwnerTypes.White) ? -1 : 1;
            //TODO: add rule what when it reaches the end of the board  allow the player to get a lost piece back (history needs implement)

            if (newPosition.Equals(Position))
                throw new IllegalMoveException(this, "Can not move to the exact same position");
            
            //Collision detection
            if (canLeap && !table[(int)Position.Column - 1, Position.Row + modifier - 1].IsEmpty)
                throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));

            //Normal forward, 2 start leap and take other rules
            if ((newPosition.Row == Position.Row + modifier) && (newPosition.Column == Position.Column))
            {
                if (!table[(int)newPosition.Column - 1,newPosition.Row - 1].IsEmpty)
                    throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));
                Position = newPosition;
            }
            else if (newPosition.Column != EColumn.H && //if on the right is a piece
                (newPosition.Row == Position.Row + modifier) &&
                ((int)newPosition.Column == (int)Position.Column + 1) && 
                !table[(int)newPosition.Column - 1, newPosition.Row - 1].IsEmpty)
            {
                Position = newPosition;
            }
            else if (newPosition.Column != EColumn.A && //if on the left is a piece
                (newPosition.Row == Position.Row + modifier) &&
                ((int)newPosition.Column == (int)Position.Column - 1) &&
                !table[(int)newPosition.Column - 1, newPosition.Row - 1].IsEmpty)
            {
                Position = newPosition;
            }
            else if (canLeap && (newPosition.Row == Position.Row + modifier * 2) && (newPosition.Column == Position.Column))
            {
                Position = newPosition;
            }
            else
                throw new IllegalMoveException(this, String.Format("Can not move from {0} to {1}", Position.ToString(), newPosition.ToString()));

            canLeap = false;
        }
    }
}
