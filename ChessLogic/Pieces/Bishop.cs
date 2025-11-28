using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Bishop : Pieces
    {
        public override PieceType Type => PieceType.Bishop;
        public override Player Color { get; }

        public Bishop(Player color)
        {
            Color = color;
        }

        public override Pieces Copy()
        {
            Bishop copy = new Bishop(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

    }
}