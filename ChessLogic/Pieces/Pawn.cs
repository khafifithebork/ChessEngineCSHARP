using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Pawn : Pieces
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        public Pawn(Player color)
        {
            Color=color;
        }

        public override Pieces Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

    }
}
