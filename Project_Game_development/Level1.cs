using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development
{
    class Level1
    {
        public Texture2D Platformtexture;
        public Texture2D Doortexture;
        public Texture2D Crystaltexture;


        public Vector2 Blokken;
        public Vector2 PosDoor = new Vector2(690,260);
        public Vector2 PosCrystal = new Vector2(30,180);

        public static int row = 4;
        public static int column = 8;

        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0,0,0 },
            {0,0,0,1,1,1,0,0 },
            {1,0,0,0,0,0,0,1 },
            {0,0,0,0,1,1,0,0 },
        };

        public Platform[,] blokArray = new Platform[row, column];

        private ContentManager content;

        private Door door;

        private Crystal crystal;


        public Level1(ContentManager content)
        {
            this.content = content;

            InitializeContent();
        }

        private void InitializeContent()
        {
            Platformtexture = content.Load<Texture2D>("resized");
            Doortexture = content.Load<Texture2D>("door");
            Crystaltexture = content.Load<Texture2D>("crystal");
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
            door = new Door(Doortexture, PosDoor);
            crystal = new Crystal(Crystaltexture, PosCrystal);
        }

        public void Draw(SpriteBatch spritebatch)
        {
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
            door.Draw(spritebatch);
            crystal.Draw(spritebatch);
            //blok.Draw(spritebatch);                 //
        }
    }
}
