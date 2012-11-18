using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreCheck.Models
{
    public class DataManager
    {
        private readonly Entities _DB;

        public DataManager()
        {
            _DB = new Entities();
        }
        //-----------------Spr_Roles----------------------------------------------
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

        //-----------------Spr_Rights----------------------------------------------
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

        public void SaveSpr_Right(Spr_Roles obj)
        {
            Spr_Rights old = GetSpr_Right(obj.ID);
            old.Name = obj.Name;
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


        //-----------------Spr_CAP----------------------------------------------
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

        //-----------------Spr_SR----------------------------------------------
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

        //-----------------Spr_ChannelRetail----------------------------------------------
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

        public IQueryable<String> GetChannelRetailListDist()
        {
            return GetChannelRetailList().Distinct();
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

        //-----------------Spr_TypeTA----------------------------------------------
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
        
        //-----------------Spr_Outlets---------------------------------------------
       
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

        public IQueryable<String> GetCatigoryTRTListDist()
        {
            return GetCatigoryTRTList().Distinct();
        }

        public string GetSprOutletsViewRow(Spr_Outlets obj)
        {
            string ret= String.Empty;
            ret = "<td class=\"td_btn\">" +
                  "<a Title=\"Просмотр\" href=\"/Store/ViewChecks/" + obj.ID.ToString() + "\"><img alt=\"Просмотр\" border=\"0\" src=\"/Content/Images/page.png\" /></a> " +
                  "<a class=\"openDialog\" data-dialog-id=\"" + obj.ID.ToString() + "\" data-dialog-title=\"Редактирование: Торговые точки\" href=\"/Spr/Spr_OutletsEdit/" + obj.ID.ToString() + "\"><img alt=\"Редактировать\" border=\"0\" src=\"/Content/Images/page_edit.png\" /></a> " +
                  "<a Title=\"Заполнить StoreCheck\" href=\"/Store/SaveCheckRes/" + obj.ID.ToString() + "\"><img alt=\"Заполнить StoreCheck\" border=\"0\" src=\"/Content/Images/page_add.png\" /></a> " +
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
       
        //-------------Stores-------------------------------------------------------

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
        
        //-----------------------------------Users-------------------------------------------------------

        public Users GetCurrUser(string username, string filterAttribute)
        {
            Users usr = null; 
            IList<Users> userlst = _DB.Users.Where( p => p.Login.Equals(username) ).ToList();
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
            UsrLst = UsrLst.Where(p => p.Login.Equals(Login)).ToList();
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

        //-----------------Admin----------------------------------------------
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
 

    }
}