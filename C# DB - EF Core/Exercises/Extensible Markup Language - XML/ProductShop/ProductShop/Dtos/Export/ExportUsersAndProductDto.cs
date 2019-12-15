using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class ExportUsersAndProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UsersAndProductDto[] Users { get; set; }
    }
}
