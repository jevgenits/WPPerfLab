using System;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WPPerfLab.Common.Serialization.DataContractJSON
{
    public class DataContractJsonSerializationHelper : ISerializationHelper
    {
        public void Serialize(Stream streamObject, object objectForSerialization)
        {
            if (objectForSerialization == null || streamObject == null)
                return;

            var ser = new DataContractJsonSerializer(objectForSerialization.GetType());
            ser.WriteObject(streamObject, objectForSerialization);
        }

        public object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if (serializedObjectType == null || streamObject == null)
                return null;

            var ser = new DataContractJsonSerializer(serializedObjectType);
            return ser.ReadObject(streamObject);
        }
    }
}
