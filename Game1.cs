using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Timers;
using TexturePackerLoader;

namespace GravityGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Entity entity;
        private Entity newEntity;
        private Physics physicsBodies;
        Timer t;
        SpriteSheet spriteSheet;
        SpriteRender spriteRender;
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
            IsMouseVisible = true;

            // LOADING ENTITIES -- MOSTLY FOR DEBUGGING CURRENTLY
            entity = new Entity(null, new Vector2(100, 100), new Vector2(50,50));
            physicsBodies = new Physics(entity);

            //Loading variables for swithing
            tog = true;
            for (int i = 0; i < TexturePackerMonoGameDefinitions.earthSprites.getSprites().Length; i++)
            {
                Debug.WriteLine(TexturePackerMonoGameDefinitions.earthSprites.getSprites()[i]);
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var spriteSheetLoader = new SpriteSheetLoader(Content, GraphicsDevice);
            this.spriteRender = new SpriteRender(this._spriteBatch);
            spriteSheet = spriteSheetLoader.Load("finalEarthExport.png");
            entity.SetTexture(Content.Load<Texture2D>("ball"));
        
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Right))
            {
                try
                {
                    physicsBodies.getEntityList()[0].SetVelocty(new Vector2(75 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0));
                }
                catch (ArgumentOutOfRangeException) { }

            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                try
                {
                    physicsBodies.getEntityList()[0].SetVelocty(new Vector2(-75 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0));
                }
                catch (ArgumentOutOfRangeException) { }

            }
            if (kstate.IsKeyDown(Keys.Up))
            {
                try
                {
                    physicsBodies.getEntityList()[0].SetVelocty(new Vector2(0, -75 * (float)gameTime.ElapsedGameTime.TotalSeconds));
                }
                catch (ArgumentOutOfRangeException) { }
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                try
                {
                    Debug.WriteLine(physicsBodies.getEntityList()[0].GetVelocity().Y);
                    physicsBodies.getEntityList()[0].SetVelocty(new Vector2(0, 75 * (float)gameTime.ElapsedGameTime.TotalSeconds));
                }
                catch (ArgumentOutOfRangeException) { }
            }
            i++;
            mouseTracker();
            foreach (Entity e in physicsBodies.getEntityList())
            {
                if (!e.GetDelete())
                {
                    e.UpdatePos(gameTime);
                }
            }
            for (int l = 0; l < physicsBodies.getEntityList().Count; l++)
            {
                if (physicsBodies.getEntityList()[l].GetDelete())
                {
                    physicsBodies.getEntityList().RemoveAt(l);
                }
            }
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
            this.spriteRender.Draw(
                this.spriteSheet.Sprite(entity.animations()
                ), entity.GetPosition()
                );
                
            }
            _spriteBatch.End();
        }

        private void mouseTracker()
        {
            mousePosition = Mouse.GetState().Position;
            mouseSpawner();

        }

        private void mouseSpawner()
        {
            Entity temp;
            mouseState = Mouse.GetState();
            if (i > 60)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    i = 0;
                    temp = new Entity(Content.Load<Texture2D>("ball"), mousePosition.ToVector2(), new Vector2(0,0));
                    physicsBodies.addToList(temp);

                }
            }
        }
    }
}
