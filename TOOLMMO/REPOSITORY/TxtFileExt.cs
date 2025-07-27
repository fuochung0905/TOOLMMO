using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY
{
    public static class TxtFileExt
    {
        public static List<T> ReadObjectsFromFile<T>(string filePath, char pairDelimiter = ';', char keyValueDelimiter = '=') where T : class, new()
        {
            var list = new List<T>();
            if (!File.Exists(filePath))
                return list;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                T obj = new T();
                var pairs = line.Split(pairDelimiter);
                foreach (var pair in pairs)
                {
                    var kv = pair.Split(keyValueDelimiter);
                    if (kv.Length != 2) continue;

                    var propertyName = kv[0].Trim();
                    var value = kv[1].Trim();

                    PropertyInfo prop = typeof(T).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                    if (prop != null && prop.CanWrite)
                    {
                        object convertedValue = Convert.ChangeType(value, prop.PropertyType);
                        prop.SetValue(obj, convertedValue);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static class TxtPipeParser
        {
            public static List<T> ReadObjectsFromPipeFile<T>(string filePath, char delimiter = '|') where T : class, new()
            {
                var list = new List<T>();
                if (!File.Exists(filePath)) return list;

                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                          .Where(p => p.CanWrite)
                                          .ToArray();

                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var values = line.Split(delimiter);
                    if (values.Length != properties.Length)
                        continue; 

                    var obj = new T();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        try
                        {
                            var convertedValue = Convert.ChangeType(values[i].Trim(), properties[i].PropertyType);
                            properties[i].SetValue(obj, convertedValue);
                        }
                        catch
                        {
                        }
                    }
                    list.Add(obj);
                }

                return list;
            }
        }

        //string FilesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FILES");
        //string AccountFile = Path.Combine(FilesDirectory, "Account.txt");
        //string ProxyFile = Path.Combine(FilesDirectory, "Proxy.txt");
        //var accounts = TxtPipeParser.ReadObjectsFromPipeFile<Account>(AccountFile);

    }
}
