using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;

namespace XMLExporterInterface
{
    public interface IXmlFormatExporter
    {
        void Export(IEnumerable<Book> books , string filePath);
    }

}
