using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development.Interfaces
{
    public interface IInputReader
    {
        Vector2 ReadInput(bool CanLeft, bool CanRight);
    }
}
