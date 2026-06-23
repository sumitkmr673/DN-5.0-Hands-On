using System;

namespace FactoryMethodPatternExample
{
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
        public void ProcessDocument()
        {
            IDocument doc = CreateDocument();
            doc.Open();
            doc.Save();
        }
    }

    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }
    public class PDFDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PDFDocument();
        }
    }
    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }
}