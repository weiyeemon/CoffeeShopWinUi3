using CoffeeShopWinUi3.Data;
using CoffeeShopWinUi3.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopWinUi3.ViewModel
{
    public class MainViewModel : ViewModelBaseClass
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;

        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    RaisedPropertyChanged();
                    RaisedPropertyChanged(nameof(IsCustomerSelected));
                }
            }
        }
        public bool IsCustomerSelected => SelectedCustomer is not null;


        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));

                }
            }
        }
    }
}
