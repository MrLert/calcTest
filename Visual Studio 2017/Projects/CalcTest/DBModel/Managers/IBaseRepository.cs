using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalcNew.Managers
{
    /// <summary>
    /// Базовый интерфейс хранилища данных
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        T Load(int id);

        void Save(T entity);

        void Update(T entity);

        IEnumerable<T> GetAll();
    }
}
