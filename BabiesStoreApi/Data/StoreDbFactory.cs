using Microsoft.EntityFrameworkCore;

namespace BabiesStoreApi.Data
{
    public class StoreDbFactory
    {
        private const string ConnectionString = "Server=localhost;Database=BabiesStoreDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public static StoreContextDB CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContextDB>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new StoreContextDB(optionsBuilder.Options);
        }
    }
}
