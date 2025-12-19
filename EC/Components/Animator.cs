using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SEGame.Animations;

namespace SEGame.EC.Components
{
    public class Animator : IDrawableComponent
    {
        private Transform _ownerTransform;
        private readonly Dictionary<string, Animation> animations;
        private bool playOnce;
        private int loopCount;

        private Animation currentAnimation;
        public Animation CurrentAnimation { get { return currentAnimation; } private set { currentAnimation = value; } }
        public ref Animation CurrentAnimationByRef
        {
            get { return ref currentAnimation; }
        }
        private string prevAnimation;

        protected Texture2D texture;
        public Vector2 Offset { get; set; } = Vector2.Zero;

        public SpriteEffects SpriteEffect { get; set; } = SpriteEffects.None;

        public Animator()
        {
            animations = new Dictionary<string, Animation>();
            playOnce = false;
        }

        public Animator(Vector2 offset)
        {
            animations = new Dictionary<string, Animation>();
            playOnce = false;
            Offset = offset;
        }

        public static AnimatorBuilder Builder()
        {
            return new AnimatorBuilder();
        }

        public bool AddAnimation(Animation animation)
        {
            if (animations.ContainsKey(animation.Name))
                return false;
            animations.Add(animation.Name, animation);
            if (animations.Count == 1)
            {
                CurrentAnimation = animations[animation.Name];
                prevAnimation = CurrentAnimation.Name;
            }
            return true;
        }

        public bool RemoveAnimation(string name)
        {
            return animations.Remove(name);
        }

        public bool SetAnimationAsActive(string name)
        {
            if (!animations.ContainsKey(name))
                return false;
            prevAnimation = CurrentAnimation.Name;
            CurrentAnimation = animations[name];
            loopCount = 0;
            return true;
        }

        public bool PlayAnimationOnce(string name)
        {
            bool result = SetAnimationAsActive(name);
            if (!result)
                return false;
            playOnce = true;
            return result;
        }

        public Rectangle GetCurrentRect()
        {
            return CurrentAnimation.CurrentFrame.SourceRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CurrentAnimation.Texture, _ownerTransform.Position + Offset, CurrentAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 2, SpriteEffect, 1);
        }

        public void Initialize(Entity entity)
        {
            _ownerTransform = entity.GetComponent<Transform>();
        }

        public void Update(Entity entity, GameTime gameTime)
        {
            CurrentAnimation.Update(gameTime);
            if (CurrentAnimation.CurrentFrameIndex == 0 && CurrentAnimation.IndexChanged)
            {
                loopCount++;
            }
            if (playOnce && loopCount >= 1)
            {
                SetAnimationAsActive(prevAnimation);
                playOnce = false;
            }
        }

        public class AnimatorBuilder
        {
            private Animator _animator;

            public AnimatorBuilder()
            {
                _animator = new();
            }

            public Animator Build()
            {
                return _animator;
            }

            public AnimatorBuilder AddAnimation(Animation animation)
            {
                _animator.AddAnimation(animation);
                return this;
            }

            public AnimatorBuilder SetOffset(Vector2 Offset)
            {
                _animator.Offset = Offset;
                return this;
            }
        }
    }
}
