using System;
using System.Drawing;

namespace snakegame
{
    public class food
    {
        private Point rand_food;
        private int MAXH, MAXW;

        public food(int MAXH, int MAXW)
        {
           this.MAXH = MAXH;
           this.MAXW = MAXW;
        }

        public void genFood()
        {
            Random randnum = new Random();
            rand_food.X = randnum.Next(MAXW - 2);
            rand_food.Y = randnum.Next(1, MAXH - 1);
            //Console.WriteLine(rand_food);
        }

        public bool samePoint(List<Point> snake_body)
        {
            foreach (var item in snake_body)
            {
                if (item.X == rand_food.X && item.Y == rand_food.Y)
                    return true;

            }
            return false;
        }

        public Point getFood() { return rand_food; }
    }
}

