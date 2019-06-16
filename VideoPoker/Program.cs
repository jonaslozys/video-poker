using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class Program
    {
        // Parse user input to only accept numbers in range [1 -5]
        public static List<int> ParseInput(string inputString)
        {
            List<int> selectedCards = new List<int>();

            foreach(char character in inputString)
            {
                int cardNumber = (int)Char.GetNumericValue(character);

                if (cardNumber > 0 && cardNumber < 6 && !selectedCards.Contains(cardNumber))
                {
                    selectedCards.Add(cardNumber);
                }
            }

            return selectedCards;
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetWindowSize(64, 40);
            Console.BufferWidth = 64;
            Console.BufferHeight = 40;
            Console.Title = "Video Poker";
          
            Dealer dealer = new Dealer();

            bool play = true;

            while (play)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 1);

                dealer.Deal();
                Console.WriteLine("Enter number(s) of cards to hold. (1 - 5)");

                List<int> cardNumbers = ParseInput(Console.ReadLine());

                dealer.Draw(cardNumbers);

                Console.WriteLine("\n\n\nPress q to exit, any other key to play another hand.");
                char quit = Console.ReadKey().KeyChar;
                if(quit == 'q')
                {
                    play = false;

                } else if (dealer.playerMoney < 1)
                {
                    Console.WriteLine("Game over, you have ran out of money");
                    System.Threading.Thread.Sleep(3000);
                    play = false;
                }

            }
        }
    }
}
