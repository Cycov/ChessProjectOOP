using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    public class DummyPiece : Piece, IDisposable
    {
        public DummyPiece() : base()
        {
            Type = PieceTypes.Undefined;
            Picture = new Bitmap(GetImage("Dummy"));
            Owner = OwnerTypes.Undefined;
            name = "empty";
        }
        public DummyPiece(PiecePosition position) : this()
        {
            Position = position;
        }
        public override void Dispose()
        {
            Picture.Dispose();
        }

        public override List<PiecePosition> GetPossibileMoves(ChessTableSquare[,] table)
        {
            throw new NullReferenceException("This piece can not be moved befause it's dummy piece ");
        }

        public override void Move(PiecePosition newPosition, ChessTableSquare[,] table)
        {
            throw new NullReferenceException(String.Format("This piece can not be moved befause it's dummy piece ( from {0} to {1} )", Position, newPosition));
        }

        public override void ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
            return;
        }
    }
}
