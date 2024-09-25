using book_loan.modals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace book_loan.Data
{
    public class AppDBContext: DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base (options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<authors> authors { get; set; }

        public DbSet<library> library { get; set; }

        public DbSet<publisher> publisher { get; set; }












    }


}


