using System.Collections.Generic;
using System.Linq;

namespace ChessLogic
{
    public class GameState
    {
        public Board Board { get; }
        public Player CurrentPlayer { get; private set; }
        public Result Result { get; private set; } = null;

        public GameState(Player player, Board board)
        {
            CurrentPlayer = player;
            Board = board;
        }

        public IEnumerable<Move> LegalMovesForPiece(Position pos)
        {
            if (Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer)
                return Enumerable.Empty<Move>();

            Pieces piece = Board[pos];
            IEnumerable<Move> moveCandidates = piece.GetMoves(pos, Board);
            return moveCandidates.Where(move => move.ToPos != null && IsLegalMove(move));
        }

        public void MakeMove(Move move)
        {
            Board.EnPassantSkipPos = null;
            move.Execute(Board);

            if (move.Type == MoveType.DoublePawn)
            {
                int skipRow = (move.FromPos.Row + move.ToPos.Row) / 2;
                Board.EnPassantSkipPos = new Position(skipRow, move.FromPos.Column);
            }

            CurrentPlayer = CurrentPlayer.Opponent();
            CheckForGameOver();
        }

        public bool IsGameOver()
        {
            return Result != null;
        }

        private bool IsLegalMove(Move move)
        {
            if (MoveCausesCheck(move)) return false;

            if (move.Type == MoveType.CastleKS || move.Type == MoveType.CastleQS)
            {
                if (Board.IsInCheck(CurrentPlayer)) return false;

                int colDir = move.Type == MoveType.CastleKS ? 1 : -1;
                Position intermediate = new Position(move.FromPos.Row, move.FromPos.Column + colDir);
                Board copy = Board.Copy();
                copy[intermediate] = copy[move.FromPos];
                copy[move.FromPos] = null;
                if (copy.IsInCheck(CurrentPlayer)) return false;
            }

            return true;
        }

        private bool MoveCausesCheck(Move move)
        {
            Board copy = Board.Copy();
            move.Execute(copy);
            return copy.IsInCheck(CurrentPlayer);
        }

        private void CheckForGameOver()
        {
            if (!HasAnyLegalMoves(CurrentPlayer))
            {
                if (Board.IsInCheck(CurrentPlayer))
                {
                    Result = Result.Win(CurrentPlayer.Opponent(), EndReason.Checkmate);
                }
                else
                {
                    Result = Result.Draw(EndReason.Stalemate);
                }
            }
        }

        private bool HasAnyLegalMoves(Player player)
        {
            return Board.PiecePositionsFor(player).Any(pos =>
                Board[pos].GetMoves(pos, Board).Any(move => move.ToPos != null && IsLegalMove(move)));
        }

        public IEnumerable<Move> AllLegalMoves(Player player)
        {
            return Board.PiecePositionsFor(player).SelectMany(pos =>
                Board[pos].GetMoves(pos, Board).Where(move => move.ToPos != null && IsLegalMove(move)));
        }
    }
}
