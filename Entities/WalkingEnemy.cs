using Microsoft.Xna.Framework;
using SEGame.Animations;
using SEGame.Collisions;
using SEGame.EC;
using SEGame.EC.Components;
using SEGame.EC.Scripts;
using SEGame.Managers;

namespace SEGame.Entities
{
    public class WalkingEnemy : Entity
    {
        public WalkingEnemy(Point location) : base()
        {
            AddComponent(new Transform(location));
            AddComponent(new Physics());
            AddComponent(new Animator());
            AddComponent(new EnemyCollider(new Rectangle(0, 0, 32, 64), new Vector2(), false));

            AddScript(new WalkingEnemyScript());

            var runAnim = new Animation("run", 8, AssetManager.Instance.GetTexture2D("we_run"));

            for (int i = 0; i < 8; i++)
            {
                runAnim.AddFrame(new AnimationFrame(new Rectangle(32 * i, 0, 32, 32)));
            }

            GetComponent<Animator>().AddAnimation(runAnim);
        }
    }
}
