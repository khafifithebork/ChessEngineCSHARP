using System;
using System.Windows;
using System.Windows.Input;

namespace ChessUI
{
    public static class ChessCursors
    {
        public static readonly Cursor WhiteCursor = LoadCursor("assets/CursorW.cur");
        public static readonly Cursor BlackCursor = LoadCursor("assets/CursorB.cur");

        private static Cursor LoadCursor(string filePath)
        {
            Uri uri = new Uri(filePath, UriKind.Relative);
            var stream = Application.GetResourceStream(uri)?.Stream;
            if (stream == null) return Cursors.Arrow;
            return new Cursor(stream);
        }
    }
}
