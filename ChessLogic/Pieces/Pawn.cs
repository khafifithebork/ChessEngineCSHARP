using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Pawn : Pieces
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        private readonly Direction forward;

        public Pawn(Player color)
        {
            Color = color;
            forward = (color == Player.White) ? Direction.North : Direction.South;
        }

        public override Pieces Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMoves(from, board).Concat(DiagonalMoves(from, board));
        }

        private IEnumerable<Move> ForwardMoves(Position from, Board board)
        {
            Position oneStep = from + forward;
            if (Board.IsInside(oneStep) && board.IsEmpty(oneStep))
            {
                if (CanPromote(oneStep))
                {
                    foreach (Move m in PromotionMoves(from, oneStep))
                        yield return m;
                }
                else
                {
                    yield return new Move(from, oneStep);
                }

                Position twoStep = oneStep + forward;
                if (!HasMoved && Board.IsInside(twoStep) && board.IsEmpty(twoStep))
                {
                    yield return new DoublePawnMove(from, twoStep);
                }
            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new[] { forward + Direction.West, forward + Direction.East })
            {
                Position to = from + dir;
                if (!Board.IsInside(to)) continue;

                if (!board.IsEmpty(to) && board[to].Color != Color)
                {
                    if (CanPromote(to))
                    {
                        foreach (Move m in PromotionMoves(from, to))
                            yield return m;
                    }
                    else
                    {
                        yield return new Move(from, to);
                    }
                }
                else if (board.IsEmpty(to) && board.EnPassantSkipPos == to)
                {
                    Position capturePos = to + (Color == Player.White ? Direction.South : Direction.North);
                    yield return new EnPassantMove(from, to, capturePos);
                }
            }
        }

        private bool CanPromote(Position pos)
        {
            return (Color == Player.White && pos.Row == 0) || (Color == Player.Black && pos.Row == 7);
        }

        private IEnumerable<Move> PromotionMoves(Position from, Position to)
        {
            yield return new PawnPromotionMove(from, to, PieceType.Queen);
            yield return new PawnPromotionMove(from, to, PieceType.Rook);
            yield return new PawnPromotionMove(from, to, PieceType.Bishop);
            yield return new PawnPromotionMove(from, to, PieceType.Knight);
        }
    }
}
