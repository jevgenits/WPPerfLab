using System;
using System.IO;

namespace WPPerfLab.Common.Serialization.Binary
{
    public class BinarySerializationHelper 
    {
        public static void Serialize(Stream streamObject, object objForSerialization)
        {
            if (objForSerialization == null || streamObject == null)
                return;

            var ser = new CustomBinarySerializer(objForSerialization.GetType());
            ser.WriteObject(streamObject, objForSerialization);
        }

        public static object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if (serializedObjectType == null || streamObject == null)
                return null;

            var ser = new CustomBinarySerializer(serializedObjectType);
            return ser.ReadObject(streamObject);
        }
    }
}
