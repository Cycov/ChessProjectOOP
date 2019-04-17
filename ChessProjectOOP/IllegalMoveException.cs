using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    class IllegalMoveException : Exception
    {
        public Piece MovedPiece;

        public IllegalMoveException(Piece piece, string message) : base(message)
        {
            MovedPiece = piece;
        }
    }
}
