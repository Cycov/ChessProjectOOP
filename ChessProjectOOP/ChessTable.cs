using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace ChessProjectOOP
{
    public partial class ChessTable : UserControl
    {
        public ChessTable()
        {
            InitializeComponent();
            squares = new ChessTableSquare[8, 8];
            userHasSelected = false;
        }
        public ChessTable(Player player1, Player player2) : this()
        {
            Player1 = player1;
            Player2 = player2;
        }

        //Events
        public delegate void PieceMovedEventHandler(object sender, PieceMovedEventArgs e);
        public delegate void PieceLostEventHandler(object sender, PieceLostEventArgs e);

        public event PieceMovedEventHandler OnPieceMoved;
        public event PieceLostEventHandler OnPieceLost;
        public event EventHandler<PieceLostEventArgs> OnKingLost;
        
        //Proprieties

        public Color WhiteBackgroundColor { get; set; } = Color.White;
        public Color BlackBackgroundColor { get; set; } = Color.DarkGray;
        public Color SelectedColor { get; set; } = Color.Magenta;
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }


        public void MovePiece(PiecePosition from, PiecePosition to)
        {
            AttemptMove(squares[(int)from.Column - 1, from.Row - 1], squares[(int)to.Column - 1, to.Row - 1], true);
        }

        public void UpdateSizeAndPosition()
        {
            int boxWidth = (Width - 16) / 8;
            int boxHeight = (Height - 16) / 8;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    squares[i, j].Location = new Point(i * boxWidth + (i + 1) * 2, j * boxHeight + (j + 1) * 2);
                    squares[i, j].Size = new Size(boxWidth, boxHeight);
                    squares[i, j].Invalidate();
                }
            }

            this.Invalidate();
        }

        #region  Private members


        private ChessTableSquare[,] squares;
        private bool userHasSelected;
        private ChessTableSquare lastSelectedSquare;

        private void ChessTable_Load(object sender, System.EventArgs e)
        {
            int boxWidth = (Width - 0) / 8 - 8; // 0 is there for spacing between boxes
            int boxHeight = (Height - 0) / 8 - 8;
            Color currentAltColor = BlackBackgroundColor;
            bool alt = false;

            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (alt)
                    {
                        currentAltColor = WhiteBackgroundColor;
                        alt = false; //Change alternance
                    }
                    else
                    {
                        currentAltColor = BlackBackgroundColor;
                        alt = true; //Change alternance
                    }
                    squares[i, j] = new ChessTableSquare(currentAltColor, SelectedColor, new DummyPiece(new PiecePosition((EColumn)(i + 1), j + 1))) //Create new square, initialise it with a blank piece
                    {
                        Location = new Point(i * boxWidth + (i + 1) * 2, j * boxHeight + (j + 1) * 2), // Calculate it's location
                        Size = new Size(boxWidth, boxHeight)    // Use the precalculated size
                    }; //Object initialiser
                    squares[i, j].Enabled = Enabled; // Set enabled status
                    squares[i, j].MouseDown += ChessTableSquare_MouseDown; //Register to click event
                    this.Controls.Add(squares[i, j]); //Add to the control
                }
                alt = !alt; // Change alternance for new row
            }
        }

        internal void ResetTable()
        {
            if (squares[0, 0] == null)
                throw new NullReferenceException("The table has not been properly initialised");
            
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!squares[i, j].IsEmpty)
                    {
                        squares[i, j].Selected = false;
                        squares[i, j].RepresentedPiece = new DummyPiece(new PiecePosition((EColumn)(i + 1), j + 1));
                    }
                }
            }
        }

        public Dictionary<string, List<PiecePosition>> GetAllPossibileMoves()
        {
            var moves = new Dictionary<string, List<PiecePosition>>();
            foreach (var square in squares)
            {
                if (!square.IsEmpty && square.RepresentedPiece.Owner == OwnerTypes.Black)
                    moves.Add(square.RepresentedPiece.ToString(), square.RepresentedPiece.GetPossibileMoves(squares));
            }
            return moves;
        }

        private void ChessTableSquare_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Enabled)
                return;
            ChessTableSquare instance = sender as ChessTableSquare;
            if (instance.Selected)
            {
                instance.Selected = false;
                userHasSelected = false;
                lastSelectedSquare = null;
            }
            else
            {
                if (userHasSelected)
                {
                    if (Player1.CanMove)
                        AttemptMove(lastSelectedSquare, instance);
                    else
                    {
                        MessageBox.Show("It's not your turn");
                        lastSelectedSquare.Selected = false;
                        lastSelectedSquare = null;
                        userHasSelected = false;
                    }
                }
                else
                {
                    if (!instance.IsEmpty && (instance.RepresentedPiece.Owner.Equals(Player1.Owner)))
                    {
                        instance.Selected = true;
                        userHasSelected = true;
                        lastSelectedSquare = instance;
                    }
                }
            }
        }

        private void AttemptMove(ChessTableSquare from, ChessTableSquare to)
        {
            try
            {
                AttemptMove(from, to, true);
            }
            catch (IllegalMoveException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AttemptMove(ChessTableSquare from, ChessTableSquare to, bool ignoreRules)
        {
            if (from.RepresentedPiece.Position.Equals(to.RepresentedPiece.Position))
                throw new IllegalMoveException(to.RepresentedPiece, "You can't move on the same space");
            PiecePosition toPosition = new PiecePosition(to.RepresentedPiece.Position);
            PiecePosition fromPosition = new PiecePosition(from.RepresentedPiece.Position);

            System.Diagnostics.Debug.WriteLine(squares[(int)to.RepresentedPiece.Position.Column - 1, to.RepresentedPiece.Position.Row - 1].RepresentedPiece.ToString() + "\n" + squares[(int)from.RepresentedPiece.Position.Column - 1, from.RepresentedPiece.Position.Row - 1].RepresentedPiece.ToString());

            //If there is another piece there not owned by player1
            if (!ignoreRules && to.RepresentedPiece.Owner.Equals(Player1.Owner))
            {
                MessageBox.Show("You can not move over your own pieces");
                return;
            }

            //If it's players turn
            if (false)
                throw new IllegalMoveException(to.RepresentedPiece, "It's not your turn");

            //If the move is even permitted, move
            if (!from.RepresentedPiece.Move(to.RepresentedPiece.Position, squares))
            {
                throw new IllegalMoveException(from.RepresentedPiece, String.Format("Can not move from {0} to {1}", from.RepresentedPiece.Position.ToString(), to.RepresentedPiece.Position.ToString()));
            }


            //If it got to this point notify player2 of what happened
            // TODO: "from" and "to" are the same when are being accesed outside
            // NOTE: OnPieceMoved is called when forcibly moved by opponent
            OnPieceMoved?.Invoke(this, new PieceMovedEventArgs(from.RepresentedPiece, to.RepresentedPiece, fromPosition, toPosition));
            //If player2 has pieces there, take them out of the board,in this case, just raise event
            if (to.RepresentedPiece.Owner != from.RepresentedPiece.Owner)
                OnPieceLost?.Invoke(this, new PieceLostEventArgs(from.RepresentedPiece, to.RepresentedPiece, fromPosition, toPosition));
            if (to.RepresentedPiece.Type == PieceTypes.King)
                OnKingLost?.Invoke(this, new PieceLostEventArgs(to.RepresentedPiece));
            //If move was succesful then move graphically
            if (to.RepresentedPiece is DummyPiece)
            {
                to.RepresentedPiece.Dispose();
            }
            squares[(int)toPosition.Column - 1, toPosition.Row - 1].RepresentedPiece = from.RepresentedPiece;

            from.Selected = false;
            userHasSelected = false;
            lastSelectedSquare = null;

            squares[(int)fromPosition.Column - 1, fromPosition.Row - 1].RepresentedPiece = new DummyPiece(fromPosition);
        }

        public void InitialisePlayers(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            InitialisePlayers();
        }

        public void InitialisePlayers()
        {
            if (Player1 == null || Player2 == null)
                throw new NullReferenceException("One of the players has not been properly initialised");

            for (int i = 0; i < Player1.Pieces.Count; i++)
            {
                squares[(int)Player1.Pieces[i].Position.Column - 1, Player1.Pieces[i].Position.Row - 1].RepresentedPiece = Player1.Pieces[i]; //Add pieces on corresponding positions
                squares[(int)Player2.Pieces[i].Position.Column - 1, Player2.Pieces[i].Position.Row - 1].RepresentedPiece = Player2.Pieces[i];
            }
        }

        private void ChessTable_EnabledChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    squares[i, j].Enabled = Enabled;
                    squares[i, j].Selected = false;
                    squares[i, j].Invalidate();
                }
            }
            Invalidate();
            userHasSelected = false;
            lastSelectedSquare = null;
        }
        #endregion

    }
}
