using Microsoft.Xna.Framework;
using SEGame.EC.Components;
namespace SEGame.Collisions
{
    public class InertCollider : Collider
    {
        public InertCollider()
        {
        }

        public InertCollider(Rectangle collisionBox, bool debug = false) : base(collisionBox, debug)
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
