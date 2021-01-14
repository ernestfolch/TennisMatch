namespace TennisMatch
{
    public class Match
    {
        private string Player1Name { get; set; }
        private string Player2Name { get; set; }

        public Match(string player1Name, string player2Name)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
        }

        public string GetPlayer1Name()
        {
            return Player1Name;
        }

        public string GetPlayer2Name()
        {
            return Player2Name;
        }
    }
}
