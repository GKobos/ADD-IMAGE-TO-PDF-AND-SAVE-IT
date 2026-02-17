using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;

class Program
{
    static void Main(){

        string inputFolder = @"LINK1";
        string outputFolder = @"LINK2";
        string imagePath = @"LINK3";

        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);

        string[] pdfFiles = Directory.GetFiles(inputFolder, "*.pdf");

        foreach (var inputPdf in pdfFiles){

            string fileName = System.IO.Path.GetFileName(inputPdf);
            string outputPdf = System.IO.Path.Combine(outputFolder, fileName);

            PdfReader reader = new PdfReader(inputPdf);
            PdfWriter writer = new PdfWriter(outputPdf);
            PdfDocument pdfDoc = new PdfDocument(reader, writer);
            Document document = new Document(pdfDoc);

            ImageData imageData = ImageDataFactory.Create(imagePath);
            Image image = new Image(imageData);

            image.SetFixedPosition(1, 460, 50);
            image.ScaleToFit(100, 100);

            document.Add(image);

            document.Close();

            Console.WriteLine($"The Photo Added to the PDF: {fileName}");
        }

        Console.WriteLine("All the PDFS are Ready.");
    }
}
