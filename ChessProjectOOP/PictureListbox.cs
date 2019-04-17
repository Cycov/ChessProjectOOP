using System.Drawing;
using System.Windows.Forms;

namespace ChessProjectOOP
{
    class PictureListbox : ListBox
    {
        public PictureListbox()
        {
            ItemHeight = 40;
            DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            PointF textCoordinates = new PointF(), pictureCoordinates = new PointF();
            SizeF textSize, pictureSize = new SizeF();

            int itemWidth = e.Bounds.Width;
            int itemHeight = e.Bounds.Height;

            PointF itemCoordinates = e.Bounds.Location;

            if (e.Index >= 0 && e.Index < Items.Count)
            {
                var displayItem = Items[e.Index] as PictureListboxItem;
                
                textSize = e.Graphics.MeasureString(displayItem.Text, Font);
                
                pictureSize = new SizeF(itemWidth - 10, itemHeight - textSize.Height - 10);
                textCoordinates = new PointF(itemWidth / 2 - textSize.Width/2, itemCoordinates.Y + itemHeight - textSize.Height - 5);
                pictureCoordinates = new PointF(itemCoordinates.X / 2 - pictureSize.Width / 2, itemCoordinates.Y - pictureSize.Height - 5);

                e.Graphics.DrawString(displayItem.Text, Font, new SolidBrush(ForeColor), textCoordinates);
                Bitmap picture = new Bitmap(displayItem.Picture,pictureSize.ToSize());
                e.Graphics.DrawImage(picture, e.Bounds.Location);
            }
            e.DrawFocusRectangle();            
        }
    }
}
