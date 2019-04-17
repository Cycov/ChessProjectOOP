using System.Drawing;
using System;

namespace ChessProjectOOP
{
    class PictureListboxItem : IDisposable
    {
        public Bitmap Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private Bitmap picture;
        private string text;

        public PictureListboxItem()
        {
            text = String.Empty;
            picture = new Bitmap(Properties.Resources.Dummy);
        }
        public PictureListboxItem(string text)
        {
            this.text = text;
            picture = new Bitmap(Properties.Resources.Dummy);
        }
        public PictureListboxItem(string text, Bitmap picture)
        {
            this.text = text;
            this.picture = new Bitmap(picture);
        }

        public void Dispose()
        {
            picture.Dispose();
        }
    }
}
