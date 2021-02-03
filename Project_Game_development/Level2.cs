using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development
{
    class Level2
    {
        public Texture2D Platformtexture;
        public Texture2D Crystaltexture;
        public Texture2D Enemytexture;
        private Texture2D Background;


        public Vector2 Blokken;
        public Vector2 PosCrystal = new Vector2(700, 350);
        public Vector2 Enemypos = new Vector2();

        public static int row = 4;
        public static int column = 8;
        public bool EndLevel2 = false;

        Enemy enemy;

        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0,0,0 },
            {0,1,0,0,0,0,0,0 },
            {0,0,0,0,1,1,0,0 },
            {0,1,0,0,0,0,0,0 },
        };

        public Platform[,] blokArray = new Platform[row, column];

        private ContentManager content;

        private Crystal crystal;


        public Level2(ContentManager content)
        {
            this.content = content;
            InitializeContent();
            enemy = new Enemy(Enemytexture, Enemypos);

        }

        private void InitializeContent()
        {
            Background = content.Load<Texture2D>("sprite_project_background");
            Platformtexture = content.Load<Texture2D>("resized");
            Crystaltexture = content.Load<Texture2D>("crystal_2");
            Enemytexture = content.Load<Texture2D>("enemy");
        }

        public void CreateWorld()
        {
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < column; y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blokArray[x, y] = new Platform(Platformtexture, Blokken = new Vector2(y * 100, x * 110));      // y coordinaat horizontaal + distance between. X coordinaat hoogte
                    }
                }
            }
            crystal = new Crystal(Crystaltexture, PosCrystal);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Background, new Vector2(0, 0), new Rectangle(0, 100, 800, 480), Color.White);

            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < column; y++)
                {
                    if (blokArray[x, y] != null)
                    {
                        blokArray[x, y].Draw(spritebatch);
                    }
                }
            }
            crystal.Draw(spritebatch);
            enemy.Draw(spritebatch);
            //blok.Draw(spritebatch);                 //
        }
    }
}