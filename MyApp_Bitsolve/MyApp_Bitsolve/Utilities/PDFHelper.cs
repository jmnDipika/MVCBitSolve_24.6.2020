using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyApp_Bitsolve
{
    public static class PDFHelper
    {
        public static void AddCellToHeader(PdfPTable _pdfTable, string cellText)
        {
            _pdfTable.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.COURIER, 10, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        public static void AddCellToBody(PdfPTable _pdfTable, string cellText)
        {
            _pdfTable.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.COURIER, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }

    }
}