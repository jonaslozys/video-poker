using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class Dealer
    {
        public Card[] playerHand;
        public CardDeck cardDeck;

        public Dealer()
        {
            playerHand = new Card[5];
            cardDeck = new CardDeck();
        }

        public void Deal()
        {
            cardDeck.SetupDeck();
            GetHand();
            DisplayCards();

        }

        public void Draw(List<int> cardsToHold)
        {
            int deckIndex = 5;

            for (int index = 1; index <= 5; index++)
            {
                if (cardsToHold.Contains(index)) {
                    playerHand[index - 1] = cardDeck.getDeck[deckIndex];
                    deckIndex++;
                }
            }

            DisplayCards();
        }


        private void GetHand()
        {
            for (int index = 0; index < 5; index++)
            {
                playerHand[index] = cardDeck.getDeck[index];
            }
        }

        private void DisplayCards()
        {
            foreach (Card card in playerHand)
            {
                Console.WriteLine($"{card.CardSuit} {card.CardValue}");
            }
        }


    }
}
