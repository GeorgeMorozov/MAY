using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace StoreCheck
{
    public static class Extentions
    {
        public static string MyH1Helper(this HtmlHelper html, string text)
        {
            return String.Format("<h1>{0}</h1>", text);
        }
    }
}