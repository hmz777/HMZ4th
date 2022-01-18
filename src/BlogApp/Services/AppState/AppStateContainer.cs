using System.Collections.Concurrent;

namespace HMZ4th.Services
{
    public class AppStateContainer : IStateContainer
    {
        private ConcurrentDictionary<string, CacheEntry> _entries = new();

        public void Set<T>(string key, T entry, Action<CacheOptions> options = null)
        {
            ArgumentNullException.ThrowIfNull(key);
            ArgumentNullException.ThrowIfNull(entry);

            var intOptions = new CacheOptions();

            options?.Invoke(intOptions);

            if (intOptions.Expiration <= TimeSpan.Zero)
                throw new ArgumentException("Expiration time must be bigger than zero.");

            if (TryGetInternal(key, out CacheEntry ent))
            {
                ent.UpdateEntry(entry);
                ent.UpdateExpiration(intOptions.Expiration);

                return;
            }

            var cacheEntry = new CacheEntry(entry, intOptions.Expiration);

            TrySetInternal(key, cacheEntry);
        }

        public bool TryGet<T>(string key, out T value)
        {
            if (TryGetInternal(key, out CacheEntry cacheEntry))
            {
                var cacheVal = cacheEntry.GetEntry();

                if (cacheVal is T)
                {
                    value = (T)cacheVal;
                    return true;
                }
                else
                    throw new ArgumentException("Invalid entry type.");
            }

            value = default(T);
            return false;
        }

        private bool TrySetInternal(string key, CacheEntry entry)
        {
            if (_entries.TryAdd(key, entry))
                return true;

            throw new Exception("Couldn't set entry.");
        }

        private bool TryGetInternal(string key, out CacheEntry? entry)
        {
            if (_entries.TryGetValue(key, out CacheEntry intEntry))
            {
                if (intEntry.IsExpired())
                {
                    if (_entries.TryRemove(key, out _) == false)
                        throw new Exception("Cache entry couldn't be removed.");
                }
                else
                {
                    entry = intEntry;
                    return true;
                }
            }

            entry = null;
            return false;
        }
    }
}