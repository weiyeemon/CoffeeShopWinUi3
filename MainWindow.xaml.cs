using CoffeeShopWinUi3.Data;
using CoffeeShopWinUi3.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CoffeeShopWinUi3
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            this.InitializeComponent();
            Title = "Customer App";
            ViewModel = viewModel;
            root.Loaded += Root_Loaded;
        }

        public MainViewModel ViewModel { get; }
        private async void Root_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadAsync();
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

        private void BtnToggle_Click(object sender, RoutedEventArgs e)
        {
            root.RequestedTheme = root.RequestedTheme == ElementTheme.Dark ?
                ElementTheme.Light : ElementTheme.Dark;
        }
    }
}
