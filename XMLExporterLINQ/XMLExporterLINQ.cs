using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;
using XMLExporterInterface;
using System.Xml.Linq;


namespace XMLExporter
{
    public class XMLExporterLINQ : IXmlFormatExporter
    {
        public void Export(IEnumerable<Book> books, string filePath)
        {
            if (ReferenceEquals(books, null)) throw new ArgumentNullException();

            XDocument doc = new XDocument(
                new XElement("Library",
                    books.Select(p =>
                        new XElement("Book",
                            new XElement("Title", p.Title),
                            new XElement("Author", p.Author),
                            new XAttribute("Year", p.Year),
                            new XAttribute("Genre", p.Genre),
                            new XAttribute("Pages", p.Pages)))));
            doc.Save(filePath);
        }
    }
}
