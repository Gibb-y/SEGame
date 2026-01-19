using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.EC.Components;

namespace SEGame.EC.Scripts
{
    public class WalkingEnemyScript : IScript
    {
        private Physics _physics;
        private Animator _animator;
        private double _walkDelta;
        private double _walkTimer = 2f;
        private bool _left;

        public void Initialize(Entity entity)
        {
            _physics = entity.GetComponent<Physics>();
            _animator = entity.GetComponent<Animator>();
            _animator.SetAnimationAsActive("run");
        }

        public void Update(GameTime gameTime)
        {
            _walkDelta += gameTime.ElapsedGameTime.TotalSeconds;
            if (_walkDelta > _walkTimer)
            {
                _left = !_left;
                _walkDelta = 0f;
            }

            var newVel = _physics.Velocity;
            newVel.X = 2 * (_left ? -1 : 1);
            _physics.Velocity = newVel;

            if (_physics.Velocity.X > 0)
                _animator.SpriteEffect = SpriteEffects.None;
            else
                _animator.SpriteEffect = SpriteEffects.FlipHorizontally;

        }
    }
}
