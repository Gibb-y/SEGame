using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SEGame.EC.Components;
using SEGame.Managers;
using System;

namespace SEGame.EC.Scripts
{
    public class PlayerScript : IScript
    {
        private Transform _transform;
        private Physics _physics;
        private Animator _animator;
        private bool _jumping = false;
        private Vector2 _groundCheck;

        public void Initialize(Entity entity)
        {
            _transform = entity.GetComponent<Transform>();
            _physics = entity.GetComponent<Physics>();
            _animator = entity.GetComponent<Animator>();
            _groundCheck = new Vector2(16, 16 + 18);
        }

        public void Update(GameTime gameTime)
        {
            var delta = Vector2.Zero;

            if (_physics.Velocity.Y < -0.1f)
            {
                _animator.PlayAnimationOnce("jump");
            }
            else if (_physics.Velocity.Y > 0.1f)
            {
                _animator.SetAnimationAsActive("fall");
            }
            else
            {
                if (!CollisionManager.Instance.BoundingBox.Contains(_transform.Position + _groundCheck))
                    _jumping = false;

                if (Math.Abs(_physics.Velocity.X) > 0.01f)
                {
                    _animator.SetAnimationAsActive("run");
                }
                else
                {
                    _animator.SetAnimationAsActive("idle");
                }
            }

            if (_physics.Velocity.X > 0)
                _animator.SpriteEffect = SpriteEffects.None;
            else
                _animator.SpriteEffect = SpriteEffects.FlipHorizontally;

            if (InputManager.Instance.IsKeyDown(Keys.A))
            {
                delta.X -= 1;
            }

            if (InputManager.Instance.IsKeyDown(Keys.D))
            {
                delta.X += 1;
            }

            _physics.Velocity += delta;

            if (Math.Abs(_physics.Velocity.X) > 10)
            {
                var newVel = _physics.Velocity;
                newVel.X = _physics.Velocity.X < 0 ? -10 : 10;
                _physics.Velocity = newVel;
            }

            if (Math.Abs(_physics.Velocity.Y) < 0.001f)
                _jumping = false;

            if (InputManager.Instance.IsKeyJustDown(Keys.Space))
            {
                if (_jumping)
                    return;

                var newVel = _physics.Velocity;
                newVel.Y = -10;
                _physics.Velocity = newVel;
                _animator.PlayAnimationOnce("jump");
                _jumping = true;
            }
        }
    }
}
