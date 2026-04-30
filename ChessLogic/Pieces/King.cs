using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class King : Pieces
    {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }

        private static readonly Direction[] dirs =
        {
            Direction.North, Direction.South, Direction.East, Direction.West,
            Direction.NorthEast, Direction.NorthWest, Direction.SouthEast, Direction.SouthWest
        };

        public King(Player color)
        {
            Color = color;
        }

        public override Pieces Copy()
        {
            King copy = new King(Color);
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

            if (!HasMoved)
            {
                foreach (Move castleMove in CastleMoves(from, board))
                {
                    yield return castleMove;
                }
            }
        }

        private IEnumerable<Move> CastleMoves(Position kingPos, Board board)
        {
            // Kingside castling
            Position ksRookPos = new Position(kingPos.Row, 7);
            if (board[ksRookPos] is Rook ksRook && !ksRook.HasMoved)
            {
                if (board.IsEmpty(new Position(kingPos.Row, 5)) && board.IsEmpty(new Position(kingPos.Row, 6)))
                {
                    yield return new CastleMove(MoveType.CastleKS, kingPos,
                        new Position(kingPos.Row, 6),
                        ksRookPos,
                        new Position(kingPos.Row, 5));
                }
            }

            // Queenside castling
            Position qsRookPos = new Position(kingPos.Row, 0);
            if (board[qsRookPos] is Rook qsRook && !qsRook.HasMoved)
            {
                if (board.IsEmpty(new Position(kingPos.Row, 1)) &&
                    board.IsEmpty(new Position(kingPos.Row, 2)) &&
                    board.IsEmpty(new Position(kingPos.Row, 3)))
                {
                    yield return new CastleMove(MoveType.CastleQS, kingPos,
                        new Position(kingPos.Row, 2),
                        qsRookPos,
                        new Position(kingPos.Row, 3));
                }
            }
        }
    }
}