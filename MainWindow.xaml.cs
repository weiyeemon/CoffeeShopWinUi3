using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CoffeeShopWinUi3
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void BtnMoveNavigation(object sender, RoutedEventArgs e)
        {
            //int col = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            int col = Grid.GetColumn(customerListGrid);
            int moveCol = col == 0 ? 2 : 0;
            //customerListGrid.SetValue(Grid.ColumnProperty, moveCol);
            Grid.SetColumn(customerListGrid, moveCol);
            symbolIconMove.Symbol = moveCol == 0 ? Symbol.Forward : Symbol.Back;
        }
    }
}
