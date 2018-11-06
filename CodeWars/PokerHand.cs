using System;
using System.Collections.Generic;
using System.Linq;
using static CodeWars.PokerHand;

namespace CodeWars
{
    public class PokerHand : IComparable<PokerHand>
    {
        public List<Card> Cards { get;  set; }
        public HandType Hand { get; set; }

        public enum RankType : int
        {
            Two = 2, Three, Four, Five, Six,
            Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
        }

        public enum SuitType : int { Clubs, Diamonds, Hearts, Spades }

        public enum HandType : int
        {
            RoyalFlush, StraightFlush, FourOfAKind,
            FullHouse, Flush, Straight, ThreeOfAKind, TwoPairs, OnePair, HighCard
        }

        public struct Card
        {
            public Card(RankType rank, SuitType suit) : this()
            { Rank = rank; Suit = suit; }

            public RankType Rank { get;  set; }
            public SuitType Suit { get;  set; }
            public HandType Hand { get; set; }
        }

        public PokerHand(string hand)
        {
            var list = new List<Card>();
            foreach (var item in hand.Split(' '))
            {
                var x = GetRankType(item[0]);
                var y = GetSuitType(item[1]);
                var c = new Card();
                c.Rank = x;
                c.Suit = y;
                list.Add(c);
               
            }
            
            Cards = list;
            Hand = GetHandType(Cards);
            Sort();

         }
  
        public  void Sort()
        {
            Cards = Cards.OrderBy(c => c.Rank)
           .OrderBy(c => Cards.Where(c1 => c1.Rank == c.Rank).Count()).ToList();

            if (Cards[4].Rank == RankType.Ace && Cards[0].Rank == RankType.Two
             && (int)Cards[3].Rank - (int)Cards[0].Rank == 3)
                Cards = new List<Card> { Cards[4], Cards[0], Cards[1], Cards[2], Cards[3] };
           
        }

        public int CompareTo(PokerHand other)
        {
             var rank1 = this.Hand; 
             var  rank2 = other.Hand;
                if(rank1 == rank2)
                    {
                         var highestHand = CheckHighestCard(this, other);
                         if (other == highestHand) return 1;
                         else return -1;
                     }
                if (rank1 > rank2) return 1;
                if (rank1 < rank2) return -1;
            
            return 0;
        }

        private static PokerHand CheckHighestCard(PokerHand hand1, PokerHand hand2)
        {
            var hand1Ace = hand1.Cards.Any(x => x.Rank == RankType.Ace);
            var hand2Ace = hand2.Cards.Any(x => x.Rank == RankType.Ace);
          
            if(hand1Ace && hand2Ace || hand1.Hand == HandType.Straight || hand1.Hand == HandType.StraightFlush)
            {
                var h1 = hand1.Cards.Where(x => x.Rank != RankType.Ace).Select(x=>x.Rank).Max();
                var h2 = hand2.Cards.Where(x => x.Rank != RankType.Ace).Select(x => x.Rank).Max();
                return (h1 > h2) ? hand1 : hand2; 
            }
            else if(hand1Ace && !hand2Ace)
            {
                return hand1;
            }
            else if(!hand1Ace && hand2Ace)
            {
                return hand2;
            }
            else
            {
                var h1 = hand1.Cards.Select(x => x.Rank).Max();
                var h2 = hand2.Cards.Select(x => x.Rank).Max();
                return (h1 > h2) ? hand1 : hand2;
            }
        }

        public static HandType GetHandType(List<Card> cards)
        {
            var count = CheckNumberOfGroups(cards);
            if(count.Item1 == 5)
            {
                if(IsRoyalFlush(cards)){ return HandType.RoyalFlush; }
                if (IsStraightFlush(cards)) { return HandType.StraightFlush; }
                if (IsStraight(cards)) { return HandType.Straight; }
                if (IsFlush(cards)) { return HandType.Flush; }
                else { return HandType.HighCard; }
            }
            if(count.Item1 == 4) { return HandType.OnePair;  } 
            if(count.Item1 == 3 && count.Item2 == 3) { return HandType.ThreeOfAKind; }
            if (count.Item1 == 3 && count.Item2 != 3) { return HandType.TwoPairs; }
            if (count.Item1 == 2 && count.Item2 != 4) { return HandType.FullHouse; }
            if (count.Item1 == 2 && count.Item2 == 4) { return HandType.FourOfAKind; }

            return HandType.HighCard;
        }
        private static bool IsRoyalFlush(List<Card> cards)
        {
            if (IsStraightFlush(cards) && (cards.Any(x => x.Rank == RankType.Ace)) && (cards.Any(x => x.Rank == RankType.King)))
            {
                return true;
            }
            else return false;
        }

        private static bool IsStraightFlush(List<Card> cards)
        {
            if (IsFlush(cards) && IsStraight(cards))
            { return true; }
            else return false;
            
        }
        
        private static bool IsFlush(List<Card> cards)
        {
            var allClubs = cards.All(x => (x.Suit == SuitType.Clubs));
            var allDiamonds = cards.All(x => (x.Suit == SuitType.Diamonds));
            var allHearts = cards.All(x => (x.Suit == SuitType.Hearts));
            var allSpades = cards.All(x => (x.Suit == SuitType.Spades));

            if (allClubs || allDiamonds || allHearts || allSpades)
            {
                return true;
            }
            else return false;
        }

        private static bool IsStraight(List<Card> cards)
        {
            var c = SortByRank(cards).Select(x=>x.Rank).ToList();

            if(c.Contains(RankType.Ace) && c.Contains(RankType.King))
            {
                if ((c[3] == c[4] - 1) && (c[2] == c[3] - 1) && (c[2] == c[1] - 1))
                {
                    return true;
                }
            }
            else if(c.Contains(RankType.Ace) && c.Contains(RankType.Two))
            {
                if ((c[2] == c[1] + 1) && (c[3] == c[2] + 1) && (c[4] == c[3] + 1))
                {
                    return true;
                }
            }
            else if ((c[1] == c[0] + 1) && (c[2] == c[1] + 1) && (c[3] == c[2] + 1) && (c[4] == c[3] + 1))
            {
                return true;
            }
          

            return false;
        }

        private static List<Card>  SortByRank(List<Card> list)
        {
            list = list.OrderBy(c => c.Rank)
           .OrderBy(c => list.Where(c1 => c1.Rank == c.Rank).Count()).ToList();

            if (list[4].Rank == RankType.Ace && list[0].Rank == RankType.Two
             && (int)list[3].Rank - (int)list[0].Rank == 3)
                return new List<Card> { list[4], list[0], list[1], list[2], list[3] };
            else return list;
        }

        private static bool HighCard(List<Card> cards)
        {
            if (CheckNumberOfGroups(cards).Item1 == 5 && !(IsStraight(cards)) && !(IsFlush(cards)))
            {
                return true;
            }
            else { return false; }
        }

        public static Tuple<int, int> CheckNumberOfGroups(List<Card> cards)
        {
            var count = from card in cards
                        group card by card.Rank into groupedCards
                        select new { Card = groupedCards.Key, Count = groupedCards.Count() };
            var max = count.Select(x => x.Count).Max();

            return Tuple.Create(count.Count(), max );
        }

        public static SuitType GetSuitType(char v)
        {
            switch (v)
            {
                case 'S':
                    return SuitType.Spades;
                case 'H':
                    return SuitType.Hearts;
                case 'D':
                    return SuitType.Diamonds;
                case 'C':
                    return SuitType.Clubs;
                default:
                    return 0;
            }
        }
        public static RankType GetRankType(char v)
        {

            switch (v)
            {
                case '2':
                    return RankType.Two;
                case '3':
                    return RankType.Three;
                case '4':
                    return RankType.Four;
                case '5':
                    return RankType.Five;
                case '6':
                    return RankType.Six;
                case '7':
                    return RankType.Seven;
                case '8':
                    return RankType.Eight;
                case '9':
                    return RankType.Nine;
                case 'T':
                    return RankType.Ten;
                case 'J':
                    return RankType.Jack; ;
                case 'Q':
                    return RankType.Queen;
                case 'K':
                    return RankType.King; ;
                case 'A':
                    return RankType.Ace; ;
                default:
                    return 0;
            }
        }

      
    }

  
}
