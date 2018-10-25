using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using AlfarBackendChallenge.EF.Models;

namespace AlfarBackendChallenge.EF
{
  public  class AlfarBackendChallengeDbContext:DbContext
    {

        public AlfarBackendChallengeDbContext() : base("name=AlfarBackendChallengeDbConnectionString")
        {
            Database.SetInitializer<AlfarBackendChallengeDbContext>(
                new CreateDatabaseIfNotExists<AlfarBackendChallengeDbContext>());
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
