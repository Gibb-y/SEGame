using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SEGame.UI
{
    public class Banner : ITextArea
    {
        public string Text { get; private set; } = "";

        public float Scale { get; set; }

        public float Rotation { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 ScaledSize { get { return BaseSize * Scale; } }

        public Vector2 Center { get { return Position + ScaledSize / 2; } }

        public Vector2 BaseSize { get; set; }

        public Util.SpriteFont Font { get; private set; }

        public Banner(Util.SpriteFont fontIn, Vector2 positionIn, float scaleIn, string textIn="")
        {
            Font = fontIn;
            Position = positionIn;
            Scale = scaleIn;
            Text = textIn;
            Rectangle rect;
            fontIn.TryGetGlyph('a', out rect);
            BaseSize = new Vector2(rect.Width * textIn.Length, rect.Height);
        }

        public void AppendText(string text)
        {
            Text += text;
        }

        public void Clear()
        {
            Text = "";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i  = 0; i < Text.Length; i++)
            {
                if (Font.TryGetGlyph(Text[i], out Rectangle glyphRect))
                {
                    Rectangle destination = new((int)(Position.X + i * glyphRect.Width * Scale), (int)Position.Y, (int)(glyphRect.Width * Scale), (int)(glyphRect.Height * Scale));
                    spriteBatch.Draw(Font.Texture, destination, glyphRect, Color.White);
                }
            }
        }

        public void SetFont(Util.SpriteFont font)
        {
            Font = font;
        }

        public void SetText(string text)
        {
            Text = text;
        }
    }
}
