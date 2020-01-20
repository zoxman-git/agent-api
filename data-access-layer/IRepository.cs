using data_access_layer.Models;
using System.Collections.Generic;

namespace data_access_layer
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> Get();

        void Add(T entity);

        void Delete(int id);

        void Update(T entity);

        T FindById(int id);
    }
}
