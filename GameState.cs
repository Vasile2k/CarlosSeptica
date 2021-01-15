namespace CarlosSeptica
{
    public class GameState
    {
        public Player PlayerHuman
        {
            get;
        }

        public Player PlayerAI
        {
            get;
        }

        public CardDealer Dealer
        {
            get;
        }

        public GameTable Table
        {
            get;
        }

        public GameState()
        {
            PlayerHuman = new Player(PlayerType.PLAYER_HUMAN);
            PlayerAI = new Player(PlayerType.PLAYER_AI);
            Dealer = new CardDealer();
            Table = new GameTable();
        }
    }
}
