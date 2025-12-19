using Microsoft.Xna.Framework;
using SEGame.Animations;
using SEGame.Collisions;
using SEGame.EC;
using SEGame.EC.Components;
using SEGame.EC.Scripts;
using SEGame.Managers;

namespace SEGame.Entities
{
    public class Player : Entity
    {
        public Player() : base()
        {
            AddComponent(new Transform(new Vector2(100, 100)));
            AddComponent(new Physics());
            AddComponent(new Animator());
            AddComponent(new PlayerCollider(new Rectangle(0, 0, 32, 32), true));

            AddScript(new PlayerScript());

            var idleAnim = new Animation("idle", 8, AssetManager.Instance.GetTexture2D("idle"));
            var runAnim = new Animation("run", 8, AssetManager.Instance.GetTexture2D("run"));
            var jumpAnim = new Animation("jump", 8, AssetManager.Instance.GetTexture2D("jump"));
            var fallAnim = new Animation("fall", 8, AssetManager.Instance.GetTexture2D("fall"));

            for (int i = 0; i < 8; i++)
            {
                idleAnim.AddFrame(new AnimationFrame(new Rectangle(32 * i, 0, 32, 32)));
                runAnim.AddFrame(new AnimationFrame(new Rectangle(32 * i, 0, 32, 32)));
            }
            jumpAnim.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            fallAnim.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));

            GetComponent<Animator>().AddAnimation(idleAnim);
            GetComponent<Animator>().AddAnimation(runAnim);
            GetComponent<Animator>().AddAnimation(jumpAnim);
            GetComponent<Animator>().AddAnimation(fallAnim);

        }
    }
}
