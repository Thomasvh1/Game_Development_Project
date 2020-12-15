using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Project_Game_development
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D texture;
        private Texture2D achtergrond;


        Platform _platform;
        Hero hero;
        Level1 level1;
        CollisionManager collisionmanager;                


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            collisionmanager = new CollisionManager();                    
            level1 = new Level1(Content);                   //
            //level1.CreateWorld();                           //
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("sprite_project");
            achtergrond = Content.Load <Texture2D>("sprite_project_background");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(texture, new KeyBoardReader());               //Hero klasse opstarten
            _platform = new Platform(level1.texture, level1.pos);                       
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (collisionmanager.CheckCollision(hero.CollisionRectangle, _platform.CollisionRectangle))
            {
                if (hero.CollisionRectangle.X > _platform.CollisionRectangle.X)     // touching Right
                {
                    Debug.WriteLine("Right!");
                    hero.Position += new Vector2(1, 0)*5;

                }
                if (hero.CollisionRectangle.X < _platform.CollisionRectangle.X)     // touching Left
                {
                    Debug.WriteLine("Left!");
                    hero.Position += new Vector2(-1, 0)*5;

                }
                if(hero.CollisionRectangle.X > _platform.CollisionRectangle.X -50 && hero.CollisionRectangle.X < _platform.CollisionRectangle.X)
                {
                    Debug.WriteLine(_platform.CollisionRectangle.Top);
                    Debug.WriteLine(hero.CollisionRectangle.Bottom);
                    hero.Position += new Vector2(0,1) * 5;

                }
            }

            hero.Update();        // Update doen van Hero

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(achtergrond, new Vector2(0, 0), new Rectangle(0, 100, 800, 480), Color.White);
            hero.Draw(_spriteBatch);        // Draw
            level1.DrawWorld(_spriteBatch);                                     //

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}