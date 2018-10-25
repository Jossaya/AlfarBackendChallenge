using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfarBackendChallenge.EF.Models;

namespace AlfarBackendChallenge.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer GetByID(Guid id);
        Customer InsertCustomer(Customer newCustomer);
        Customer UpdateCustomer(Customer updatedCustomer);
        Customer DeleteCustomer(Customer deletedCustomer);
    }
}
