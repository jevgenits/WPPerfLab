using System;
using System.Xml.Serialization;
using System.IO;

namespace WPPerfLab.Common.Serialization.XML
{
    public class XMLSerializerHelper : ISerializationHelper
    {
        public void Serialize(Stream streamObject, object objectForSerialization)
        {
            if (objectForSerialization == null || streamObject == null)
                return;

            var serializer = new XmlSerializer(objectForSerialization.GetType());
            serializer.Serialize(streamObject, objectForSerialization);
        }

        public object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if (serializedObjectType == null || streamObject == null)
                return null;

            var serializer = new XmlSerializer(serializedObjectType);
            return serializer.Deserialize(streamObject);
        }
    }
}
