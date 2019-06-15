using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class Card
    {
        public enum Suit
        {
            HERTS,
            SPADES,
            DIAMONDS,
            CLUBS
        }

        public enum Value
        {
            TWO = 2,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING,
            ACE
        }

        public Suit CardSuit { get; set; }
        public Value CardValue { get; set; }
    }
}
