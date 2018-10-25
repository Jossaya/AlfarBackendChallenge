using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfarBackendChallenge.EF;
using AlfarBackendChallenge.EF.Models;

namespace AlfarBackendChallenge.DataAccess.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        AlfarBackendChallengeDbContext GetDBContext();

        IQueryable<T> List();

        DbDataReader List(SqlCommand sqlCommand);
        
        T Insert(T newEntity);
        T Update(T updatedEntity);
        T Delete(T deletedEntity);

    } 
}
