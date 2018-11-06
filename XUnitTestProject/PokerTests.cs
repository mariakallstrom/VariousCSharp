using CodeWars;
using System;
using System.Collections.Generic;
using Xunit;
using static CodeWars.PokerHand;

namespace XUnitTestProject
{
    public class PokerTests
    {
        [Fact]
        public void GetRankType_Test()
        {
            var hand = "2C 3C AC 4C 5C";
            var list = new List<RankType>();

            foreach (var item in hand.Split(' '))
            {
                list.Add(GetRankType(item[0]));
            }
            var expected = new List<RankType>() { RankType.Two, RankType.Three, RankType.Ace, RankType.Four, RankType.Five };
            Assert.Equal(expected, list);
         }

        [Fact]
        public void GetSuitType_Test()
        {
            var hand = "2C 3C AC 4C 5C";
            var list = new List<SuitType>();

            foreach (var item in hand.Split(' '))
            {
                list.Add(GetSuitType(item[1]));
            }
            var expected = new List<SuitType>() { SuitType.Clubs, SuitType.Clubs, SuitType.Clubs, SuitType.Clubs, SuitType.Clubs };
            Assert.Equal(expected, list);
        }

   

        [Fact]
        public void IsStraight_AceIsOne_Test()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.Ace, Suit = SuitType.Clubs},
                    new Card{Rank = RankType.Two, Suit = SuitType.Hearts},
                        new Card{Rank = RankType.Four, Suit = SuitType.Clubs},
                            new Card{Rank = RankType.Three, Suit = SuitType.Clubs},
                                new Card{Rank = RankType.Five, Suit = SuitType.Diamonds},
            };
     
            var handType = GetHandType(list);

            Assert.Equal(HandType.Straight, handType);
        }

        [Fact]
        public void IsStraight_AceIsFourteen_Test()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.Ace, Suit = SuitType.Clubs},
                    new Card{Rank = RankType.King, Suit = SuitType.Hearts},
                        new Card{Rank = RankType.Queen, Suit = SuitType.Clubs},
                            new Card{Rank = RankType.Jack, Suit = SuitType.Clubs},
                                new Card{Rank = RankType.Ten, Suit = SuitType.Diamonds},
            };

            var handType = GetHandType(list);

            Assert.Equal(HandType.Straight, handType);
        }

        [Fact]
        public void IsStraightFlush_Test()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.Five, Suit = SuitType.Clubs},
                    new Card{Rank = RankType.Three, Suit = SuitType.Clubs},
                        new Card{Rank = RankType.Four, Suit = SuitType.Clubs},
                            new Card{Rank = RankType.Two, Suit = SuitType.Clubs},
                                new Card{Rank = RankType.Six, Suit = SuitType.Clubs},
            };

            var handType = GetHandType(list);

            Assert.Equal(HandType.StraightFlush, handType);
        }


        [Fact]
        public void IsStraightFlush_AceIsOneTest()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.Ace, Suit = SuitType.Clubs},
                    new Card{Rank = RankType.Three, Suit = SuitType.Clubs},
                        new Card{Rank = RankType.Four, Suit = SuitType.Clubs},
                            new Card{Rank = RankType.Two, Suit = SuitType.Clubs},
                                new Card{Rank = RankType.Five, Suit = SuitType.Clubs},
            };

            var handType = GetHandType(list);

            Assert.Equal(HandType.StraightFlush, handType);
        }

        [Fact]
        public void IsRoyalFlush_Test()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.Ace, Suit = SuitType.Clubs},
                    new Card{Rank = RankType.King, Suit = SuitType.Clubs},
                        new Card{Rank = RankType.Queen, Suit = SuitType.Clubs},
                            new Card{Rank = RankType.Jack, Suit = SuitType.Clubs},
                                new Card{Rank = RankType.Ten, Suit = SuitType.Clubs},
            };

            var handType = GetHandType(list);

            Assert.Equal(HandType.RoyalFlush, handType);
        }

        [Fact]
        public void FourOfAKind_Test()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.King, Suit = SuitType.Clubs},
                    new Card{Rank = RankType.King, Suit = SuitType.Hearts},
                        new Card{Rank = RankType.King, Suit = SuitType.Diamonds},
                            new Card{Rank = RankType.King, Suit = SuitType.Spades},
                                new Card{Rank = RankType.Ten, Suit = SuitType.Clubs},
            };

            var handType = GetHandType(list);

            Assert.Equal(HandType.FourOfAKind, handType);
        }

        [Fact]
        public void ThreeOfAKind_Test()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.King, Suit = SuitType.Clubs},
                    new Card{Rank = RankType.King, Suit = SuitType.Hearts},
                        new Card{Rank = RankType.King, Suit = SuitType.Diamonds},
                            new Card{Rank = RankType.Six, Suit = SuitType.Spades},
                                new Card{Rank = RankType.Ten, Suit = SuitType.Clubs},
            };

            var handType = GetHandType(list);

            Assert.Equal(HandType.ThreeOfAKind, handType);
        }

        [Fact]
        public void FullHouse_Test()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.King, Suit = SuitType.Clubs},
                    new Card{Rank = RankType.King, Suit = SuitType.Hearts},
                        new Card{Rank = RankType.King, Suit = SuitType.Diamonds},
                            new Card{Rank = RankType.Ten, Suit = SuitType.Spades},
                                new Card{Rank = RankType.Ten, Suit = SuitType.Clubs},
            };

            var handType = GetHandType(list);

            Assert.Equal(HandType.FullHouse, handType);
        }


        [Fact]
        public void CheckNumberOfGroups_Test()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.King, Suit = SuitType.Clubs},
                    new Card{Rank = RankType.King, Suit = SuitType.Hearts},
                        new Card{Rank = RankType.King, Suit = SuitType.Diamonds},
                            new Card{Rank = RankType.Ten, Suit = SuitType.Spades},
                                new Card{Rank = RankType.Ten, Suit = SuitType.Clubs},
            };


            var count = CheckNumberOfGroups(list);
            Assert.Equal(2, count.Item1);
        }

        [Fact]
        public void IsHighCard_Test()
        {

            var list = new List<Card>() {
                new Card{Rank = RankType.King, Suit = SuitType.Spades},
                    new Card{Rank = RankType.Two, Suit = SuitType.Hearts},
                        new Card{Rank = RankType.Five, Suit = SuitType.Clubs},
                            new Card{Rank = RankType.Jack, Suit = SuitType.Diamonds},
                                new Card{Rank = RankType.Ten, Suit = SuitType.Diamonds},
            };

            var handType = GetHandType(list);

            Assert.Equal(HandType.HighCard, handType);
        }
    }
}
