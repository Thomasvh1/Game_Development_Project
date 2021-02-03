using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development
{
    class Door : IGameObject
    {
        Texture2D _texture;
        Vector2 position;
        Animatie animatie;
        public Door(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            position = pos;
            animatie = new Animatie();

            animatie.AddFrame(new AnimationFrame(new Rectangle(1,1,_texture.Width/6,_texture.Height)));     // 107,160
            animatie.AddFrame(new AnimationFrame(new Rectangle(107, 1, _texture.Width / 6, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(217, 1, _texture.Width / 6, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(321, 1, _texture.Width / 6, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(428, 1, _texture.Width / 6, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(535, 1, _texture.Width / 6, _texture.Height)));     // frame lopend
        }
        public void Draw(SpriteBatch _spritebatch)
        {
            _spritebatch.Draw(_texture, position, animatie.CurrentFrame.SourceRectangle, Color.White);

        }

        public void Update()
        {
            animatie.Update();
        }
    }
}
