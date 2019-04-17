using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChessProjectOOP
{
    public partial class ChessTableSquare : UserControl
    {

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (isEmpty) return;
                if (!value)
                    this.BackColor = NormalColor; //Deselect square
                else
                    this.BackColor = SelectedColor;
                selected = value;
                Invalidate();
            }
        }

        public Color SelectedColor { get; private set; }
        public Color NormalColor { get; private set; }
        public bool IsEmpty
        {
            get { return isEmpty; }
            set { isEmpty = value; }
        }


        public Bitmap Picture
        {
            get { return picture; }
            set
            {
                picture = value;
            }
        }
        public Piece RepresentedPiece
        {
            get
            {
                return representedPiece;
            }
            set
            {
                representedPiece = value;
                try
                {
                    Picture = value.Picture;
                }                    
                catch (Exception ex)
                {
                    throw new ArgumentNullException("The new represented piece can not be null.", ex);
                }
                if (value is DummyPiece)
                    isEmpty = true;
                else
                    isEmpty = false;
                Selected = false;
                this.Invalidate();
            }
        }

        private bool selected = false;
        private Bitmap picture;
        private bool isEmpty = true;
        private Piece representedPiece;

        public ChessTableSquare()
        {
            InitializeComponent();
            SelectedColor = Color.White;
            NormalColor = Color.White;
            Selected = false;
            IsEmpty = true;
        }
        public ChessTableSquare(Color defaultColor, Color selectedColor)
        {
            InitializeComponent();
            SelectedColor = selectedColor;
            NormalColor = defaultColor;
            BackColor = defaultColor;
            IsEmpty = true;
            Selected = false;
        }
        public ChessTableSquare(Color defaultColor, Color selectedColor,Piece piece) : this(defaultColor, selectedColor)
        {
            Picture = piece.Picture;
            representedPiece = piece;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap resized = new Bitmap(Picture, new Size(Width, Height));
            if (Enabled)
                e.Graphics.DrawImage(resized, 0, 0);

            e.Graphics.InterpolationMode = InterpolationMode.High;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            base.OnPaint(e);
        }

        private void ChessTableSquare_MouseDown(object sender, MouseEventArgs e)
        {
            //Selected = !Selected;
        }

        public override string ToString()
        {
            return representedPiece?.Owner + " " + representedPiece?.Name + " " + representedPiece?.Position.ToString() + " " + IsEmpty.ToString();
        }
    }
}
