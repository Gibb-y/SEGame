using Microsoft.Xna.Framework;
using SEGame.EC.Components;
using SEGame.Managers;
using System.Diagnostics;

namespace SEGame.Collisions
{
    public class PlayerCollider : Collider
    {
        public PlayerCollider()
        {
        }

        public PlayerCollider(Rectangle collisionBox, Vector2 Offset, bool debug = false) : base(collisionBox, Offset, debug)
        {
        }

        public override void OnBoundingBox(Rectangle boundingBox)
        {
            if (!InsideBoundingBox)
            {
                var newPos = _transform.Position;
                var newVel = _owner.GetComponent<Physics>().Velocity;

                Rectangle deltaX = new((int)_transform.Position.X, (int)_transform.PreviousPosition.Y, CollisionBox.Width, CollisionBox.Height);
                Rectangle deltaY = new((int)_transform.PreviousPosition.X, (int)_transform.Position.Y, CollisionBox.Width, CollisionBox.Height);

                if (!boundingBox.Contains(deltaX))
                {
                    newPos.X = _transform.PreviousPosition.X;
                    newVel.X = 0;
                }

                if (!boundingBox.Contains(deltaY))
                {
                    newPos.Y = _transform.PreviousPosition.Y;
                    newVel.Y = 0;
                }

                _transform.Position = newPos;
                _owner.GetComponent<Physics>().Velocity = newVel;
            }
        }

        public override void OnCollision(Collision collision)
        {
            bool isFirst = collision.FirstCollisionObject.Equals(this);

            if (isFirst)
                if (collision.SecondCollisionObject is EnemyCollider)
                {
                    // lose level
                    var level = SceneManager.Instance.GetLevel!;
                    level.CurrentGameSate = level.GameOver;
                }

            if (isFirst)
                if (collision.SecondCollisionObject is TriggerCollider)
                {
                    var level = SceneManager.Instance.GetLevel!;
                    level.CurrentGameSate = level.Victory;
                }

            var newPos = _transform.Position;
            var newVel = _owner.GetComponent<Physics>().Velocity;

            Rectangle deltaX = new((int)_transform.Position.X, (int)_transform.PreviousPosition.Y, CollisionBox.Width, CollisionBox.Height);
            Rectangle deltaY = new((int)_transform.PreviousPosition.X, (int)_transform.Position.Y, CollisionBox.Width, CollisionBox.Height);

            if (deltaX.Intersects(isFirst ? collision.SecondCollisionObject.CollisionBox : collision.FirstCollisionObject.CollisionBox))
            {
                newPos.X = _transform.PreviousPosition.X;
                newVel.X = 0;
            }

            if (deltaY.Intersects(isFirst ? collision.SecondCollisionObject.CollisionBox : collision.FirstCollisionObject.CollisionBox))
            {
                newPos.Y = _transform.PreviousPosition.Y;
                newVel.Y = 0;
            }

            _transform.Position = newPos;
            _owner.GetComponent<Physics>().Velocity = newVel;
        }
    }
}
