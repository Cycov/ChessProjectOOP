using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    public class PieceLostEventArgs : PieceMovedEventArgs
    {
        public Piece LostPiece
        {
            get
            {
                return lostPiece;
            }
        }

        private Piece lostPiece;

        public PieceLostEventArgs() : base()
        {
            lostPiece = null;
        }
        public PieceLostEventArgs(Piece lostPiece)
        {
            this.lostPiece = lostPiece;
        }
        public PieceLostEventArgs(Piece movedPiece, Piece overlappedPiece) : base(movedPiece, overlappedPiece) { }
        public PieceLostEventArgs(Piece movedPiece, Piece overlappedPiece, PiecePosition beforePosition, PiecePosition afterPosition) : base(movedPiece, overlappedPiece, beforePosition, afterPosition) { }
        public PieceLostEventArgs(Piece movedPiece, Piece overlappedPiece, PiecePosition beforePosition, PiecePosition afterPosition, string comment) : base(movedPiece, overlappedPiece, beforePosition, afterPosition, comment) { }
    }
}
