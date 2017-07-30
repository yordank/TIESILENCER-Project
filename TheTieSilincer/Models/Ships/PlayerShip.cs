﻿using System;

namespace TheTieSilincer.Models
{
    public class PlayerShip : Ship
    {
        public override void ClearShip()
        {
            if (PreviousPosition != null)
            {
                Console.SetCursorPosition(PreviousPosition.Y + 4, PreviousPosition.X);

                Console.WriteLine(" ");

                Console.SetCursorPosition(PreviousPosition.Y + 4, PreviousPosition.X + 1);
                Console.WriteLine(" ");

                Console.SetCursorPosition(PreviousPosition.Y + 3, PreviousPosition.X + 2);

                Console.WriteLine("   ");

                Console.SetCursorPosition(PreviousPosition.Y, PreviousPosition.X + 3);

                Console.WriteLine("         ");

                Console.SetCursorPosition(PreviousPosition.Y, PreviousPosition.X + 4);

                Console.WriteLine("         ");
            }


        }

        public override void DrawShip()
        {

            Console.SetCursorPosition(Position.Y + 4, Position.X);

            Console.WriteLine(@"^");

            Console.SetCursorPosition(Position.Y + 4, Position.X + 1);
            Console.WriteLine("o");

            Console.SetCursorPosition(Position.Y + 3, Position.X + 2);

            Console.WriteLine(@"|o|");

            Console.SetCursorPosition(Position.Y, Position.X + 3);

            Console.WriteLine(@"/\\\o///\");

            Console.SetCursorPosition(Position.Y, Position.X + 4);

            Console.WriteLine(@"  </o\>  ");
        }

        public override bool InBounds(Position nextDirection)
        {
            Position currPosition = this.Position;

            var nextPosition = new Position
                (currPosition.X + nextDirection.X, currPosition.Y + nextDirection.Y);

            if (nextPosition.X >= Console.BufferHeight || nextPosition.Y >= Console.BufferHeight ||
                nextPosition.X < 0 || nextPosition.Y < 0)
            {
                return false;
            }

            this.PreviousPosition = this.Position;
            this.Position = nextPosition;

            return true;
        }

        public void DrawBullets()
        {
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                Console.SetCursorPosition(this.Bullets[i].Position.Y, this.Bullets[i].Position.X);
                Console.WriteLine("^");
            }
        }

        public void UpdateBullets()
        {
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                Bullet currentBullet = this.Bullets[i];
                currentBullet.UpdatePosition();
               // if(currentBullet.Position.X == 0)
               // {
               //     this.Bullets.RemoveAt(i);
               //     i--;
               // }

            }

        }

        public void ClearBullets()
        {
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                Bullet currentBullet = this.Bullets[i];
                if(currentBullet.PreviousPosition != null)
                {
                    Console.SetCursorPosition(currentBullet.PreviousPosition.Y, currentBullet.PreviousPosition.X);
                    Console.WriteLine(" ");
                }

            }
        }

        public override void UpdateShip()
        {
            throw new NotImplementedException();
        }
    }
}
