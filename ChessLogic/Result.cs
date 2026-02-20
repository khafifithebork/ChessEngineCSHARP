namespace ChessLogic
{
    public class Result
    {
        public Player Winner { get; }
        public EndReason Reason { get; }

        private Result(Player winner, EndReason reason)
        {
            Winner = winner;
            Reason = reason;
        }

        public static Result Win(Player winner, EndReason reason)
        {
            return new Result(winner, reason);
        }

        public static Result Draw(EndReason reason)
        {
            return new Result(Player.None, reason);
        }
    }
}
