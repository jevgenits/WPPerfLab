using System;
using System.Runtime.Serialization;
using System.IO;

namespace WPPerfLab.Common.Serialization.DataContract
{
    public class DataContractSerializationHelper : ISerializationHelper
    {
        public void Serialize(Stream streamObject, object objectForSerialization)
        {
            if (objectForSerialization == null || streamObject == null)
                return;

            var ser = new DataContractSerializer(objectForSerialization.GetType());
            ser.WriteObject(streamObject, objectForSerialization);
        }

        public object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if (serializedObjectType == null || streamObject == null)
                return null;

            var ser = new DataContractSerializer(serializedObjectType);
            return ser.ReadObject(streamObject);
        }
    }
}
