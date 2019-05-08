using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace ChessProjectOOP
{
    public abstract class Piece : IDisposable
    {
        public PieceTypes Type
        {
            get;
            protected set;
        }

        public OwnerTypes Owner
        {
            get;
            protected set;
        }

        public Bitmap Picture
        {
            get;
            protected set;

        }

        public PiecePosition Position { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
        }

        protected string name;

        public Color GetColor(OwnerTypes owner)
        {
            switch (owner)
            {
                case OwnerTypes.White: return Color.White;
                case OwnerTypes.Black: return Color.Black;
                default: return Color.Pink;
            }
        }
        public Bitmap GetImage(string name)
        {
            Bitmap b = Properties.Resources.ResourceManager.GetObject(name, Properties.Resources.Culture) as Bitmap;
            if (b == null)
                throw new NullReferenceException(String.Format("The image with the name of {0} could not be found", name));
            return b;
        }
        public Bitmap GetImage(PieceTypes type, OwnerTypes owner)
        {
            Bitmap b = Properties.Resources.ResourceManager.GetObject(owner.ToString() + type.ToString(), Properties.Resources.Culture) as Bitmap;
            if (b == null)
                throw new NullReferenceException(String.Format("The image with the name of {0} could not be found", owner.ToString() + type.ToString()));
            return b;
        }
        public Bitmap GetImage(string type, OwnerTypes owner)
        {
            Bitmap b = Properties.Resources.ResourceManager.GetObject(owner.ToString() + type, Properties.Resources.Culture) as Bitmap;
            if (b == null)
                throw new NullReferenceException(String.Format("The image with the name of {0} could not be found", owner.ToString() + type));
            return b;
        }

        public Piece()
        {
            Owner = OwnerTypes.Undefined;
            Type = PieceTypes.Undefined;
            Position = null;
        }
        public Piece(PieceTypes type)
        {
            Owner = OwnerTypes.Undefined;
            Type = type;
        }
        public Piece(OwnerTypes owner)
        {
            Owner = owner;
            Type = PieceTypes.Undefined;
        }
        public Piece(PieceTypes type, OwnerTypes owner)
        {
            Owner = owner;
            Type = type;
        }
        public Piece(OwnerTypes owner,PiecePosition position)
        {
            Owner = owner;
            Type = PieceTypes.Undefined;
            Position = position;
        }
        public Piece(PieceTypes type, OwnerTypes owner,PiecePosition position)
        {
            Owner = owner;
            Type = type;
            Position = position;
        }

        public abstract List<PiecePosition> GetPossibileMoves(ChessTableSquare[,] table);

        public virtual void ValidateMove(PiecePosition newPosition, ChessTableSquare[,] table, int direction = 0)
        {
            if (table[(int)newPosition.Column - 1, newPosition.Row - 1].RepresentedPiece.Owner == Owner)
                throw new IllegalMoveException(this, "You can not move over your own pieces");
        }
        // TODO: add extra rule to check if there is no piece in the way of the piece movement: done for tower
        public abstract void Move(PiecePosition newPosition, ChessTableSquare[,] table);

        public override string ToString()
        {
            return String.Format("{0} owned by {1} at position {2}", Type.ToString(), Owner.ToString(), Position.ToString());
        }

        public abstract void Dispose();
    }
}
