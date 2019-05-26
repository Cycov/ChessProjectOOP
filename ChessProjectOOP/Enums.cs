using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    public enum PieceTypes
    {
        Pawn,
        Tower,
        Knight,
        Bishop,
        King,
        Queen,
        Undefined,
        None
    }

    public enum OwnerTypes
    {
        White = 8,
        Black = 1,
        Undefined = 0
    }

    public enum EColumn
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8
    }
}
