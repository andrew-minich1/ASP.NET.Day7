using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;
using XMLExporterInterface;
using System.Xml;

namespace XMLExporter
{
    public class XMLExporterXmlWriter : IXmlFormatExporter
    {
        public void Export(IEnumerable<Book> books, string filePath)
        {
            if (ReferenceEquals(books, null)) throw new ArgumentNullException();
            using (var xmlWriter = XmlWriter.Create(filePath, null))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Library");
                foreach (var book in books)
                {
                    xmlWriter.WriteStartElement("Book");
                    xmlWriter.WriteAttributeString("Year", book.Year);
                    xmlWriter.WriteAttributeString("Genre", book.Genre);
                    xmlWriter.WriteAttributeString("Pages", book.Pages.ToString());
                    xmlWriter.WriteElementString("Title", book.Title);
                    xmlWriter.WriteElementString("Author", book.Author);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
        }
    }
}
