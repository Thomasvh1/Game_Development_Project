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
        Texture2D HeroTexture;
        Animatie animatie;
        private IInputReader inputreader;
        private int SchuifX;
        private int SchuifY;
        private Vector2 direction;
        public Vector2 Position { get; set; }   // positie implementeren (interface)

        KeyboardState state = Keyboard.GetState();
        Boolean staat = false;



        //private Vector2 positie;
        private Vector2 snelheid;
        private Vector2 versnelling;
        private Vector2 MouseVector;

        private IGameCommand movecommand;

        public Hero(Texture2D Texture, IInputReader reader)         // Iinputreader => hoe input uitlezen?
        {
            //read input for hero class
            this.inputreader = reader;
            HeroTexture = Texture;
            animatie = new Animatie();







            snelheid = new Vector2(1,1);      // richting aangeven
            //positie = new Vector2(100, 100);     // start positie
            versnelling = new Vector2(0.1f, 0.1f);

            movecommand = new MoveCommand();
        }


        public void Lopen()
        {
            for (int i = 0; i <= 27; i++)
            {
                animatie.AddFrame(new AnimationFrame(new Rectangle(SchuifX, SchuifY, 75, 85)));     // frame lopend

                SchuifX = animatie.BerekenX();
                SchuifY = animatie.BerekenY();
            }
        }
        public void Staan()
        {
            animatie.AddFrame(new AnimationFrame(new Rectangle(75, 85, 75, 85)));       // frame stilstaan
        }


        public void Update()
        {
            if (direction == new Vector2(0,0))
                staat = false;
            if (direction == new Vector2(1,0))
                staat = true;


            if (staat == true)
            {
                Lopen();
            }
            else
            {
                Staan();
            }

            direction = inputreader.ReadInput();

            MoveHorizontal(direction);
            //direction *= 4;
            //positie += direction;

            //Move(GetMouseState());
            animatie.Update();

        }
        private void MoveHorizontal(Vector2 _direction)
        {
            movecommand.Execute(this, _direction);
        }
        private Vector2 GetMouseState()     // muis laten volgen
        {
            MouseState state = Mouse.GetState();
            MouseVector = new Vector2(state.X, state.Y);            // positie muis
            return MouseVector;
        }

        private void Move(Vector2 mouse)
        {
            //var direction = Vector2.Add(mouse, -positie);           // positie naar muis toe, van elkaar aftrekken
            //direction.Normalize();
            //direction = Vector2.Multiply(direction, 0.5f);

            //positie += snelheid;
            //snelheid += direction;
            //snelheid = Limit(snelheid, 10);

            //if (positie.X > 730 || positie.X < 0)       // lengte terminal
            //{
            //    snelheid.X *= -1;
            //    versnelling.X *= -1;
            //}
             
            //if (positie.Y > 400 || positie.Y < 0)       // breedte terminal
            //{
            //    snelheid.Y *= -1;
            //    versnelling *= -1;
            //}
        }
        private Vector2 Limit(Vector2 v, float max)
        {
            if(v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }

            return v;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(HeroTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White);

        }
    }
}
