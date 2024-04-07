
namespace Infrastructure.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DBmodels.Configuration;
    using DBmodels.Models;
    using Infrastructure.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="GenericRepository{T}" />.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    [ExcludeFromCodeCoverage]
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable
        where T : BaseEntity
    {
        /// <summary>
        /// Defines the Entities.
        /// </summary>
        protected readonly DbSet<T> Entities;

        /// <summary>
        /// Gets or sets the CacheManager.
        /// </summary>
        // protected ICacheManager CacheManager { get; set; }

        /// <summary>
        /// Defines the context.
        /// </summary>
        protected readonly GcContext context;

        /// <summary>
        /// Defines the isDisposed.
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cacheManager">The cacheManager<see cref="ICacheManager"/>.</param>
        // public GenericRepository(GcContext context, ICacheManager cacheManager)
        public GenericRepository(GcContext context)
        {
            this.context = context;
            this.Entities = context.Set<T>();
            // this.CacheManager = cacheManager;
        }

        /// <summary>
        /// Gets the Table.
        /// </summary>
        public virtual IQueryable<T> Table => this.Entities;

        /// <summary>
        /// Converts to list.
        /// </summary>
        /// <returns>The list.</returns>
        public async Task<List<T>> ToListAsync()
        {
            return await this.Entities.ToListAsync();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The task.</returns>
        public async Task<T> GetById(object id)
        {
            return await this.Entities.FindAsync(id);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(Convert.ToString(nameof(T)));
            }

            return this.InsertEntity(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(T).ToString());
            }

            return this.UpdateEntity(entity);
        }

        /// <summary>
        /// The AddRangeAsync.
        /// </summary>
        /// <param name="entityCollection">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual Task AddRangeAsync(ICollection<T> entityCollection)
        {
            return this.AddRange(entityCollection);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entityCollection">The entityCollection.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual ICollection<T> UpdateRange(ICollection<T> entityCollection)
        {
            throw new NotImplementedException(nameof(T).ToString());
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(T).ToString());
            }

            return this.DeleteEntity(entity);
        }

        /// <summary>
        /// The SaveChangesAsync.
        /// </summary>
        /// <returns>The int.</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// The RefreshCache.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task RefreshCache()
        {
            await this.context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The CreatePaging.
        /// </summary>
        /// <param name="source">The source<see cref="IQueryable{T}"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="PagingList{T}"/>.</returns>
        //public PagingList<T> CreatePaging(IQueryable<T> source, int pageIndex, int pageSize)
        //{
        //    var count = source.Count();
        //    var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        //    return new PagingList<T>(items, count, pageIndex, pageSize);
        //}

        /// <summary>
        /// The OrderByDescending.
        /// </summary>
        /// <param name="sortExpression">The sortExpression.</param>
        /// <param name="source">The source<see cref="IQueryable{T}"/>.</param>
        /// <returns>The <see cref="IQueryable{T}"/>.</returns>
        public IQueryable<T> OrderByDescending(Expression<Func<T, object>> sortExpression, IQueryable<T> source) => source.OrderByDescending(sortExpression);

        /// <summary>
        /// The Order By ascending .
        /// </summary>
        /// <param name="sortExpression">The sortExpression.</param>
        /// <param name="source">The source<see cref="IQueryable{T}"/>.</param>
        /// <returns>The <see cref="IQueryable{T}"/>.</returns>
        public virtual IQueryable<T> OrderByAscending(Expression<Func<T, object>> sortExpression, IQueryable<T> source) => source.OrderBy(sortExpression);

        /// <summary>
        /// The Order By ascending.
        /// </summary>
        /// <param name="sortExpression">The sortExpression.</param>
        /// <returns>The List{T}.</returns>
        public virtual Task<List<T>> OrderByAscending(Expression<Func<T, object>> sortExpression) => this.Entities.OrderBy(sortExpression).ToListAsync();

        /// <summary>
        /// The DeleteRange.
        /// </summary>
        /// <param name="entityCollection">The entityCollection.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual ICollection<T> DeleteRange(ICollection<T> entityCollection)
        {
            throw new NotImplementedException(nameof(T).ToString());
        }

        /// <summary>
        /// Disposes the specified dispose.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [dispose].</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            if (disposing)
            {
                this.context.Dispose();
            }

            this.isDisposed = true;
        }

        /// <summary>
        /// The InsertEntity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task InsertEntity(T entity)
        {
            await this.Entities.AddAsync(entity);
            await this.SaveChangesAsync();
        }

        /// <summary>
        /// The AddRange.
        /// </summary>
        /// <param name="entityCollection">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task AddRange(ICollection<T> entityCollection)
        {
            this.Entities.AddRange(entityCollection);
            await this.SaveChangesAsync();
        }

        /// <summary>
        /// The UpdateEntity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task UpdateEntity(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            await this.SaveChangesAsync();
            await Task.FromResult<object>(null);
        }

        /// <summary>
        /// The DeleteEntity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task DeleteEntity(T entity)
        {
            this.Entities.Remove(entity);
            await this.SaveChangesAsync();
            await Task.FromResult<object>(null);
        }

        /// <summary>
        /// The Order By ascending .
        /// </summary>
        /// <param name="sortExp">.</param>
        /// <param name="source">The source<see cref="IQueryable{T}"/>.</param>
        /// <returns>The <see cref="IQueryable{T}"/>.</returns>
        public IQueryable<T> OrderByAsc(Expression<Func<T, object>> sortExp, IQueryable<T> source) => source.OrderBy(sortExp);

        /// <summary>
        /// The Order By ascending.
        /// </summary>
        /// <param name="sortExp">.</param>
        /// <returns>The Task{List{T}}.</returns>
        public virtual Task<List<T>> OrderByAsc(Expression<Func<T, object>> sortExp) => this.Entities.OrderBy(sortExp).ToListAsync();
    }
}
