using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProjectOOP
{
    public class Player : IDisposable
    {
        public List<Piece> Pieces;
        public DummyPiece Dummy;
        public bool CanMove = false;
        public string Name
        {
            get;
            set;
        }
        public string CurrentIP;

        public OwnerTypes Owner
        {
            get;
            protected set;
        }

        public Player(OwnerTypes owner)
        {
            Owner = owner;
            Pieces = new List<Piece>(16);
            Dummy = new DummyPiece();
            InitializePieces();
        }

        public void InitializePieces()
        {
            byte row;
            if (Owner == OwnerTypes.Black)
            {
                row = 2;
            }
            else
                row = 7;

            //for (int i = 0; i < 8; i++)
            //    Pieces.Add(new Pawn(Owner, new PiecePosition((EColumn)(i + 1), row)));

            Pieces.Add(new Tower(Owner, new PiecePosition(EColumn.A, (int)Owner)));
            Pieces.Add(new Tower(Owner, new PiecePosition(EColumn.H, (int)Owner)));
            Pieces.Add(new Knight(Owner, new PiecePosition(EColumn.B, (int)Owner)));
            Pieces.Add(new Knight(Owner, new PiecePosition(EColumn.G, (int)Owner)));
            Pieces.Add(new Bishop(Owner, new PiecePosition(EColumn.C, (int)Owner)));
            Pieces.Add(new Bishop(Owner, new PiecePosition(EColumn.F, (int)Owner)));
            Pieces.Add(new King(Owner, new PiecePosition(EColumn.E, (int)Owner)));
            Pieces.Add(new Queen(Owner, new PiecePosition(EColumn.D, (int)Owner)));
        }

        public void Dispose()
        {
            foreach (Piece item in Pieces)
            {
                item.Dispose();
            }
            Pieces.Clear();
            Dummy.Dispose();
        }
    }
}
