using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Knight : Pieces
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }

        private static readonly Direction[] dirs =
        {
            new Direction(-2, -1), new Direction(-2, 1),
            new Direction(-1, -2), new Direction(-1, 2),
            new Direction(1, -2), new Direction(1, 2),
            new Direction(2, -1), new Direction(2, 1)
        };

        public Knight(Player color)
        {
            Color = color;
        }

        public override Pieces Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Direction dir in dirs)
            {
                Position to = from + dir;
                if (Board.IsInside(to) && (board.IsEmpty(to) || board[to].Color != Color))
                {
                    yield return new Move(from, to);
                }
            }
        }
    }
}
