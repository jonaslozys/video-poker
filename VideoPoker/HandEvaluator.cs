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
            None = 0,
            JacksOrBetter = 1,
            TwoPair = 2,
            ThreeOfAKind = 3,
            Straight = 4,
            Flush = 6,
            FullHouse = 9,
            FourOfAKind = 25,
            StraightFlush = 50,
            RoyalFlush = 800,
        }

        // The player's hand is sorted by value
        public Hand Evaluate(Card[] playerHand)
        {
            if (RoyalFlush(playerHand))
            {
                return Hand.RoyalFlush;
            }
            else if (StraightFlush(playerHand))
            {
                return Hand.StraightFlush;
            }
            else if (FourOfAKind(playerHand))
            {
                return Hand.FourOfAKind;
            }
            else if (FullHouse(playerHand))
            {
                return Hand.FullHouse;
            }
            else if (Flush(playerHand))
            {
                return Hand.Flush;
            }
            else if (Straight(playerHand))
            {
                return Hand.Straight;
            }
            else if (ThreeOfAKind(playerHand))
            {
                return Hand.ThreeOfAKind;
            }
            else if (TwoPair(playerHand))
            {
                return Hand.TwoPair;
            }
            else if (JacksOrBetter(playerHand))
            {
                return Hand.JacksOrBetter;
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

                if ((int)playerHand[index].CardValue < 10)
                {
                    positive = false;
                }

                if ((int)playerHand[index].CardValue + 1 != (int)playerHand[index + 1].CardValue)
                {
                    positive = false;
                }
            }

            return positive;
        }

        private bool StraightFlush(Card[] playerHand)
        {
            bool positive = true;

            for (int index = 0; index < 4; index++)
            {
                if (playerHand[index].CardSuit != playerHand[index + 1].CardSuit)
                {
                    positive = false;
                }

                if ((int)playerHand[index].CardValue + 1 != (int)playerHand[index + 1].CardValue)
                {
                    positive = false;
                }
            }

            return positive;
        }

        private bool FourOfAKind(Card[] playerHand)
        {
            bool positive = false;

            if (playerHand[0].CardValue == playerHand[1].CardValue && playerHand[0].CardValue == playerHand[2].CardValue && playerHand[0].CardValue == playerHand[3].CardValue)
            {
                positive = true;
            }
            else if (playerHand[1].CardValue == playerHand[2].CardValue && playerHand[1].CardValue == playerHand[3].CardValue && playerHand[1].CardValue == playerHand[4].CardValue)
            {
                positive = true;
            }

            return positive;
        }

        private bool FullHouse(Card[] playerHand)
        {
            bool positive = false;

            if (playerHand[0].CardValue == playerHand[1].CardValue && playerHand[2].CardValue == playerHand[3].CardValue && playerHand[3].CardValue == playerHand[4].CardValue)
            {
                positive = true;
            }
            else if (playerHand[0].CardValue == playerHand[1].CardValue && playerHand[1].CardValue == playerHand[2].CardValue && playerHand[3].CardValue == playerHand[4].CardValue)
            {
                positive = true;
            }

            return positive;
        }

        private bool Flush(Card[] playerHand)
        {
            bool positive = true;

            for (int index = 0; index < 4; index++)
            {
                if (playerHand[index].CardSuit != playerHand[index + 1].CardSuit)
                {
                    positive = false;
                }
            }

            return positive;
        }

        private bool Straight(Card[] playerHand)
        {
            bool positive = true;

            for (int index = 0; index < 4; index++)
            {
                if ((int)playerHand[index].CardValue + 1 != (int)playerHand[index + 1].CardValue)
                {
                    positive = false;
                }
            }

            return positive;
        }

        private bool ThreeOfAKind(Card[] playerHand)
        {
            bool positive = false;

            if (playerHand[0].CardValue == playerHand[1].CardValue && playerHand[1].CardValue == playerHand[2].CardValue)
            {
                positive = true;

            }
            else if (playerHand[1].CardValue == playerHand[2].CardValue && playerHand[2].CardValue == playerHand[3].CardValue)
            {
                positive = true;
            }
            else if (playerHand[2].CardValue == playerHand[3].CardValue && playerHand[3].CardValue == playerHand[4].CardValue)
            {
                positive = true;
            }

            return positive;
        }

        private bool TwoPair(Card[] playerHand)
        {
            bool positive = false;

            if (playerHand[0].CardValue == playerHand[1].CardValue && playerHand[2].CardValue == playerHand[3].CardValue)
            {
                positive = true;

            }
            else if (playerHand[1].CardValue == playerHand[2].CardValue && playerHand[3].CardValue == playerHand[4].CardValue)
            {
                positive = true;
            }
            else if (playerHand[0].CardValue == playerHand[1].CardValue && playerHand[3].CardValue == playerHand[4].CardValue)
            {
                positive = true;
            }

            return positive;
        }

        private bool JacksOrBetter(Card[] playerHand)
        {
            bool positive = false;

            if (playerHand[0].CardValue == playerHand[1].CardValue && (int)playerHand[0].CardValue > 10)
            {
                positive = true;

            }
            else if (playerHand[1].CardValue == playerHand[2].CardValue && (int)playerHand[1].CardValue > 10)
            {
                positive = true;
            }
            else if (playerHand[2].CardValue == playerHand[3].CardValue && (int)playerHand[2].CardValue > 10)
            {
                positive = true;
            }
            else if (playerHand[3].CardValue == playerHand[4].CardValue && (int)playerHand[3].CardValue > 10)
            {
                positive = true;
            }

            return positive;
        }


    }
}
