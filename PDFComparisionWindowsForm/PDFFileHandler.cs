using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using DiffMatchPatch;


namespace PDFComparisionWindowsForm
{
    class PDFFileHandler
    {
        private TextBox filePath;
        private TextBox filePath2;
        iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph();
        public string changed_text;
        public string equal_text;
        public string deleted_text;
        public string whole_text;
        public string text1;
        

        public PDFFileHandler(TextBox filePath, TextBox filePath2)
        {
            this.filePath = filePath;
            this.filePath2 = filePath2;
        }
        public string ReadFile(TextBox pdfPath)
        {
            var pageText = new StringBuilder();
            using (PdfDocument pdfDocument = new PdfDocument(new iText.Kernel.Pdf.PdfReader(pdfPath.Text)))
            {
                var pageNumbers = pdfDocument.GetNumberOfPages();
                for (int i = 1; i <= pageNumbers; i++)
                {
                    LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                    PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
                    parser.ProcessPageContent(pdfDocument.GetFirstPage());
                    pageText.Append(strategy.GetResultantText());
                }
            }
            return pageText.ToString();
        }

        public string ComparePdfFiles()
        {
            var dmp = DiffMatchPatchModule.Default;
            StringBuilder compareResult = new StringBuilder();
             text1 = ReadFile(filePath);
            var text2 = ReadFile(filePath2);
            var diff = dmp.DiffMain(text1, text2);
            foreach (var d in diff)
            {
                whole_text = d.Text;
                if (d.Operation.IsEqual)
                {

                    compareResult.Append(d.Text + " ");
                    equal_text = d.Text;
                   
                    p.SpacingBefore = 10;
                    p.SpacingAfter = 10;
                    p.Alignment = Element.ALIGN_LEFT;
                    p.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.BLUE);
                    p.Add(d.Text);
                }
                else if (d.Operation.IsInsert)
                {
                    compareResult.Append(d.Text + " ");
                    changed_text = d.Text;
                  
                    p.SpacingBefore = 10;
                    p.SpacingAfter = 10;
                    p.Alignment = Element.ALIGN_LEFT;
                    p.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.RED);
                    p.Add(d.Text);
                }
                else if (d.Operation.IsDelete)
                {
                    compareResult.Append(d.Text + " ");
                    deleted_text = d.Text;
                   
                    p.SpacingBefore = 10;
                    p.SpacingAfter = 10;
                    p.Alignment = Element.ALIGN_LEFT;
                    p.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
                    p.Add(d.Text);
                }
             
               
            }

            return compareResult.ToString();

        }
        
        public void GeneratePdf(string[] paragraphs, string destination)
        {
           
            Document document = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream("D:/create.pdf", FileMode.Create));
                document.Open();
            document.Add(p);
           
            document.Close();
           
        }
        }
    }
