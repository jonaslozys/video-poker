using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class Program
    {
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
                int[] cardNumbers = ParseInput(selectedCards).ToArray();
                foreach(int number in cardNumbers)
                {
                    Console.WriteLine($"Holding {number}");

                }

            }


            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
