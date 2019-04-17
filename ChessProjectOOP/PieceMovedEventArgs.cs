using System;

namespace ChessProjectOOP
{
    public class PieceMovedEventArgs : EventArgs
    {
        public Piece MovedPiece
        {
            get
            {
                return movedPiece;
            }
        }

        public Piece OverlappedPiece
        {
            get
            {
                return overlappedPiece;
            }
        }

        public PiecePosition BeforePosition
        {
            get
            {
                return beforePosition;
            }
        }

        public PiecePosition AfterPosition
        {
            get
            {
                return afterPosition;
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }
        }

        protected Piece movedPiece, overlappedPiece;
        protected PiecePosition beforePosition, afterPosition;
        protected string comment;

        public PieceMovedEventArgs()
        {
            movedPiece = null;
            overlappedPiece = null;
            beforePosition = null;
            afterPosition = null;
        }

        public PieceMovedEventArgs(Piece movedPiece, Piece overlappedPiece)
        {
            this.movedPiece = movedPiece;
            this.overlappedPiece = overlappedPiece;
            beforePosition = null;
            afterPosition = null;
        }

        public PieceMovedEventArgs(Piece movedPiece, Piece overlappedPiece, PiecePosition beforePosition, PiecePosition afterPosition)
        {
            this.movedPiece = movedPiece;
            this.overlappedPiece = overlappedPiece;
            this.beforePosition = beforePosition;
            this.afterPosition = afterPosition;
        }

        public PieceMovedEventArgs(Piece movedPiece, Piece overlappedPiece, PiecePosition beforePosition, PiecePosition afterPosition, string comment)
        {
            this.movedPiece = movedPiece;
            this.overlappedPiece = overlappedPiece;
            this.beforePosition = beforePosition;
            this.afterPosition = afterPosition;
            this.comment = comment;
        }
    }
}
