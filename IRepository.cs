using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using KSS.Common.Utility.Model;

namespace KSS.Common.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> InitialIQueryable();

        #region Find

        Task<T?> FindAsync(Filter id);

        T? Find(object id);

        #endregion

        #region Single

        Task<T> SingleAsync();
        Task<T> SingleAsync(Expression<Func<T, bool>> filter);
        Task<T> SingleAsync(IQueryable<T> queryable);
        Task<T> SingleAsync(T filter);

        T Single();
        T Single(Expression<Func<T, bool>> filter);
        T Single(IQueryable<T> queryable);

        Task<T> SingleUnawaited();
        Task<T> SingleUnawaited(Expression<Func<T, bool>> filter);
        Task<T> SingleUnawaited(IQueryable<T> queryable);


        Task<T?> SingleOrDefaultAsync();
        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<T?> SingleOrDefaultAsync(IQueryable<T> queryable);

        T? SingleOrDefault();
        T? SingleOrDefault(Expression<Func<T, bool>> filter);
        T? SingleOrDefault(IQueryable<T> queryable);

        Task<T?> SingleOrDefaultUnawaited();
        Task<T?> SingleOrDefaultUnawaited(Expression<Func<T, bool>> filter);
        Task<T?> SingleOrDefaultUnawaited(IQueryable<T> queryable);

        #endregion

        #region First

        Task<T> FirstAsync();
        Task<T> FirstAsync(Expression<Func<T, bool>> filter);
        Task<T> FirstAsync(IQueryable<T> queryable);

        T First();
        T First(Expression<Func<T, bool>> filter);
        T First(IQueryable<T> queryable);

        Task<T> FirstUnawaited();
        Task<T> FirstUnawaited(Expression<Func<T, bool>> filter);
        Task<T> FirstUnawaited(IQueryable<T> queryable);


        Task<T?> FirstOrDefaultAsync();
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<T?> FirstOrDefaultAsync(IQueryable<T> queryable);

        T? FirstOrDefault();
        T? FirstOrDefault(Expression<Func<T, bool>> filter);
        T? FirstOrDefault(IQueryable<T> queryable);

        Task<T?> FirstOrDefaultUnawaited();
        Task<T?> FirstOrDefaultUnawaited(Expression<Func<T, bool>> filter);
        Task<T?> FirstOrDefaultUnawaited(IQueryable<T> queryable);

        #endregion

        #region ToList

        Task<IEnumerable<T>> ToListAsync();
        Task<IEnumerable<T>> ToListAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> ToListAsync(IQueryable<T> queryable);
        Task<IEnumerable<T>> ToListAsync(T filter);
        Task<IEnumerable<T>> ToListAsync(Filter filter);

        IEnumerable<T> ToList();
        IEnumerable<T> ToList(Expression<Func<T, bool>> filter);
        IEnumerable<T> ToList(IQueryable<T> queryable);

        Task<List<T>> ToListUnawaited();
        Task<List<T>> ToListUnawaited(Expression<Func<T, bool>> filter);
        Task<List<T>> ToListUnawaited(IQueryable<T> queryable);

        #endregion

        #region Count

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> filter);
        Task<int> CountAsync(IQueryable<T> queryable);

        int Count();
        int Count(Expression<Func<T, bool>> filter);
        int Count(IQueryable<T> queryable);

        Task<int> CountUnawaited();
        Task<int> CountUnawaited(Expression<Func<T, bool>> filter);
        Task<int> CountUnawaited(IQueryable<T> queryable);

        #endregion

        #region Add

        Task AddAsync(T item, bool saveChanges = true);
        void AddUnawaitedAsync(T item, bool saveChanges = true);

        void Add(T item, bool saveChanges = true);
        void AddUnawaited(T item, bool saveChanges = true);


        Task AddRangeAsync(IEnumerable<T> items, bool saveChanges = true);
        void AddRangeUnawaitedAsync(IEnumerable<T> items, bool saveChanges = true);

        void AddRange(IEnumerable<T> items, bool saveChanges = true);
        void AddRangeUnawaited(IEnumerable<T> items, bool saveChanges = true);

        #endregion

        #region Update

        void Update(T item, bool saveChanges = true);
        void Update(T item, Expression<Func<T, object>>[] properties, bool saveChanges = true);
        void UpdateRange(IEnumerable<T> items, bool saveChanges = true);

        Task ExecuteUpdateAsync(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
        Task ExecuteUpdateAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
        Task ExecuteUpdateAsync(IQueryable<T> queryable, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);

        void ExecuteUpdateUnawaitedAsync(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
        void ExecuteUpdateUnawaitedAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
        void ExecuteUpdateUnawaitedAsync(IQueryable<T> queryable, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);

        void ExecuteUpdate(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
        void ExecuteUpdate(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
        void ExecuteUpdate(IQueryable<T> queryable, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);

        void ExecuteUpdateUnawaited(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
        void ExecuteUpdateUnawaited(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
        void ExecuteUpdateUnawaited(IQueryable<T> queryable, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);

        #endregion

        #region Remove / Delete

        void Remove(T item, bool saveChanges = true);
        void RemoveRange(IEnumerable<T> items, bool saveChanges = true);

        Task ExecuteDeleteAsync();
        Task ExecuteDeleteAsync(Expression<Func<T, bool>> filter);
        Task ExecuteDeleteAsync(IQueryable<T> queryable);

        void ExecuteDeleteUnawaitedAsync();
        void ExecuteDeleteUnawaitedAsync(Expression<Func<T, bool>> filter);
        void ExecuteDeleteUnawaitedAsync(IQueryable<T> queryable);

        void ExecuteDelete();
        void ExecuteDelete(Expression<Func<T, bool>> filter);
        void ExecuteDelete(IQueryable<T> queryable);

        void ExecuteDeleteUnawaited();
        void ExecuteDeleteUnawaited(Expression<Func<T, bool>> filter);
        void ExecuteDeleteUnawaited(IQueryable<T> queryable);

        #endregion

        #region SaveChanges

        Task SaveChangesAsync();
        void SaveChangesUnawaitedAsync();
        void SaveChanges();
        void SaveChangesUnawaited();

        #endregion
    }
}
