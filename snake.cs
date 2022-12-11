using System;
using System.Drawing;

namespace snakegame
{
    public class snake
    {
        private Point pos;
        private int len, vel, MAXH, MAXW;
        private bool isAte = false;
        private char direction;
        public List<Point> snake_body = new();

        public snake(Point pos, int vel, int MAXH, int MAXW)
        {
            this.pos = pos;
            this.vel = vel;
            len = 0;
            this.MAXH = MAXH;
            this.MAXW = MAXW;
            direction = 'r';
        }

        // Change the direction 
        public void change_dir(char dir)
        {
            direction = dir;
        }

        // Move the snake
        public void move_snake()
        {
            snakeBody();
            switch (direction )
            {
                case 'u':pos.Y = pos.Y  - vel;break;
                case 'd':pos.Y = pos.Y  + vel;break;
                case 'l':pos.X = pos.X  - vel;break;
                case 'r':pos.X = pos.X  + vel;break;
            }

            positionADJ_X();
            positionADJ_Y();
            //Console.WriteLine(pos);
        }

        public Point get_pos() { return pos; }

        public bool food_ate(Point food_pos) 
        {
            if (pos.X == food_pos.X && pos.Y == food_pos.Y)
            {
                len++;
                isAte = true;
                return true;
            }
            else
            {
                isAte = false;
                return false;
            }
        }

        public int get_len(){ return len; }
        public List<Point> get_body() { return snake_body; }

        private void snakeBody()
        {
            snake_body.Add(pos);
            if (!isAte)
            {
                snake_body.RemoveAt(0);
            }

            /* Write the body coordination
            var report = new System.Text.StringBuilder();
            foreach (var item in snake_body)
            {
                report.AppendLine(item.ToString());
            }
            Console.WriteLine(report);
            */
        }

        public bool snake_collided()
        {
            foreach (var item in snake_body)
            {
                if (item.X == pos.X && item.Y == pos.Y)
                    //return true;
                    throw new InvalidOperationException("GAME OVER");
            }
            return false;
        }

        private void positionADJ_X()
        {
            pos.X = (pos.X + MAXW-2) % (MAXW - 2);
        }
        private void positionADJ_Y()
        {
            if (pos.Y == (MAXH-1))
            { pos.Y = 1; }
            else if (pos.Y == 0)
            { pos.Y = MAXH -2; }
            else { pos.Y = pos.Y % (MAXH - 1); }
        }

    }
}

