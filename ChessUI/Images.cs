using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLogic;

namespace ChessUI
{
    public static class Images
    {
        private static readonly Dictionary<PieceType, ImageSource> whiteSources = new()
        {
            { PieceType.Pawn, LoadImage("assets/PawnW.png") },
            { PieceType.Bishop, LoadImage("assets/BishopW.png") },
            { PieceType.Knight, LoadImage("assets/KnightW.png") },
            { PieceType.Rook, LoadImage("assets/RookW.png") },
            { PieceType.Queen, LoadImage("assets/QueenW.png") },
            { PieceType.King, LoadImage("assets/KingW.png") }
        };

        private static readonly Dictionary<PieceType, ImageSource> blackSources = new()
        {
            { PieceType.Pawn, LoadImage("assets/PawnB.png") },
            { PieceType.Bishop, LoadImage("assets/BishopB.png") },
            { PieceType.Knight, LoadImage("assets/KnightB.png") },
            { PieceType.Rook, LoadImage("assets/RookB.png") },
            { PieceType.Queen, LoadImage("assets/QueenB.png") },
            { PieceType.King, LoadImage("assets/KingB.png") }
        };

        public static ImageSource GetImage(Player color, PieceType type)
        {
            return color == Player.White ? whiteSources[type] : blackSources[type];
        }

        public static ImageSource GetImage(Pieces piece)
        {
            if (piece == null) return null;
            return GetImage(piece.Color, piece.Type);
        }

        private static ImageSource LoadImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.Relative));
        }
    }
}
