﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development
{
    public class Platform : IGameObject
    {
        public Texture2D _texture { get; set; }
        public Vector2 Positie { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public Platform(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            Positie = pos;
            CollisionRectangle = new Rectangle((int)pos.X, (int)pos.Y, texture.Width-7, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Positie, Color.AliceBlue);
        }

        public void Update()
        {
            //
        }
    }
}