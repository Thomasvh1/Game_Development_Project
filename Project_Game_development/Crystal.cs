using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development
{
    class Crystal : IGameObject
    {
        Animatie animatie;
        Texture2D _texture;

        Vector2 position;

        public Crystal(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            position = pos;
            animatie = new Animatie();

            animatie.AddFrame(new AnimationFrame(new Rectangle(1, 1, _texture.Width /6 -6, _texture.Height/6)));     // 107,160
            animatie.AddFrame(new AnimationFrame(new Rectangle(107, 1, _texture.Width / 6, _texture.Height/6)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(217, 1, _texture.Width / 6, _texture.Height/6)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(321, 1, _texture.Width / 6, _texture.Height/6)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(428, 1, _texture.Width / 6, _texture.Height/6)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(535, 1, _texture.Width / 6, _texture.Height/6)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(428, 1, _texture.Width / 6, _texture.Height/6)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(535, 1, _texture.Width / 6, _texture.Height/6)));     // frame lopend
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
