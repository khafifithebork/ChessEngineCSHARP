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

    }
}
