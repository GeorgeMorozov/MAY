using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreCheck.Models
{
    public class DataManager
    {
        private DBEntities _SprDB;

        public DataManager()
        {
            _SprDB = new DBEntities();
        }
//-----------------Spr_Roles----------------------------------------------
        public IQueryable<Spr_Roles> GetSpr_Roles()
        {
            return _SprDB.Spr_Roles;
        }

        public Spr_Roles GetSpr_Role(Guid id)
        {
            return _SprDB.Spr_Roles.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_Role(Spr_Roles obj)
        {
            Spr_Roles old = GetSpr_Role(obj.ID);
            old.Name = obj.Name;
            _SprDB.SaveChanges();
        }

        public void AddSpr_Role(Spr_Roles obj)
        {
            _SprDB.Spr_Roles.AddObject(obj);
            _SprDB.SaveChanges();
        }

        public void DeleteSpr_Role(Guid id)
        {
            var obj = _SprDB.Spr_Roles.SingleOrDefault(c => c.ID == id);
            _SprDB.Spr_Roles.DeleteObject(obj);
            _SprDB.SaveChanges();
        }

//-----------------Spr_Rights----------------------------------------------
        public IQueryable<Spr_Rights> GetSpr_Rights()
        {
            return _SprDB.Spr_Rights;
        }

        public Spr_Rights GetSpr_Right(Guid id)
        {
            return _SprDB.Spr_Rights.SingleOrDefault(it => it.ID == id);
        }

        public void SaveSpr_Right(Spr_Roles obj)
        {
            Spr_Rights old = GetSpr_Right(obj.ID);
            old.Name = obj.Name;
            _SprDB.SaveChanges();
        }

        public void AddSpr_Right(Spr_Rights obj)
        {
            _SprDB.Spr_Rights.AddObject(obj);
            _SprDB.SaveChanges();
        }

        public void DeleteSpr_Right(Guid id)
        {
            var obj = _SprDB.Spr_Rights.SingleOrDefault(c => c.ID == id);
            _SprDB.Spr_Rights.DeleteObject(obj);
            _SprDB.SaveChanges();
        }


//-----------------Spr_CAP----------------------------------------------
        public IQueryable<Spr_CAP> GetSpr_CAPs()
        {
            return _SprDB.Spr_CAP;
        }

        public Spr_CAP GetSpr_CAP(Guid id)
        {
            return _SprDB.Spr_CAP.SingleOrDefault(it => it.ID == id);
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
            _SprDB.SaveChanges();
        }

        public void AddSpr_CAP(Spr_CAP obj)
        {
            _SprDB.Spr_CAP.AddObject(obj);
            _SprDB.SaveChanges();
        }

        public void DeleteSpr_CAP(Guid id)
        {
            var obj = _SprDB.Spr_CAP.SingleOrDefault(c => c.ID == id);
            _SprDB.Spr_CAP.DeleteObject(obj);
            _SprDB.SaveChanges();
        }


//-----------------Spr_SR----------------------------------------------
        public IQueryable<Spr_SR> GetSpr_SRs()
        {
            return _SprDB.Spr_SR;
        }

        public Spr_SR GetSpr_SR(Guid id)
        {
            return _SprDB.Spr_SR.SingleOrDefault(it => it.ID == id);
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
            _SprDB.SaveChanges();
        }

        public void AddSpr_SR(Spr_SR obj)
        {
            _SprDB.Spr_SR.AddObject(obj);
            _SprDB.SaveChanges();
        }

        public void DeleteSpr_SR(Guid id)
        {
            var obj = _SprDB.Spr_SR.SingleOrDefault(c => c.ID == id);
            _SprDB.Spr_SR.DeleteObject(obj);
            _SprDB.SaveChanges();
        }

//-----------------------------------------------------------------------
    }
}