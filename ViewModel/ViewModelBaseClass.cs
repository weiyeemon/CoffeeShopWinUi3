using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoffeeShopWinUi3.ViewModel
{
    public class ViewModelBaseClass :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void RaisedPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
