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

        StartPage start;
        EndPage end;
        Crystal crystal;
        Door door;
        Hero hero;
        Level1 level1;
        Level2 level2;
        CollisionManager collisionmanager;
        Enemy enemy;

        private bool EnemyCol;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.Components.Add(new EndPage(Content, this));
            this.Components.Add(new StartPage(Content,this));
            collisionmanager = new CollisionManager();
            start = new StartPage(Content, this);
            level1 = new Level1(Content);                   //
            level2 = new Level2(Content);
            level1.CreateWorld();                           //
            level2.CreateWorld();
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("sprite_project");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(texture, new KeyBoardReader());               //Hero klasse opstarten
            door = new Door(level1.Doortexture, level1.PosDoor);
            crystal = new Crystal(level1.Crystaltexture, level1.PosCrystal);
            enemy = new Enemy(level2.Enemytexture, level2.Enemypos);
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            collisionmanager.ColissionPlatforms(hero, level1);
            EnemyCol = collisionmanager.CollisionEnemy(hero, enemy);
            if (collisionmanager.CheckCollision(hero.CollisionRectangle, crystal.CollisionRectangle))
                level1.HasCrystal = true;
            if (level1.HasCrystal == true)
            door.Update();
            enemy.Update();
            hero.Update();        // Update doen van Hero
            crystal.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            InitializeLevels();
            _spriteBatch.End();


            base.Draw(gameTime);
        }

        private void InitializeLevels()
        {
            if (start.StartGame == false)
                start.Draw(_spriteBatch);
            else if (start.StartGame) // || end.StartGame
            {
                level1.Draw(_spriteBatch);
                hero.Draw(_spriteBatch);        // Draw if startGame is true
            }
            else if (level1.HasCrystal && hero.Position.X > level1.PosDoor.X)
            {
                level2.Draw(_spriteBatch);
                hero.Draw(_spriteBatch);        // Draw if startGame is true
            }
            else if (level2.EndLevel2 || EnemyCol)
                end.Draw(_spriteBatch);
        }
    }
}