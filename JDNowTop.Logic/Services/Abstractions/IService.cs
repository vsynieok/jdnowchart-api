namespace JDNowTop.Logic.Services.Abstractions
{
    public interface IService<T>
    {
        public Task<T?> CreateAsync(T _entity);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
