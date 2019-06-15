using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class HandEvaluator
    {
        public enum Hand
        {
            RoyalFlush,
            StraightFlush,
            FourOfAKind,
            FullHouse,
            Flush,
            Straight,
            ThreeOfAKind,
            TwoPair,
            JacksOrBetter,
            None
        }

        public Hand Evaluate(Card[] playerHand)
        {
            if (RoyalFlush(playerHand))
            {
                return Hand.RoyalFlush;
            }
            else return Hand.None;
        }

        private bool RoyalFlush(Card[] playerHand)
        {
            bool positive = true;

            for (int index = 0; index < 4; index++)
            {
                if (playerHand[index].CardSuit != playerHand[index + 1].CardSuit)
                {
                    positive = false;
                }
                
            }

            if (positive)
            {
                foreach (Card card in playerHand)
                {
                    Console.WriteLine($"THIS {card.CardSuit} {card.CardValue}");
                }
            }
            return positive;
        }
    }
}
