﻿namespace HMZ4th.Services
{
    public class CacheOptions
    {
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(10);
    }
}