using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class HandDisplay
    {
        public static void DrawCardOutline(int x,  int y)
        {
            x *= 10;

            Console.SetCursorPosition(x, y);

            for(int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + i);

                if(i == 0 || i == 9)
                {
                    Console.WriteLine(" -------- ");
                } else
                {
                    Console.WriteLine("|        |");
                }
            }
        }
    }
}
