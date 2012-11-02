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

        public ActionResult EditStore(string RegNm, string OblNm, string DistNm, string Release, string Category, string Client, string Adress, int? page)
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");

            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<Spr_Outlets> Fltlst =  _db.GetStores();

            List<string> RegLst = new List<string>();
            List<string> OblLst = new List<string>();
            List<string> DistLst = new List<string>();
            List<string> ReleaseLst = new List<string>();
            List<string> CategoryLst = new List<string>();
            List<string> ClientLst = new List<string>();
            List<string> AdressLst = new List<string>();

            RegNm = RegNm ?? "Все";
            OblNm = OblNm ?? "Все";
            DistNm = DistNm ?? "Все";
            Release = Release ?? "Все";
            Category = Category ?? "Все";
            Client = Client ?? "Все";
            Adress = Adress ?? "Все";

            //RegLst = new string[Fltlst.Count + 1];
            RegLst.Add("Все");
            //OblLst = new string[Fltlst.Count + 1]; 
            OblLst.Add("Все");
            //DistLst = new string[Fltlst.Count + 1]; 
            DistLst.Add("Все");
            //ReleaseLst = new string[Fltlst.Count + 1]; 
            ReleaseLst.Add("Все");
            //CategoryLst = new string[Fltlst.Count + 1]; 
            CategoryLst.Add("Все");
            //ClientLst = new string[Fltlst.Count + 1]; 
            ClientLst.Add("Все");
            //AdressLst = new string[Fltlst.Count + 1]; 
            AdressLst.Add("Все");

            foreach (var item in Fltlst)
            {
                if (!String.IsNullOrEmpty(item.Регион))
                RegLst.Add(item.Регион);
                if (!String.IsNullOrEmpty(item.Область))
                OblLst.Add(item.Область);
                if (!String.IsNullOrEmpty(item.Дистрибутор))
                DistLst.Add(item.Дистрибутор);
                if (!String.IsNullOrEmpty(item.Каналреализации))
                ReleaseLst.Add(item.Каналреализации);
                if (!String.IsNullOrEmpty(item.КатегорияТРТ))
                CategoryLst.Add(item.КатегорияТРТ);
                if (!String.IsNullOrEmpty(item.Клиент))
                ClientLst.Add(item.Клиент);
                if (!String.IsNullOrEmpty(item.Адресдоставки))
                AdressLst.Add(item.Адресдоставки);
            }

            if (RegNm != "Все") Fltlst = Fltlst.Where(p => p.Регион.Equals(RegNm)).ToList();

            if (OblNm != "Все") Fltlst = Fltlst.Where(p => p.Область.Equals(OblNm)).ToList();

            if (DistNm != "Все") Fltlst = Fltlst.Where(p => p.Дистрибутор.Equals(DistNm)).ToList();

            if (Release != "Все") Fltlst = Fltlst.Where(p => p.Каналреализации.Equals(Release)).ToList();

            if (Category != "Все") Fltlst = Fltlst.Where(p => p.КатегорияТРТ.Equals(Category)).ToList();

            if (Client != "Все") Fltlst = Fltlst.Where(p => p.Клиент.Equals(Client)).ToList();

            if (Adress != "Все") Fltlst = Fltlst.Where(p => p.Адресдоставки.Equals(Adress)).ToList();

            ViewData["RegNm"] = new SelectList(RegLst.AsEnumerable().Distinct<string>(), RegNm);
            ViewData["OblNm"] = new SelectList(OblLst.AsEnumerable().Distinct<string>(), OblNm);
            ViewData["DistNm"] = new SelectList(DistLst.AsEnumerable().Distinct<string>(), DistNm);
            ViewData["Release"] = new SelectList(ReleaseLst.AsEnumerable().Distinct<string>(), Release);
            ViewData["Category"] = new SelectList(CategoryLst.AsEnumerable().Distinct<string>(), Category);
            ViewData["Client"] = new SelectList(ClientLst.AsEnumerable().Distinct<string>(), Client);
            ViewData["Adress"] = new SelectList(AdressLst.AsEnumerable().Distinct<string>(), Adress);

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
           

            if (usr.SortType == enSortType.enSrtAssort)
                Caplst = _db.GetSpr_CAPs().Where(p => p.КатегорияТРТ.Equals(Outlet.КатегорияТРТ)).OrderBy(obj => obj.Ассортимент).ToList();
            else
                Caplst = _db.GetSpr_CAPs().Where(p => p.КатегорияТРТ.Equals(Outlet.КатегорияТРТ)).OrderBy(obj => obj.ТорговаяМарка).ToList();
            
            ViewBag.ChkBoxLstNm = Caplst;
            ViewBag.SortTp = usr.SortType;
                    
            return View(_db.GetStore(id));
        }
        /*
        public ActionResult SaveStore(Guid OutletID) 
        {
          string []values;
          CheckOutlet Outlet = new CheckOutlet();
          Outlet.ID = Guid.NewGuid();
          Outlet.OutletID = OutletID;
          Users usr = (Users)Session["CurrUsr"];
          Outlet.UserID = usr.ID;
          Outlet.CkeckDate = DateTime.Now;
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
          return RedirectToAction("EditStore");
        }
         */


        [HttpPost]
        public ActionResult SaveCheckRes(IEnumerable<HttpPostedFileBase> files, Guid OutletID)
        {
            AppConfiguration cfg = new AppConfiguration();
            //cfg.imagePath = "~/App_Data/uploads";
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