using CoffeeShopWinUi3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopWinUi3.Data
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>?> GetAllAsync();
    }
    public class CustomerDataProvider : ICustomerDataProvider
    {
        public async Task<IEnumerable<Customer>?> GetAllAsync()
        {
            await Task.Delay(100);
            return new List<Customer>
            {
                new Customer{Id = 1, FirstName = "Julia", LastName="Robert", IsDeveloper=true},
                new Customer{Id = 2, FirstName = "Helena", LastName="Choi"},
                new Customer{Id = 3, FirstName = "Gera", LastName="Wai", IsDeveloper=true},
                new Customer{Id = 4, FirstName = "Anne", LastName="HalfWay", IsDeveloper=true},
                new Customer{Id = 4, FirstName = "Rosennie", LastName="Park"},

            };
        }
    }
}
