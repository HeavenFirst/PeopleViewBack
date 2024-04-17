using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PeopleViewBack.Models;

namespace PeopleViewBack.Data
{
    public class PeopleViewContext : DbContext
    {

        public PeopleViewContext(DbContextOptions<PeopleViewContext> options)
            : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();
                    }
                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                //handling exseption
            }

        }

        public DbSet<User> Users { get; set; }
    }
}
