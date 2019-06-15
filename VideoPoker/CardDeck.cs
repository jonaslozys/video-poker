using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class CardDeck : Card
    {
        private const int NUM_OF_CARDS = 52; // Number of cards in typical card deck
        public Card[] deck;

        public CardDeck()
        {
            deck = new Card[NUM_OF_CARDS];
        }

        public Card[] getDeck { get { return deck; } }

        public void SetupDeck()
        {
            int index = 0;

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    deck[index] = new Card
                    {
                        CardSuit = suit,
                        CardValue = value
                    };

                    index++;
                }
            }

            ShuffleCards();
        }

        private void ShuffleCards()
        {
            Random random = new Random();
            Card temporary;

            for (int shuffleTimes = 0; shuffleTimes < 100; shuffleTimes++)
            {
                for (int index = 0; index < NUM_OF_CARDS; index++)
                {
                    int secondCardIndex = random.Next(51);
                    temporary = deck[index];
                    deck[index] = deck[secondCardIndex];
                    deck[secondCardIndex] = temporary;
                }
            }
        }
    }
}
