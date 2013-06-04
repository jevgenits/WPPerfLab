using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WPPerfLab.Common.Entities
{
    public class ProductEntity
    {
        [DataMemberAttribute]
        public string Title { get; set; }

        [DataMemberAttribute]
        public string Description { get; set; }

        [DataMemberAttribute]
        public string ImagePath { get; set; }

        [DataMemberAttribute]
        public List<string> Keys { get; set; }
    }
}
