using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development.Command
{
    interface IGameCommand
    {
        void Execute(ITransform transform, Vector2 direction);
        SpriteEffects Direction(Vector2 goingleft);
        void Jumping(ITransform transform, bool CanDown, bool CanJump);
    }
}