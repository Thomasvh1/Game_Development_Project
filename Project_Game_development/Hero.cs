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
    public class Hero : IGameObject, ITransform
    {

        SpriteEffects effect = SpriteEffects.None;

        Texture2D HeroTexture;
        Animatie animatie;

        private IInputReader inputreader;
        private Vector2 direction;
        public Vector2 Position { get; set; }   // positie implementeren (interface)
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle collisionrectangle;

        //KeyboardState state = Keyboard.GetState();
        KeyBoardReader keyb;

        private IGameCommand movecommand;
        private bool CanLeft;
        private bool CanRight;
        private bool CanUp;
        private bool CanDown;

        public Hero(Texture2D Texture, IInputReader reader)         // Iinputreader => hoe input uitlezen?
        {
            Position = new Vector2(0, 335);
            //read input for hero class
            this.inputreader = reader;
            HeroTexture = Texture;
            animatie = new Animatie();
            keyb = new KeyBoardReader();

            int SchuifX = 0;
            int SchuifY = 0;
            for (int i = 0; i < 27; i++)
            {
                animatie.AddFrame(new AnimationFrame(new Rectangle(SchuifX, SchuifY, 75, 85)));     // frame lopend

                SchuifX = animatie.BerekenX();
                SchuifY = animatie.BerekenY();
            }

            movecommand = new MoveCommand();

            collisionrectangle = new Rectangle((int)Position.X, (int)Position.Y,68, 85);

        }

        public void Update()
        {

            direction = inputreader.ReadInput(CanLeft, CanRight);

            MoveHorizontal(direction);
            MoveJump(Position);

            if (direction != Vector2.Zero)
                animatie.Update();

            collisionrectangle.X = (int)Position.X;
            collisionrectangle.Y = (int)Position.Y;
            CollisionRectangle = collisionrectangle;

        }

        private void MoveJump(Vector2 pos)
        {
            movecommand.Jumping(this, CanDown, CanUp);
        }

        public void SetCollision(bool Left, bool Right, bool Down, bool Up)
        {
            CanLeft = Left;
            CanRight = Right;
            CanUp = Up;
            CanDown = Down;
        }

        private void MoveHorizontal(Vector2 _direction)
        {
            movecommand.Execute(this, _direction);
            effect = movecommand.Direction(_direction);
        }
        //private Vector2 Limit(Vector2 v, float max)
        //{
        //    if (v.Length() > max)
        //    {
        //        var ratio = max / v.Length();
        //        v.X *= ratio;
        //        v.Y *= ratio;
        //    }

        //    return v;
        //}

        public void Draw(SpriteBatch _spriteBatch)
        {

            //_spriteBatch.Draw(HeroTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White);
            _spriteBatch.Draw(HeroTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White, 44f, new Vector2(0,0),1f,effect,0f);

        }
    }
}