namespace ChessLogic
{
    public class DoublePawnMove : Move
    {
        public DoublePawnMove(Position from, Position to)
            : base(from, to, MoveType.DoublePawn)
        {
        }
    }
}
