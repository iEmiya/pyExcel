using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace pyExcel.Framework
{
    public static class SerializationExtensions
    {
        #region Serialize

        public static string Serialize<T>(this T obj)
        {
            return Serialize(obj, (IEnumerable<Type>)null);
        }

        public static string Serialize<T>(this T obj, Type type)
        {
            return Serialize(obj, new List<Type>() { type });
        }

        public static string Serialize<T>(this T obj, IEnumerable<Type> knownTypes)
        {
            var serializer = new DataContractSerializer(obj.GetType(), knownTypes);
            using (var writer = new StringWriter())
            using (var stm = new XmlTextWriter(writer))
            {
                serializer.WriteObject(stm, obj);
                return writer.ToString();
            }
        }

        #endregion
        #region Deserialize

        public static T Deserialize<T>(this byte[] entryBytes)
        {
            return Deserialize<T>(entryBytes, (IEnumerable<Type>)null);
        }

        public static T Deserialize<T>(this byte[] entryBytes, Type type)
        {
            return Deserialize<T>(entryBytes, new List<Type>() { type });
        }

        public static T Deserialize<T>(this byte[] entryBytes, IEnumerable<Type> knownTypes)
        {
            string content = Encoding.UTF8.GetString(entryBytes);
            return Deserialize<T>(content, knownTypes);
        }

        public static T Deserialize<T>(this string serialized)
        {
            return Deserialize<T>(serialized, (IEnumerable<Type>)null);
        }

        public static T Deserialize<T>(this string serialized, Type type)
        {
            return Deserialize<T>(serialized, new List<Type>() { type });
        }

        public static T Deserialize<T>(this string serialized, IEnumerable<Type> knownTypes)
        {
            var serializer = new DataContractSerializer(typeof(T), knownTypes);
            using (var reader = new StringReader(serialized))
            using (var stm = new XmlTextReader(reader))
            {
                return (T)serializer.ReadObject(stm);
            }
        }

        #endregion
    }
}
