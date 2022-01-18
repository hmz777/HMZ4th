namespace BlogApp.Services
{
    public class CacheEntry
    {
        private object _value;
        private DateTimeOffset _expiration;

        public CacheEntry(object value, TimeSpan expirationTime)
        {
            _value = value;
            _expiration = DateTimeOffset.UtcNow + expirationTime;
        }

        public void UpdateEntry(object Value)
        {
            ArgumentNullException.ThrowIfNull(Value);

            _value = Value;
        }

        public void UpdateExpiration(TimeSpan exp)
        {
            if (exp <= TimeSpan.Zero)
                throw new ArgumentException("Expiration time must be bigger than zero.");

            _expiration = DateTimeOffset.UtcNow + exp;
        }

        public object GetEntry() => _value;

        public bool IsExpired() => DateTimeOffset.UtcNow.Ticks - _expiration.UtcTicks > 0;
    }
}