using System;
using System.Drawing;
using static System.Formats.Asn1.AsnWriter;

namespace snakegame
{

    public class board
    {
        private int MAXW = 20, MAXH = 10;
        public int x1, x2, y1, y2, getGrow;
        //bool isAte = false;
        public List<Point> snake_body = new();

        public board(int MAXH, int MAXW)
        {
            this.MAXH = MAXH;
            this.MAXW = MAXW;
        }

        public void background(int score2)
        {
            Console.Write("SCORE:");
            for (int i = 0; i < MAXH; i++)
            {
                if (i == 1) Console.Write(score2);
                Console.Write("\t\t*");
                for (int j = 0; j < (MAXW - 2); j++)
                {
                    if (i == 0 || i == (MAXH - 1))
                        Console.Write("*");
                    else if (i == y1 && j == x1)
                        Console.Write("@");
                    else if (i == y2 && j == x2)
                        Console.Write("P");
                    else
                    {
                        bool isBodyPart = false;
                        for (int k = 0; k < snake_body.Count(); k++)
                        {
                            if (i == snake_body[k].Y && j == snake_body[k].X)
                            {
                                Console.Write("o");
                                isBodyPart = true;
                            }
                        }
                        if (!isBodyPart)
                            Console.Write(" ");
                    }

                }
                Console.Write("*\n");
            }

        }

    }
}