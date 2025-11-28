using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Rook : Pieces
    {
        public override PieceType Type => PieceType.Rook;
        public override Player Color { get; }

        public Rook(Player color)
        {
            Color = color;
        }

        public override Pieces Copy()
        {
            Rook copy = new Rook(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

    }
}
