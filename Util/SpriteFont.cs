using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SEGame.Util
{
    public class SpriteFont
    {
        private Dictionary<char, Rectangle> glyphRectangles = new Dictionary<char, Rectangle>();
        public Texture2D Texture { get; private set; }

        public SpriteFont(Texture2D textureIn, Dictionary<char, Rectangle> glyphRectanglesIn)
        {
            glyphRectangles = glyphRectanglesIn;
            Texture = textureIn;
        }

        public bool TryGetGlyph(char glyphChar, out Rectangle glyphRectangle)
        {
            return glyphRectangles.TryGetValue(glyphChar, out glyphRectangle);
        }
    }
}
