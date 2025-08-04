using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Application.Context
{
    public class TodoDBContextFactory : IDesignTimeDbContextFactory<TodoDBContext>
    {
        public TodoDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoDBContext>();
            var connectionString = Environment.GetEnvironmentVariable("TodoDBConnectionString");
            if (connectionString != null)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
