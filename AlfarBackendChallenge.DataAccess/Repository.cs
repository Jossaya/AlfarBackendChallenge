using AlfarBackendChallenge.DataAccess.Interface;
using AlfarBackendChallenge.EF;
using AlfarBackendChallenge.EF.Models;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;

namespace AlfarBackendChallenge.DataAccess
{
    public class Repository<T> : IRepository<T>, IDisposable where T : BaseEntity
    {
        private const string ExceptionMessage = "Alfar Backend Challenge DbContext CANNOT BE NULL";
        private readonly AlfarBackendChallengeDbContext _alfarBackendChallengeDbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AlfarBackendChallengeDbContext alfarBackendChallengeDbContext)
        {
            try
            {
                _alfarBackendChallengeDbContext = alfarBackendChallengeDbContext ?? throw new ArgumentNullException(ExceptionMessage);
                _dbSet = _alfarBackendChallengeDbContext.Set<T>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public AlfarBackendChallengeDbContext GetDBContext()
        {
            throw new NotImplementedException();
        }
        public T Insert(T newEntity)
        {
            try
            {
                DbEntityEntry dbEntityEntry = _alfarBackendChallengeDbContext.Entry(newEntity);
                if (dbEntityEntry.State != EntityState.Detached)
                {
                    dbEntityEntry.State = EntityState.Added;
                }
                else
                {

                    _dbSet.Add(newEntity);

                }
                _alfarBackendChallengeDbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        var message = string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);


                    }
                }
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {


                throw new Exception(ex.ToString());

            }

            return newEntity;

        }

        public IQueryable<T> List()
        {
            try
            {
                return _dbSet.AsQueryable();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DbDataReader List(SqlCommand sqlCommand)
        {
            try
            {
                _alfarBackendChallengeDbContext.Database.Connection.Open();

                sqlCommand.Connection = (SqlConnection)_alfarBackendChallengeDbContext.Database.Connection;
                sqlCommand.CommandTimeout = _alfarBackendChallengeDbContext.Database.Connection.ConnectionTimeout;
                return sqlCommand.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public T Update(T updatedEntity)
        {

            try
            {
                using (var transaction = _alfarBackendChallengeDbContext.Database.BeginTransaction())
                {
                    try
                    {

                        var originalEntity = _dbSet.Where(
                                original => original.Id == updatedEntity.Id)
                                .AsQueryable()
                                .FirstOrDefault();

                        if (originalEntity != null)
                        {

                            _alfarBackendChallengeDbContext.Entry(originalEntity).CurrentValues.SetValues(updatedEntity);
                            _alfarBackendChallengeDbContext.SaveChanges();

                            //commit transaction
                            transaction.Commit();

                            return updatedEntity;
                        }

                        return null;


                    }
                    catch (Exception ex)
                    {
                        //Rollback transaction if exception occurs
                        transaction.Rollback();
                        throw new Exception(ex.ToString());
                    }

                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        var message = string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);


                    }
                }
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {


                throw new Exception(ex.ToString());

            }
        }
        public T Delete(T deletedEntity)
        {
            try
            {
                using (var transaction = _alfarBackendChallengeDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var originalEntity = _dbSet.Where(
                                original => original.Id == deletedEntity.Id)
                            .AsQueryable()
                            .FirstOrDefault();

                        if (originalEntity != null)
                        {

                            _dbSet.Remove(originalEntity);
                            _alfarBackendChallengeDbContext.SaveChanges();
                            transaction.Commit();

                            return deletedEntity;
                        }
                        return null;


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.ToString());
                    }

                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        var message = string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);


                    }
                }
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_alfarBackendChallengeDbContext != null)
                    {
                        _alfarBackendChallengeDbContext.Dispose();
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
