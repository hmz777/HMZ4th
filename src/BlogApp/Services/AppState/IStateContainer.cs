namespace BlogApp.Services
{
    public interface IStateContainer
    {
        bool TryGet<T>(string key, out T value);
        void Set<T>(string key, T entry, Action<CacheOptions> options = null);
    }
}
