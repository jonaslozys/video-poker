using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class Dealer
    {
        private Card[] playerHand;
        private CardDeck cardDeck;
        private HandEvaluator handEvaluator;
        public int playerMoney { get; protected set; }

        public Dealer()
        {
            playerHand = new Card[5];
            cardDeck = new CardDeck();
            handEvaluator = new HandEvaluator();
            playerMoney = 100;
        }

        public void Deal()
        {
            playerMoney -= 1;
            cardDeck.SetupDeck();
            GetHand();
            DisplayCards();

        }

        // Leave user selected cards, replace others with new ones from deck
        public void Draw(List<int> cardsToHold)
        {
            int deckIndex = 5;

            for (int index = 1; index <= 5; index++)
            {
                if (!cardsToHold.Contains(index)) {
                    playerHand[index - 1] = cardDeck.getDeck[deckIndex];
                    deckIndex++;
                }
            }
            DisplayCards();
            SortHand();
            EvaluateCombination();
        }


        private void GetHand()
        {
            for (int index = 0; index < 5; index++)
            {
                playerHand[index] = cardDeck.getDeck[index];
            }
        }

        private void SortHand()
        {
            var sortQuery = from hand in playerHand orderby hand.CardValue select hand;

            var index = 0;
            foreach (var element in sortQuery.ToList())
            {
                playerHand[index] = element;
                index++;
            }
        }

        private void DisplayCards()
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            foreach (Card card in playerHand)
            {
                HandDisplay.DrawCardOutline(x, y);
                HandDisplay.DrawSuitAndValue(card, x, y);
                x++;
            }

            Console.SetCursorPosition(0, y += 12);

        }

        private void EvaluateCombination()
        {
            var hand = handEvaluator.Evaluate(playerHand);

            Console.WriteLine(hand.ToString());
            playerMoney += (int)hand;
            Console.WriteLine(playerMoney);
            
        }


    }
}
