using System;
using System.Windows.Controls;
using ChessLogic;

namespace ChessUI
{
    public enum Option { Restart, Exit }

    public partial class GameOverMenu : UserControl
    {
        public event Action<Option> OptionSelected;

        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();
            Result result = gameState.Result;

            if (result.Winner == Player.White)
            {
                ResultText.Text = "WHITE WINS!";
                ResultText.Foreground = System.Windows.Media.Brushes.White;
            }
            else if (result.Winner == Player.Black)
            {
                ResultText.Text = "BLACK WINS!";
                ResultText.Foreground = System.Windows.Media.Brushes.Gray;
            }
            else
            {
                ResultText.Text = "DRAW!";
                ResultText.Foreground = System.Windows.Media.Brushes.Yellow;
            }

            ReasonText.Text = result.Reason switch
            {
                EndReason.Checkmate => "by Checkmate",
                EndReason.Stalemate => "by Stalemate",
                EndReason.FiftyMoveRule => "by Fifty Move Rule",
                EndReason.InsufficientMaterial => "by Insufficient Material",
                EndReason.ThreefoldRepetition => "by Threefold Repetition",
                _ => ""
            };
        }

        private void Restart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
