using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SEGame.Animations;
using SEGame.EC.Components;
using SEGame.Entities;
using SEGame.Managers;

namespace SEGame
{
    public class InfiniJump : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private EntityManager _entityManager;
        private AssetManager _assetManager;
        private DrawManager _drawManager;
        private Player _player;

        public InfiniJump()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _player = new();
            _entityManager = EntityManager.Instance;
            _assetManager = AssetManager.Instance;
            _drawManager = DrawManager.Instance;
            _entityManager.AddEntity(_player);
            _drawManager.AddDrawable(_player.GetComponent<Animator>());
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _assetManager.AddTexture2D("idle", Content.Load<Texture2D>("Player/idle"));
            var idleAnim = new Animation("idle", 4, AssetManager.Instance.GetTexture2D("idle"));
            for (int i = 0; i < 8; i++)
            {
                idleAnim.AddFrame(new AnimationFrame(new Rectangle(32 * i, 0, 32, 32)));
            }
            _player.GetComponent<Animator>().AddAnimation(idleAnim);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _entityManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _drawManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
