using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Queen : Pieces
    {
        public override PieceType Type => PieceType.Queen;
        public override Player Color { get; }

        private static readonly Direction[] dirs =
        {
            Direction.North, Direction.South, Direction.East, Direction.West,
            Direction.NorthEast, Direction.NorthWest, Direction.SouthEast, Direction.SouthWest
        };

        public Queen(Player color)
        {
            Color = color;
        }

        public override Pieces Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionInDirs(from, board, dirs).Select(to => new Move(from, to));
        }
    }
}
