using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development
{
    public class AnimationFrame             // een Frame van de sprite
    {
        public Rectangle SourceRectangle { get; set; }
        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }
}
