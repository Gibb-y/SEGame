using SEGame.EC;
using SEGame.EC.Components;
using SEGame.EC.Scripts;

namespace SEGame.Entities
{
    public class Player : Entity
    {
        public Player() : base()
        {
            AddComponent(new Transform());
            AddComponent(new Physics());
            AddComponent(new Animator());
            AddScript(new PlayerScript());
        }
    }
}
