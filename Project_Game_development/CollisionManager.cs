using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Project_Game_development
{
    class CollisionManager
    {
        public bool CanMoveLeft = true;
        public bool CanMoveRight = true;
        public bool CanJump = true;
        public bool CanDown = true;

        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect2))
            {
                return true;
            }
            return false;
        }
        public void ColissionPlatforms(Hero _hero, Level1 _level)
        {

            for (int x = 0; x < Level1.row; x++)
            {
                for (int y = 0; y < Level1.column; y++)
                {
                    if (_level.tileArray[x,y] == 1)
                    {



                        if (CheckCollision(_hero.CollisionRectangle, _level.blokArray[x,y].CollisionRectangle))
                        {
                            if (_hero.CollisionRectangle.Y < _level.blokArray[x, y].CollisionRectangle.Y)
                            {
                                Debug.WriteLine("Top!");
                                CanMoveLeft = true;
                                CanMoveRight = true;
                                CanDown = false;
                                //hero.Position += new Vector2(1, -1) * 5;
                                //collision = true;
                            }
                            else if (_hero.CollisionRectangle.X > _level.blokArray[x,y].CollisionRectangle.X && CanDown == true)     // touching Right
                            {
                                Debug.WriteLine("Right!");
                                CanMoveRight = true;
                                CanDown = true;
                                CanMoveLeft = false;

                                //hero.Position += new Vector2(1, 0) * 5;
                                //collision = true;
                            }
                            else if (_hero.CollisionRectangle.X < _level.blokArray[x,y].CollisionRectangle.X - 50 && CanDown == true)     // touching Left
                            {
                                Debug.WriteLine("Left!");
                                CanMoveLeft = true;
                                CanDown = true;
                                CanMoveRight = false;

                                //hero.Position += new Vector2(-1, 0) * 5;
                                //collision = true;
                            }
                        }
                        else
                        {
                            CanMoveRight = true;
                            CanMoveLeft = true;
                            CanDown = true;
                            CanJump = true;
                        }
                        _hero.SetCollision(CanMoveLeft, CanMoveRight, CanDown, CanJump);
                    }
                }
            }
        }
    }
}