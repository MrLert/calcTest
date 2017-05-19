using System.Data.Entity;
using WebCalcNew.Managers;

namespace WebCalcNew.Helpers
{
    public class UserContext : DbContext
    {
        public UserContext() : base("EFConnection")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}