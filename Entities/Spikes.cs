using Microsoft.Xna.Framework;
using SEGame.Animations;
using SEGame.Collisions;
using SEGame.EC;
using SEGame.EC.Components;
using SEGame.Managers;

namespace SEGame.Entities
{
    public class Spikes : Entity
    {
        public Spikes(Point location)
        {
            AddComponent(new Transform(location));
            AddComponent(new EnemyCollider(new Rectangle(0, 0, 16, 16), Vector2.Zero));
            AddComponent(new Animator());
            AddComponent(new Physics());

            var idleAnim = new Animation("idle", 8, AssetManager.Instance.GetTexture2D("spikes"));
            idleAnim.AddFrame(new AnimationFrame(new Rectangle(0, 0, 16, 16)));

            GetComponent<Animator>().AddAnimation(idleAnim);
        }
    }
}
