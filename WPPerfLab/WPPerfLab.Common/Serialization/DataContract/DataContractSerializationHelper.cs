using System;
using System.Runtime.Serialization;
using System.IO;

namespace WPPerfLab.Common.Serialization.DataContract
{
    public class DataContractSerializationHelper
    {
        public static void Serialize(Stream streamObject, object objForSerialization)
        {
            if (objForSerialization == null || streamObject == null)
                return;

            var ser = new DataContractSerializer(objForSerialization.GetType());
            ser.WriteObject(streamObject, objForSerialization);
        }

        public static object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if (serializedObjectType == null || streamObject == null)
                return null;

            var ser = new DataContractSerializer(serializedObjectType);
            return ser.ReadObject(streamObject);
        }
    }
}
