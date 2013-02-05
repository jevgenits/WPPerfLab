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
    public class CustomBinarySerializer
    {
        private readonly List<PropertyInfo> serializableProperties = new List<PropertyInfo>();
        private readonly Type serializableObjectType;

        public CustomBinarySerializer(Type objectType)
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
                else if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof (IList<>))
                {
                    WriteList(bw, value as IList);
                }
            }
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
                if (pi.PropertyType == typeof (string))
                {
                    pi.SetValue(deserializedObject, br.ReadString(), null);
                }
                else if (serializableObjectType.IsGenericType && serializableObjectType.GetGenericTypeDefinition() == typeof (IList<>))
                {
                    pi.SetValue(deserializedObject, ReadList(br), null);
                }
            }
            return deserializedObject;
        }

        private List<PropertyInfo> GetMarkedProperties(Type type)
        {
            return (from property in type.GetProperties()
                    where property.GetCustomAttributes(true).Any(x => x is DataMemberAttribute)
                    select property).ToList();
        }

        private void WriteList(BinaryWriter bw, IList list)
        {
            if (list == null || list.Count == 0)
            {
                bw.Write(0);
            }
            else
            {   
                bw.Write(list.Count);
                foreach (var item in list)
                {
                    if (item is string)
                    {
                        var str = (string) item;
                        // write lenght of the string first
                        bw.Write(str.Length);
                        // write every char of string
                        foreach (var c in str.ToCharArray())
                        {
                            bw.Write(c);
                        }
                    }
                }
            }
        }

        private IList ReadList(BinaryReader br)
        {
            //try
            //{
            //    int count = br.ReadInt32();
            //    foreach (var item in list)
            //    {
            //        if (item is string)
            //        {
            //            var str = (string) item;
            //            // write lenght of the string first
            //            bw.Write(str.Length);
            //            // write every char of string
            //            foreach (var c in str.ToCharArray())
            //            {
            //                bw.Write(c);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.InnerException);
            //}
            return null;
        }
  
}
}
