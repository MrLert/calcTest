using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebCalcNew.Helpers;

namespace WebCalcNew.Managers
{
    public class EFOperResultRepository :IOperationResultRepository
    {
        public OperationResult Load(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(OperationResult entity)
        {
            using (var context = new OperationResultContext())
            {
                context.OperationResults.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(OperationResult entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OperationResult> GetAll()
        {
            using (var context = new OperationResultContext())
            {
                return context.OperationResults.ToList();
            }
        }
    }
}