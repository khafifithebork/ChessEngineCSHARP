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

    }
}