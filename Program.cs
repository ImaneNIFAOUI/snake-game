using System;
using System.Threading;
using System.Drawing;

namespace snakegame;

class game
{
      static void Main(string[] args )
      {
        int MAXH = 10, MAXW = 20, score1=0;
        TimeSpan time_pose = new TimeSpan(0,0,0,0,300);

        board board1 = new board(MAXH, MAXW);
        snake snake1 = new snake(new Point(2, 3), 1, MAXH, MAXW);
        food food1 = new food(MAXH, MAXW);

        Point snake_pos = snake1.get_pos();
        food1.genFood();
        Point food_pos = food1.getFood();
        char inSnake;
        bool gameover = false, ifAte = false;
        List<Point> snake_body = new();
        

        while (gameover == false)
        {
            ifAte = snake1.food_ate(food_pos);
            
            if (ifAte)
            {
                score1++;
                food1.genFood(); // Get new food.
                while (food1.samePoint(snake_body))
                    food1.genFood();

                food_pos = food1.getFood(); // Get new food position
            }

            board1.x1 = snake_pos.X;
            board1.y1 = snake_pos.Y;
            board1.x2 = food_pos.X;
            board1.y2 = food_pos.Y;
            board1.snake_body = snake1.get_body();
            board1.getGrow = snake1.get_len();

            board1.background(score1);
            
            if (Console.KeyAvailable)
            {
                inSnake = Console.ReadKey().KeyChar;
                // Console.WriteLine("\nYou have input:{0}", inSnake);
                switch (inSnake)
                {
                    case 'a': snake1.change_dir('l'); break;
                    case 'd': snake1.change_dir('r'); break;
                    case 'w': snake1.change_dir('u'); break;
                    case 's': snake1.change_dir('d'); break;
                }
            }

            snake1.move_snake();
            snake_pos = snake1.get_pos();
            snake_body = snake1.get_body();

            gameover = snake1.snake_collided();
            Thread.Sleep(time_pose);

            Console.Clear();
            //Console.SetCursorPosition(0, 0);
        }

        /*
        if (gameover)
        {
            Console.WriteLine("**GAMEOVER**");
            Console.WriteLine(score1);
        }
        */
      }

}


