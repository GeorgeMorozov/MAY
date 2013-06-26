using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using StoreCheck.Models;
using System.Web.Routing;

namespace StoreCheck.Controllers
{
    public class StoreController : ApplicationController
    {        
        public AccountMembershipService MembershipService { get; set; }               
        private readonly DataManager _db = new DataManager();
        private const int defaultPageSize = 10;
        private const string ALL = "Все";
        private string searchUP = String.Empty;

        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null) { MembershipService = new AccountMembershipService(requestContext.HttpContext.User.Identity.Name); }

            base.Initialize(requestContext);
        }

        [HttpGet]
        public ActionResult EditStore(
                                       string RegNm, string OblNm, string DistNm, string Release, string Category, string TypeAkciya, string Client, string Adress, string City, string Street, string House, string Comment,
                                       string _RegNm, string _OblNm, string _DistNm, string _Release, string _Category, string _TypeAkciya, string _Client, string _Adress, string _City, string _Street, string _House, string _Comment,
                                       int? page, int SortBy = 1, string _search = null, bool isAsc = true, string search = null
                                     )
        {
            
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            IList<Spr_Outlets> Fltlst =  _db.GetStores();

            RegNm = !String.IsNullOrEmpty(RegNm) ? RegNm : _RegNm;
            OblNm = !String.IsNullOrEmpty(OblNm) ? OblNm : _OblNm;
            DistNm = !String.IsNullOrEmpty(DistNm) ? DistNm : _DistNm;
            Release = !String.IsNullOrEmpty(Release) ? Release : _Release;
            Category = !String.IsNullOrEmpty(Category) ? Category : _Category;
            TypeAkciya = !String.IsNullOrEmpty(TypeAkciya) ? TypeAkciya : _TypeAkciya;
            Client = !String.IsNullOrEmpty(Client) ? Client : _Client;
            Adress = !String.IsNullOrEmpty(Adress) ? Adress : _Adress;
            City = !String.IsNullOrEmpty(City) ? City : _City;
            search = !String.IsNullOrEmpty(search) ? search : _search;
            Street = !String.IsNullOrEmpty(search) ? Street : _Street;
            House = !String.IsNullOrEmpty(search) ? House : _House;
            Comment = !String.IsNullOrEmpty(search) ? Comment : _Comment;

            List<string> RegLst = new List<string>(from itm in Fltlst orderby itm.Регион select itm.Регион);
            List<string> OblLst = new List<string>(from itm in Fltlst orderby itm.Область select itm.Область);
            List<string> DistLst = new List<string>(from itm in Fltlst orderby itm.Дистрибутор select itm.Дистрибутор);
            List<string> ReleaseLst = new List<string>(from itm in Fltlst orderby itm.Каналреализации select itm.Каналреализации);
            List<string> CategoryLst = new List<string>(from itm in Fltlst orderby itm.КатегорияТРТ select itm.КатегорияТРТ);
            //List<string> ClientLst = new List<string>(from itm in Fltlst orderby itm.Клиент select  String.IsNullOrEmpty(itm.Клиент)? String.Empty : itm.Клиент.Trim() );
            //List<string> AdressLst = new List<string>(from itm in Fltlst orderby itm.Адресдоставки select  String.IsNullOrEmpty(itm.Адресдоставки)? String.Empty : itm.Адресдоставки.Trim());
            List<string> CityLst = new List<string>(from itm in Fltlst orderby itm.ГородТРТ select itm.ГородТРТ);
            List<string> StreetLst = new List<string>(from itm in Fltlst orderby itm.УлицаТРТ select itm.УлицаТРТ);
            List<string> HouseLst = new List<string>(from itm in Fltlst orderby itm.ДомТРТ select itm.ДомТРТ);
            List<string> CommentLst = new List<string>(from itm in Fltlst orderby itm.ПримечаниеТРТ select itm.ПримечаниеТРТ);
            List<string> TypeAkciyaLst = new List<string>(from itm in Fltlst orderby itm.ТипАкции select itm.ТипАкции);

            ViewBag.RegNm = RegNm;
            ViewBag.OblNm = OblNm;
            ViewBag.DistNm = DistNm;
            ViewBag.Release = Release;
            ViewBag.Category = Category;
            ViewBag.TypeAkciya = TypeAkciya;
            //ViewBag.Client = Client;
            //ViewBag.Adress = Adress;
            ViewBag.City = City;
            ViewBag.Street = Street;
            ViewBag.House = House;
            ViewBag.Comment = Comment;

            RegNm = RegNm ?? ALL;
            OblNm = OblNm ?? ALL;
            DistNm = DistNm ?? ALL;
            Release = Release ?? ALL;
            Category = Category ?? ALL;
            Client = Client ?? ALL;
            Adress = Adress ?? ALL;
            City = City ?? ALL;
            Street = Street ?? ALL;
            House = House ?? ALL;
            Comment = Comment ?? ALL;
            TypeAkciya = TypeAkciya ?? ALL;

            RegLst.Insert(0, ALL);
            OblLst.Insert(0, ALL);
            DistLst.Insert(0, ALL);
            ReleaseLst.Insert(0, ALL);
            CategoryLst.Insert(0, ALL);
            //ClientLst.Insert(0, ALL);
            //AdressLst.Insert(0, ALL);
            CityLst.Insert(0, ALL);
            StreetLst.Insert(0, ALL);
            HouseLst.Insert(0, ALL);
            CommentLst.Insert(0, ALL);
            TypeAkciyaLst.Insert(0, ALL);

            if (RegNm != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.Регион) ? p.Регион : String.Empty).Equals(RegNm)).ToList();
            if (OblNm != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.Область) ? p.Область : String.Empty).Equals(OblNm)).ToList();
            if (DistNm != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.Дистрибутор) ? p.Дистрибутор : String.Empty).Equals(DistNm)).ToList();
            if (Release != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.Каналреализации) ? p.Каналреализации : String.Empty).Equals(Release)).ToList();
            if (Category != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.КатегорияТРТ) ? p.КатегорияТРТ : String.Empty).Equals(Category)).ToList();
            if (Client != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.Клиент) ? p.Клиент : String.Empty).Equals(Client)).ToList();
            if (Adress != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.Адресдоставки) ? p.Адресдоставки : String.Empty).Equals(Adress)).ToList();
            if (City != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.ГородТРТ) ? p.ГородТРТ : String.Empty).Equals(City)).ToList();
            if (Street != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.УлицаТРТ) ? p.УлицаТРТ : String.Empty).Equals(Street)).ToList();
            if (House != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.ДомТРТ) ? p.ДомТРТ : String.Empty).Equals(House)).ToList();
            if (Comment != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.ПримечаниеТРТ) ? p.ПримечаниеТРТ : String.Empty).Equals(Comment)).ToList();
            if (TypeAkciya != ALL) Fltlst = Fltlst.Where(p => (!String.IsNullOrEmpty(p.ТипАкции) ? p.ТипАкции : String.Empty).Equals(TypeAkciya)).ToList();

            #region Search
            if (String.IsNullOrEmpty(search)) search = null;
            searchUP = search != null ? search.ToUpper() : String.Empty;
            Fltlst = Fltlst.Where(
            p => search == null
            || (!String.IsNullOrEmpty(p.Регион) ? p.Регион : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.Область) ? p.Область : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.Дистрибутор) ? p.Дистрибутор : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.Каналреализации) ? p.Каналреализации : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.КатегорияТРТ) ? p.КатегорияТРТ : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.Клиент) ? p.Клиент : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.Адресдоставки) ? p.Адресдоставки : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.ГородТРТ) ? p.ГородТРТ : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.УлицаТРТ) ? p.УлицаТРТ : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.ДомТРТ) ? p.ДомТРТ : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.ПримечаниеТРТ) ? p.ПримечаниеТРТ : String.Empty).ToUpper().Contains(searchUP)
            || (!String.IsNullOrEmpty(p.ТипАкции) ? p.ТипАкции : String.Empty).ToUpper().Contains(searchUP)
            ).ToList();
            #endregion

            #region Sorting
            switch (SortBy)
            {
                case 1:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Регион).ToList() : Fltlst.OrderByDescending(p => p.Регион).ToList();
                    break;
                case 2:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Область).ToList() : Fltlst.OrderByDescending(p => p.Область).ToList();
                    break;
                case 3:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Дистрибутор).ToList() : Fltlst.OrderByDescending(p => p.Дистрибутор).ToList();
                    break;
                case 4:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Каналреализации).ToList() : Fltlst.OrderByDescending(p => p.Каналреализации).ToList();
                    break;
                case 5:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.КатегорияТРТ).ToList() : Fltlst.OrderByDescending(p => p.КатегорияТРТ).ToList();
                    break;
                case 6:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Клиент).ToList() : Fltlst.OrderByDescending(p => p.Клиент).ToList();
                    break;
                case 7:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Адресдоставки).ToList() : Fltlst.OrderByDescending(p => p.Адресдоставки).ToList();
                    break;
                case 8:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.ГородТРТ).ToList() : Fltlst.OrderByDescending(p => p.ГородТРТ).ToList();
                    break;
                case 9:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.КатегорияТРТ).ToList() : Fltlst.OrderByDescending(p => p.КатегорияТРТ).ToList();
                    break;
                case 10:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.УлицаТРТ).ToList() : Fltlst.OrderByDescending(p => p.УлицаТРТ).ToList();
                    break;
                case 11:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.ДомТРТ).ToList() : Fltlst.OrderByDescending(p => p.ДомТРТ).ToList();
                    break;
                default:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.ПримечаниеТРТ).ToList() : Fltlst.OrderByDescending(p => p.ПримечаниеТРТ).ToList();
                    break;
            }
            #endregion

            ViewData["_RegNm"] = new SelectList(RegLst.AsEnumerable().Distinct<string>(), RegNm);
            ViewData["_OblNm"] = new SelectList(OblLst.AsEnumerable().Distinct<string>(), OblNm);
            ViewData["_DistNm"] = new SelectList(DistLst.AsEnumerable().Distinct<string>(), DistNm);
            ViewData["_Release"] = new SelectList(ReleaseLst.AsEnumerable().Distinct<string>(), Release);
            ViewData["_Category"] = new SelectList(CategoryLst.AsEnumerable().Distinct<string>(), Category);
            //ViewData["_Client"] = new SelectList(ClientLst.AsEnumerable().Distinct<string>(), Client);
            //ViewData["_Adress"] = new SelectList(AdressLst.AsEnumerable().Distinct<string>(), Adress);
            ViewData["_City"] = new SelectList(CityLst.AsEnumerable().Distinct<string>(), City);
            ViewData["_Street"] = new SelectList(StreetLst.AsEnumerable().Distinct<string>(), Street);
            ViewData["_House"] = new SelectList(HouseLst.AsEnumerable().Distinct<string>(), House);
            ViewData["_Comment"] = new SelectList(CommentLst.AsEnumerable().Distinct<string>(), Comment);
            ViewData["_TypeAkciya"] = new SelectList(TypeAkciyaLst.AsEnumerable().Distinct<string>(), TypeAkciya);

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = defaultPageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)Fltlst.Count() / defaultPageSize);
            ViewBag.SortBy = SortBy;
            ViewBag.IsAsc = isAsc;
            ViewBag.Search = search;

            return View(Fltlst.ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult SaveCheckRes(Guid id)
        {

            Spr_Outlets Outlet = _db.GetSpr_Outlet(id);
            if (Outlet == null)
            {
                return RedirectToAction("EditStore", "Store");
            }
            if (String.IsNullOrEmpty(Outlet.КатегорияТРТ)) 
            {
                return RedirectToAction("Spr_OutletsEdit","Spr", new { id = Outlet.ID });
               }

            IList<Spr_CAP> Caplst = null;
            Users usr = base.MembershipService.CurrUser;
            if (usr.SortType == enSortType.enSrtAssort)
                Caplst = _db.GetSpr_CAPs().Where(p => p.КатегорияТРТ.Equals(Outlet.КатегорияТРТ)).OrderBy(obj => obj.КодАссортимент).ThenBy(obj => obj.Приоритетность).ToList();
            else
                Caplst = _db.GetSpr_CAPs().Where(p => p.КатегорияТРТ.Equals(Outlet.КатегорияТРТ)).OrderBy(obj => obj.ТорговаяМарка).ThenBy(obj => obj.Приоритетность).ToList();
            
            ViewBag.ChkBoxLstNm = Caplst;
            ViewBag.SortTp = usr.SortType;
            ViewBag.Category_StoreCheck = _db.GetSpr_Category_StoreCheck().OrderBy(it => it.Category).ThenBy(it => it.Name_Category);                  
            return View(_db.GetStore(id));
        }

        [HttpPost]
        public ActionResult SaveCheckRes(IEnumerable<HttpPostedFileBase> files, Guid OutletID)
        {
            //AppConfiguration cfg = new AppConfiguration();
            //AppConfiguration.imagePath = "~/Content/Images/foto";
            String[] values;
            String imgPath = "~/Content/Images/foto";//AppConfiguration.imagePath;
            int SKUf = 0;
            List<string> imgPathLst = new List<string>();
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    if ( Path.GetExtension(file.FileName) == (".jpg")
                        || Path.GetExtension(file.FileName) == (".png")
                        || Path.GetExtension(file.FileName) == (".bmp")
                       )
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath(imgPath), fileName);
                        file.SaveAs(path);
                        imgPathLst.Add(imgPath +"//"+ fileName);
                    }
                }
            }         
            CheckOutlet Outlet = new CheckOutlet();
            Outlet.ID = Guid.NewGuid();
            Outlet.OutletID = OutletID;
            Users usr = (Users)Session["CurrUsr"];
            if (usr == null)
                usr = MembershipService.CurrUser;
            Outlet.UserID = usr.ID;
            Outlet.CheckDate = DateTime.Now;
            Dictionary<Guid, String> Vals = new Dictionary<Guid, String>();
            String CatTRT = _db.GetCatTRT(OutletID);

            for (int i = 0; i < Request.Form.Count; i++)
            {
                values = Request.Form.GetValues(i);
               
                String SprID = String.Empty;
                String itmID = String.Empty;
                Guid SKUID = Guid.Empty;
                CheckOutletData OutletData = new CheckOutletData();
                String[] sep = {"##"};
                String[] rawStr = Request.Form.Keys[i].Split(sep, StringSplitOptions.RemoveEmptyEntries);
                OutletData.ID = Guid.NewGuid();
                OutletData.CheckOutletID = Outlet.ID;
               
                if (values != null && values[0] == "true") //checkbox
                {   
                    Vals.Add(Guid.Parse(Request.Form.Keys[i]), String.Empty); 
                }                        
                if (rawStr.Count() > 1)
                {
                    SprID = rawStr[0];
                    itmID = rawStr[1];
                    SKUID = Guid.Parse(itmID);
                }
                if (SprID == "SPR_CUP")
                {                    
                    OutletData.SKUID = SKUID;
                    if (Vals.ContainsKey(SKUID))
                    {
                        OutletData.Value = values[0];
                        if (_db.GetSKUCode(SKUID) == 1)
                            SKUf++;
                        _db.AddCheckOutletData(OutletData);
                    }  
                }
                else if (!String.IsNullOrEmpty(SprID))
                {
                    OutletData.CategoryID = SKUID;
                    if (Vals.ContainsKey(SKUID))
                    {
                        OutletData.Value = values[0];
                        _db.AddCheckOutletData(OutletData);
                    } 
                }                           
            }

            for (int i = 0; i < imgPathLst.Count; i++ )
            {
                CheckOutletImg OutletImg = new CheckOutletImg();
                OutletImg.ID = Guid.NewGuid();
                OutletImg.OutletID = Outlet.ID;
                OutletImg.Path = imgPathLst[i];
                _db.AddCheckOutletImg(OutletImg);
            }
            Outlet.SKUf = SKUf;
            Outlet.SKUp = _db.GetSKUInCatTRT(CatTRT); 
            _db.AddCheckOutlet(Outlet);       
            return RedirectToAction("EditStore");
        }

        public ActionResult ViewChecks(int? page, Guid id)
        {
            ViewBag.Name = _db.GetSpr_Outlet(id).Клиент; 
            return View(_db.GetVWCheckOutlet(id).OrderBy( it => it.Login).ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }
        
        public ActionResult ViewCheckDetails(int? page, Guid id)
        {
            ViewBag.ImgList = _db.GetImgList(id); 

            return View(_db.GetVWCheckOutletData(id).OrderBy(it => it.Login).ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }
        
    }
}