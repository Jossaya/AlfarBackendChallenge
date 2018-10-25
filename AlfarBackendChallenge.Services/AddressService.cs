using AlfarBackendChallenge.DataAccess;
using AlfarBackendChallenge.DataAccess.Interface;
using AlfarBackendChallenge.EF;
using AlfarBackendChallenge.EF.Models;
using AlfarBackendChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AlfarBackendChallenge.Services
{
    
      /// <summary>
    /// Address CRUD Operations
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _repository;

        public AddressService() => _repository = new Repository<Address>(new AlfarBackendChallengeDbContext());

        public Address GetByID(Guid id)
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
        public IList<Address> GetAll()
        {
            try
            {
                const string storedProcedureToExecute = "dbo.GetAllAddresses";

                var sqlCommand = new SqlCommand(storedProcedureToExecute);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                return GetRecordsFromDB(sqlCommand);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public Address InsertAddress(Address newAddress)
        {
            try
            {
                return _repository.Insert(newAddress);

            }
            catch (Exception ex)
            {


                throw new Exception(ex.ToString());

            }
        }

        public Address UpdateAddress(Address updatedAddress)
        {
            try
            {
                return _repository.Update(updatedAddress);

            }
            catch (Exception ex)
            {


                throw new Exception(ex.ToString());

            }
        }

        public Address DeleteAddress(Address deletedAddress)
        {
            try
            {
                return _repository.Delete(deletedAddress);

            }
            catch (Exception ex)
            {


                throw new Exception(ex.ToString());

            }
        }
        private List<Address> GetRecordsFromDB(SqlCommand sqlCommand)
        {
            try
            {


                var recordsFromDB = _repository.List(sqlCommand);

                var listOfT = new List<Address>();

                while (recordsFromDB.Read())
                {

                    var reportModel = new Address();
                    //extract columns in the records returned
                    for (int i = 0; i < recordsFromDB.FieldCount; i++)
                    {
                        var propertyInfo = reportModel.GetType().GetProperty(recordsFromDB.GetName(i));

                        if (propertyInfo != null)
                        {
                            if (recordsFromDB.GetValue(i) != DBNull.Value)
                            {
                                propertyInfo.SetValue(reportModel, Convert.ChangeType(recordsFromDB.GetValue(i), propertyInfo.PropertyType), null);
                            }
                        }


                    }
                    listOfT.Add(reportModel);
                }

                if (!listOfT.Any())
                {
                    listOfT.Add(new Address());
                }


                return listOfT;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }



    }
}
