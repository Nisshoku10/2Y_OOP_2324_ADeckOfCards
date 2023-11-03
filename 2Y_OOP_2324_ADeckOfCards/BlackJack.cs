using System;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class BlackJack
    {
        private DeckOfCards doc;
        private GameState gs;
        private int round = 1;
        public BlackJack()
        {
            doc = new DeckOfCards(true);
            gs = new GameState();

            MainGame();
        }

        private void MainGame()
        {
            InitialCards();
            PlayerTurn();

            gs.DisplayGameState();

            if (gs.isBlackJack())
            {
                gs.DecideWinner();
                Console.WriteLine($"Blackjack! {gs.Winner} wins!");
            }
            else
            {
                while (!gs.isGameOver())
                {
                    gs.ComputerTurn();
                }
            }

            Console.Clear();
            gs.DisplayGameState();
            string winner = gs.DecideWinner();
            Console.WriteLine($"The winner is: {winner}");
        }
        private void InitialCards()
        {
            gs.PlayerHand.Add(doc.drawACard());
            gs.PlayerHand.Add(doc.drawACard());

            gs.ComputerHand.Add(doc.drawACard());
            gs.ComputerHand.Add(doc.drawACard());
        }
        private void PlayerTurn()
        {
            Console.WriteLine("Player's Turn");

            gs.DisplayGameState();

            while (gs.GetPlayerChoice() == 'H')
            {
                gs.PlayerHand.Add(doc.drawACard());
                gs.DisplayGameState();
                if (gs.PlayerBusts())
                {
                    Console.WriteLine("Player busts!");
                    break;
                }
            }
        }

    }
}