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
    public class StoreController : Controller
    {
        
        public AccountMembershipService MembershipService { get; set; }        
        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null) { MembershipService = new AccountMembershipService(requestContext.HttpContext.User.Identity.Name); }

            base.Initialize(requestContext);
        }
        private readonly DataManager _db = new DataManager();
        private const int defaultPageSize = 10;
        private const string ALL = "Все";


        public ActionResult EditStore(string RegNm, string OblNm, string DistNm, string Release, string Category, string Client, string Adress, string City, string Street, string House, string Comment, int? page)
        {
            
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");

            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<Spr_Outlets> Fltlst =  _db.GetStores();

            List<string> RegLst = new List<string>(from itm in Fltlst orderby itm.Регион select itm.Регион);
            List<string> OblLst = new List<string>(from itm in Fltlst orderby itm.Область select itm.Область);
            List<string> DistLst = new List<string>(from itm in Fltlst orderby itm.Дистрибутор select itm.Дистрибутор);
            List<string> ReleaseLst = new List<string>(from itm in Fltlst orderby itm.Каналреализации select itm.Каналреализации);
            List<string> CategoryLst = new List<string>(from itm in Fltlst orderby itm.КатегорияТРТ select itm.КатегорияТРТ);
            List<string> ClientLst = new List<string>(from itm in Fltlst orderby itm.Клиент select itm.Клиент);
            List<string> AdressLst = new List<string>(from itm in Fltlst orderby itm.Адресдоставки select itm.Адресдоставки);
            List<string> CityLst = new List<string>(from itm in Fltlst orderby itm.ГородТРТ select itm.ГородТРТ);
            List<string> StreetLst = new List<string>(from itm in Fltlst orderby itm.УлицаТРТ select itm.УлицаТРТ);
            List<string> HouseLst = new List<string>(from itm in Fltlst orderby itm.ДомТРТ select itm.ДомТРТ);
            List<string> CommentLst = new List<string>(from itm in Fltlst orderby itm.ПримечаниеТРТ select itm.ПримечаниеТРТ);

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

            RegLst.Insert(0, ALL);
            OblLst.Insert(0, ALL);
            DistLst.Insert(0, ALL);
            ReleaseLst.Insert(0, ALL);
            CategoryLst.Insert(0, ALL);
            ClientLst.Insert(0, ALL);
            AdressLst.Insert(0, ALL);
            CityLst.Insert(0, ALL);
            StreetLst.Insert(0, ALL);
            HouseLst.Insert(0, ALL);
            CommentLst.Insert(0, ALL);

            if (RegNm != ALL) Fltlst = Fltlst.Where(p => p.Регион.Equals(RegNm)).ToList();
            if (OblNm != ALL) Fltlst = Fltlst.Where(p => p.Область.Equals(OblNm)).ToList();
            if (DistNm != ALL) Fltlst = Fltlst.Where(p => p.Дистрибутор.Equals(DistNm)).ToList();
            if (Release != ALL) Fltlst = Fltlst.Where(p => p.Каналреализации.Equals(Release)).ToList();
            if (Category != ALL) Fltlst = Fltlst.Where(p => p.КатегорияТРТ.Equals(Category)).ToList();
            if (Client != ALL) Fltlst = Fltlst.Where(p => p.Клиент.Equals(Client)).ToList();
            if (Adress != ALL) Fltlst = Fltlst.Where(p => p.Адресдоставки.Equals(Adress)).ToList();
            if (City != ALL) Fltlst = Fltlst.Where(p => p.ГородТРТ.Equals(City)).ToList(); 
            if (Street != ALL) Fltlst = Fltlst.Where(p => p.УлицаТРТ.Equals(Street)).ToList();
            if (House != ALL) Fltlst = Fltlst.Where(p => p.ДомТРТ.Equals(House)).ToList();
            if (Comment != ALL) Fltlst = Fltlst.Where(p => p.ПримечаниеТРТ.Equals(Comment)).ToList();

            ViewData["RegNm"] = new SelectList(RegLst.AsEnumerable().Distinct<string>(), RegNm);
            ViewData["OblNm"] = new SelectList(OblLst.AsEnumerable().Distinct<string>(), OblNm);
            ViewData["DistNm"] = new SelectList(DistLst.AsEnumerable().Distinct<string>(), DistNm);
            ViewData["Release"] = new SelectList(ReleaseLst.AsEnumerable().Distinct<string>(), Release);
            ViewData["Category"] = new SelectList(CategoryLst.AsEnumerable().Distinct<string>(), Category);
            ViewData["Client"] = new SelectList(ClientLst.AsEnumerable().Distinct<string>(), Client);
            ViewData["Adress"] = new SelectList(AdressLst.AsEnumerable().Distinct<string>(), Adress);
            ViewData["City"] = new SelectList(CityLst.AsEnumerable().Distinct<string>(), City);
            ViewData["Street"] = new SelectList(StreetLst.AsEnumerable().Distinct<string>(), Street);
            ViewData["House"] = new SelectList(HouseLst.AsEnumerable().Distinct<string>(), House);
            ViewData["Comment"] = new SelectList(CommentLst.AsEnumerable().Distinct<string>(), Comment);
            return View(Fltlst.ToPagedList(currentPageIndex, defaultPageSize));

        }

        [HttpGet]
        public ActionResult SaveCheckRes(Guid id)
        {

            Spr_Outlets Outlet = _db.GetSpr_Outlet(id);

            if (String.IsNullOrEmpty(Outlet.КатегорияТРТ)) 
            {
                return RedirectToAction("Spr_OutletsEdit","Spr", new { id = Outlet.ID });
            }

            IList<Spr_CAP> Caplst = null;
            Users usr = MembershipService.CurrUser;
            //MYS 14.11.2012
            //Также, когда выбрана группировка по ассортименту, в первую очередь показывать СКЮ Стандартного ассортиментного присутствия, а затем ассортимент для развития.
            //СКЮ должны быть отсортированы по полю «Приоритетность» 1 – высокая приоритетность.

            if (usr.SortType == enSortType.enSrtAssort)
                //Caplst = _db.GetSpr_CAPs().Where(p => p.КатегорияТРТ.Equals(Outlet.КатегорияТРТ)).OrderBy(obj => obj.Ассортимент).OrderBy(obj => obj.Приоритетность).ToList();
                Caplst = _db.GetSpr_CAPs().Where(p => p.КатегорияТРТ.Equals(Outlet.КатегорияТРТ)).OrderBy(obj => obj.КодАссортимент).ThenBy(obj => obj.Приоритетность).ToList();
            else
                Caplst = _db.GetSpr_CAPs().Where(p => p.КатегорияТРТ.Equals(Outlet.КатегорияТРТ)).OrderBy(obj => obj.ТорговаяМарка).ThenBy(obj => obj.Приоритетность).ToList();
            
            ViewBag.ChkBoxLstNm = Caplst;
            ViewBag.SortTp = usr.SortType;
                    
            return View(_db.GetStore(id));
        }

        [HttpPost]
        public ActionResult SaveCheckRes(IEnumerable<HttpPostedFileBase> files, Guid OutletID)
        {
            AppConfiguration cfg = new AppConfiguration();
            cfg.imagePath = "~/Content/Images/foto";
            string imgPath = cfg.imagePath;

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
            string[] values;
            CheckOutlet Outlet = new CheckOutlet();
            Outlet.ID = Guid.NewGuid();
            Outlet.OutletID = OutletID;
            Users usr = (Users)Session["CurrUsr"];
            Outlet.UserID = usr.ID;
            Outlet.CheckDate = DateTime.Now;
            _db.AddCheckOutlet(Outlet);

            for (int i = 0; i < Request.Form.Count; i++)
            {
                values = Request.Form.GetValues(i);
                if (values != null && values[0] == "true")
                {
                    CheckOutletData OutletData = new CheckOutletData();
                    OutletData.ID = Guid.NewGuid();
                    OutletData.CheckOutletID = Outlet.ID;
                    OutletData.SKUID = Guid.Parse(Request.Form.Keys[i]);
                    _db.AddCheckOutletData(OutletData);
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