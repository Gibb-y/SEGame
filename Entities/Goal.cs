using Microsoft.Xna.Framework;
using SEGame.Animations;
using SEGame.Collisions;
using SEGame.EC;
using SEGame.EC.Components;
using SEGame.Managers;

namespace SEGame.Entities
{
    public class Goal : Entity
    {
        public Goal(Point location) : base()
        {
            AddComponent(new Transform(location));
            AddComponent(new Animator());
            AddComponent(new TriggerCollider(new Rectangle(0, 0, 64, 64), Vector2.Zero));

            var goal = new Animation("goal", 8, AssetManager.Instance.GetTexture2D("goal"));
            goal.AddFrame(new AnimationFrame(new Rectangle(0, 0, 64, 64)));

            GetComponent<Animator>().AddAnimation(goal);


        }
    }
}
