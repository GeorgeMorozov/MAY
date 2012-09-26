using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreCheck.Models
{
    public class DataManager
    {
        private readonly DBEntities _DB;

        public DataManager()
        {
            _DB = new DBEntities();
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
            old.КодСупервайзер = obj.КодСупервайзер;
            old.КодТА = obj.КодТА;
            old.МаршрутТА = obj.МаршрутТА;
            old.Область = obj.Область;
            old.Регион = obj.Регион;
            old.Супервайзер = obj.Супервайзер;
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

        public void Test(Guid id)
        {
            //return _DB.Spr_Outlets.SingleOrDefault(it => it.ID == id);
            //System.Data.Objects.ObjectParameter[] params;
            // _DB.CreateQuery("select * from Spr_Outlets", params);
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
        //-----------------------------------Users-------------------------------------------------------

        public Users GetCurrUser(string username, string filterAttribute)
        {
            Users usr = null; 
            IList<Users> userlst = _DB.Users.Where(p => p.Login.Equals(username)).ToList();
            if (userlst.Count == 0)
            {
                usr = new Users();
                usr.Login = username;
                usr.FIO = filterAttribute;
                _DB.Users.AddObject(usr);
                _DB.SaveChanges();
            }
            else
                usr = userlst[0];
            return usr;
 
        }
    }
}