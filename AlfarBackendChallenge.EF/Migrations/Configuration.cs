using AlfarBackendChallenge.EF.Models;
using System;

namespace AlfarBackendChallenge.EF.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AlfarBackendChallenge.EF.AlfarBackendChallengeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AlfarBackendChallenge.EF.AlfarBackendChallengeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
               context.Database.ExecuteSqlCommand("DELETE FROM [AlfarBackendChallengeDB].[dbo].[Customers]");
            context.Database.ExecuteSqlCommand("DELETE FROM [AlfarBackendChallengeDB].[dbo].[Addresses]");
            context.Database.ExecuteSqlCommand("DROP PROCEDURE GetAllAddresses;");
            context.Addresses.AddOrUpdate(
              new Address { Id = Guid.NewGuid(),Name="John Stored Procedure", Line1 = "+254724117222", Line2 = "+254724117222", City = "Boise", Region = "Idaho", PostalCode = "83757", Country = "United States", CreationTimeStamp = DateTime.Now },
             new Address { Id = Guid.NewGuid(), Name="John ASP.NET MVC + C#", Line1 = "+254724117222", Line2 = "+254724117222", City = "Indianapolis", Region = "Indiana", PostalCode = "46207", Country = "United States", CreationTimeStamp = DateTime.Now },
             new Address { Id = Guid.NewGuid(), Name="John MVC", Line1 = "+254724117222", Line2 = "+254724117222", City = "Jamaica", Region = "New York", PostalCode = "11480", Country = "United States", CreationTimeStamp = DateTime.Now },
             new Address { Id = Guid.NewGuid(), Name="John Web API ", Line1 = "+254724117222", Line2 = "+254724117222", City = "San Diego", Region = "California", PostalCode = "92153", Country = "United States", CreationTimeStamp = DateTime.Now }
            );

            string sp_GetAllAddresses = @"CREATE PROCEDURE GetAllAddresses
                                            AS
                                            BEGIN
	                                            -- SET NOCOUNT ON added to prevent extra result sets from
	                                            -- interfering with SELECT statements.
	                                            SET NOCOUNT ON;

                                                -- Insert statements for procedure here
	                                            SELECT [Id],[Name], [Line1]
                                                  ,[Line2]
                                                  ,[City]
                                                  ,[Region]
                                                  ,[PostalCode]
                                                  ,[Country]
                                                  ,[CreationTimeStamp]
                                                  ,[LastModificationTimeStamp]
	                                               FROM [AlfarBackendChallengeDB].[dbo].[Addresses] 
                                            END";
            context.Database.ExecuteSqlCommand(sp_GetAllAddresses);

        }
    }
}
