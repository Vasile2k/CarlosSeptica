namespace CarlosSeptica
{
    public class GameState : Clonable
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

        public Player CurrentTurn
        {
            get;
            set;
        }

        public GameState()
        {
            PlayerHuman = new Player(PlayerType.PLAYER_HUMAN);
            PlayerAI = new Player(PlayerType.PLAYER_AI);
            Dealer = new CardDealer();
            Table = new GameTable();
        }

        private GameState(Player human, Player ai, CardDealer dealer, GameTable table, Player currentTurn)
        {
            PlayerHuman = human;
            PlayerAI = ai;
            Dealer = dealer;
            Table = table;
            CurrentTurn = currentTurn;
        }

        public Clonable Clone()
        {
            Player humanClone = (Player)PlayerHuman.Clone();
            Player aiClone = (Player)PlayerAI.Clone();

            CardDealer dealerClone = (CardDealer)Dealer.Clone();

            GameTable tableClone = (GameTable)Table.Clone();

            // Remember to set references
            tableClone.HandOwner = (Table.HandOwner.Type == PlayerType.PLAYER_AI) ? aiClone : humanClone;
            Player currentTurnReferenceClone = (CurrentTurn.Type == PlayerType.PLAYER_AI) ? aiClone : humanClone;

            return new GameState(humanClone, aiClone, dealerClone, tableClone, currentTurnReferenceClone);
        }
    }
}
