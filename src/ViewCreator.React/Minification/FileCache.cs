namespace ViewCreator.React.Minification
{
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class FileCache
    {
        private static Lazy<IMemoryCache> Cache = new Lazy<IMemoryCache>(() => { return new MemoryCache(new MemoryCacheOptions()); });

        /// <summary>
        /// Gets the text file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string GetTextFile(string path)
        {
            if (Exists(path))
            {
                return Get(path).ToString();
            }
            else
            {
                string data = ReadFile(path);
                Add(data, path);
                return data;
            }
        }

        /// <summary>
        /// Gets the text file using a file parser.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="parser">The parser.</param>
        /// <returns></returns>
        public static string GetTextFile(string path, IFileParser parser)
        {
            if (Exists(path))
            {
                return Get(path).ToString();
            }
            else
            {
                string data = parser.Parse(path);
                Add(data, path);
                return data;
            }
        }

        /// <summary>
        /// Reads the file form disk.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <returns></returns>
        private static string ReadFile(string path)
        {
            TextReader s = new StreamReader(path);
            string data = s.ReadToEnd();
            s.Close();
            s.Dispose();
            return data;
        }

        /// <summary>
        /// Adds the specified cache object.
        /// </summary>
        /// <param name="cacheObject">The cache object.</param>
        /// <param name="keyName">Name of the key.</param>
        private static void Add(object cacheObject, string keyName)
        {
            Cache.Value.Set(keyName, cacheObject);
        }

        /// <summary>
        /// Check if object exists in cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static bool Exists(string key)
        {
            return Cache.Value.TryGetValue(key, out object value);
        }

        /// <summary>
        /// remove object from cache
        /// </summary>
        /// <param name="key"></param>
        private static void Remove(string key)
        {
            Cache.Value.Remove(key);
        }

        /// <summary>
        /// get object from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            if(Cache.Value.TryGetValue(key, out object value))
            {
                return value;
            }

            return default(object);
        }
    }
}
