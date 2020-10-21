using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development.Interfaces
{
    interface IGameObject
    {
        public void Update();
        public void Draw(SpriteBatch _spritebatch);
    }
}