using Microsoft.Xna.Framework;
using SEGame.EC.Components;

namespace SEGame.Collisions
{
    public class PlayerCollider : Collider
    {
        public PlayerCollider()
        {
        }

        public PlayerCollider(Rectangle collisionBox) : base(collisionBox)
        {
        }

        public override void OnBoundingBox()
        {
            if (!InsideBoundingBox)
            {
                _transform.Position = _transform.PreviousPosition;
                var newVel = _owner.GetComponent<Physics>().Velocity;
                newVel.Y = 0;
                _owner.GetComponent<Physics>().Velocity = newVel;
            }
        }

        public override void OnCollision(Collision collision)
        {
            
        }
    }
}
