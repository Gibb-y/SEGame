using SEGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace SEGame.Util
{
    internal class AssetLoader
    {
        public static bool LoadTexture2D(string path, ContentManager content, out Texture2D texture)
        {
            try
            {
                texture = content.Load<Texture2D>(path);
            } catch (Exception e)
            {
                texture = null;
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        
        public static bool LoadTextures2DFromXmlFile(string path, ContentManager content)
        {
            XmlReader reader;
            try
            {
                reader = XmlReader.Create(path);
                reader.Read();
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

            bool succes = true;
            string name = "";
            string assetLocation = "";
            string glyphstring = "";
            int rectx = 0;
            int recty = 0;
            int width = 0;
            Dictionary<char, Rectangle> glyphrects = new Dictionary<char, Rectangle>();
            AssetManager assetManager = AssetManager.Instance;

            while (reader.Read())
            {
                reader.MoveToElement();

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "name":
                            reader.Read();
                            reader.MoveToElement();
                            name = reader.Value;
                            break;
                        case "texture2d":
                            int.TryParse(reader.GetAttribute("width"), out width);
                            reader.Read();
                            reader.MoveToElement();
                            assetLocation = reader.Value;
                            break;
                        case "rectx":
                            rectx = reader.ReadElementContentAsInt();
                            break;
                        case "recty":
                            recty = reader.ReadElementContentAsInt();
                            break;
                        case "glyphstring":
                            glyphstring = reader.ReadElementContentAsString();
                            glyphrects = GetGlyphRectangles(rectx, recty, width, glyphstring);
                            break;
                        // possibility to expand for other asset types
                        default: break;
                    }
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    switch (reader.Name)
                    {
                        case "asset":
                            succes = succes && assetManager.AddTexture2D(name, content.Load<Texture2D>(assetLocation));
                            break;
                        case "font":
                            succes &= assetManager.AddSpriteFont(name, new SpriteFont(content.Load<Texture2D>(assetLocation), glyphrects));
                            break;

                    }
                }
            }
            return succes;
        }
        private static Dictionary<char, Rectangle> GetGlyphRectangles(int x, int y, int width, string glyphs)
        {
            var result = new Dictionary<char, Rectangle>();
            for (int i = 0; i < glyphs.Length; i++)
            {
                var glyph = glyphs[i];
                result.TryAdd(glyph, new Rectangle(i * x % width, i * x / width * y, x, y));
            }
            return result;
        }
    }

}
