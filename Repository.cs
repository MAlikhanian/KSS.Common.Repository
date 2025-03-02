using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using KSS.Common.Utility;
using KSS.Common.Utility.Model;

namespace KSS.Common.Repository
{
    public class Repository<TDbContext, T> : IRepository<T>, IDisposable where T : class where TDbContext : DbContext
    {
        private bool _disposed = false;
        private readonly TDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(TDbContext dbContext) { _dbContext = dbContext; _dbSet = _dbContext.Set<T>(); }

        public IQueryable<T> InitialIQueryable() => _dbSet.AsQueryable();

        #region Find

        public virtual async Task<T?> FindAsync(Filter id) => await _dbSet.FindAsync(Assistant.FilterGetValue(id));

        public virtual T? Find(object id) => _dbSet.Find(id);

        #endregion

        #region Single

        public virtual async Task<T> SingleAsync() => await _dbSet.SingleAsync();
        public virtual async Task<T> SingleAsync(Expression<Func<T, bool>> filter) => await _dbSet.SingleAsync(filter);
        public virtual async Task<T> SingleAsync(IQueryable<T> queryable) => await queryable.SingleAsync();
        public virtual async Task<T> SingleAsync(T filter) => throw new NotImplementedException();

        public virtual T Single() => _dbSet.Single();
        public virtual T Single(Expression<Func<T, bool>> filter) => _dbSet.Single(filter);
        public virtual T Single(IQueryable<T> queryable) => queryable.Single();

        public virtual Task<T> SingleUnawaited() => _dbSet.SingleAsync();
        public virtual Task<T> SingleUnawaited(Expression<Func<T, bool>> filter) => _dbSet.SingleAsync(filter);
        public virtual Task<T> SingleUnawaited(IQueryable<T> queryable) => queryable.SingleAsync();


        public virtual async Task<T?> SingleOrDefaultAsync() => await _dbSet.SingleOrDefaultAsync();
        public virtual async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter) => await _dbSet.SingleOrDefaultAsync(filter);
        public virtual async Task<T?> SingleOrDefaultAsync(IQueryable<T> queryable) => await queryable.SingleOrDefaultAsync();

        public virtual T? SingleOrDefault() => _dbSet.SingleOrDefault();
        public virtual T? SingleOrDefault(Expression<Func<T, bool>> filter) => _dbSet.SingleOrDefault(filter);
        public virtual T? SingleOrDefault(IQueryable<T> queryable) => queryable.SingleOrDefault();

        public virtual Task<T?> SingleOrDefaultUnawaited() => _dbSet.SingleOrDefaultAsync();
        public virtual Task<T?> SingleOrDefaultUnawaited(Expression<Func<T, bool>> filter) => _dbSet.SingleOrDefaultAsync(filter);
        public virtual Task<T?> SingleOrDefaultUnawaited(IQueryable<T> queryable) => queryable.SingleOrDefaultAsync();

        #endregion

        #region First

        public virtual async Task<T> FirstAsync() => await _dbSet.FirstAsync();
        public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> filter) => await _dbSet.FirstAsync(filter);
        public virtual async Task<T> FirstAsync(IQueryable<T> queryable) => await queryable.FirstAsync();

        public virtual T First() => _dbSet.First();
        public virtual T First(Expression<Func<T, bool>> filter) => _dbSet.First(filter);
        public virtual T First(IQueryable<T> queryable) => queryable.First();

        public virtual Task<T> FirstUnawaited() => _dbSet.FirstAsync();
        public virtual Task<T> FirstUnawaited(Expression<Func<T, bool>> filter) => _dbSet.FirstAsync(filter);
        public virtual Task<T> FirstUnawaited(IQueryable<T> queryable) => queryable.FirstAsync();


        public virtual async Task<T?> FirstOrDefaultAsync() => await _dbSet.FirstOrDefaultAsync();
        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter) => await _dbSet.FirstOrDefaultAsync(filter);
        public virtual async Task<T?> FirstOrDefaultAsync(IQueryable<T> queryable) => await queryable.FirstOrDefaultAsync();

        public virtual T? FirstOrDefault() => _dbSet.FirstOrDefault();
        public virtual T? FirstOrDefault(Expression<Func<T, bool>> filter) => _dbSet.FirstOrDefault(filter);
        public virtual T? FirstOrDefault(IQueryable<T> queryable) => queryable.FirstOrDefault();

        public virtual Task<T?> FirstOrDefaultUnawaited() => _dbSet.FirstOrDefaultAsync();
        public virtual Task<T?> FirstOrDefaultUnawaited(Expression<Func<T, bool>> filter) => _dbSet.FirstOrDefaultAsync(filter);
        public virtual Task<T?> FirstOrDefaultUnawaited(IQueryable<T> queryable) => queryable.FirstOrDefaultAsync();

        #endregion

        #region ToList

        public virtual async Task<IEnumerable<T>> ToListAsync() => await _dbSet.ToListAsync();
        public virtual async Task<IEnumerable<T>> ToListAsync(Expression<Func<T, bool>> filter) => await _dbSet.Where(filter).ToListAsync();
        public virtual async Task<IEnumerable<T>> ToListAsync(IQueryable<T> queryable) => await queryable.ToListAsync();
        public virtual Task<IEnumerable<T>> ToListAsync(T filter) => throw new NotImplementedException();
        public virtual Task<IEnumerable<T>> ToListAsync(Filter filter) => throw new NotImplementedException();

        public virtual IEnumerable<T> ToList() => _dbSet.ToList();
        public virtual IEnumerable<T> ToList(Expression<Func<T, bool>> filter) => _dbSet.Where(filter).ToList();
        public virtual IEnumerable<T> ToList(IQueryable<T> queryable) => queryable.ToList();

        public virtual Task<List<T>> ToListUnawaited() => _dbSet.ToListAsync();
        public virtual Task<List<T>> ToListUnawaited(Expression<Func<T, bool>> filter) => _dbSet.Where(filter).ToListAsync();
        public virtual Task<List<T>> ToListUnawaited(IQueryable<T> queryable) => queryable.ToListAsync();

        #endregion

        #region Count

        public virtual async Task<int> CountAsync() => await _dbSet.CountAsync();
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> filter) => await _dbSet.Where(filter).CountAsync();
        public virtual async Task<int> CountAsync(IQueryable<T> queryable) => await queryable.CountAsync();

        public virtual int Count() => _dbSet.Count();
        public virtual int Count(Expression<Func<T, bool>> filter) => _dbSet.Where(filter).Count();
        public virtual int Count(IQueryable<T> queryable) => queryable.Count();

        public virtual Task<int> CountUnawaited() => _dbSet.CountAsync();
        public virtual Task<int> CountUnawaited(Expression<Func<T, bool>> filter) => _dbSet.Where(filter).CountAsync();
        public virtual Task<int> CountUnawaited(IQueryable<T> queryable) => queryable.CountAsync();

        #endregion

        #region Add

        public virtual async Task AddAsync(T item, bool saveChanges = true)
        {
            await _dbSet.AddAsync(item);

            if (saveChanges) await _dbContext.SaveChangesAsync();
        }
        public virtual async void AddUnawaitedAsync(T item, bool saveChanges = true)
        {
            await _dbSet.AddAsync(item);

            if (saveChanges) await _dbContext.SaveChangesAsync();
        }

        public virtual void Add(T item, bool saveChanges = true)
        {
            _dbSet.Add(item);

            if (saveChanges) _dbContext.SaveChanges();
        }
        public virtual void AddUnawaited(T item, bool saveChanges = true)
        {
            _dbSet.AddAsync(item);

            if (saveChanges) _dbContext.SaveChangesAsync();
        }


        public virtual async Task AddRangeAsync(IEnumerable<T> items, bool saveChanges = true)
        {
            await _dbSet.AddRangeAsync(items);

            if (saveChanges) await _dbContext.SaveChangesAsync();
        }
        public virtual async void AddRangeUnawaitedAsync(IEnumerable<T> items, bool saveChanges = true)
        {
            await _dbSet.AddRangeAsync(items);

            if (saveChanges) await _dbContext.SaveChangesAsync();
        }

        public virtual void AddRange(IEnumerable<T> items, bool saveChanges = true)
        {
            _dbSet.AddRange(items);

            if (saveChanges) _dbContext.SaveChanges();
        }
        public virtual void AddRangeUnawaited(IEnumerable<T> items, bool saveChanges = true)
        {
            _dbSet.AddRangeAsync(items);

            if (saveChanges) _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Update

        public virtual void Update(T item, bool saveChanges = true)
        {
            _dbSet.Update(item);

            if (saveChanges) _dbContext.SaveChanges();
        }
        public virtual void Update(T item, Expression<Func<T, object>>[] properties, bool saveChanges = true)
        {
            _dbSet.Attach(item);

            foreach (var property in properties)
                _dbSet.Entry(item).Property(property).IsModified = true;

            if (saveChanges)
            {
                _dbContext.SaveChanges();

                _dbSet.Entry(item).State = EntityState.Detached;
            }
        }
        public virtual void UpdateRange(IEnumerable<T> items, bool saveChanges = true)
        {
            _dbSet.UpdateRange(items);

            if (saveChanges) _dbContext.SaveChanges();
        }

        public virtual async Task ExecuteUpdateAsync(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => await _dbSet.ExecuteUpdateAsync(setPropertyCalls);
        public virtual async Task ExecuteUpdateAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => await _dbSet.Where(filter).ExecuteUpdateAsync(setPropertyCalls);
        public virtual async Task ExecuteUpdateAsync(IQueryable<T> queryable, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => await queryable.ExecuteUpdateAsync(setPropertyCalls);

        public virtual async void ExecuteUpdateUnawaitedAsync(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => await _dbSet.ExecuteUpdateAsync(setPropertyCalls);
        public virtual async void ExecuteUpdateUnawaitedAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => await _dbSet.Where(filter).ExecuteUpdateAsync(setPropertyCalls);
        public virtual async void ExecuteUpdateUnawaitedAsync(IQueryable<T> queryable, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => await queryable.ExecuteUpdateAsync(setPropertyCalls);

        public virtual void ExecuteUpdate(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => _dbSet.ExecuteUpdate(setPropertyCalls);
        public virtual void ExecuteUpdate(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => _dbSet.Where(filter).ExecuteUpdate(setPropertyCalls);
        public virtual void ExecuteUpdate(IQueryable<T> queryable, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => queryable.ExecuteUpdate(setPropertyCalls);

        public virtual void ExecuteUpdateUnawaited(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => _dbSet.ExecuteUpdateAsync(setPropertyCalls);
        public virtual void ExecuteUpdateUnawaited(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => _dbSet.Where(filter).ExecuteUpdateAsync(setPropertyCalls);
        public virtual void ExecuteUpdateUnawaited(IQueryable<T> queryable, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
            => queryable.ExecuteUpdateAsync(setPropertyCalls);

        #endregion

        #region Remove / Delete

        public virtual void Remove(T item, bool saveChanges = true)
        {
            _dbSet.Remove(item);

            if (saveChanges) _dbContext.SaveChanges();
        }
        public virtual void RemoveRange(IEnumerable<T> items, bool saveChanges = true)
        {
            _dbSet.RemoveRange(items);

            if (saveChanges) _dbContext.SaveChanges();
        }

        public virtual async Task ExecuteDeleteAsync() => await _dbSet.ExecuteDeleteAsync();
        public virtual async Task ExecuteDeleteAsync(Expression<Func<T, bool>> filter) => await _dbSet.Where(filter).ExecuteDeleteAsync();
        public virtual async Task ExecuteDeleteAsync(IQueryable<T> queryable) => await queryable.ExecuteDeleteAsync();

        public virtual async void ExecuteDeleteUnawaitedAsync() => await _dbSet.ExecuteDeleteAsync();
        public virtual async void ExecuteDeleteUnawaitedAsync(Expression<Func<T, bool>> filter) => await _dbSet.Where(filter).ExecuteDeleteAsync();
        public virtual async void ExecuteDeleteUnawaitedAsync(IQueryable<T> queryable) => await queryable.ExecuteDeleteAsync();

        public virtual void ExecuteDelete() => _dbSet.ExecuteDelete();
        public virtual void ExecuteDelete(Expression<Func<T, bool>> filter) => _dbSet.Where(filter).ExecuteDelete();
        public virtual void ExecuteDelete(IQueryable<T> queryable) => queryable.ExecuteDelete();

        public virtual void ExecuteDeleteUnawaited() => _dbSet.ExecuteDeleteAsync();
        public virtual void ExecuteDeleteUnawaited(Expression<Func<T, bool>> filter) => _dbSet.Where(filter).ExecuteDeleteAsync();
        public virtual void ExecuteDeleteUnawaited(IQueryable<T> queryable) => queryable.ExecuteDeleteAsync();

        #endregion

        #region SaveChanges

        public async Task SaveChangesAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
                await _dbContext.SaveChangesAsync();
        }
        public async void SaveChangesUnawaitedAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
                await _dbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            if (_dbContext.ChangeTracker.HasChanges())
                _dbContext.SaveChanges();
        }
        public void SaveChangesUnawaited()
        {
            if (_dbContext.ChangeTracker.HasChanges())
                _dbContext.SaveChangesAsync();
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _dbContext.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
