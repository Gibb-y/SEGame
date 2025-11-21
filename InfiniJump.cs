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
        private InputManager _inputManager;
        private CollisionManager _collisionManager;
        private Player _player;

        private bool _firstFrame = true;

        public InfiniJump()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _entityManager = EntityManager.Instance;
            _assetManager = AssetManager.Instance;
            _drawManager = DrawManager.Instance;
            _inputManager = InputManager.Instance;
            _collisionManager = CollisionManager.Instance;
            _collisionManager.Initialize(400, 200);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _assetManager.AddTexture2D("idle", Content.Load<Texture2D>("Player/idle"));
            _assetManager.AddTexture2D("run", Content.Load<Texture2D>("Player/run"));
            _assetManager.AddTexture2D("jump", Content.Load<Texture2D>("Player/jump"));
            _assetManager.AddTexture2D("fall", Content.Load<Texture2D>("Player/fall"));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (_firstFrame)
            {
                _player = new();
                _entityManager.AddEntity(_player);
                _drawManager.AddDrawable(_player.GetComponent<Animator>());
                _firstFrame = false;
            }

            // TODO: Add your update logic here
            _inputManager.Update(gameTime);
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
