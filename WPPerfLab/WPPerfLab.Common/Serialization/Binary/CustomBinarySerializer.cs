using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WPPerfLab.Common.Serialization.Binary
{
    public class CustomBinarySerializer
    {
        private readonly List<PropertyInfo> serializableProperties = new List<PropertyInfo>();
        private readonly Type serializableObjectType;

        public CustomBinarySerializer(Type objectType)
        {
            this.serializableObjectType = objectType;
            this.serializableProperties = this.GetMarkedProperties(objectType);
        }

        private List<PropertyInfo> GetMarkedProperties(Type type)
        {
            return (from property in type.GetProperties()
                    where property.GetCustomAttributes(true).Any(x => x is DataMemberAttribute)
                    select property).ToList();
        }

        #region Write

        public void WriteObject(Stream stream, object graph)
        {
            if (stream == null || graph == null)
                return;

            var bw = new BinaryWriter(stream);

            foreach (PropertyInfo pi in this.serializableProperties)
            {
                var value = pi.GetValue(graph, null);

                if (pi.PropertyType == typeof(string))
                {
                    bw.Write(value as string ?? string.Empty);
                }
                else if (pi.PropertyType == typeof(List<int>))
                {
                    this.WriteIntegerList(bw, value as List<int>);
                }
            }
        }

        private void WriteIntegerList(BinaryWriter bw, List<int> list)
        {
            if (list == null || !list.Any())
            {
                bw.Write(0);
            }
            else
            {
                bw.Write(list.Count);
                list.ForEach(bw.Write);
            }
        }

        #endregion Write

        #region Read

        public object ReadObject(Stream stream)
        {
            if (stream == null)
                return null;

            var br = new BinaryReader(stream);

            object deserializedObject = Activator.CreateInstance(this.serializableObjectType);

            foreach (PropertyInfo pi in this.serializableProperties)
            {
                if (pi.PropertyType == typeof(string))
                {
                    pi.SetValue(deserializedObject, br.ReadString(), null);
                }
                else if (pi.PropertyType == typeof(List<int>))
                {
                    pi.SetValue(deserializedObject, this.ReadIntegerList(br), null);
                }
            }
            return deserializedObject;
        }

        private List<int> ReadIntegerList(BinaryReader br)
        {
            var list = new List<int>();
            int count = br.ReadInt32();

            int index = count;
            while (index > 0)
            {
                list.Add(br.ReadInt32());
                index--;
            }
            return list;
        }

        #endregion Read

    }
}
