using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Configuration;

namespace StoreCheck.Models
{
    public class TRights
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public String Subject { get; set; }
        public int SubjectID { get; set; }
        public int Type { get; set; }

        public TRights() 
        { }
    }

    public class TCheckDataSKU
    {
        public Guid SKUID { get; set; }
        public String SKUName { get; set; }
        public String SKUValue { get; set; }
        public String CodeAssortment { get; set; }
        public String Assortment { get; set; }
        public String Trademark { get; set; }
        public int Priority { get; set; }
        public TCheckDataSKU() 
        { }
    }

    public class TCheckDataCatStrChk
    {
        public Guid CategoryID { get; set; }
        public String Category { get; set; }
        public String NameCategory { get; set; }
        public String CategoryValue { get; set; }

        public TCheckDataCatStrChk()
        { }
    }

    public class TLogRec
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public String UserName { get; set; }
        public String Field { get; set; }
        public String New { get; set; }
        public String Old { get; set; }
        public TLogRec()
        { }
    }

    // Перечень прав с группровкой по типам    (системный справочник Spr_AdmObject "Объекты администрирования")

    public enum EnClassifRights           // Типы прав (поле Spr_AdmObject.Type)
    {
        enAccessRights     = 0,    // Доступ к разделам 
        enModifySprRights  = 1,    // Модификация справочников
        enStoreCheckRights = 2,    // Робота с торговыми точками (Сторчек)
        enReportsRights    = 3,    // Робота с Отчетами
    }

    public enum EnAccessRights            // Права на доступ к разделам  
    {
        enAccessPageAdm    = 1,    // Доступ к разделу "Администрирование"
        enAccessPageTA     = 2,    // Доступ к разделу "Торговые агенты"
        enAccessPageSpr    = 4,    // Доступ к разделу "Справочники"
        enAccessPageStrChk = 8,    // Доступ к разделу "Торговые точки"
        enAccessPageRep    = 16,    // Доступ к разделу "Отчеты" 
    }

    public enum EnModifyRights            // Права для модификации справочников
    {
        enSprAdd           = 1,    // Добавление 
        enSprEdit          = 2,    // Редактирование
        enSprDel           = 4,    // Удаление
    }

    public enum EnStoreCheckRights        //  Права для работы с торговыми точками
    {
        enStrChkAdd        = 1,    // Добавление данных проверки
        enStrChkEdit       = 2,    // Редактирование справочника торговых точек (Spr_Outlets)
    }

    public enum EnReportsRights           // Права для работы с отчетами
    {
        enRepView          = 1,    // Просмотр отчетов
    }
        
    public class DataManager
    {
        private readonly Entities _DB;

        public DataManager()
        {
            _DB = new Entities();
        }

        #region  ---------------------------------Spr_Roles---------------------------------

        public IQueryable<Spr_Roles> GetSpr_RolesIQ()
        {
            return _DB.Spr_Roles;
        }

        public IList<Spr_Roles> GetSpr_Roles()
        {
            return _DB.Spr_Roles.AsEnumerable().ToList();
        }

        public IQueryable<VWRoles> GetVWRolesFlt()
        {
            var a =  _DB.VWRoles.Where(it => !it.RightName.Equals(String.Empty));
            return a;
        }

        public IQueryable<String> GetRolesList()
        {
            return from itm in _DB.Spr_Roles
                   orderby itm.Name
                   select itm.Name;
        }

        private IQueryable<String> _GetRolesListEx()
        {
            return from itm in _DB.VWRoles.Where(it => !it.RightName.Equals(String.Empty))
                   orderby itm.RoleName
                   select itm.RoleName;
        }

        public IQueryable<String> GetRolesListDist()
        {
            return _GetRolesListEx().Distinct();
        }

        public Guid GetRoleID(string name)
         {
             Spr_Roles Role = _DB.Spr_Roles.SingleOrDefault(c => c.Name == name);
             return Role.ID;
         }

        public Spr_Roles GetSpr_Role(Guid id)
        {
            return _DB.Spr_Roles.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_Role(Spr_Roles obj)
        {
            Spr_Roles old = GetSpr_Role(obj.ID);
            old.Name = obj.Name;
            _DB.SaveChanges();
        }

        public void AddSpr_Role(Spr_Roles obj)
        {
            _DB.Spr_Roles.AddObject(obj);
            _DB.SaveChanges();
        }

        public void DeleteSpr_Role(Guid id)
        {
            var obj = _DB.Spr_Roles.SingleOrDefault(c => c.ID == id);
            _DB.Spr_Roles.DeleteObject(obj);
            _DB.SaveChanges();
        }

        #endregion

        #region ---------------------------------Spr_Right---------------------------------

        public IQueryable<Spr_Rights> GetSpr_RightsIQ()
        {
            return _DB.Spr_Rights;
        }

        public IList<Spr_Rights> GetSpr_Rights()
        {
            return _DB.Spr_Rights.AsEnumerable().ToList();
        }

        public IQueryable<String> GetRightsList()
        {
            return from itm in _DB.Spr_Rights
                   orderby itm.Name
                   select itm.Name;
        }

        public Guid GetRightID(string name)
        {
            Spr_Rights Right = _DB.Spr_Rights.SingleOrDefault(c => c.Name == name);
            return Right.ID;
        }

        public Spr_Rights GetSpr_Right(Guid id)
        {
            return _DB.Spr_Rights.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_Right(Spr_Roles obj, Guid AdmObjId)
        {
            Spr_Rights old = GetSpr_Right(obj.ID);
            old.Name = obj.Name;
            old.AdmObj = AdmObjId;
            _DB.SaveChanges();
        }

        public void AddSpr_Right(Spr_Rights obj)
        {
            _DB.Spr_Rights.AddObject(obj);
            _DB.SaveChanges();
        }

        public void DeleteSpr_Right(Guid id)
        {
            var obj = _DB.Spr_Rights.SingleOrDefault(c => c.ID == id);
            _DB.Spr_Rights.DeleteObject(obj);
            _DB.SaveChanges();
        }

        #endregion

        #region ---------------------------------Spr_CAP---------------------------------

        public IQueryable<Spr_CAP> GetSpr_CAPsIQ()
        {
            return _DB.Spr_CAP;
        }

        public IList<Spr_CAP> GetSpr_CAPs()
        {
            return _DB.Spr_CAP.AsEnumerable().ToList();
        }

        public Spr_CAP GetSpr_CAP(Guid id)
        {
            return _DB.Spr_CAP.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_CAP(Spr_CAP obj)
        {
            Spr_CAP old = GetSpr_CAP(obj.ID);
            old.SKUКМУ = obj.SKUКМУ;
            old.SKUгруппировка = obj.SKUгруппировка;
            old.Ассортимент = obj.Ассортимент;
            old.КатегорияТРТ = obj.КатегорияТРТ;
            old.КодАссортимент = obj.КодАссортимент;
            old.Приоритетность = obj.Приоритетность;
            old.ПриоритетностьСчет = obj.ПриоритетностьСчет;
            _DB.SaveChanges();
        }

        public void AddSpr_CAP(Spr_CAP obj)
        {
            _DB.Spr_CAP.AddObject(obj);
            _DB.SaveChanges();
        }

        public void DeleteSpr_CAP(Guid id)
        {
            var obj = _DB.Spr_CAP.SingleOrDefault(c => c.ID == id);
            _DB.Spr_CAP.DeleteObject(obj);
            _DB.SaveChanges();
        }

        public int GetSKUCode(Guid id)
        {
            Spr_CAP obj = GetSpr_CAP(id);
            return Convert.ToInt32(String.IsNullOrEmpty(obj.КодАссортимент) ? "0" : obj.КодАссортимент);
        }

        public int GetSKUInCatTRT(string CatTRT)
        {
            return _DB.Spr_CAP.Where(o => o.КатегорияТРТ == CatTRT).Where(o => o.КодАссортимент == "1").Count();
        }
        

        #endregion

        #region ---------------------------------Spr_TypeAkciya---------------------------------

        public IQueryable<Spr_SR> GetSpr_SRsIQ()
        {
            return _DB.Spr_SR;
        }

        public IList<Spr_SR> GetSpr_SRs()
        {
            return _DB.Spr_SR.AsEnumerable().ToList();
        }

        public Spr_SR GetSpr_SR(Guid id)
        {
            return _DB.Spr_SR.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_SR(Spr_SR obj)
        {
            Spr_SR old = GetSpr_SR(obj.ID);
            old.SBU = obj.SBU;
            old.Дистрибутор = obj.Дистрибутор;
            old.КодТА = obj.КодТА;
            old.МаршрутТА = obj.МаршрутТА;
            old.Область = obj.Область;
            old.Регион = obj.Регион;
            old.ТА = obj.ТА;
            old.ТипТА = obj.ТипТА;
            _DB.SaveChanges();
        }

        public void AddSpr_SR(Spr_SR obj)
        {
            _DB.Spr_SR.AddObject(obj);
            _DB.SaveChanges();
        }

        public void DeleteSpr_SR(Guid id)
        {
            var obj = _DB.Spr_SR.SingleOrDefault(c => c.ID == id);
            _DB.Spr_SR.DeleteObject(obj);
            _DB.SaveChanges();
        }

        public string GetSprSRViewRow(Spr_SR obj)
        {
            string ret = String.Empty;

            ret = "<td class=\"td_btn\"><a class=\"openDialog\" data-dialog-id=\"" + obj.ID.ToString() + "\" data-dialog-title=\"Редактирование торгового агента (" + obj.ТА + ")\" href=\"/Spr/Spr_SREdit/" + obj.ID.ToString() + "\"><img alt=\"Редактировать\" border=\"0\" src=\"/Content/Images/page_edit.png\" /></a> " +
            "<a Title=\"Просмотреть\" href=\"/Spr/Spr_SRDetails/" + obj.ID.ToString() + "\"><img alt=\"Просмотреть\" border=\"0\" src=\"/Content/Images/page.png\"></a> " +
            "<a Title=\"Удалить\" href=\"/Spr/Spr_SRDelete/" + obj.ID.ToString() + "\"><img alt=\"Удалить\" border=\"0\" src=\"/Content/Images/page_delete.png\"></a " +
                                        
            "</td>" +
            "<td>" +
                obj.SBU +
            "</td>" +
            "<td>" +
                obj.Регион +
            "</td>" +
            "<td>" +
                obj.Область +
            "</td>" +
            "<td>" +
                obj.Дистрибутор +
            "</td>" +
            "<td>" +
                obj.КодТА +
            "</td>" +
            "<td>" +
                obj.ТА +
            "</td>" +
            "<td>" +
                obj.ТипТА +
            "</td>" +
            "<td>" +
                obj.МаршрутТА +
            "</td>";

            return ret;
        }

        #endregion

        #region ---------------------------------Spr_ChannelRetail----------------------------------------------

        public IQueryable<Spr_ChannelRetail> GetSpr_ChannelRetailsIQ()
        {
            return _DB.Spr_ChannelRetail;
        }

        public IList<Spr_ChannelRetail> GetSpr_ChannelRetails()
        {
            return _DB.Spr_ChannelRetail.AsEnumerable().ToList();
        }

        public Spr_ChannelRetail GetSpr_ChannelRetail(Guid id)
        {
            return _DB.Spr_ChannelRetail.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_ChannelRetail(Spr_ChannelRetail obj)
        {
            Spr_ChannelRetail old = GetSpr_ChannelRetail(obj.ID);
            old.SBU = obj.SBU;
            old.Каналреализации = obj.Каналреализации;
            _DB.SaveChanges();
        }

        public void AddSpr_ChannelRetail(Spr_ChannelRetail obj)
        {
            _DB.Spr_ChannelRetail.AddObject(obj);
            _DB.SaveChanges();
        }

        public void DeleteSpr_ChannelRetail(Guid id)
        {
            var obj = _DB.Spr_ChannelRetail.SingleOrDefault(c => c.ID == id);
            _DB.Spr_ChannelRetail.DeleteObject(obj);
            _DB.SaveChanges();
        }

        public IQueryable<String> GetChannelRetailList()
        {
            return from itm in _DB.Spr_ChannelRetail
                   orderby itm.Каналреализации
                   select itm.Каналреализации;
        }

        public List<String> GetChannelRetailListDist()
        {
            List<String> l = new List<String>();
            l.Add("");
            l.AddRange(GetChannelRetailList().Distinct());
            return l;
        }

        public IQueryable<String> GetSBUList()
        {
            return from itm in _DB.Spr_ChannelRetail
                   orderby itm.SBU
                   select itm.SBU;
        }

        public IQueryable<String> GetGetSBUListDist()
        {
            return GetSBUList().Distinct();
        }

        #endregion

        #region ---------------------------------Spr_TypeTA----------------------------------------------

        public IQueryable<Spr_TypeTA> GetSpr_TypeTAsIQ()
        {
            return _DB.Spr_TypeTA;
        }

        public IList<Spr_TypeTA> GetSpr_TypeTA()
        {
            return _DB.Spr_TypeTA.AsEnumerable().ToList();
        }

        public Spr_TypeTA GetSpr_TypeTA(Guid id)
        {
            return _DB.Spr_TypeTA.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_TypeTA(Spr_TypeTA obj)
        {
            Spr_TypeTA old = GetSpr_TypeTA(obj.ID);
            old.ТипТА = obj.ТипТА;
            _DB.SaveChanges();
        }

        public void AddSpr_TypeTA(Spr_TypeTA obj)
        {
            _DB.Spr_TypeTA.AddObject(obj);
            _DB.SaveChanges();
        }

        public void DeleteSpr_TypeTA(Guid id)
        {
            var obj = _DB.Spr_TypeTA.SingleOrDefault(c => c.ID == id);
            _DB.Spr_TypeTA.DeleteObject(obj);
            _DB.SaveChanges();
        }

        public IQueryable<String> GetSpr_TypeTAList()
        {
            return from itm in _DB.Spr_TypeTA
                   orderby itm.ТипТА
                   select itm.ТипТА;
        }

        public IQueryable<String> GetSpr_TypeTADist()
        {
            return GetSpr_TypeTAList().Distinct();
        }

        #endregion

        #region ---------------------------------Spr_TypeAkciya----------------------------------------------

        public IQueryable<Spr_TypeAkciya> GetSpr_TypeAkciyaIQ()
        {
            return _DB.Spr_TypeAkciya;
        }

        public IList<Spr_TypeAkciya> GetSpr_TypeAkciya()
        {
            return _DB.Spr_TypeAkciya.AsEnumerable().ToList();
        }

        public Spr_TypeAkciya GetSpr_TypeAkciya(Guid id)
        {
            return _DB.Spr_TypeAkciya.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_TypeAkciya(Spr_TypeAkciya obj)
        {
            Spr_TypeAkciya old = GetSpr_TypeAkciya(obj.ID);
            old.ТипАкции = obj.ТипАкции;
            _DB.SaveChanges();
        }

        public void AddSpr_TypeAkciya(Spr_TypeAkciya obj)
        {
            _DB.Spr_TypeAkciya.AddObject(obj);
            _DB.SaveChanges();
        }

        public void DeleteSpr_TypeAkciya(Guid id)
        {
            var obj = _DB.Spr_TypeAkciya.SingleOrDefault(c => c.ID == id);
            _DB.Spr_TypeAkciya.DeleteObject(obj);
            _DB.SaveChanges();
        }

        public IQueryable<String> GetTypeAkciyaList()
        {
            return from itm in _DB.Spr_TypeAkciya
                   orderby itm.ТипАкции
                   select itm.ТипАкции;
        }

        public IQueryable<String> GetTypeAkciyaListDist()
        {
            return GetTypeAkciyaList().Distinct();
        }

        public List<String> GetActualsListDist()
        {
            List<String> lst = new List<String>();
            lst.Add("Рабочая");
            lst.Add("Закрыта"); 
            return lst;
        }

        #endregion

        #region ---------------------------------Spr_Holding----------------------------------------------

        public IQueryable<String> GetHoldingList()
        {
            return from itm in _DB.Spr_Holding
                   orderby itm.Холдинг
                   select itm.Холдинг;
        }

        public List<String> GetHoldingListDist()
        {
            List<String> l = new List<String>();
            l.Add("");
            l.AddRange(GetHoldingList().Distinct());
            return l;
        }

        #endregion

        #region ---------------------------------Spr_Outlets---------------------------------------------

        public Spr_Outlets GetSpr_Outlets(Guid id)
        {
            return _DB.Spr_Outlets.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_Outlets(Spr_Outlets obj)
        {
            Spr_Outlets old = GetSpr_Outlets(obj.ID);
            old.SBU = obj.SBU;
            old.Адресдоставки = obj.Адресдоставки;
            old.Актуальность = obj.Актуальность;
            old.ГородТРТ = obj.ГородТРТ;
            old.Дистрибутор = obj.Дистрибутор;
            old.ДомТРТ = obj.ДомТРТ;
            old.ИНН = obj.ИНН;
            old.Каналреализации = obj.Каналреализации;
            old.КатегорияТРТ = obj.КатегорияТРТ;
            old.ТипАкции = obj.ТипАкции;
            old.Клиент = obj.Клиент;
            old.КодАдресдоставки = obj.КодАдресдоставки;
            old.КодКлиент = obj.КодКлиент;
            old.Область = obj.Область;
            old.ОбластьТРТ = obj.ОбластьТРТ;
            old.ПримечаниеТРТ = obj.ПримечаниеТРТ;
            old.ПровереноМП = obj.ПровереноМП;
            old.РайонТРТ = obj.РайонТРТ;
            old.Регион = obj.Регион;
            old.УлицаТРТ = obj.УлицаТРТ;
            old.Холдинг = obj.Холдинг;
            
            _DB.SaveChanges();
        }

        public IQueryable<String> GetCatigoryTRTList()
        {
            return from itm in _DB.Spr_CAP
                   orderby itm.КатегорияТРТ
                   select itm.КатегорияТРТ;
        }

        public List<String> GetCatigoryTRTListDist()
        {
            List<String> l = new List<String>();
            l.Add("");
            l.AddRange(GetCatigoryTRTList().Distinct());
            return l;
        }

        public string GetSprOutletsViewRow(Spr_Outlets obj)
        {
            string ret= String.Empty;
            ret = "<td class=\"td_btn\">" +
                  "<!--a Title=\"Просмотр\" href=\"/Store/ViewChecks/" + obj.ID.ToString() + "\"><img alt=\"Просмотр\" border=\"0\" src=\"/Content/Images/page.png\" /></a--> " +
                  "<a class=\"openDialog\" data-dialog-id=\"" + obj.ID.ToString() + "\" data-dialog-title=\"Редактирование: Торговые точки\" href=\"/Spr/Spr_OutletsEdit/" + obj.ID.ToString() + "\"><img alt=\"Редактировать\" border=\"0\" src=\"/Content/Images/page_edit.png\" /></a> " +
                  "<a Title=\"Заполнить StoreCheck\" href=\"/Store/SaveCheckRes/" + obj.ID.ToString() + "\" trget=\"_blank\"><img alt=\"Заполнить StoreCheck\" border=\"0\" src=\"/Content/Images/page_add.png\" /></a> " +
            "</td>" +
            "<td>" +
                obj.Регион +
            "</td>" +
            "<td>" +
                obj.Область +
            "</td>" +
            "<td>" +
                obj.Дистрибутор +
            "</td>" +
            "<td>" +
                obj.Каналреализации +
            "</td>" +
            "<td>" +
                obj.КатегорияТРТ +
            "</td>" +
            "<td>" +
                obj.ТипАкции +
            "</td>" +
            "<td>" +
                obj.Клиент +
            "</td>" +
            "<td>" +
                obj.Адресдоставки +
            "</td>" +
            "<td>" +
                obj.ГородТРТ +
            "</td>" +
            "<td>" +
                obj.УлицаТРТ +
            "</td>" +
            "<td>" +
                obj.ДомТРТ +
            "</td>" +
            "<td>" +
                obj.ПримечаниеТРТ +
            "</td>";         
            
            return ret;
        }

        public string GetCatTRT(Guid OutletID) 
        {
            return _DB.Spr_Outlets.SingleOrDefault(it => it.ID == OutletID).КатегорияТРТ;
        }

        #endregion

        #region ---------------------------------Spr_AdmObject---------------------------------------------

        public IQueryable<Spr_AdmObject> GetSpr_AdmObjectLst()
        {
            return _DB.Spr_AdmObject.OrderBy(o => o.Type);
        }

        public IQueryable<String> GetAdminObjectList()
        {
            return from itm in _DB.Spr_AdmObject
                   orderby itm.Type
                   select itm.Name;
        }

        public IQueryable<String> GetAdminObjectListDist()
        {
            return GetAdminObjectList().Distinct();
        }

        #endregion

        #region ---------------------------------Spr_Category_StoreCheck---------------------------------

        public IQueryable<Spr_Category_StoreCheck> GetSpr_Category_StoreCheckIQ()
        {
            return _DB.Spr_Category_StoreCheck;
        }

        public Guid Get_CatNameID_StoreCheck(String CategoryName)
        {
            Spr_Category_StoreCheck obj = _DB.Spr_Category_StoreCheck.SingleOrDefault(it => it.Name_Category == CategoryName);
            return obj.ID;
        }

        public IList<Spr_Category_StoreCheck> GetSpr_Category_StoreCheck()
        {
            return _DB.Spr_Category_StoreCheck.AsEnumerable().ToList();
        }

        public Spr_Category_StoreCheck GetSpr_Category_StoreCheck(Guid id)
        {
            return _DB.Spr_Category_StoreCheck.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_Category_StoreCheck(Spr_Category_StoreCheck obj)
        {
            Spr_Category_StoreCheck old = GetSpr_Category_StoreCheck(obj.ID);
            //old.ТипАкции = obj.ТипАкции;
            _DB.SaveChanges();
        }

        public void AddSpr_Category_StoreCheck(Spr_Category_StoreCheck obj)
        {
            _DB.Spr_Category_StoreCheck.AddObject(obj);
            _DB.SaveChanges();
        }

        public void DeleteSpr_Category_StoreCheck(Guid id)
        {
            var obj = _DB.Spr_Category_StoreCheck.SingleOrDefault(c => c.ID == id);
            _DB.Spr_Category_StoreCheck.DeleteObject(obj);
            _DB.SaveChanges();
        }

        public IQueryable<String> GetCategory_StoreCheckList()
        {
            return from itm in _DB.Spr_Category_StoreCheck
                   orderby itm.Category
                   select itm.Category;
        }

        public IQueryable<String> GetCategory_StoreCheckListDist()
        {
            return GetCategory_StoreCheckList().Distinct();
        }

        #endregion

        #region ---------------------------------Stores-------------------------------------------------------

        public IList<Spr_Outlets> GetStores()
        {
            return _DB.Spr_Outlets.AsEnumerable().ToList();
        }

        public IQueryable<Spr_Outlets> GetStoresIQ()
        {
            return _DB.Spr_Outlets;
        }

        public Spr_Outlets GetStore(Guid id)
        {
            return _DB.Spr_Outlets.SingleOrDefault(it => it.ID == id);
        }

        public Spr_Outlets GetSpr_Outlet(Guid id)
        {
            return _DB.Spr_Outlets.SingleOrDefault(it => it.ID == id);
        }

        public void AddCheckOutlet(CheckOutlet obj)
        {
            _DB.CheckOutlet.AddObject(obj);
            _DB.SaveChanges();
        }

        public void AddCheckOutletData(CheckOutletData obj)
        {                   
            _DB.CheckOutletData.AddObject(obj);
            _DB.SaveChanges();
        }

        public void AddCheckOutletImg(CheckOutletImg obj)
        {
            _DB.CheckOutletImg.AddObject(obj);
            _DB.SaveChanges();
        }

        public IQueryable<VWCheckOutlet> GetVWCheckOutlet(Guid id) 
        {
            return _DB.VWCheckOutlet.Where(p => p.OutletID.Equals(id));
        }
        
        public IQueryable<VWCheckOutletData> GetVWCheckOutletData(Guid id)
        {
            return _DB.VWCheckOutletData.Where(p => p.CheckOutletID.Equals(id));
        }

        public IQueryable<CheckOutletImg> GetImgList(Guid id)
        {
            return _DB.CheckOutletImg.Where(p => p.OutletID.Equals(id));
        }

        #endregion

        #region ---------------------------------Users---------------------------------

        public Users GetCurrUser(string username, string filterAttribute)
        {
            Users usr = null; 
            if (username == "sysadmin")
            {
                if (filterAttribute == Configuration.SysPassword)
                {
                    usr = new Users();
                    usr.ID = Guid.NewGuid();
                    usr.Login = username;
                    usr.FIO = username;
                    usr.AccessRights = 31;//все права
                }

                //_DB.Users.AddObject(usr);
                //_DB.SaveChanges();
                return usr;
            }


            IList<Users> userlst = _DB.Users.Where(p => p.Login.Equals(username, StringComparison.CurrentCultureIgnoreCase)).ToList();           
            
            if (userlst.Count == 0 || userlst[0].FIO != filterAttribute)
            {
                usr = new Users();
                usr.ID = Guid.NewGuid();
                usr.Login = username;
                usr.FIO = filterAttribute;
                _DB.Users.AddObject(usr);
                _DB.SaveChanges();
            }
            else
                usr = userlst[0];
            return usr;
        }

        public Users GetUserByLogin(string Login)
        {
            Users usr = null;
            IList<Users> UsrLst = _DB.Users.ToList();
            UsrLst = UsrLst.Where(p => p.Login.Equals(Login, StringComparison.CurrentCultureIgnoreCase)).ToList();
            if (UsrLst.Count > 0)
                usr = UsrLst[0];
            return usr;
        }

        public VWUsers GetVWUser(Guid id)
        {
            VWUsers usr = null;
            IList<VWUsers> UsrLst = _DB.VWUsers.ToList();
            UsrLst = UsrLst.Where(p => p.UserID.Equals(id)).ToList();
            if (UsrLst.Count > 0)
                usr = UsrLst[0];
            return usr;
        }

        public Users GetUser(Guid id)
        {
            return _DB.Users.SingleOrDefault(it => it.ID == id);
        }

        public void SaveUser(Users obj) 
        {
            Users old = GetUser(obj.ID);
            old.RoleID = obj.RoleID;
            old.SortType = obj.SortType;
            _DB.SaveChanges();
        }

        public IList<VWUsers> GetVWUsers()
        {
            return _DB.VWUsers.OrderBy(it => it.Login).AsEnumerable().ToList(); 
        }

        #endregion

        #region ---------------------------------Rights---------------------------------

        public IQueryable<TRights> GetRights(Guid RoleId)
        {

            IQueryable<TRights> model = from ro in _DB.Roles
                        join ri in _DB.Spr_Rights on ro.Rights equals ri.ID
                        join ad in _DB.Spr_AdmObject on ri.AdmObj equals ad.ID
                        where ro.Roles1 == RoleId
                        select new TRights() { ID = ro.ID, Name = ri.Name, Subject = ad.Name, SubjectID = ad.SubjectID ?? 0 , Type = ad.Type ?? 0};
            return model;
        }

        #endregion

        #region ---------------------------------Roles---------------------------------

        public bool IsDuplicateRight(Guid? roles, Guid? rights)
        {
            return _DB.Roles.Where(i => i.Roles1 == roles).Where(i => i.Rights == rights).ToList<Roles>().Count > 0;
        }

        #endregion

        #region ---------------------------------Admin---------------------------------

        public IList<VWRoles> GetVWRoles()
        {
            return _DB.VWRoles.OrderBy(it => it.RoleName).AsEnumerable().ToList();
        }

        public IList<VWRoles> GetVWRole(Guid id)
        {
            return _DB.VWRoles.Where(it => it.ID == id).AsEnumerable().ToList();
        }

        public void DeleteRole(Guid id)
        {
            var obj = _DB.Roles.SingleOrDefault(c => c.ID == id);
            _DB.Roles.DeleteObject(obj);
            _DB.SaveChanges();
        }

        public void AddRole(Roles obj)
        {
            _DB.Roles.AddObject(obj);
            _DB.SaveChanges();
        }

        #endregion

        #region ---------------------------------VWRepStoreCheck---------------------------------

        public IQueryable<VWRepStoreCheck> GetVWRepStoreCheckIQ()
        {
            return _DB.VWRepStoreCheck;
        }

        public IList<VWRepStoreCheck> GetVWRepStoreCheck()
        {
            return _DB.VWRepStoreCheck.AsEnumerable().ToList();
        }

        public VWRepStoreCheck GetRepStoreCheck(Guid id)
        {
            return _DB.VWRepStoreCheck.SingleOrDefault(it => it.ID == id);
        }

        public IQueryable<TCheckDataSKU> GetCheckDataSKU(Guid CheckOutletID)
        {
            /*join s in _DB.Spr_CAP on d.SKUID equals s.ID*/
            IQueryable<TCheckDataSKU> model = from d in _DB.CheckOutletData
                                              where d.CheckOutletID == CheckOutletID
                                              where d.SKUID != null
                                              select new TCheckDataSKU() { SKUID = d.SKUID ?? Guid.Empty, SKUName = d.SKUКМУ ?? String.Empty, SKUValue = d.Value ?? String.Empty, CodeAssortment = d.КодАссортимент ?? String.Empty, Assortment = d.Ассортимент ?? String.Empty, Trademark = d.ТорговаяМарка ?? String.Empty, Priority = d.Приоритетность ?? 0 };
            return model;
        }

        public IQueryable<TCheckDataCatStrChk> GetCheckDataCatStrChk(Guid CheckOutletID)
        {
            IQueryable<TCheckDataCatStrChk> model = from d in _DB.CheckOutletData
                                              where d.CheckOutletID == CheckOutletID
                                              where d.SKUID == null
                                                    select new TCheckDataCatStrChk() { CategoryID = d.CategoryID ?? Guid.Empty, Category = d.Category ?? String.Empty, NameCategory = d.CategoryName ?? String.Empty, CategoryValue = d.Value ?? String.Empty };
            return model.OrderBy(o=>o.Category).ThenBy(o=>o.NameCategory);
        }
           
        /*
        public void SaveVWRepStoreCheck(VWRepStoreCheck obj)
        {
            VWRepStoreCheck old = GetVWRepStoreCheck(obj.ID);
            //old.ТипАкции = obj.ТипАкции;
            _DB.SaveChanges();
        }

        public void AddVWRepStoreCheck(VWRepStoreCheck obj)
        {
            _DB.VWRepStoreCheck.AddObject(obj);
            _DB.SaveChanges();
        }

        public void DeleteVWRepStoreCheck(Guid id)
        {
            var obj = _DB.VWRepStoreCheck.SingleOrDefault(c => c.ID == id);
            _DB.VWRepStoreCheck.DeleteObject(obj);
            _DB.SaveChanges();
        }

        public IQueryable<String> GetVWRepStoreCheckList()
        {
            return from itm in _DB.VWRepStoreCheck
                   orderby itm.FIO
                   select itm.FIO;
        }

        public IQueryable<String> GetVWRepStoreCheckListDist()
        {
            return GetVWRepStoreCheckList().Distinct();
        }
         */ 

        #endregion

        #region ---------------------------------Log---------------------------------

        public IQueryable<Log> GetLogIQ()
        {
            return _DB.Log;
        }

        public IList<Log> GetLog()
        {
            return _DB.Log.AsEnumerable().ToList();
        }

        public IList<TLogRec> GetVWLog()
        {
            IQueryable<TLogRec> model = from l in _DB.Log
                                              join u in _DB.Users  on l.UserID equals u.ID
                                              where u.ID != null
                                        select new TLogRec() { ID = l.ID, Date = l.CrtDate ?? DateTime.Now, Field = l.Field, UserName = u.FIO, New = l.New, Old = l.Old };
   
            
            return model.AsEnumerable().ToList();
        }

        public void AddLog(Log obj)
        {
            _DB.Log.AddObject(obj);
            _DB.SaveChanges();
        }

        #endregion
    }
}