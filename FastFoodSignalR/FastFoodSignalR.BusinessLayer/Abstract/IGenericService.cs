using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class

    {
        void TAdd(T entity);
        void TDelete(T entity);
        void Update(T entity, T unchanged);
        T TGetById(int Id);
        List<T> TGetListAll();
    }
}
