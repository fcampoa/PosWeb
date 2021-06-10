using POS.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Repositories
{
    public class LookupRepository<T> : RepositoryBase<T>, ILookupRepository<T> where T : class
    {
        public LookupRepository(POSContext dbContext) : base(dbContext) { }

        public override IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>();
        }
    }
}
