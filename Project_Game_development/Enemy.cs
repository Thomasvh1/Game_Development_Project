using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_development.Command;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Project_Game_development
{
    public class Enemy : IGameObject, ITransform
    {

        SpriteEffects effect = SpriteEffects.None;

        Texture2D EnemyTexture;
        Animatie animatie;
        MoveCommand move;

        private Vector2 direction;
        public Vector2 Position { get; set; }   // positie implementeren (interface)
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle collisionrectangle;


        private IGameCommand movecommand;


        public Enemy(Texture2D Texture, Vector2 position)         // Iinputreader => hoe input uitlezen?
        {
            Position = position;
            //read input for hero class
            EnemyTexture = Texture;
            animatie = new Animatie();
            move = new MoveCommand();

            movecommand = new MoveCommand();

            animatie.AddFrame(new AnimationFrame(new Rectangle(Texture.Width/9, Texture.Height, Texture.Width/9, Texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(Texture.Width / 9*2, Texture.Height, Texture.Width / 9, Texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(Texture.Width / 9*3, Texture.Height, Texture.Width / 9, Texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(Texture.Width / 9*4, Texture.Height, Texture.Width / 9, Texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(Texture.Width / 9*5, Texture.Height, Texture.Width / 9, Texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(Texture.Width / 9*6, Texture.Height, Texture.Width / 9, Texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(Texture.Width / 9*7, Texture.Height, Texture.Width / 9, Texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(Texture.Width / 9*8, Texture.Height, Texture.Width / 9, Texture.Height)));     // frame lopend
            animatie.AddFrame(new AnimationFrame(new Rectangle(Texture.Width, Texture.Height, Texture.Width / 9, Texture.Height)));     // frame lopend



            collisionrectangle = new Rectangle((int)Position.X, (int)Position.Y, 68, 85);
            Moving();
        }

        public void Update()
        {

            //direction = inputreader.ReadInput(CanLeft, CanRight);

            //MoveHorizontal(direction);


            if (direction != Vector2.Zero)
                animatie.Update();

            collisionrectangle.X = (int)Position.X;
            collisionrectangle.Y = (int)Position.Y;
            CollisionRectangle = collisionrectangle;

        }
        private void Moving()
        {
            if (!move.Side)
                direction = new Vector2(1, 0);
            else
                direction.X = direction.X * -1;

            MoveHorizontal(direction);
        }
        private void MoveHorizontal(Vector2 _direction)
        {
            movecommand.Execute(this, _direction);
            effect = movecommand.Direction(_direction);
        }
        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }

            return v;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            //_spriteBatch.Draw(HeroTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White);
            _spriteBatch.Draw(EnemyTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White, 44f, new Vector2(0, 0), 1f, effect, 0f);

        }
    }
}