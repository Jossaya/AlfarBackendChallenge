using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfarBackendChallenge.EF.Models;

namespace AlfarBackendChallenge.Services.Interfaces
{
    public interface IAddressService
    {
        Address GetByID(Guid id);
        IList<Address> GetAll();
        Address InsertAddress(Address newAddress);
        Address UpdateAddress(Address updatedAddress);
        Address DeleteAddress(Address deletedAddress);
    }
}
