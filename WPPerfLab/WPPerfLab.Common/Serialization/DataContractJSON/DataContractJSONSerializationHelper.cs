using System;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WPPerfLab.Common.Serialization.DataContractJSON
{
    public class DataContractJsonSerializationHelper : ISerializationHelper
    {
        public void Serialize(Stream streamObject, object objForSerialization)
        {
            if (objForSerialization == null || streamObject == null)
                return;

            var ser = new DataContractJsonSerializer(objForSerialization.GetType());
            ser.WriteObject(streamObject, objForSerialization);
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
