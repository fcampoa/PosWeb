using POS.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Service.Interfaces
{
    public interface ICRUD<T>
    {
        ResponseModel Add(T entity);
        ResponseModel Update(T entity);
        ResponseModel Delete(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
