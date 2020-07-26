using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel;
using Repository;
using System.Web;

namespace BusinessLogic
{
    public class BidService : IBidService
    {

        private readonly IRFQRepository _RFQRepository;
        private readonly IRFQDetailsRepository _rFQDtRepository;
        private readonly IEmployeeRepository _EmpRepository;
        private readonly ISupplierRepository _SuppRepository;
        private readonly IItemMasterRepository _ItemRepository;
        private readonly IUnitRepository _UnitRespsitory;
        private readonly ITaxRepsitory _TaxRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBidMasterRepository _BidMasterRep;
        private readonly IBidDetailsRepository _BidDetailsRep;
        private static LoginVM user = new LoginVM();
        public BidService()
        {
            _unitOfWork =  new UnitOfWork(new MyApp_BitSolveEntities());
            _RFQRepository = new RFQRepository(_unitOfWork);
            _rFQDtRepository = new REQDetailsRepository(_unitOfWork);
            _EmpRepository = new EmployeeRepository(_unitOfWork);
            _SuppRepository = new SupplierRepository(_unitOfWork);
            _ItemRepository = new ItemMasterRepository(_unitOfWork);
            _UnitRespsitory = new UnitRepository(_unitOfWork);
            _TaxRespository = new TaxRepository(_unitOfWork);
            _BidMasterRep = new BidMasterRepository(_unitOfWork);
            _BidDetailsRep = new BidDetailsRepository(_unitOfWork);
            if (HttpContext.Current.Session["User"] != null)
            {
                user = (LoginVM)HttpContext.Current.Session["User"];
            }
        }

        public IEnumerable<BidMasterVM> GetAllBid()
        {
            try
            {
                var BidDetails = _BidMasterRep.GetAll(x => x.IsDeleted == false);
                List<BidMasterVM> _BidList = new List<BidMasterVM>();
                if (BidDetails != null)
                {
                    foreach (var x in BidDetails)
                    {
                        BidMasterVM bid = new BidMasterVM();
                        bid.BidDate = x.BidDate;
                        bid.BidId = x.BidId;
                        bid.BidNo = x.BidNo;
                        bid.CreatedBy = x.CreatedBy;
                        bid.CreatedDate = x.CreatedDate;
                        bid.NetAmount = x.NetAmount;
                        bid.TotalAmount = x.TotalAmount;
                        bid.RFQNO = _RFQRepository.GetById((long)x.RFQId).RfqNo;
                        bid.RFQDate = (DateTime)_RFQRepository.GetById((long)x.RFQId).RfqDate;
                        //int[] sids = x.supplierId.Split(',').Select(y => int.Parse(y)).ToArray();
                        //foreach (var supp in sids)
                        //{
                        //    bid.SupplierName += _SuppRepository.GetById(supp).SupplierName + ",";
                        //    bid.SupplierCode += _SuppRepository.GetById(supp).SupplierCode + ",";
                        //}
                        bid.SupplierName = _SuppRepository.GetById(int.Parse(x.supplierId)).SupplierName;
                        bid.SupplierCode = _SuppRepository.GetById(int.Parse(x.supplierId)).SupplierCode;
                        _BidList.Add(bid);
                    }
                }
                return _BidList;
            }
            catch (Exception e) { throw e; }

        }


        public BidMasterVM GetRFQDetailsById(int rfqId, int suppid)
        {
            try
            {
                var rfqDet = _RFQRepository.GetById(rfqId);
                BidMasterVM bid = new BidMasterVM();

                bid.RFQNO = rfqDet.RfqNo;
                bid.RFQDate = (DateTime)rfqDet.RfqDate;
                bid.SupplierCode = _SuppRepository.GetById(suppid).SupplierCode;
                bid.BidValidUntil = (DateTime)rfqDet.BidValidUntil;
                bid.CompanyName = rfqDet.CompanyName;
                bid.DeliverTo = rfqDet.DeliverTo;
                bid.OrderDate = (DateTime)rfqDet.OrderDate;
                bid.ScheduleDate = (DateTime)rfqDet.ScheduleDate;
                var rfqDetList = _rFQDtRepository.GetAll(x => x.RfqId == rfqId && x.isDeleted == false).Select(
                    x => new BidDetailsVM
                    {
                        RfqDetailsId = x.RfqDetailsId,
                        ItemId = x.ItemId,
                        ItemName = _ItemRepository.GetById(x.ItemId).ItemName,
                        Description = x.Description,
                        ManufacturedBy = x.ManufacturedBy,
                        Price = x.Price,
                        Qty = x.Qty,
                        SubTotal = x.SubTotal,
                        TaxId = x.TaxId,
                        Tax = _TaxRespository.GetById(x.TaxId).TaxName,
                        UnitId = x.UnitId,
                        Unit = _UnitRespsitory.GetById(x.UnitId).abbreviation
                    }).ToList();
                bid._BidDetailsVMList = rfqDetList;
                return bid;
            }
            catch (Exception e) { throw e; }

        }

        //public List< BidDetailsVM> GetRFQDetailsListById(int rfqId)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception e) { throw e; }
        //}

        public BidMasterVM GetBidById(int id)
        {
            try
            {
                var bidMaster = _BidMasterRep.GetById(id);
                var rfqMaster=_RFQRepository.GetById((long)bidMaster.RFQId);
                BidMasterVM _bidVM = new BidMasterVM();
                _bidVM.BidId = bidMaster.BidId;
                _bidVM.BidDate = bidMaster.BidDate;
                _bidVM.BidNo = bidMaster.BidNo;
                //_bidVM.CreatedBy = bidMaster.CreatedBy == null ? string.Empty : bidMaster.CreatedBy;
                _bidVM.CreatedDate = bidMaster.CreatedDate;
                _bidVM.NetAmount = bidMaster.NetAmount;
                _bidVM.RFQDate = (DateTime)_RFQRepository.GetById((long)bidMaster.RFQId).RfqDate;
                _bidVM.RFQId = bidMaster.RFQId;
                _bidVM.RFQNO = _RFQRepository.GetById((long)bidMaster.RFQId).RfqNo;
                _bidVM.SupplierCode = _SuppRepository.GetById(int.Parse(bidMaster.supplierId)).SupplierCode;
                _bidVM.supplierId = bidMaster.supplierId;
                _bidVM.SupplierName = _SuppRepository.GetById(int.Parse(bidMaster.supplierId)).SupplierName;
                _bidVM.TotalAmount = bidMaster.TotalAmount;
                _bidVM.DeliverTo = rfqMaster.DeliverTo;
                _bidVM.OrderDate = rfqMaster.OrderDate;
                _bidVM.ScheduleDate = rfqMaster.ScheduleDate;
                _bidVM.BidValidUntil = rfqMaster.BidValidUntil;
                _bidVM.CompanyName = rfqMaster.CompanyName;

                var bidDetails = _BidDetailsRep.GetAll(x => x.BidId == id && x.isDeleted == false);
                List<BidDetailsVM> bdtlist = new List<BidDetailsVM>();
                foreach (var item in bidDetails)
                {
                    BidDetailsVM bdt = new BidDetailsVM();
                    bdt.BidDetailId = item.BidDetailId;
                    bdt.BidId = item.BidId;
                    bdt.Description = item.Description;
                    bdt.HSN = item.HSN;
                    bdt.ItemId = item.ItemId;
                    bdt.ItemName = _ItemRepository.GetById(item.ItemId).ItemName;
                    bdt.ManufacturedBy = item.ManufacturedBy;
                    bdt.Price = item.Price;
                    bdt.Qty = item.Qty;
                    bdt.RfqDetailsId = item.RfqDetailsId;
                    bdt.SubTotal = item.SubTotal;
                    bdt.TaxId = item.TaxId;
                    bdt.UnitId = item.UnitId;
                    bdtlist.Add(bdt);
                }
                _bidVM._BidDetailsVMList = bdtlist;
                return _bidVM;

            }
            catch (Exception e) { throw e; }
        }

        public bool AddBid(BidMasterVM _BidVM)
        {
            try
            {
                if (_BidVM != null)
                {
                    tblBidMaster bidMaster = new tblBidMaster();
                    bidMaster.BidDate = _BidVM.BidDate;
                    bidMaster.BidNo = _BidVM.BidNo;
                    bidMaster.CreatedBy = user.LoginId == null ? 0 : user.LoginId;
                    bidMaster.CreatedDate = System.DateTime.Now;
                    bidMaster.IsDeleted = false;
                    bidMaster.ModifiedBy = user.LoginId == null ? 0 : user.LoginId;
                    bidMaster.ModifiedDate = System.DateTime.Now;
                    bidMaster.NetAmount = _BidVM.NetAmount;
                    bidMaster.RFQId = _BidVM.RFQId;
                    bidMaster.supplierId = _BidVM.supplierId;
                    bidMaster.TotalAmount = _BidVM.TotalAmount;
                    _BidMasterRep.Add(bidMaster);

                    foreach (var item in _BidVM._BidDetailsVMList)
                    {
                        if (item != null)
                        {
                            tblBidDetail bdt = new tblBidDetail();
                            bdt.BidId = bidMaster.BidId;
                            bdt.Description = item.Description;
                            bdt.HSN = item.HSN;
                            bdt.ItemId = item.ItemId;
                            bdt.ManufacturedBy = item.ManufacturedBy;
                            bdt.Price = item.Price;
                            bdt.Qty = item.Qty;
                            bdt.SubTotal = item.SubTotal;
                            bdt.TaxId = item.TaxId;
                            bdt.UnitId = item.UnitId;
                            _BidDetailsRep.Add(bdt);
                        }
                        else { return false; }
                    }
                    _unitOfWork.Complete();
                    return true;
                }
                else { return false; }
            }
            catch (Exception e) { return false; }
        }

        public bool UpdateBid(BidMasterVM _BidVM)
        {
            try
            {
                if (_BidVM != null)
                {
                    tblBidMaster bidMaster = _BidMasterRep.GetById(_BidVM.BidId);
                    bidMaster.BidDate = _BidVM.BidDate;
                    bidMaster.BidNo = _BidVM.BidNo;
                    bidMaster.CreatedBy = user.LoginId == null ? 0 : user.LoginId;
                    bidMaster.CreatedDate = System.DateTime.Now;
                    bidMaster.IsDeleted = false;
                    bidMaster.ModifiedBy = user.LoginId == null ? 0 : user.LoginId;
                    bidMaster.ModifiedDate = _BidVM.ModifiedDate;
                    bidMaster.NetAmount = _BidVM.NetAmount;
                    bidMaster.RFQId = _BidVM.RFQId;
                    bidMaster.supplierId = _BidVM.supplierId;
                    bidMaster.TotalAmount = _BidVM.TotalAmount;
                    _BidMasterRep.Update(bidMaster);

                    //foreach (var item in _BidVM._BidDetailsVMList)
                    //{
                    //    if (item != null)
                    //    {
                    //        tblBidDetail bdt = new tblBidDetail();
                    //        bdt.BidId = bidMaster.BidId;
                    //        bdt.Description = item.Description;
                    //        bdt.HSN = item.HSN;
                    //        bdt.ItemId = item.ItemId;
                    //        bdt.ManufacturedBy = item.ManufacturedBy;
                    //        bdt.Price = item.Price;
                    //        bdt.Qty = item.Qty;
                    //        bdt.SubTotal = item.SubTotal;
                    //        bdt.TaxId = item.TaxId;
                    //        bdt.UnitId = item.UnitId;
                    //        _BidDetailsRep.Add(bdt);
                    //    }
                    //    else { return false; }
                    //}
                    //_unitOfWork.Complete();
                    return true;
                }
                else { return false; }
            }
            catch (Exception e) { return false; }
        }

        public bool DeleteBid(int id)
        {
            try
            {
                var bid = _BidMasterRep.GetById(id);
                var bidDt = _BidDetailsRep.GetAll(x => x.BidId == id);
                bid.IsDeleted = true;
                _BidMasterRep.Update(bid);
                foreach (var item in bidDt)
                {
                    if (item != null)
                    {
                        item.isDeleted = true;
                        _BidDetailsRep.Update(item);
                    }
                }
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception e) { return false; throw e; }
        }





    }
}
