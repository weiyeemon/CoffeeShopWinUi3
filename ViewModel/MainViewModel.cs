﻿using CoffeeShopWinUi3.Command;
using CoffeeShopWinUi3.Data;
using CoffeeShopWinUi3.Model;
using System;
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
            AddCommand = new DelegateCommand(Add);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }
        
        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }
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
                    DeleteCommand.RaiseCanExecuteChange();
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

        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }
        private void Delete(object? parameter)
        {
            if(SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer=null;
            }
        }
        private bool CanDelete(object? parameter) => SelectedCustomer is not null;

    }
}
