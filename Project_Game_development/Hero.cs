using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_development.Command;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
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

        KeyboardState state = Keyboard.GetState();



        //private Vector2 positie;
        private Vector2 snelheid;
        private Vector2 versnelling;

        private IGameCommand movecommand;

        public Hero(Texture2D Texture, IInputReader reader)         // Iinputreader => hoe input uitlezen?
        {
            //read input for hero class
            this.inputreader = reader;
            HeroTexture = Texture;
            animatie = new Animatie();

            int SchuifX = 0;
            int SchuifY = 0;
            for (int i = 0; i < 27; i++)
            {
                animatie.AddFrame(new AnimationFrame(new Rectangle(SchuifX, SchuifY, 75, 85)));     // frame lopend

                SchuifX = animatie.BerekenX();
                SchuifY = animatie.BerekenY();
            }



            snelheid = new Vector2(1, 1);      // richting aangeven
            //positie = new Vector2(100, 100);     // start positie
            versnelling = new Vector2(0.1f, 0.1f);

            movecommand = new MoveCommand();

            collisionrectangle = new Rectangle((int)Position.X, (int)Position.Y,60, 341);

        }

        public void Update()
        {

            direction = inputreader.ReadInput();

            MoveHorizontal(direction);
            MoveJump(direction);

            if (direction != Vector2.Zero)
                animatie.Update();

            collisionrectangle.X = (int)Position.X;
            CollisionRectangle = collisionrectangle;

        }

        private void MoveJump(Vector2 _direction)
        {
            movecommand.Jumping(this);
        }

        private void MoveHorizontal(Vector2 _direction)
        {
            movecommand.Execute(this, _direction);
            effect = movecommand.Direction();

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
            _spriteBatch.Draw(HeroTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White, 44f, new Vector2(0,-335),1f,effect,0f);

        }
    }
}
