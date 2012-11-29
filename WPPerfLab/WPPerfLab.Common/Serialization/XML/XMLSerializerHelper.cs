using System;
using System.Xml.Serialization;
using System.IO;

namespace WPPerfLab.Common.Serialization.XML
{
    public class XMLSerializerHelper
    {
        public static void Serialize(Stream streamObject, object objForSerialization)
        {
            if (objForSerialization == null || streamObject == null)
                return;

            var serializer = new XmlSerializer(objForSerialization.GetType());
            serializer.Serialize(streamObject, objForSerialization);
        }

        public static object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if (serializedObjectType == null || streamObject == null)
                return null;

            var serializer = new XmlSerializer(serializedObjectType);
            return serializer.Deserialize(streamObject);
        }
    }
}
