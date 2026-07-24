using DocumentFormat.OpenXml.Packaging;
using UglyToad.PdfPig;

namespace NooshApp.Helpers
{
    public static class CvTextExtractor
    {
        public static string ExtractText(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();

            return extension switch
            {
                ".pdf" => ExtractFromPdf(filePath),
                ".docx" => ExtractFromDocx(filePath),
                _ => string.Empty
            };
        }

        private static string ExtractFromPdf(string filePath)
        {
            using var document = PdfDocument.Open(filePath);
            var textBuilder = new System.Text.StringBuilder();

            foreach (var page in document.GetPages())
            {
                textBuilder.AppendLine(page.Text);
            }

            return textBuilder.ToString();
        }

        private static string ExtractFromDocx(string filePath)
        {
            using var document = WordprocessingDocument.Open(filePath, false);
            var body = document.MainDocumentPart?.Document?.Body;

            return body?.InnerText ?? string.Empty;
        }
    }
}