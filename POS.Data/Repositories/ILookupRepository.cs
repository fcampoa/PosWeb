using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Repositories
{
    public interface ILookupRepository<T> : IRepository<T> where T : class
    {
    }
}
