using Microsoft.Xna.Framework;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development.Command
{
    public class MoveCommand : IGameCommand
    {
        public Vector2 speed;
        public MoveCommand()
        {
            this.speed = new Vector2(5, 0);         // snelheid bewegen
        }
        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= speed;
            transform.Position += direction;
        }
    }
}
