using Microsoft.Xna.Framework;
using SEGame.EC.Components;
namespace SEGame.Collisions
{
    public class InertCollider : Collider
    {
        public InertCollider()
        {
        }

        public InertCollider(Rectangle collisionBox, Vector2 offset, bool debug = false) : base(collisionBox, offset, debug)
        {
        }

        public override void OnBoundingBox(Rectangle boundingBox)
        {
        }

        public override void OnCollision(Collision collision)
        {
        }
    }
}
