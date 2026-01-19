using Microsoft.Xna.Framework;
using SEGame.Animations;
using SEGame.Collisions;
using SEGame.EC;
using SEGame.EC.Components;
using SEGame.EC.Scripts;
using SEGame.Managers;

namespace SEGame.Entities
{
    public class Enemy : Entity
    {
        public Enemy(Vector2 position) : base()
        {
            AddComponent(new Transform(position));
            AddComponent(new Physics());
            AddComponent(new Animator());
            AddComponent(new EnemyCollider(new Rectangle(0, 0, 32, 64), new Vector2(), false));

            AddScript(new JumpingEnemyScript());

            var idleAnim = new Animation("idle", 8, AssetManager.Instance.GetTexture2D("je_idle"));
            var jumpAnim = new Animation("jump", 8, AssetManager.Instance.GetTexture2D("je_jump"));

            for (int i = 0; i < 8; i++)
            {
                idleAnim.AddFrame(new AnimationFrame(new Rectangle(32 * i, 0, 32, 32)));
            }
            
            jumpAnim.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));

            GetComponent<Animator>().AddAnimation(idleAnim);
            GetComponent<Animator>().AddAnimation(jumpAnim);

        }
    }
}
