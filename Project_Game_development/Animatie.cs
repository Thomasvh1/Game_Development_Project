using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Game_development
{
    class Animatie      // alle frames van de sprite doorlopen
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;

        private int counter = 0;
        private int X=0;
        private int Y=0;

        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }
        public void AddFrame(AnimationFrame animatieframe)
        {
            frames.Add(animatieframe);
            CurrentFrame = frames[0];
        }
        public int BerekenX()               // schuiven frames X berekenen
        {
            X += 75;

            if (X >= 450)
            {
                Y += 85;
                X = 0;
            }
            return X;
        }
        public int BerekenY()           // schuiven frames Y berekenen
        {
            if (Y >= 320)
                Y = 0;

            return Y;
        }
        public void Update()
        {
            CurrentFrame = frames[counter];
            counter++;
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
    }
}