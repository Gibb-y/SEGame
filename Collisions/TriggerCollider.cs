using Microsoft.Xna.Framework;
using SEGame.EC.Components;

namespace SEGame.Collisions
{
    public class TriggerCollider : Collider
    {
        public delegate void OnTriggerDelegate();
        public OnTriggerDelegate OnTrigger;

        public TriggerCollider() : base() {  }

        public TriggerCollider(Rectangle collisionBox, Vector2 offset, bool debug = false) : base(collisionBox, offset, debug)
        {
        }

        public override void OnBoundingBox(Rectangle boundingBox)
        {
            
        }

        public override void OnCollision(Collision collision)
        {
            OnTrigger?.Invoke();
        }
    }
}
