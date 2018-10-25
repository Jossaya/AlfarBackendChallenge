using AlfarBackendChallenge.DataAccess;
using AlfarBackendChallenge.DataAccess.Interface;
using AlfarBackendChallenge.EF;
using AlfarBackendChallenge.EF.Models;
using AlfarBackendChallenge.Services.Interfaces;
using System;
using System.Linq;

namespace AlfarBackendChallenge.Services
{
    
      /// <summary>
    /// Customer CRUD Operations
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        public CustomerService() => _repository = new Repository<Customer>(new AlfarBackendChallengeDbContext());
        public Customer GetByID(Guid id)
        {
            try
            {
                return _repository.List()
                    .FirstOrDefault(s => s.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public Customer InsertCustomer(Customer newCustomer)
        {
            try
            {
                return _repository.Insert(newCustomer);

            }
            catch (Exception ex)
            {


                throw new Exception(ex.ToString());

            }
        }

        public Customer UpdateCustomer(Customer updatedCustomer)
        {
            try
            {
                return _repository.Update(updatedCustomer);

            }
            catch (Exception ex)
            {


                throw new Exception(ex.ToString());

            }
        }

        public Customer DeleteCustomer(Customer deletedCustomer)
        {
            try
            {
                return _repository.Delete(deletedCustomer);

            }
            catch (Exception ex)
            {


                throw new Exception(ex.ToString());

            }
        }
    }
}
