using DocumentFormat.OpenXml.Packaging;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;



namespace linkedin.Models
{
    public static class CVExtractor
    {
        public static string ExtractText(string filePath)
        {
            if (filePath.EndsWith(".pdf"))
                return ExtractPdf(filePath);

            if (filePath.EndsWith(".docx"))
                return ExtractDocx(filePath);

            return string.Empty;
        }

        private static string ExtractPdf(string filePath)
        {
            using (PdfReader reader = new PdfReader(filePath))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                    sb.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                return sb.ToString();
            }
        }

        private static string ExtractDocx(string filePath)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                return string.Join(" ", doc.MainDocumentPart.Document.Body
                    .Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>()
                    .Select(t => t.Text));
            }
        }
    }
}

