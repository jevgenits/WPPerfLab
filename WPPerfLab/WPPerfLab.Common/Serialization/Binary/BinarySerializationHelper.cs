using System;
using System.IO;

namespace WPPerfLab.Common.Serialization.Binary
{
    public class BinarySerializationHelper : ISerializationHelper 
    {
        public void Serialize(Stream streamObject, object objForSerialization)
        {
            if (objForSerialization == null || streamObject == null)
                return;

            var ser = new SimpleBinarySerializer(objForSerialization.GetType());
            ser.WriteObject(streamObject, objForSerialization);
        }

        public object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if (serializedObjectType == null || streamObject == null)
                return null;

            var ser = new SimpleBinarySerializer(serializedObjectType);
            return ser.ReadObject(streamObject);
        }
    }
}
