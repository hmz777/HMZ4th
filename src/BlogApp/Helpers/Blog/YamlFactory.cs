﻿using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BlogApp.Helpers.Blog
{
    public class YamlFactory
    {
        private static IDeserializer Deserializer { get; set; }
        private static ISerializer Serializer { get; set; }

        public static IDeserializer DeserializerGetOrCreate()
        {
            if (Deserializer != null)
                return Deserializer;

            Deserializer = new DeserializerBuilder()
                .WithNamingConvention(PascalCaseNamingConvention.Instance)
                .Build();

            return Deserializer;
        }

        public static ISerializer SerializerGetOrCreate()
        {
            if (Serializer != null)
                return Serializer;

            Serializer = new SerializerBuilder().Build();

            return Serializer;
        }
    }
}
