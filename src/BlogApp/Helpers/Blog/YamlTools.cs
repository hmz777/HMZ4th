﻿using BlogApp.Models;

namespace BlogApp.Helpers.Blog
{
    public class YamlTools
    {
        public static YamlMetadata DeserializeYaml(string yaml)
        {
            var yamlDeserializer = YamlFactory.DeserializerGetOrCreate();

            return yamlDeserializer.Deserialize<YamlMetadata>(yaml);
        }

        public static string SerializeYaml(YamlMetadata yaml)
        {
            var yamlDeserializer = YamlFactory.SerializerGetOrCreate();

            return yamlDeserializer.Serialize(yaml);
        }
    }
}
