using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;
using System.Net.Mail;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Xml;
using iTextSharp.tool.xml;

namespace MyApp_Bitsolve.Controllers
{
    public class RFQController : Controller
    {
        private IRFQService _RFQSerivce;
        private BusinessDropDownList dropDown;
        public RFQController()
        {
            _RFQSerivce = new RFQService();
            dropDown = new BusinessDropDownList();
        }
        //
        // GET: /RFQ/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RFQ()
        {
            return View();
        }

        public JsonResult AutoCompleteItemList(string itemname)
        {
            var items = dropDown.DDLGetItems(itemname);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTaxValue(int taxid)
        {
            return Json(_RFQSerivce.GetTaxValue(taxid), JsonRequestBehavior.AllowGet);
        }

       [HttpGet]
        public ActionResult RFQList()
        {
            var rfqList = _RFQSerivce.GetAllRFQ();
            return PartialView(rfqList);
        }

        [HttpGet]
        public ActionResult ShowRFQDetails(int id)
        {
            RFQVM rfqVM = new RFQVM();
            if (id != 0)
            {
                rfqVM = _RFQSerivce.GetRFQById(id);
            }
            return PartialView(rfqVM);
        }

        [HttpGet]
        public ActionResult AddOrEditRFQ(int id = 0)
        {
            RFQVM rfqVM = new RFQVM();
            RFQDetailsVM rfqdt = new RFQDetailsVM();
            rfqVM._RFQDetailsVM = rfqdt;
            ViewBag.supplierList = dropDown.DDLGetSuppliers();
            //ViewBag.ItemList = DropDownLists.DDLGetItems();
            ViewBag.UnitList = dropDown.DDLGetUnits();
            ViewBag.TaxList = dropDown.DDLGetTax();
            ViewBag.message = "";
            if (id == 0)
            {
                return PartialView(rfqVM);
            }
            else
            {
                return PartialView(rfqVM);
            }

        }

        [HttpPost]
        public ActionResult DeleteRFQ(int id)
        {
            try
            {
                bool status = false;

                status = _RFQSerivce.DeleteRFQ(id);
                if (status)
                {
                    return Json(new { success = true, message = "Deleted Successfully...!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Error...!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { throw e; }

        }

        [HttpPost]
        public ActionResult AddOrEditRFQ(RFQVM _RFQVM)
        {
            try
            {
                ViewBag.supplierList = dropDown.DDLGetSuppliers();
                ViewBag.ItemList = dropDown.DDLGetItems();
                ViewBag.UnitList = dropDown.DDLGetUnits();
                ViewBag.TaxList = dropDown.DDLGetTax();

                if (ModelState.IsValid)
                {
                    //save rfq and details
                    bool status = false;
                    status = _RFQSerivce.AddRFQ(_RFQVM);
                    if (status)
                    {
                        return Json(new { success = true, message = "Saved Successfully...!" }, JsonRequestBehavior.AllowGet);
                    }
                    else { return Json(new { success = false, message = "Error..!" }, JsonRequestBehavior.AllowGet); }

                }
                else
                {
                    return PartialView(_RFQVM);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost]
        public ActionResult SendRFQ(int id)
        {
            RFQVM rfq = new RFQVM();
            if (id != 0)
            {
                try
                {
                    rfq = _RFQSerivce.GetRFQById(id);
                    bool isSend = false;
                    int[] Arrid = rfq.SupplierId.Split(',').Select(x => int.Parse(x)).ToArray();
                    foreach (var sid in Arrid)
                    {
                        var supp = _RFQSerivce.GetSupplier(sid);
                        isSend = SendEmailForRFQ(rfq, supp.Email, supp.SupplierName, supp.SupplierCode);
                    }
                    if (isSend)
                    {
                        _RFQSerivce.SetMailSend(id);
                        // ViewBag.message = "Mail sent successfully..";
                        return Json(new { message = "Mail sent successfully.." }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        // ViewBag.message = "Error in email processing..";
                        return Json(new { message = "Error in email processing.." }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception e) { throw e; }
            }
            else { return Json(new { message = "Error in email processing.." }, JsonRequestBehavior.AllowGet); }
        }

        [NonAction]
        public bool SendEmailForRFQ(RFQVM _RFQVM, string emailId, string suppName, string suppCode)
        {
            try
            {
                string strPDFFileName = string.Format("RFQ" + DateTime.Now.ToString("yyyyMMdd") + suppCode + ".pdf");
                string strAttachment = Server.MapPath("~/EmpProfileImages/" + strPDFFileName);
                //call fun to convert in to pdf 
                ConvertIntoPDF(_RFQVM, suppName, suppCode, strAttachment);
                string subject = "";
                string body = "";

                subject = "Company Name - RFQ Details";
                body = "Dear " + suppName + ",<br/><br/> Your Supplier Code: " + suppCode +
                    "<br/><br/><br/> Your Matter ";

                MailMessage mailMessage = new MailMessage()
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                //attach that pdf to mailmessage
                mailMessage.Attachments.Add(new Attachment(strAttachment));
                mailMessage.To.Add(new MailAddress(emailId));
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [NonAction]
        public void ConvertIntoPDF(RFQVM rfq, string suppName, string suppCode, string strAttachment)
        {
            string strheader = "RFQ Details";
            FileStream fs = new FileStream(strAttachment, FileMode.Create, FileAccess.Write, FileShare.None);
            Document _document = new Document();
            _document.SetPageSize(PageSize.A4);
            PdfWriter _pdfWriter = PdfWriter.GetInstance(_document, fs);
            _document.Open();

            //pdf Header
            BaseFont _basefontHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font _fontHeader = new Font(_basefontHead, 16, 1, BaseColor.GRAY);
            Paragraph _prgHeading = new Paragraph();
            _prgHeading.Alignment = Element.ALIGN_CENTER;
            _prgHeading.Add(new Chunk(strheader.ToUpper(), _fontHeader));
            _document.Add(_prgHeading);

            //Supplier Details
            Paragraph _prgSupp = new Paragraph();
            BaseFont _basefontSupp = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font _fontSupp = new Font(_basefontSupp, 8, 1, BaseColor.DARK_GRAY);
            _prgSupp.Alignment = Element.ALIGN_RIGHT;
            _prgSupp.Add(new Chunk(" Supplier Name : " + suppName, _fontSupp));
            _prgSupp.Add(new Chunk("\n Supplier Code : " + suppCode, _fontSupp));
            _prgSupp.Add(new Chunk("\n Date : " + DateTime.Now.ToShortDateString(), _fontSupp));
            _document.Add(_prgSupp);

            //add line
            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0f, 100.0f, BaseColor.BLACK, Element.ALIGN_LEFT, -1)));
            _document.Add(line);
            _document.Add(new Chunk("\n", _fontHeader));

            //Other Master Details
            //Supplier Details
            //Paragraph _prgMaster = new Paragraph();
            //BaseFont _basefontMaster = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //Font _fontMaster = new Font(_basefontMaster, 8, 1, BaseColor.DARK_GRAY);
            //_prgMaster.Alignment = Element.ALIGN_LEFT;
            //_prgMaster.Add(new Chunk(" RFQ No.            :  " + rfq.RfqNo, _fontMaster));
            //_prgMaster.Add(new Chunk("\n RFQ Date         :  " + rfq.RfqDate.Value.ToShortDateString(), _fontMaster));
            //_prgMaster.Add(new Chunk("\n Order Date       :  " + rfq.OrderDate.Value.ToShortDateString(), _fontMaster));
            //_prgMaster.Add(new Chunk("\n Company Name     :  " + rfq.CompanyName, _fontMaster));
            //_prgMaster.Add(new Chunk("\n Deliver To       :  " + rfq.DeliverTo, _fontMaster));
            //_prgMaster.Add(new Chunk("\n Schedule Date    :  " + rfq.ScheduleDate.Value.ToShortDateString(), _fontMaster));
            //_prgMaster.Add(new Chunk("\n Bid Valid Until  :  " + rfq.BidValidUntil.Value.ToShortDateString(), _fontMaster));
            //_prgMaster.Add(new Chunk("\n Total Amount     :  " + rfq.TotalAmount, _fontMaster));
            //_document.Add(_prgMaster);
            //_document.Add(new Chunk("\n", _fontMaster));

            PdfPTable _MasterTable = new PdfPTable(2);
            //table header
            _MasterTable.WidthPercentage = 100;
            PDFHelper.AddCellToBody(_MasterTable, "RFQ No.");
            PDFHelper.AddCellToBody(_MasterTable, rfq.RfqNo);
            PDFHelper.AddCellToBody(_MasterTable, "RFQ Date");
            PDFHelper.AddCellToBody(_MasterTable, rfq.RfqDate.Value.ToShortDateString());
            PDFHelper.AddCellToBody(_MasterTable, "Order Date");
            PDFHelper.AddCellToBody(_MasterTable, rfq.OrderDate.Value.ToShortDateString());
            PDFHelper.AddCellToBody(_MasterTable, "Company Name");
            PDFHelper.AddCellToBody(_MasterTable, rfq.CompanyName);
            PDFHelper.AddCellToBody(_MasterTable, "Deliver To");
            PDFHelper.AddCellToBody(_MasterTable, rfq.DeliverTo);

            PDFHelper.AddCellToBody(_MasterTable, "Schedule Date");
            PDFHelper.AddCellToBody(_MasterTable, rfq.ScheduleDate.Value.ToShortDateString());
            PDFHelper.AddCellToBody(_MasterTable, "Bid Valid Until");
            PDFHelper.AddCellToBody(_MasterTable, rfq.BidValidUntil.Value.ToShortDateString());
            PDFHelper.AddCellToBody(_MasterTable, "Total Amount");
            PDFHelper.AddCellToBody(_MasterTable, rfq.TotalAmount.ToString());
            _document.Add(_MasterTable);
            _document.Add(new Chunk("\n", _fontHeader));

            //List Details in table
            PdfPTable _pdfTable = new PdfPTable(8);
            //table header
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HeaderRows = 1;

            PDFHelper.AddCellToHeader(_pdfTable, "Item Name");
            PDFHelper.AddCellToHeader(_pdfTable, "Description");
            PDFHelper.AddCellToHeader(_pdfTable, "Manufactured By");
            PDFHelper.AddCellToHeader(_pdfTable, "Qty");
            PDFHelper.AddCellToHeader(_pdfTable, "Unit");
            PDFHelper.AddCellToHeader(_pdfTable, "Price");
            PDFHelper.AddCellToHeader(_pdfTable, "Tax");
            PDFHelper.AddCellToHeader(_pdfTable, "Sub Total");

            //table body
            if (rfq._RFQDetailsVMList.Count > 0)
            {
                foreach (var item in rfq._RFQDetailsVMList)
                {
                    PDFHelper.AddCellToBody(_pdfTable, item.ItemName);
                    PDFHelper.AddCellToBody(_pdfTable, item.Description);
                    PDFHelper.AddCellToBody(_pdfTable, item.ManufacturedBy);
                    PDFHelper.AddCellToBody(_pdfTable, item.Qty.ToString());
                    PDFHelper.AddCellToBody(_pdfTable, item.UnitName);
                    PDFHelper.AddCellToBody(_pdfTable, item.Price.ToString());
                    PDFHelper.AddCellToBody(_pdfTable, item.TaxName);
                    PDFHelper.AddCellToBody(_pdfTable, item.SubTotal.ToString());

                }
            }
            _document.Add(new Chunk("\n Requirment Details", _fontHeader));
            _document.Add(_pdfTable);
            _document.Close();
            _pdfWriter.Close();
            fs.Close();

        }//end of pdf



    }

}