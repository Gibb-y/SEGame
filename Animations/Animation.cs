using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SEGame.Animations
{
    public class Animation
    {
        public delegate void OnStartAnimation();
        public event OnStartAnimation OnStartOfAnimation;
        public delegate void OnEndAnimation();
        public event OnEndAnimation OnEndOfAnimation;
        public string Name { get; private set; }
        public Texture2D Texture { get; private set; }
        public AnimationFrame CurrentFrame { get; private set; }
        public float Framerate { get; set; }
        public int PrevCounter { get; private set; }
        public bool IndexChanged
        {
            get; private set;
        }

        private int counter;
        public int CurrentFrameIndex { get { return counter; } }

        private readonly List<AnimationFrame> frames;
        private float deadline;
        private float deltaTime;


        public Animation(string name, float framerate, Texture2D texture)
        {
            Name = name;
            Framerate = framerate;
            Texture = texture;
            frames = new List<AnimationFrame>();
            deadline = 1 / Framerate;
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            deltaTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (deltaTime >= deadline)
            {
                deltaTime = 0;
                IndexChanged = true;
                counter++;
                counter %= frames.Count;
                CurrentFrame = frames[counter];
                if (counter == 0)
                    OnStartOfAnimation?.Invoke();
                else if (OnLastFrame())
                {
                    OnEndOfAnimation?.Invoke();
                }
            }
            else
            {
                IndexChanged = false;
            }
        }

        public bool OnLastFrame()
        {
            return counter == frames.Count - 1;
        }

        public Vector2 GetCenter()
        {
            return new Vector2(CurrentFrame.SourceRectangle.Width / 2, CurrentFrame.SourceRectangle.Height / 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(0, 0, 32, 32), CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
