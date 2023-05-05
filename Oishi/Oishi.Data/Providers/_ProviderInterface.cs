namespace Oishi.Data.Providers
{
    internal interface IProvider<T>
    {
        public List<T> Get();
        public T? GetFirstById(int id);
        public T Insert(T item);
        public T? Update(T item);
        public bool Delete(int id);
    }
}
