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

        public Rectangle CollisionRectangle { get; set; }


        public Crystal(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            position = pos;
            animatie = new Animatie();

            animatie.AddFrame(new AnimationFrame(new Rectangle(1, 1, _texture.Width /6-10, _texture.Height)));     // 107,160
            animatie.AddFrame(new AnimationFrame(new Rectangle(106, 1, _texture.Width / 6-10, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(212, 1, _texture.Width / 6-10, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(318, 1, _texture.Width / 6-10, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(424, 1, _texture.Width / 6-10, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(530, 1, _texture.Width / 6-10, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(636, 1, _texture.Width / 6-10, _texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(742, 1, _texture.Width / 6-10, _texture.Height)));     // frame lopend

            CollisionRectangle = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);

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
