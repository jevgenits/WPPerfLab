using System;
using System.IO;

namespace WPPerfLab.Common.Serialization
{
    public interface ISerializationHelper
    {
        void Serialize(Stream streamObject, object objForSerialization);
        object Deserialize(Stream streamObject, Type serializedObjectType);
    }
}
