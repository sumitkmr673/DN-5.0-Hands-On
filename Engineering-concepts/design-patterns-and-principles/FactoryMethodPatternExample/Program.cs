using System;

namespace FactoryMethodPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Testing Factory Method Pattern Example----");
   
            Console.WriteLine("Client: Requesting a Word Document.....");
            DocumentFactory wordFactory = new WordDocumentFactory();
            wordFactory.ProcessDocument();
            Console.WriteLine("\n-----------------------------------------------------------\n");

            Console.WriteLine("Client: Requesting a PDF Document.....");
            DocumentFactory pdfFactory = new PDFDocumentFactory();
            pdfFactory.ProcessDocument();
            Console.WriteLine("\n-----------------------------------------------------------\n");

            Console.WriteLine("Client: Requesting a Excel Document.....");
            DocumentFactory excelFactory = new ExcelDocumentFactory();
            excelFactory.ProcessDocument();
        }
    }
}