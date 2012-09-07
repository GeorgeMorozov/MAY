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

    }
}