namespace ChessLogic
{
    public class Move
    {
        public MoveType Type { get; }
        public Position FromPos { get; }
        public Position ToPos { get; }

        public Move(Position from, Position to, MoveType type = MoveType.Normal)
        {
            FromPos = from;
            ToPos = to;
            Type = type;
        }

        public virtual void Execute(Board board)
        {
            board[ToPos] = board[FromPos];
            board[FromPos] = null;
            board[ToPos].HasMoved = true;
        }
    }
}
