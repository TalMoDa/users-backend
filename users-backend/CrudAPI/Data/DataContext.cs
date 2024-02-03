using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Data
{
    // Created the database context to have a connection using EF and sql db.
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
    }
}
