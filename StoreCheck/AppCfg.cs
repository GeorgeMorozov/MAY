using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StoreCheck
{
    public static class Configuration
    {
        /*
        [ConfigurationProperty("imagePath", IsRequired = true)]
        public string imagePath
        {
            get { return (string)base["imagePath"]; }
            set { base["imagePath"] = value; }
        }
        */
        public static string ImgPath
        {
            get
            {
                string s = ConfigurationManager.AppSettings["ImgPath"];
                return s;
            }
        }
        public static string SysPassword
        {
            get
            {
                string s = ConfigurationManager.AppSettings["filterAttribute"];
                return s;
            }
        }
    }

/*
    private static AppConfiguration instance = null;

    public static AppConfiguration Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (MailCenterConfiguration)WebConfigurationManager
                     .GetSection("mailCenter");
            }
            return instance;
        }
    }
*/	
}