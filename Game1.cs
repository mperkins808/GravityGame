using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GravityGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Entity entity;
        private Entity newEntity;
        private Physics physicsBodies;
        //Mouse variables for mouse capture
        MouseState mouseState;
        Point mousePosition;
        //WINDOW SIZE
        const int WINDOW_WIDTH = 1280;
        const int WINDOW_HEIGHT = 720;
        //DEBUGGING VARIABLES
        bool tog;
        int i;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // LOADING WINDOW SIZE
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.ApplyChanges();

            //Loading mouse capture
            mouseState = Mouse.GetState();
            mousePosition = new Point(mouseState.X, mouseState.Y);
            IsMouseVisible = false;

            // LOADING ENTITIES -- MOSTLY FOR DEBUGGING CURRENTLY
            entity = new Entity(null, new Vector2(100, 100));
            newEntity = new Entity(null, new Vector2(150, 150));
            physicsBodies = new Physics(entity);

            //Loading variables for swithing
            tog = true;
            i = 0;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            entity.SetTexture(Content.Load<Texture2D>("ball"));
            newEntity.SetTexture(Content.Load<Texture2D>("ball"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Right))
            {
               entity.UpdatePos(150, 0, gameTime);
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                entity.UpdatePos(-150, 0, gameTime);
            }
            if (kstate.IsKeyDown(Keys.Up))
            {
                entity.UpdatePos(0, -150, gameTime);
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                entity.UpdatePos(0, 150, gameTime);
            }
            mouseTracker();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            bundleDraw();
            base.Draw(gameTime);
        }

        protected void bundleDraw()
        {
            _spriteBatch.Begin();
            foreach (var entity in physicsBodies.getEntityList())
            {
                 _spriteBatch.Draw(entity.GetTexture(), entity.GetPosition(), Color.White);
            }
            _spriteBatch.End();
        }

        private void mouseTracker()
        {
            mousePosition = Mouse.GetState().Position;
            mouseSpawner();
            //Debug.WriteLine("X: " + mousePosition.X + "Y: " + mousePosition.Y);
            // Tracking X position
            if (mousePosition.X < 0 + entity.GetTexture().Width)
            {
                entity.SetX(0);
            }
            else if (mousePosition.X > WINDOW_WIDTH - entity.GetTexture().Width)
            {
                entity.SetX(WINDOW_WIDTH - entity.GetTexture().Width);
            }
            else
            {
                entity.SetX(mousePosition.X - entity.GetTexture().Width / 2);
            }
            //Tracking Y position
            if (mousePosition.Y < 0 + entity.GetTexture().Height)
            {
                entity.SetY(0);
            }
            else if (mousePosition.Y > WINDOW_HEIGHT - entity.GetTexture().Height)
            {
                entity.SetY(WINDOW_HEIGHT - entity.GetTexture().Height);
            }
            else
            {
                entity.SetY(mousePosition.Y - entity.GetTexture().Height / 2);
            }
        }

        private void mouseSpawner()
        {
            Entity temp;
 
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Debug.WriteLine("CLICKED");
                temp = new Entity(Content.Load<Texture2D>("ball"), mousePosition.ToVector2());
                physicsBodies.addToList(temp);
            }
        }

        public bool timer(int framesTillTrue, bool on)
        {
            i++;
            if (i == framesTillTrue)
            {
                Debug.WriteLine("TRUE");
                return true;
            }
            else return false;

        }
    }
}
