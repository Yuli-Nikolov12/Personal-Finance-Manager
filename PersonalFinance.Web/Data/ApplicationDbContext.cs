using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {}
    }
}
