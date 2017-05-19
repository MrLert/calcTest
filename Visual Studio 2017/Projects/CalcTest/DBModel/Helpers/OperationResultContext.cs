using System.Data.Entity;
using WebCalcNew.Managers;

namespace WebCalcNew.Helpers
{
    public class OperationResultContext : DbContext
    {
        public OperationResultContext() : base("EFConnection")
        {
            
        }
        public DbSet<OperationResult> OperationResults { get; set; }
    }
}