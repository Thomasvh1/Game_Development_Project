using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development.Command
{
    public class MoveCommand : IGameCommand
    {
        SpriteEffects s = SpriteEffects.None;
        public Vector2 speed;
        public Vector2 Power;


        Vector2 position;
        Vector2 Velocity;

        bool Jumped;


        public MoveCommand()
        {
            this.speed = new Vector2(5, 0);         // snelheid bewegen
            this.Power = new Vector2(0, -10);
        }
        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= speed;
            if (transform.Position.X >= 740)
            {
                transform.Position += new Vector2(-1, 0);
            }
            else if(transform.Position.X < 0)
            {
                transform.Position += new Vector2(1, 0);
            }
            else
                transform.Position += direction;

        }

        public SpriteEffects Direction()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                s = SpriteEffects.FlipHorizontally;
                //frame flip
                return s;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                s = SpriteEffects.None;
                //normale frame
                return s;
            }
            return s;
        }

        public void Jumping(ITransform transform)
        {

            position += Velocity;
            transform.Position += Velocity;

            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //    Velocity.X = 3f;
            //else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //    Velocity.X = -3f;
            //else
            //    Velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Jumped == false)
            {
                transform.Position += new Vector2(0,-10);
                Velocity.Y = -5f;
                Jumped = true;
            }

            if (Jumped == true)
            {
                float i = 1;
                Velocity.Y += 0.15f * i;
            }
            if (transform.Position.Y >= 0.1f)
            {
                Jumped = false;
            }
            if (Jumped == false)
            {
                Velocity.Y = 0f;
            }

        }
    }
}
