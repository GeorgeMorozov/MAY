using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcPaging;
using StoreCheck.Models;

namespace StoreCheck.Controllers
{
    public class SprController : ApplicationController
    {
        private readonly DataManager _db = new DataManager();
        private const int defaultPageSize = 10;
        private const string ALL = "Все";
        private String searchUP = String.Empty;

        public ActionResult Spr()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");        
           return View();
        }

        #region  ---------------------------------Spr_Roles---------------------------------

        public ActionResult Spr_RolesList(int? page)
        {
            return View(_db.GetSpr_Roles().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_RoleCreate(Spr_Roles obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_Role(obj);
            return RedirectToAction("Spr_RolesList");
        }

        public ActionResult Spr_RoleDetails(Guid id)
        {
            return View(_db.GetSpr_Role(id));
        }

        public ActionResult Spr_RoleDelete(Guid id)
        {
            _db.DeleteSpr_Role(id);
            return RedirectToAction("Spr_RolesList");
        }

        [HttpGet]
        public ActionResult Spr_RoleEdit(Guid id)
        {
            return View(_db.GetSpr_Role(id));
        }

        [HttpPost]
        public ActionResult Spr_RoleEdit(Spr_Roles obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_Role(obj);
                return RedirectToAction("Spr_RolesList");
            }
            return View();
        }

        #endregion

        #region ---------------------------------Spr_Right---------------------------------

        public ActionResult Spr_RightsList(int? page)
        {
            return View(_db.GetSpr_Rights().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_RightCreate()
        {
            ViewBag.ChkBoxLst_AdmObj = _db.GetSpr_AdmObjectLst().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Spr_RightCreate(Spr_Rights obj)
        {
            obj.ID = Guid.NewGuid();
            string[] values;
            Guid AdmObjID = Guid.Empty;
            for (int i = 0; i < Request.Form.Count; i++)
            {
                values = Request.Form.GetValues(i);
                if (values != null && values[0] == "true")
                {
                    AdmObjID = Guid.Parse(Request.Form.Keys[i]);
                    break;
                }
            }
            obj.AdmObj = AdmObjID; 
            _db.AddSpr_Right(obj);
            return RedirectToAction("Spr_RightsList");
        }

        public ActionResult Spr_RightDetails(Guid id)
        {
            return View(_db.GetSpr_Right(id));
        }

        public ActionResult Spr_RightDelete(Guid id)
        {
            _db.DeleteSpr_Right(id);
            return RedirectToAction("Spr_RightsList");
        }

        [HttpGet]
        public ActionResult Spr_RightEdit(Guid id)
        {
            ViewBag.ChkBoxLst_AdmObj = _db.GetSpr_AdmObjectLst().ToList();
            return View(_db.GetSpr_Right(id));
        }

        [HttpPost]
        public ActionResult Spr_RightEdit( Spr_Roles obj)
        {
            if (ModelState.IsValid)
            {
                string[] values;
                Guid AdmObjID = Guid.Empty;
                for (int i = 0; i < Request.Form.Count; i++)
                {
                    values = Request.Form.GetValues(i);
                    if (values != null && values[0] == "true")
                    {
                        AdmObjID = Guid.Parse(Request.Form.Keys[i]);
                        break;
                    }
                }                             
                _db.SaveSpr_Right(obj, AdmObjID);
                return RedirectToAction("Spr_RightsList");
            }
            return View();
        }

        #endregion

        #region ---------------------------------Spr_CAP---------------------------------

        public ActionResult Spr_CAPList(int? page)
        {
            return View(_db.GetSpr_CAPs().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_CAPCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_CAPCreate(Spr_CAP obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_CAP(obj);
            return RedirectToAction("Spr_CAPList");
        }

        public ActionResult Spr_CAPDetails(Guid id)
        {
            return View(_db.GetSpr_CAP(id));
        }

        public ActionResult Spr_CAPDelete(Guid id)
        {
            _db.DeleteSpr_CAP(id);
            return RedirectToAction("Spr_CAPList");
        }

        [HttpGet]
        public ActionResult Spr_CAPEdit(Guid id)
        {
            return View(_db.GetSpr_CAP(id));
        }

        [HttpPost]
        public ActionResult Spr_CAPEdit(Spr_CAP obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_CAP(obj);
                return RedirectToAction("Spr_CAPList");
            }
            return View();

        }

        #endregion

        #region ---------------------------------Spr_TypeAkciya---------------------------------

        public ActionResult Spr_TypeAkciyaList(int? page)
        {
            return View(_db.GetSpr_TypeAkciya().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_TypeAkciyaCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_TypeAkciyaCreate(Spr_TypeAkciya obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_TypeAkciya(obj);
            return RedirectToAction("Spr_TypeAkciyaList");
        }

        public ActionResult Spr_TypeAkciyaDetails(Guid id)
        {
            return View(_db.GetSpr_TypeAkciya(id));
        }

        public ActionResult Spr_TypeAkciyaDelete(Guid id)
        {
            _db.DeleteSpr_TypeAkciya(id);
            return RedirectToAction("Spr_TypeAkciyaList");
        }

        [HttpGet]
        public ActionResult Spr_TypeAkciyaEdit(Guid id)
        {
            return View(_db.GetSpr_TypeAkciya(id));
        }

        [HttpPost]
        public ActionResult Spr_TypeAkciyaEdit(Spr_TypeAkciya obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_TypeAkciya(obj);
                return RedirectToAction("Spr_TypeAkciyaList");
            }
            return View();

        }

        #endregion

        #region ---------------------------------Spr_SR---------------------------------

        [HttpGet]
        public ActionResult Spr_SRList(
                                        string SBU, string RegNm, string OblNm, string DistNm, string CodeTA, string TypeTA, string TA, string RouteTA,
                                        string _SBU, string _RegNm, string _OblNm, string _DistNm, string _CodeTA, string _TypeTA, string _TA, string _RouteTA, 
                                        int? page, int SortBy = 1, bool isAsc = true, string search = null
                                      )
        {         
            IList<Spr_SR> Fltlst = _db.GetSpr_SRs();
            List<string> SBULst = new List<string>(from itm in Fltlst orderby itm.SBU select itm.SBU );
            List<string> RegLst = new List<string>(from itm in Fltlst orderby itm.Регион select itm.Регион);
            List<string> OblLst = new List<string>(from itm in Fltlst orderby itm.Область select itm.Область);
            List<string> DistLst = new List<string>(from itm in Fltlst orderby itm.Дистрибутор select itm.Дистрибутор);
            List<string> CodeTALst = new List<string>(from itm in Fltlst orderby itm.КодТА select itm.КодТА);
            List<string> TALst = new List<string>(from itm in Fltlst orderby itm.ТА select itm.ТА);
            List<string> TypeTALst = new List<string>(from itm in Fltlst orderby itm.ТипТА select itm.ТипТА);
            List<string> RouteTALst = new List<string>(from itm in Fltlst orderby itm.МаршрутТА select itm.МаршрутТА);

            SBU = !String.IsNullOrEmpty(SBU) ? SBU : _SBU;
            RegNm = !String.IsNullOrEmpty(RegNm) ? RegNm : _RegNm;
            OblNm = !String.IsNullOrEmpty(OblNm) ? OblNm : _OblNm;
            DistNm = !String.IsNullOrEmpty(DistNm) ? DistNm : _DistNm;
            CodeTA = !String.IsNullOrEmpty(CodeTA) ? CodeTA : _CodeTA;
            TA = !String.IsNullOrEmpty(TA) ? TA : _TA;
            TypeTA = !String.IsNullOrEmpty(TypeTA) ? TypeTA : _TypeTA;
            RouteTA = !String.IsNullOrEmpty(RouteTA) ? RouteTA : _RouteTA;

            ViewBag.SBU = SBU;
            ViewBag.RegNm = RegNm;
            ViewBag.OblNm = OblNm;
            ViewBag.DistNm = DistNm;
            ViewBag.CodeTA = CodeTA;
            ViewBag.TA = TA;
            ViewBag.TypeTA = TypeTA;
            ViewBag.RouteTA = RouteTA;

            SBU = SBU ?? ALL;
            RegNm = RegNm ?? ALL;
            OblNm = OblNm ?? ALL;
            DistNm = DistNm ?? ALL;
            CodeTA = CodeTA ?? ALL;
            TA = TA ?? ALL;
            TypeTA = TypeTA ?? ALL;
            RouteTA = RouteTA ?? ALL;

            SBULst.Insert(0, ALL);
            RegLst.Insert(0, ALL);
            OblLst.Insert(0, ALL);
            DistLst.Insert(0, ALL);
            CodeTALst.Insert(0, ALL);
            TALst.Insert(0, ALL);
            TypeTALst.Insert(0, ALL);
            RouteTALst.Insert(0, ALL);

            if (SBU != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.SBU) ? p.SBU : String.Empty).Equals(SBU)).ToList();
            if (RegNm != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.Регион) ? p.Регион : String.Empty).Equals(RegNm)).ToList();
            if (OblNm != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.Область) ? p.Область : String.Empty).Equals(OblNm)).ToList();
            if (DistNm != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.Дистрибутор) ? p.Дистрибутор : String.Empty).Equals(DistNm)).ToList();
            if (CodeTA != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.КодТА) ? p.КодТА : String.Empty).Equals(CodeTA)).ToList();
            if (TA != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.ТА) ? p.ТА : String.Empty).Equals(TA)).ToList();
            if (TypeTA != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.ТипТА) ? p.ТипТА : String.Empty).Equals(TypeTA)).ToList();
            if (RouteTA != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.МаршрутТА) ? p.МаршрутТА : String.Empty).Equals(RouteTA)).ToList();

            #region Search
            if (String.IsNullOrEmpty(search)) search = null;
            searchUP = search != null ? search.ToUpper() : String.Empty;
            Fltlst = Fltlst.Where(
            p => search == null
            || (!String.IsNullOrEmpty(p.SBU) ? p.SBU : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.Регион) ? p.Регион : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.Область) ? p.Область : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.Дистрибутор) ? p.Дистрибутор : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.КодТА) ? p.КодТА : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.ТА) ? p.ТА : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.ТипТА) ? p.ТипТА : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.МаршрутТА) ? p.МаршрутТА : String.Empty).ToUpper().Contains(searchUP)
            ).ToList();
            #endregion

            #region Sorting
            switch (SortBy)
            {
                case 1:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.SBU).ToList() : Fltlst.OrderByDescending(p => p.SBU).ToList();
                    break;
                case 2:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Регион).ToList() : Fltlst.OrderByDescending(p => p.Регион).ToList();
                    break;
                case 3:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Область).ToList() : Fltlst.OrderByDescending(p => p.Область).ToList();
                    break;
                case 4:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Дистрибутор).ToList() : Fltlst.OrderByDescending(p => p.Дистрибутор).ToList();
                    break;
                case 5:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.КодТА).ToList() : Fltlst.OrderByDescending(p => p.КодТА).ToList();
                    break;
                case 6:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.ТА).ToList() : Fltlst.OrderByDescending(p => p.ТА).ToList();
                    break;
                case 7:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.ТипТА).ToList() : Fltlst.OrderByDescending(p => p.ТипТА).ToList();
                    break;
                case 8:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.МаршрутТА).ToList() : Fltlst.OrderByDescending(p => p.МаршрутТА).ToList();
                    break;
                default:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.SBU).ToList() : Fltlst.OrderByDescending(p => p.SBU).ToList();
                    break;
            }
            #endregion

            ViewData["_SBU"]    = new SelectList(SBULst.AsEnumerable().Distinct<string>(), SBU);
            ViewData["_RegNm"]  = new SelectList(RegLst.AsEnumerable().Distinct<string>(), RegNm);
            ViewData["_OblNm"]  = new SelectList(OblLst.AsEnumerable().Distinct<string>(), OblNm);
            ViewData["_DistNm"] = new SelectList(DistLst.AsEnumerable().Distinct<string>(), DistNm);
            ViewData["_CodeTA"] = new SelectList(CodeTALst.AsEnumerable().Distinct<string>(), CodeTA);
            ViewData["_TA"]     = new SelectList(TALst.AsEnumerable().Distinct<string>(), TA);
            ViewData["_TypeTA"] = new SelectList(TypeTALst.AsEnumerable().Distinct<string>(), TypeTA);
            ViewData["_RouteTA"] = new SelectList(RouteTALst.AsEnumerable().Distinct<string>(), RouteTA);

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = defaultPageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)Fltlst.Count() / defaultPageSize);
            ViewBag.SortBy = SortBy;
            ViewBag.IsAsc = isAsc;
            ViewBag.Search = search;

            return View(Fltlst.ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_SRCreate()
        {
            ViewData["TypeTA"] = new SelectList(_db.GetSpr_TypeTADist());
            return View();
        }

        [HttpPost]
        public ActionResult Spr_SRCreate(Spr_SR obj, String TypeTA)
        {
            obj.ID = Guid.NewGuid();
            obj.ТипТА = TypeTA;
            _db.AddSpr_SR(obj);
            return RedirectToAction("Spr_SRList");
        }

        public ActionResult Spr_SRDetails(Guid id)
        {
            return View(_db.GetSpr_SR(id));
        }

        public ActionResult Spr_SRDelete(Guid id)
        {
            _db.DeleteSpr_SR(id);
            return RedirectToAction("Spr_SRList");
        }

        [HttpGet]
        public ActionResult Spr_SREdit(Guid id)
        {
            if (Request.IsAjaxRequest())
            {
                Spr_SR obj = _db.GetSpr_SR(id);
                ViewData["TypeTA"] = new SelectList(_db.GetSpr_TypeTADist(), obj.ТипТА);
                //ViewData["SBU"] = new SelectList(_db.GetGetSBUListDist(),  obj.SBU);
                return PartialView(_db.GetSpr_SR(id));
            }
            return View();
        }

        [HttpPost]
        public ActionResult Spr_SREdit(Spr_SR obj, String TypeTA)
        {
            if (ModelState.IsValid)
            {
                obj.ТипТА = TypeTA;
                _db.SaveSpr_SR(obj);
                return  Content(_db.GetSprSRViewRow(obj));
               // return RedirectToAction("Spr_SRList");
            }
            return View();

        }

        #endregion

        #region ---------------------------------Spr_TypeTA----------------------------------------

        public ActionResult Spr_TypeTAList(int? page)
        {
            return View(_db.GetSpr_TypeTA().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_TypeTACreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_TypeTACreate(Spr_TypeTA obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_TypeTA(obj);
            return RedirectToAction("Spr_TypeTAList");
        }

        public ActionResult Spr_TypeTADetails(Guid id)
        {
            return View(_db.GetSpr_TypeTA(id));
        }

        public ActionResult Spr_TypeTADelete(Guid id)
        {
            _db.DeleteSpr_TypeTA(id);
            return RedirectToAction("Spr_TypeTAList");
        }

        [HttpGet]
        public ActionResult Spr_TypeTAEdit(Guid id)
        {
            return View(_db.GetSpr_TypeTA(id));
        }

        [HttpPost]
        public ActionResult Spr_TypeTAEdit(Spr_TypeTA obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_TypeTA(obj);
                return RedirectToAction("Spr_TypeTAList");
            }
            return View();
        }

        #endregion

        #region ---------------------------------Spr_ChannelRetail----------------------------------------

        public ActionResult Spr_ChannelRetailList(int? page)
        {
            return View(_db.GetSpr_ChannelRetails().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_ChannelRetailCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_ChannelRetailCreate(Spr_ChannelRetail obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_ChannelRetail(obj);
            return RedirectToAction("Spr_ChannelRetailList");
        }

        public ActionResult Spr_ChannelRetailDetails(Guid id)
        {
            return View(_db.GetSpr_ChannelRetail(id));
        }

        public ActionResult Spr_ChannelRetailDelete(Guid id)
        {
            _db.DeleteSpr_ChannelRetail(id);
            return RedirectToAction("Spr_ChannelRetailList");
        }

        [HttpGet]
        public ActionResult Spr_ChannelRetailEdit(Guid id)
        {
            return View(_db.GetSpr_ChannelRetail(id));
        }

        [HttpPost]
        public ActionResult Spr_ChannelRetailEdit(Spr_ChannelRetail obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_ChannelRetail(obj);
                return RedirectToAction("Spr_ChannelRetailList");
            }
            return View();
        }

        #endregion

        #region ---------------------------------Spr_Outlets-------------------------------

        [HttpGet]
        public ActionResult Spr_OutletsEdit(Guid id)
        {
            Spr_Outlets obj = _db.GetSpr_Outlet(id);
            ViewData["CatigoryTRT"] = new SelectList(_db.GetCatigoryTRTListDist(), obj.КатегорияТРТ);
            ViewData["ChannelRetail"] = new SelectList(_db.GetChannelRetailListDist(), obj.Каналреализации);
            ViewData["TypeAkciya"] = new SelectList(_db.GetTypeAkciyaListDist(), obj.ТипАкции);
            ViewData["Actuals"] = new SelectList(_db.GetActualsListDist(), obj.Актуальность);
            ViewData["Holding"] = new SelectList(_db.GetHoldingListDist(), obj.Холдинг);
            ViewBag.ID = id;
            if (Request.IsAjaxRequest())
            {
                return PartialView(_db.GetSpr_Outlets(id));
            }
            return View(_db.GetSpr_Outlets(id));
        }

        [HttpPost]
        public ActionResult Spr_OutletsEdit(Spr_Outlets obj, String CatigoryTRT, String ChannelRetail, String Actuals, String TypeAkciya, String Holding)
        {
            if (ModelState.IsValid)
            {
                //Еще нужен лог-файл. Важно отслеживать кто и когда изменил поля: 
                //Категория ТРТ, Канал реализации, Тип акции, Холдинг.
                 //AddLog(Log obj)
                Spr_Outlets old = _db.GetSpr_Outlet(obj.ID);
                Users usr = base.MembershipService.CurrUser;
                Guid UserID = (usr != null )? usr.ID : Guid.Empty ;

                obj.КатегорияТРТ = CatigoryTRT;
                // obj.Клиент
                // 

                if (!(String.IsNullOrEmpty(old.КатегорияТРТ) ? String.Empty : old.КатегорияТРТ).Equals(CatigoryTRT))
                {
                    Log l = new Log();
                    l.ID = Guid.NewGuid();
                    l.CrtDate = DateTime.Now;
                    l.UserID = UserID;
                    l.Field = "КатегорияТРТ";
                    l.New = CatigoryTRT;
                    l.Old = old.КатегорияТРТ;
                    _db.AddLog(l);
                }
                obj.Каналреализации = ChannelRetail;
                if (!(String.IsNullOrEmpty(old.Каналреализации) ? String.Empty : old.Каналреализации).Equals(ChannelRetail))
                {
                    Log l = new Log();
                    l.ID = Guid.NewGuid();
                    l.CrtDate = DateTime.Now;
                    l.Field = "Каналреализации";
                    l.UserID = UserID;
                    l.New = ChannelRetail;
                    l.Old = old.Каналреализации;
                    _db.AddLog(l);
                }
                obj.ТипАкции = TypeAkciya;
                if (!(String.IsNullOrEmpty(old.ТипАкции) ? String.Empty : old.ТипАкции).Equals(TypeAkciya))
                {
                    Log l = new Log();
                    l.ID = Guid.NewGuid();
                    l.CrtDate = DateTime.Now;
                    l.Field = "ТипАкции";
                    l.UserID = UserID;
                    l.New =  TypeAkciya;
                    l.Old = old.ТипАкции;
                    _db.AddLog(l);
                }
                
                obj.Холдинг = Holding;
                if (!(String.IsNullOrEmpty(old.Холдинг) ? String.Empty : old.Холдинг).Equals(Holding))
                {
                    Log l = new Log();
                    l.ID = Guid.NewGuid();
                    l.CrtDate = DateTime.Now;
                    l.Field = "Холдинг";
                    l.UserID = UserID;
                    l.New =  Holding;
                    l.Old = old.Холдинг;
                    _db.AddLog(l);
                }

                obj.Актуальность = Actuals;
                _db.SaveSpr_Outlets(obj);
                return Content(_db.GetSprOutletsViewRow(obj));
            }
            return PartialView("EditStore");

        }

        #endregion

    }
}
