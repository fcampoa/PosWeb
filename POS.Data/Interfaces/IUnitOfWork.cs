using POS.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
        int Commit(IResponseData responseData);
        Task CommitAsync();
        void Dispose();
    }
}
