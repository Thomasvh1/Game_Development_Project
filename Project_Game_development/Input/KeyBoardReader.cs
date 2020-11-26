using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development
{
    class KeyBoardReader : IInputReader
    {
        public Vector2 ReadInput()
        {

            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right))
                direction = new Vector2(1, 0);
            if (state.IsKeyDown(Keys.Left))
                direction = new Vector2(-1, 0);

            if (state.IsKeyDown(Keys.Up))
                direction = new Vector2(0, -1);



            return direction;
        }
    }
}
