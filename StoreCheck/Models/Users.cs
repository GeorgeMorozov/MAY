using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreCheck.Models
{
     public enum enSortType
    {
         enSrtTM     = 0,         //По категории
         enSrtAssort = 1,         //По имени
            
    };
    
    public partial class Users
    {        
        private enSortType _sortTp;
        public Users()
        {
            
        }

        
        public enSortType SortType
        {
            
            get {
                int sortBit = this.UserBits ?? 0;
                if (Convert.ToBoolean(sortBit & (int)enSortType.enSrtAssort))
                    _sortTp = enSortType.enSrtAssort;
                else
                    _sortTp = enSortType.enSrtTM;  
                    return _sortTp;               
                }
            set {
                    _sortTp = value;
                    if (this.UserBits == null)
                        this.UserBits = 0;
                    if (_sortTp == enSortType.enSrtAssort)
                        
                        this.UserBits |= (int)enSortType.enSrtAssort;
                    else
                        this.UserBits &=~ (int)enSortType.enSrtAssort;
                         
                }
        
            /*
            get
            {
                int sortBit = this.Sort;
                if (Convert.ToBoolean(sortBit & (int)enSortType.enSrtAssort))
                    _sortTp = enSortType.enSrtAssort;
                else
                    _sortTp = enSortType.enSrtTM;
                return _sortTp;
            }
            set
            {
                _sortTp = value;
                if (_sortTp == enSortType.enSrtAssort)

                    this.Sort = 1;
                else
                    this.Sort = 0;

            }
             */ 
        }
    }
}