
namespace Infrastructure.Repository.Interfaces
{
    using DBmodels.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref = "IGenericRepository{T}" />.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public interface IGenericRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Gets the Table.
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Converts to list.
        /// </summary>
        /// <returns>The list.</returns>
        Task<List<T>> ToListAsync();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The object.</returns>
        Task<T> GetById(object id);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Insert(T entity);

        /// <summary>
        /// The AddRangeAsync.
        /// </summary>
        /// <param name="entityCollection">The entityCollection<see cref="ICollection{T}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task AddRangeAsync(ICollection<T> entityCollection);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Update(T entity);

        /// <summary>
        /// The UpdateRange.
        /// </summary>
        /// <param name="entityCollection">The entityCollection<see cref="ICollection{T}"/>.</param>
        /// <returns>The <see cref="ICollection{T}"/>.</returns>
        public ICollection<T> UpdateRange(ICollection<T> entityCollection);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Delete(T entity);

        /// <summary>
        /// The SaveChangesAsync.
        /// </summary>
        /// <returns>The Task{int}.</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// The CreatePaging.
        /// </summary>
        /// <param name="source">The source<see cref="IQueryable{T}"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="PagingList{T}"/>.</returns>
        //PagingList<T> CreatePaging(IQueryable<T> source, int pageIndex, int pageSize);

        /// <summary>
        /// The OrderByDescending.
        /// </summary>
        /// <param name="sortExpression">The sortExpression.</param>
        /// <param name="source">The source<see cref="IQueryable{T}"/>.</param>
        /// <returns>The <see cref="IQueryable{T}"/>.</returns>
        IQueryable<T> OrderByDescending(Expression<Func<T, object>> sortExpression, IQueryable<T> source);

        /// <summary>
        /// The Order By ascending .
        /// </summary>
        /// <param name="sortExpression">The sortExpression.</param>
        /// <param name="source">The source<see cref="IQueryable{T}"/>.</param>
        /// <returns>The <see cref="IQueryable{T}"/>.</returns>
        IQueryable<T> OrderByAscending(Expression<Func<T, object>> sortExpression, IQueryable<T> source);

        /// <summary>
        /// The Order ascending
        /// </summary>
        /// <param name="sortExp">The sort expression.</param>
        /// <param name="source">The source<see cref="IQueryable{T}"/>.</param>
        /// <returns>The <see cref="IQueryable{T}"/>.</returns>
        IQueryable<T> OrderByAsc(Expression<Func<T, object>> sortExp, IQueryable<T> source);

        /// <summary>
        /// The DeleteRange.
        /// </summary>
        /// <param name="entityCollection">The entityCollection<see cref="ICollection{T}"/>.</param>
        /// <returns>The <see cref="ICollection{T}"/>.</returns>
        ICollection<T> DeleteRange(ICollection<T> entityCollection);
    }
}
