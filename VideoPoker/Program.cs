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
            Dealer dealer = new Dealer();

            while (true)
            {
                dealer.Deal();

                Console.WriteLine("Enter number(s) of cards to hold. (1 - 5)");
                string selectedCards = Console.ReadLine();

                List<int> cardNumbers = ParseInput(selectedCards);

                dealer.Draw(cardNumbers);

                Console.WriteLine("\nPlay again \n");

            }
        }
    }
}
