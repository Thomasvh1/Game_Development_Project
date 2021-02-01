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
        public Texture2D texture;
        private Platform blok;
        public Vector2 pos = new Vector2(150, 340);

        //public Vector2 Blokken;               //


        //public byte[,] tileArray = new Byte[,]
        //{
        //    {0,0,0,0,0,0,0,0 },
        //    {0,0,0,1,1,1,0,0 },
        //    {1,0,0,0,0,0,0,1 },
        //    {0,0,0,0,1,1,0,0 },
        //};

        //private Platform[,] blokArray = new Platform[4, 8];

        private ContentManager content;

        public Level2(ContentManager content)
        {
            this.content = content;


            InitializeContent();
            blok = new Platform(texture, pos);
        }

        private void InitializeContent()
        {
            texture = content.Load<Texture2D>("resized");
        }

        //public void CreateWorld()
        //{
        //    for (int x = 0; x < 4; x++)
        //    {
        //        for (int y = 0; y < 8; y++)
        //        {
        //            if (tileArray[x, y] == 1)
        //            {
        //                blokArray[x, y] = new Platform(texture, Blokken = new Vector2(y * 100, x * 110));      // y coordinaat horizontaal + distance between. X coordinaat hoogte
        //            }
        //        }
        //    }
        //}

        public void DrawWorld(SpriteBatch spritebatch)
        {
            //    for (int x = 0; x < 4; x++)
            //    {
            //        for (int y = 0; y < 8; y++)
            //        {
            //            if (blokArray[x, y] != null)
            //            {
            //                blokArray[x, y].Draw(spritebatch);
            //            }
            //        }
            //    }
            blok.Draw(spritebatch);                 //
        }
    }
}
