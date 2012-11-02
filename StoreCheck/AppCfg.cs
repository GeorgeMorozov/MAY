using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StoreCheck
{
    public sealed class AppConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("imagePath", IsRequired = true)]
        public  string imagePath
        {
            get { return (string)base["imagePath"]; }
            set { base["imagePath"] = value; }
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