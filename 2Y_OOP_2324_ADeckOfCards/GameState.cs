using System;
using System.Collections.Generic;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class GameState
    {
        private Card card;
        public List<Card> PlayerHand;
        public List<Card> ComputerHand;
        public string Winner = "";
        private char PlayerChoice = ' ';
        private DeckOfCards doc;

        public GameState()
        {
            PlayerHand = new List<Card>();
            ComputerHand = new List<Card>();
        }
        public int PlayerScore()
        {
            int score = 0;
            foreach (Card card in PlayerHand)
            {
                score += card.GetCardValue();
            }

            while (score > 21)
            {
                break;
            }
            return score;
        }
        public int ComputerScore()
        {
            int score = 0;
            foreach (Card card in ComputerHand)
            {
                score += card.GetCardValue();
            }

            while (score > 21)
            {
                break;
            }
            return score;
        }
        public bool PlayerBusts()
        {
            return PlayerScore() > 21;
        }
        public bool ComputerBusts()
        {
            return ComputerScore() > 21;
        }
        public bool isBlackJack()
        {
            return PlayerScore() == 21 || ComputerScore() == 21;
        }
        
        /// <summary>
        /// Displays current scores of player and computer
        /// </summary>
        public void DisplayGameState()
        {
            Console.WriteLine($"Player score: {PlayerScore()}");

            Card firstComputerCard = ComputerHand[0];
            Console.WriteLine($"Computer first card value: {firstComputerCard.GetCardValue()}");
        }


        /// <summary>
        /// Gets player choice for Hit or Pass
        /// </summary>
        /// <returns>user choice</returns>
        public char GetPlayerChoice()
        {
            Console.WriteLine("\nDo you want to Hit(H) or Pass(P)?");
            Console.Write("Your choice [H/P]: ");
            PlayerChoice = char.Parse(Console.ReadLine().ToUpper());
            ValidateUserChoice(PlayerChoice);

            Console.Clear();
            return PlayerChoice;
        }

        private char ValidateUserChoice(char uInput)
        {
            Console.Clear();
            if (uInput != 'H' && uInput != 'P')
            {
                Console.WriteLine("Choice must only be H for hit and P for pass!");
                Console.WriteLine($"Do you want to Hit or Pass?");
                Console.WriteLine("Your choice [H/P]: ");
                return GetPlayerChoice();
            }
            return uInput;
        }


        /// <summary>
        /// Compares player and cpu scores
        /// </summary>
        /// <returns>Winner</returns>
        public string DecideWinner()
        {
            if (PlayerBusts())
            {
                Winner = "Player";
            }
            else if (ComputerBusts())
            {
                Winner = "Computer";
            }
            else
            {
                if (PlayerScore() > ComputerScore())
                {
                    Winner = "Player";
                }
                else if (PlayerScore() < ComputerScore())
                {
                    Winner = "Computer";
                }
                else
                {
                    Winner = "Tie";
                }
            }

            return Winner;
        }

        public void ComputerTurn()
        {
            while (ComputerScore() < 17)
            {
                ComputerHand.Add(doc.drawACard());
            }
        }

        public bool isGameOver()
        {
            while (PlayerBusts() || ComputerBusts())
            {
                break;
            }

            if (ifPlayerHits() && ifComputerHits())
            {
                return true;
            }

            return false;
        }

        public bool ifPlayerHits()
        {
            return PlayerChoice == 'P';
        }

        public bool ifComputerHits()
        {
            return ComputerScore() >= 17;
        }

    }
}