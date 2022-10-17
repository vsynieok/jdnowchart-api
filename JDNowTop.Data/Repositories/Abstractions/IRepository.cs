using System.Linq.Expressions;

namespace JDNowTop.Data.Repositories.Abstractions
{
    /// <summary>
    /// An interface describing basic interactions with database.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <typeparam name="K">Primary key type.</typeparam>
    public interface IRepository<T, K>
    {
        /// <summary>
        /// Create a database entry for the given entity
        /// and returns the entity with an assigned ID.
        /// </summary>
        /// <param name="entity">Entity to create.</param>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Update an entity with the same ID as the input entity in the database
        /// and returns the updated entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Delete an entity with the specified ID from the database.
        /// </summary>
        /// <param name="id">Primary key to use.</param>
        Task DeleteAsync(K id);

        /// <summary>
        /// Find an entity in the database by ID.
        /// </summary>
        /// <param name="id">Primary key to use.</param>
        /// <returns>Entity itself.</returns>
        Task<T?> GetAsync(K id);

        /// <summary>
        /// Get all entities from the database.
        /// </summary>
        /// <returns>A collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets an entity by a passed predicate.
        /// </summary>
        /// <returns>An entity if the predicate condition is met, <see langword="null"/> if it isn't.</returns>
        Task<T?> GetIfAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets an entity collection by a passed predicate.
        /// </summary>
        /// <returns>An entity collection with items that match the predicate condition.</returns>
        Task<IEnumerable<T>> GetAnyAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Checks whether an entity with specified ID exists in the database.
        /// </summary>
        /// <returns><see langword="true"/> if entity exists and <see langword="false"/> if it doesn't.</returns>
        Task<bool> CheckExists(K id);
    }
}
