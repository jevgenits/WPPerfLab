using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WPPerfLab.Common.Serialization.Binary
{
    public class SimpleBinarySerializer
    {
        private readonly IEnumerable<PropertyInfo> serializableProperties = new List<PropertyInfo>();
        private readonly Type serializableObjectType;

        public SimpleBinarySerializer(Type objectType)
        {
            serializableObjectType = objectType;
            serializableProperties = GetMarkedProperties(objectType);
        }

        public void WriteObject(Stream stream, object graph)
        {
            if (stream == null || graph == null)
            {
                return;
            }

            var bw = new BinaryWriter(stream);

            foreach (PropertyInfo pi in serializableProperties)
            {
                var value = pi.GetValue(graph, null);

                if (pi.PropertyType == typeof (string))
                {
                    bw.Write(value as string ?? string.Empty);
                }
                else if (pi.PropertyType.IsGenericType && pi.PropertyType.GetInterfaces().Contains(typeof(IList<string>)))
                {
                    WriteStringList(bw, (IList<string>)value);
                }
            }

            bw.Flush();
        }

        public object ReadObject(Stream stream)
        {
            if (stream == null)
            {
                return null;
            }

            var br = new BinaryReader(stream);

            var deserializedObject = Activator.CreateInstance(serializableObjectType);

            foreach (PropertyInfo pi in serializableProperties)
            {
                if (pi.PropertyType == typeof(string))
                {
                    pi.SetValue(deserializedObject, br.ReadString(), null);
                }
                else if (pi.PropertyType.IsGenericType && pi.PropertyType.GetInterfaces().Contains(typeof(IList<string>)))
                {
                    pi.SetValue(deserializedObject, ReadStringList(br), null);
                }
            }

            br.Close();

            return deserializedObject;
        }

        private IEnumerable<PropertyInfo> GetMarkedProperties(Type type)
        {
            return (from property in type.GetProperties()
                    where property.GetCustomAttributes(true).Any(x => x is DataMemberAttribute)
                    select property);
        }

        private void WriteStringList(BinaryWriter bw, IList<string> list)
        {
            if (list == null || !list.Any())
            {
                bw.Write(0);
            }
            else
            {
                bw.Write(list.Count);
                foreach (var item in list)
                {
                    bw.Write(item);
                }
            }
        }

        private IList<string> ReadStringList(BinaryReader br)
        {
            var list = new List<string>();
            try
            {
                var count = br.ReadInt32();

                var index = count;
                while (index > 0)
                {
                    list.Add(br.ReadString());
                    index--;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
            return list;
        }
    }
}
