using bill.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace bill.Dynamic
{

    public class BillPrintDbContext : DbContext
    {
        public BillPrintDbContext(DbContextOptions<BillPrintDbContext> options)
            : base(options)
        {
        }

        public DbSet<ItemNameModel> ItemNames { get; set; }
        public DbSet<CalculateBillModel> CalculateBills { get; set; }
    }
}
