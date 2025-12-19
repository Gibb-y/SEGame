using Microsoft.Xna.Framework;
using SEGame.Animations;
using SEGame.Collisions;
using SEGame.EC;
using SEGame.EC.Components;
using SEGame.Managers;

namespace SEGame.Entities
{
    public class Platform : Entity
    {
        public Platform(Point location, Rectangle collisionBox, string animName = "defaultplatform")
        {
            AddComponent(new Transform(location));
            AddComponent(new InertCollider(collisionBox, true));

            Animation defaultPlatformStart = new("defaultplatform-start", 1, AssetManager.Instance.GetTexture2D("terrain"));
            Animation defaultPlatformMiddle = new("defaultplatform-middle", 1, AssetManager.Instance.GetTexture2D("terrain"));
            Animation defaultPlatformEnd = new("defaultplatform-end", 1, AssetManager.Instance.GetTexture2D("terrain"));
            defaultPlatformStart.AddFrame(new(new(272, 16, 16, 16)));
            defaultPlatformMiddle.AddFrame(new(new(272 + 26, 16, 16, 16)));
            defaultPlatformEnd.AddFrame(new(new(272 + 2 * 16, 16, 16, 16)));

            var platformLength = collisionBox.Width / 16;

            AddComponent(Animator.Builder()
                                    .AddAnimation(defaultPlatformStart)
                                    .Build());

            for (int i = 1; i < platformLength - 1; i++)
            {
                AddComponent(Animator.Builder()
                                        .AddAnimation(defaultPlatformMiddle)
                                        .SetOffset(new Vector2(16 * i, 0))
                                        .Build());
            }


            AddComponent(Animator.Builder()
                                    .AddAnimation(defaultPlatformEnd)
                                    .SetOffset(new Vector2(16 * platformLength - 1, 0))
                                    .Build());
        }
    }
}
