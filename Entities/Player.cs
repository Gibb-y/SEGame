using Microsoft.Xna.Framework;
using SEGame.Collisions;
using SEGame.EC;
using SEGame.EC.Components;
using SEGame.EC.Scripts;

namespace SEGame.Entities
{
    public class Player : Entity
    {
        public Player() : base()
        {
            AddComponent(new Transform(new Vector2(100, 100)));
            AddComponent(new Physics());
            AddComponent(new Animator());
            AddComponent(new PlayerCollider(new Rectangle(0, 0, 32, 32)));
            AddScript(new PlayerScript());
        }
    }
}
