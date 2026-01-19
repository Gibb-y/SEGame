using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Collisions;
using SEGame.EC.Components;
using SEGame.Entities;
using SEGame.Managers;
using SEGame.Scenes;
using SEGame.Util;

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
        private Rectangle _playerCollisionBox;
        private Rectangle _platformCollisionBox;
        private SceneManager _sceneManager;

        private bool _firstFrame = true;

        public InfiniJump()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 800;
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
            _collisionManager.Initialize(1280, 800);
            Shapes.Instance.Initialize(GraphicsDevice);
            _sceneManager = SceneManager.Instance;
            _sceneManager.AddScene("level_1", new Level1());
            _sceneManager.SetSceneAsActive("level_1");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _assetManager.AddTexture2D("idle", Content.Load<Texture2D>("Player/idle"));
            _assetManager.AddTexture2D("run", Content.Load<Texture2D>("Player/run"));
            _assetManager.AddTexture2D("jump", Content.Load<Texture2D>("Player/jump"));
            _assetManager.AddTexture2D("fall", Content.Load<Texture2D>("Player/fall"));
            _assetManager.AddTexture2D("terrain", Content.Load<Texture2D>("Environment/terrain"));
            AssetLoader.LoadTextures2DFromXmlFile("C:\\Users\\Sander\\source\\repos\\SEGame\\AssetList.xml", Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //if (_firstFrame)
            //{
            //    _player = new();
            //    var platform = new Platform(new Point(400, 600), new Rectangle(400, 600, 16 * 3, 16));
            //    _entityManager.AddEntity(_player);
            //    _entityManager.AddEntity(platform);
            //    //_drawManager.AddDrawable(_player.GetComponent<Animator>());
            //    _collisionManager.DebugFFS(_player.GetComponent<PlayerCollider>().CollisionBox, platform.GetComponent<InertCollider>().CollisionBox);
            //    _firstFrame = false;
            //}

            // TODO: Add your update logic here
            //_inputManager.Update(gameTime);
            //_entityManager.Update(gameTime);
            _sceneManager.Update(gameTime);
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
