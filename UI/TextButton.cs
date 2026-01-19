using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SEGame.UI
{
    public class TextButton : IButton, ITextContainer
    {
        public delegate void ClickAction();
        public ClickAction OnButtonClick;

        private Vector2 position;

        public ITextArea TextArea { get; set; }

        public Texture2D Texture { get; set; }

        public Rectangle? SourceRectangle { get; set; }

        public float Scale { get; set; } = 1f;

        public Vector2 Position 
        { 
            get => position; 
            set 
            {
                var diff = value - position;
                position = value; 
                TextArea.Position += diff; 
            } 
        }

        public Vector2 Center => Position + new Vector2((int)TextArea.ScaledSize.Y * 5, (int)(TextArea.ScaledSize.Y * 2.5f));

        public Vector2 TextOffset 
        { 
            get { return TextArea.Position - Position; } 
            set { TextArea.Position += value; }
        }

        public TextButton(ITextArea textArea, Texture2D textureIn, float scaleIn, Vector2 positionIn)
        {
            TextArea = textArea;
            Texture = textureIn;
            Scale = scaleIn;
            Position = positionIn;
        }

        public TextButton(ITextArea textArea, Texture2D textureIn, float scaleIn, Vector2 positionIn, Rectangle sourceRectangle) :
            this(textArea, textureIn, scaleIn, positionIn)
        {
            SourceRectangle = sourceRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (SourceRectangle == null)
                spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, (int)(Texture.Width * Scale), (int)(Texture.Height * Scale)), Color.White);
            else
                spriteBatch.Draw(Texture, GetClickableArea(), SourceRectangle, Color.White);
            TextArea.Draw(spriteBatch);
        }

        public void OnClick()
        {
            OnButtonClick?.Invoke();
        }

        public Rectangle GetClickableArea()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)TextArea.ScaledSize.Y * 10, (int)TextArea.ScaledSize.Y * 5);
        }

        public void CenterTextOnTexture()
        {
            var diff = TextArea.Center - Center;
            TextArea.Position -= diff;
        }
    }
}
