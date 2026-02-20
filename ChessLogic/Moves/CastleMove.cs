namespace ChessLogic
{
    public class CastleMove : Move
    {
        private readonly Position rookFromPos;
        private readonly Position rookToPos;

        public CastleMove(MoveType type, Position kingFrom, Position kingTo, Position rookFrom, Position rookTo)
            : base(kingFrom, kingTo, type)
        {
            rookFromPos = rookFrom;
            rookToPos = rookTo;
        }

        public override void Execute(Board board)
        {
            base.Execute(board);
            board[rookToPos] = board[rookFromPos];
            board[rookFromPos] = null;
            board[rookToPos].HasMoved = true;
        }
    }
}
