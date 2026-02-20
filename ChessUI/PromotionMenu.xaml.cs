using System;
using System.Windows.Controls;
using ChessLogic;

namespace ChessUI
{
    public partial class PromotionMenu : UserControl
    {
        public event Action<PieceType> PieceSelected;
        private readonly Player player;

        public PromotionMenu(Player player)
        {
            InitializeComponent();
            this.player = player;
            QueenImage.Source = Images.GetImage(player, PieceType.Queen);
            RookImage.Source = Images.GetImage(player, PieceType.Rook);
            BishopImage.Source = Images.GetImage(player, PieceType.Bishop);
            KnightImage.Source = Images.GetImage(player, PieceType.Knight);
        }

        private void QueenButton_Click(object sender, System.Windows.RoutedEventArgs e) => PieceSelected?.Invoke(PieceType.Queen);
        private void RookButton_Click(object sender, System.Windows.RoutedEventArgs e) => PieceSelected?.Invoke(PieceType.Rook);
        private void BishopButton_Click(object sender, System.Windows.RoutedEventArgs e) => PieceSelected?.Invoke(PieceType.Bishop);
        private void KnightButton_Click(object sender, System.Windows.RoutedEventArgs e) => PieceSelected?.Invoke(PieceType.Knight);
    }
}
