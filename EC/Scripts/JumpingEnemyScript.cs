using Microsoft.Xna.Framework;
using SEGame.EC.Components;
using System;

namespace SEGame.EC.Scripts
{
    public class JumpingEnemyScript : IScript
    {
        private Physics _physics;
        private Animator _animator;

        private float _jumpTimer = 3f;
        private double _jumpDelta;
        private bool _isJumping;

        public void Initialize(Entity entity)
        {
            _physics = entity.GetComponent<Physics>();
            _animator = entity.GetComponent<Animator>();
            _jumpDelta = 0f;
        }

        public void Update(GameTime gameTime)
        {
            if (Math.Abs(_physics.Velocity.Y) < 0.01 && _isJumping)
            {
                _jumpDelta = 0f;
                _isJumping = false;
                _animator.SetAnimationAsActive("idle");
            }

            _jumpDelta += gameTime.ElapsedGameTime.TotalSeconds;

            if (_jumpDelta > _jumpTimer)
            {
                if (_isJumping)
                    return;

                var newVel = _physics.Velocity;
                newVel.Y = -7;
                _physics.Velocity = newVel;
                _animator.SetAnimationAsActive("jump");
                _isJumping = true;
            }
        }
    }
}
