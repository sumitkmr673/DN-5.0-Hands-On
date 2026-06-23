using System;

namespace FactoryMethodPatternExample
{
    public interface IDocument
    {
        void Open();
        void Save();
    }

    public class WordDocument: IDocument
    {
        public void Open() => Console.WriteLine("Opening WordDocument........");
        public void Save() => Console.WriteLine("Saving WordDocument........");
    
    }

    public class PDFDocument: IDocument
    {
        public void Open() => Console.WriteLine("Opening PDFDocument........");
        public void Save() => Console.WriteLine("Saving PDFDocument........");
    }

    public class ExcelDocument: IDocument
    {
        public void Open() => Console.WriteLine("Opening ExcelDocument........");
        public void Save() => Console.WriteLine("Saving ExcelDocument........");
    }
}