using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestEmpty.Test.Util
{
    public class DbSetTest<TEntity> : DbSet<TEntity>, IEnumerable<TEntity> where TEntity : class, new()
    {
        public DbSetTest()
        {
            this.elements = new List<TEntity>();
        }
        public DbSetTest(List<TEntity> eles)
        {
            this.elements = eles;
        }
        private List<TEntity> elements { get; set; }

        public override TEntity Add(TEntity entity) { elements.Add(entity); return entity; }
        public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities) { return new List<TEntity>(); }
        public override TEntity Attach(TEntity entity){ return new TEntity(); }
        public override TEntity Create(){ return new TEntity(); }
        public override TDerivedEntity Create<TDerivedEntity>(){ return null; }
        //
        public override TEntity Find(params object[] keyValues){ return new TEntity(); }
        public override Task<TEntity> FindAsync(params object[] keyValues){ return new Task<TEntity>(() => { return new TEntity(); }); }
        public override Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues){ return new Task<TEntity>(() => { return new TEntity(); }); }
        
        public override TEntity Remove(TEntity entity){ return new TEntity(); }
        public override IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities){ return new List<TEntity>(); }
        public override DbSqlQuery<TEntity> SqlQuery(string sql, params object[] parameters){ return null; }

        public IEnumerator<TEntity> GetEnumerator() {
            return new List<TEntity>().GetEnumerator();
        }
    }
}
