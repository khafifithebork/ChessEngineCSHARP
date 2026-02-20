namespace ChessLogic
{
    public class PawnPromotionMove : Move
    {
        private readonly PieceType newType;

        public PawnPromotionMove(Position from, Position to, PieceType newType = PieceType.Queen)
            : base(from, to, MoveType.PawnPromotion)
        {
            this.newType = newType;
        }

        public override void Execute(Board board)
        {
            Player color = board[FromPos].Color;
            base.Execute(board);
            board[ToPos] = newType switch
            {
                PieceType.Queen => new Queen(color),
                PieceType.Rook => new Rook(color),
                PieceType.Bishop => new Bishop(color),
                PieceType.Knight => new Knight(color),
                _ => new Queen(color)
            };
            board[ToPos].HasMoved = true;
        }
    }
}
