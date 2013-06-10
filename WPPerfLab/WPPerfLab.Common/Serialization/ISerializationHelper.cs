using System;
using System.IO;

namespace WPPerfLab.Common.Serialization
{
public interface ISerializationHelper
{
    void Serialize(Stream streamObject, object objectForSerialization);
    object Deserialize(Stream streamObject, Type serializedObjectType);
}
}
