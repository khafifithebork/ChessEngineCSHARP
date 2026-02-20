namespace ChessLogic
{
    public class EnPassantMove : Move
    {
        private readonly Position capturePos;

        public EnPassantMove(Position from, Position to, Position capturePos)
            : base(from, to, MoveType.EnPassant)
        {
            this.capturePos = capturePos;
        }

        public override void Execute(Board board)
        {
            base.Execute(board);
            board[capturePos] = null;
        }
    }
}
