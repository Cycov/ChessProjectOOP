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

        public override List<PiecePosition> GetPossibileMoves(ChessTableSquare[,] table)
        {
            List<PiecePosition> moves = new List<PiecePosition>();

            // TODO: Only for black, add white
            if (Position.Row + 1 <= 8)
            {
                var newPos = new PiecePosition(Position.Column, Position.Row + 1);
                if (ValidateMove(newPos, table, 1))
                {
                    moves.Add(newPos);
                    if (canLeap)
                    {
                        newPos = new PiecePosition(Position.Column, Position.Row + 2);
                        if (ValidateMove(newPos, table, 4))
                            moves.Add(newPos);
                    }
                }
            }

            if (Position.Row > 1)
            {
                if ((int)Position.Column < 8)
                {
                    if (table[(int)Position.Column, Position.Row].RepresentedPiece.Owner == OwnerTypes.White)
                    {
                        var newPos = new PiecePosition((int)Position.Column + 1, Position.Row - 1);
                        if (ValidateMove(newPos, table, 2))
                            moves.Add(newPos);
                    }
                        
                }

                if ((int)Position.Column > 1)
                {
                    if (table[(int)Position.Column - 2, Position.Row].RepresentedPiece.Owner == OwnerTypes.White)
                    {
                        var newPos = new PiecePosition((int)Position.Column - 1, Position.Row + 1);
                        if (ValidateMove(newPos, table, 3))
                            moves.Add(newPos);
                    }
                }
            }

            return moves;
        }

        public override bool ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
            if (!base.ValidateMove(newPosition, table, direction))
                return false;


            if (direction == 0 && Position.Row != newPosition.Row && Position.Column != newPosition.Column)
                return false;

            int modifier = (Owner == OwnerTypes.White) ? -1 : 1;
            //TODO: add rule what when it reaches the end of the board  allow the player to get a lost piece back (history needs implement)


            //Collision detection
            if (canLeap && !table[(int)Position.Column - 1, Position.Row + modifier - 1].IsEmpty)
                return false;

            //Normal forward, 2 start leap and take other rules
            if ((newPosition.Row == Position.Row + modifier) && (newPosition.Column == Position.Column))
            {
                if (table[(int)newPosition.Column - 1, newPosition.Row - 1].IsEmpty)
                {
                    return true;
                }
            }
            else if (newPosition.Column != EColumn.H && //if on the right is a piece
                (newPosition.Row == Position.Row + modifier) &&
                ((int)newPosition.Column == (int)Position.Column + 1) &&
                !table[(int)newPosition.Column - 1, newPosition.Row - 1].IsEmpty)
            {
                return true;
            }
            else if (newPosition.Column != EColumn.A && //if on the left is a piece
                (newPosition.Row == Position.Row + modifier) &&
                ((int)newPosition.Column == (int)Position.Column - 1) &&
                !table[(int)newPosition.Column - 1, newPosition.Row - 1].IsEmpty)
            {
                return true;
            }
            else if (canLeap && (newPosition.Row == Position.Row + modifier * 2) && (newPosition.Column == Position.Column))
            {
                return true;
            }


            canLeap = false;
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
