using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using BusinessEntities;
using DataModel;
using System.Web;

namespace BusinessLogic
{
    public class IRepositories
    {
        public readonly string _myRep;
        //public IRepositories(T myRep)
        //{
        //    _myRep = myRep;
        //}
        //public string CommaSeperatedString(string str)
        //{
        //    myrep.
        //    string _CommaSeperatedString = string.Empty;
        //    int[] idArr = str.Split(',').Select(x => int.Parse(x)).ToArray();
        //    foreach (int id in idArr)
        //    {

        //        //_CommaSeperatedString=
        //    }
        //    return _CommaSeperatedString;
        //}
    }


    public class RFQService : IRFQService
    {
        private readonly IRFQRepository _RFQRepository;
        private readonly IRFQDetailsRepository _rFQDtRepository;
        private readonly IEmployeeRepository _EmpRepository;
        private readonly ISupplierRepository _SuppRepository;
        private readonly IItemMasterRepository _ItemRepository;
        private readonly IUnitRepository _UnitRespsitory;
        private readonly ITaxRepsitory _TaxRespository;
        private readonly IUnitOfWork _unitOfWork;
        private static LoginVM user;
        public RFQService()
        {
            _unitOfWork = new UnitOfWork(new MyApp_BitSolveEntities());
            _RFQRepository = new RFQRepository(_unitOfWork);
            _rFQDtRepository = new REQDetailsRepository(_unitOfWork);
            _EmpRepository = new EmployeeRepository(_unitOfWork);
            _SuppRepository = new SupplierRepository(_unitOfWork);
            _ItemRepository = new ItemMasterRepository(_unitOfWork);
            _UnitRespsitory = new UnitRepository(_unitOfWork);
            _TaxRespository = new TaxRepository(_unitOfWork);
            if (HttpContext.Current.Session["User"] != null)
                {
                     user = (LoginVM)HttpContext.Current.Session["User"];
            }
        }


        public IEnumerable<RFQVM> GetAllRFQ()
        {
            try
            {
                var RFQList = _RFQRepository.GetAll(x => x.isDeleted == false);
                
                    List<RFQVM> RFQVMList = new List<RFQVM>();
                    if (RFQList != null)
                    {
                        foreach (var item in RFQList)
                        {
                            RFQVM rfq = new RFQVM();

                            rfq.BidValidUntil = item.BidValidUntil;
                            rfq.CompanyName = item.CompanyName;
                            rfq.createdByName = _EmpRepository.GetById(item.createdBy).FirstName;
                            rfq.CreatedDate = item.CreatedDate.Value.Date;
                            rfq.ModifiedByName = _EmpRepository.GetById((int)item.ModifiedBy).FirstName;
                            rfq.ModifiedDate = item.ModifiedDate.Value.Date;
                            rfq.DeliverTo = item.DeliverTo;
                            rfq.OrderDate = item.OrderDate.Value.Date;
                            rfq.RfqDate = item.RfqDate.Value.Date;
                            rfq.RfqId = item.RfqId;
                            rfq.RfqNo = item.RfqNo;
                            rfq.ScheduleDate = item.ScheduleDate.Value.Date;
                            int[] sIdArr = item.SupplierId.Split(',').Select(x => int.Parse(x)).ToArray();
                            foreach (var sid in sIdArr)
                            {
                                rfq.SupplierName += _SuppRepository.GetById(sid).SupplierName + " ,";
                            }
                            rfq.SupplierName = rfq.SupplierName.TrimEnd(',');
                            
                            rfq.SupplierId = item.SupplierId; // _SuppRepository.GetById(item.SupplierId);
                            rfq.IsEmailSent = (bool)item.IsEmailSent;
                            rfq.TotalAmount = item.TotalAmount;
                            RFQVMList.Add(rfq);

                            //---------------------------------------------------
                            //Array.ForEach(sIdArr, element =>rfq.SupplierName += _SuppRepository.GetById(element).SupplierName + " ,");
                            //rfq.SupplierName = rfq.SupplierName.TrimEnd(',');
                        }
                    }
                
                    return RFQVMList;
                
            }
            catch (Exception e) { throw e; }
        }

       

        public RFQVM GetRFQById(int id)
        {
            try
            {
                var item = _RFQRepository.GetById(id);
                RFQVM rfq = new RFQVM();
                rfq.BidValidUntil = item.BidValidUntil;
                rfq.CompanyName = item.CompanyName;
                rfq.createdByName = _EmpRepository.GetById(item.createdBy).FirstName;
                rfq.CreatedDate = item.CreatedDate.Value.Date;
                rfq.ModifiedByName = _EmpRepository.GetById((int)item.ModifiedBy).FirstName;
                rfq.ModifiedDate = item.ModifiedDate.Value.Date;
                rfq.DeliverTo = item.DeliverTo;
                rfq.OrderDate = item.OrderDate;
                rfq.RfqDate = item.RfqDate;
                rfq.RfqId = item.RfqId;
                rfq.RfqNo = item.RfqNo;
                rfq.ScheduleDate = item.ScheduleDate;
                rfq.SupplierId = item.SupplierId;
                int[] suppIdArr = item.SupplierId.Split(',').Select(x => int.Parse(x)).ToArray();
                foreach (int sid in suppIdArr)
                {
                rfq.SupplierName +=  _SuppRepository.GetById(sid).SupplierName +" ," ;  
                }
                rfq.SupplierName = rfq.SupplierName.TrimEnd(',');
                rfq.hdnSupplierIds = item.SupplierId;
                rfq.IsEmailSent = (bool)item.IsEmailSent;
                rfq.TotalAmount = item.TotalAmount;

                var detailsList = _rFQDtRepository.GetAll(x => x.RfqId == id).Select(x => new RFQDetailsVM
                {
                    Description = x.Description,
                    ItemId = x.ItemId,
                    ItemName = _ItemRepository.GetById(x.ItemId).ItemName,
                    ManufacturedBy = x.ManufacturedBy,
                    Price = x.Price,
                    Qty = x.Qty,
                    RfqDetailsId = x.RfqDetailsId,
                    RfqId = x.RfqId,
                    SubTotal = x.SubTotal,
                    TaxId = x.TaxId,
                    TaxName = _TaxRespository.GetById(x.TaxId).TaxName,
                    UnitId = x.UnitId,
                    UnitName = _UnitRespsitory.GetById(x.UnitId).Unit
                }).ToList();

                rfq._RFQDetailsVMList = detailsList;
                return rfq;
            }
            catch (Exception e) { throw e; }
        }

        public bool AddRFQ(RFQVM _RFQVM)
        {
            try
            {
                if (_RFQVM != null)
                {
                    tblRFQ rfq = new tblRFQ();
                    rfq.BidValidUntil = _RFQVM.BidValidUntil;
                    rfq.CompanyName = _RFQVM.CompanyName;
                    rfq.DeliverTo = _RFQVM.DeliverTo;
                    rfq.OrderDate = _RFQVM.OrderDate;
                    rfq.RfqDate = _RFQVM.RfqDate;
                    rfq.RfqNo = _RFQVM.RfqNo;
                    rfq.ScheduleDate = _RFQVM.ScheduleDate;
                    rfq.SupplierId = _RFQVM.SupplierId;
                    rfq.TotalAmount = _RFQVM.TotalAmount;
                    rfq.createdBy = user.RoleId;
                    rfq.CreatedDate = System.DateTime.Now;
                    rfq.ModifiedDate = System.DateTime.Now;
                    rfq.ModifiedBy = user.RoleId;
                    rfq.isDeleted = false;
                    rfq.IsEmailSent = false;
                    _RFQRepository.Add(rfq);

                    foreach (var detail in _RFQVM._RFQDetailsVMList)
                    {
                        tblRFQDetail rfqdt = new tblRFQDetail();
                        rfqdt.Description = detail.Description;
                        rfqdt.ItemId = detail.ItemId;
                        rfqdt.ManufacturedBy = detail.ManufacturedBy;
                        rfqdt.Price = detail.Price;
                        rfqdt.Qty = detail.Qty;
                        rfqdt.RfqId = rfq.RfqId;
                        rfqdt.SubTotal = detail.SubTotal;
                        rfqdt.TaxId = detail.TaxId;
                        rfqdt.UnitId = detail.UnitId;
                        rfqdt.isDeleted = false;
                        _rFQDtRepository.Add(rfqdt);
                    }
                    _unitOfWork.Complete();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateRFQ(RFQVM _RFQVM)
        {
            try
            {
                if (_RFQVM != null)
                {
                    tblRFQ rfq = _RFQRepository.GetById(_RFQVM.RfqId);
                    rfq.BidValidUntil = _RFQVM.BidValidUntil;
                    rfq.CompanyName = _RFQVM.CompanyName;
                    rfq.DeliverTo = _RFQVM.DeliverTo;
                    rfq.OrderDate = _RFQVM.OrderDate;
                    rfq.RfqDate = _RFQVM.RfqDate;
                    rfq.RfqNo = _RFQVM.RfqNo;
                    rfq.ScheduleDate = _RFQVM.ScheduleDate;
                    rfq.SupplierId = _RFQVM.SupplierId;
                    rfq.TotalAmount = _RFQVM.TotalAmount;
                    rfq.ModifiedBy = user.RoleId;
                    rfq.ModifiedDate = System.DateTime.Now;
                    _RFQRepository.Update(rfq);

                    foreach (var detail in _RFQVM._RFQDetailsVMList)
                    {
                        tblRFQDetail rfqdt = _rFQDtRepository.GetById(detail.RfqDetailsId);
                        rfqdt.Description = detail.Description;
                        rfqdt.ItemId = detail.ItemId;
                        rfqdt.ManufacturedBy = detail.ManufacturedBy;
                        rfqdt.Price = detail.Price;
                        rfqdt.Qty = detail.Qty;
                        rfqdt.RfqId = rfq.RfqId;
                        rfqdt.SubTotal = detail.SubTotal;
                        rfqdt.TaxId = detail.TaxId;
                        rfqdt.UnitId = detail.UnitId;
                        _rFQDtRepository.Update(rfqdt);
                    }
                    _unitOfWork.Complete();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteRFQ(int id)
        {
            try
            {
                var rfq = _RFQRepository.GetById(id);
                var refDt = _rFQDtRepository.GetAll(x => x.isDeleted == false);
                if (rfq != null || refDt != null)
                {
                    rfq.isDeleted = true;
                    _RFQRepository.Update(rfq);

                    foreach (var item in refDt)
                    {
                        item.isDeleted = true;
                        _rFQDtRepository.Update(item);
                    }

                    _unitOfWork.Complete();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public Decimal GetTaxValue(int taxid)
        {
            return (decimal)_TaxRespository.GetById(taxid).TaxValue;;
        }

        public SupplierVM GetSupplier(int id)
        {
            var Supplier = _SuppRepository.GetById(id);
            SupplierVM svm = new SupplierVM();
            if (Supplier != null)
            {
                svm.SupplierCode = Supplier.SupplierCode;
                svm.SupplierId = Supplier.SupplierId;
                svm.SupplierName = Supplier.SupplierName;
                svm.Email = Supplier.Email;
            }
            return svm;
        }

        public bool SetMailSend(int rfqId)
        {
            try
            {
                if (rfqId != 0)
                {
                    tblRFQ rfq = _RFQRepository.GetById(rfqId);
                    rfq.IsEmailSent = true;
                    _RFQRepository.Update(rfq);
                    _unitOfWork.Complete();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
