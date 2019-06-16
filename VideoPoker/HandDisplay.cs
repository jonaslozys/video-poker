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
            x *= 12;

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Black;


            for (int i = 0; i < 10; i++)
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

        public static void DrawSuitAndValue(Card card, int x, int y)
        {
            x *= 12;
            char cardSuit = ' ';

            switch(card.CardSuit)
            {
                case Card.Suit.CLUBS:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;

                case Card.Suit.SPADES:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;

                case Card.Suit.HEARTS:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.Suit.DIAMONDS:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.SetCursorPosition(x += 2, y += 2);
            Console.Write(cardSuit);

            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(x += 2, y += 6);
            Console.Write(card.CardValue);

        }
    }
}
