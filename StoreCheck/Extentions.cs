using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace StoreCheck
{
    
    public static class Extension
    {
            
        public static MvcHtmlString MyH1Helper(this HtmlHelper html, string text)
        {
            string s = String.Format("<h1>{0}</h1>", text);
            return MvcHtmlString.Create(s);
        }

        // Extension method
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, object routeValues, string imagePath, string alt, bool newPage = false)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            imgBuilder.MergeAttribute("border", "0");
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);
            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, routeValues));
            anchorBuilder.MergeAttribute("Title", alt);
            if (newPage)
              anchorBuilder.MergeAttribute("target", "_blank");          
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }

        // Extension method
        
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controllerName, object routeValues, string imagePath, string alt, bool newPage = false)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            imgBuilder.MergeAttribute("border", "0");
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);
            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controllerName, routeValues));
            anchorBuilder.MergeAttribute("Title", alt);
            if (newPage)
                anchorBuilder.MergeAttribute("target", "_blank");  
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }

        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, object routeValues, string imagePath, string alt, object htmlAttributes)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            imgBuilder.MergeAttribute("border", "0");
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);
            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, routeValues));
            anchorBuilder.MergeAttribute("Title", alt);
            RouteValueDictionary v = new RouteValueDictionary(htmlAttributes);
            anchorBuilder.Attributes.Add("onclick", v["onclick"].ToString());
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }
        //function OpenDialog() {window.open("some url", "DialogName", "height=200,width=200,modal=yes,alwaysRaised=yes");}
        // Extension method
        /*
        public static MvcHtmlString ActionImagePopup(this HtmlHelper html, string action, string controllerName, object routeValues, string imagePath, string alt, bool popup)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            imgBuilder.MergeAttribute("border", "0");
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);
            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controllerName, routeValues));
            anchorBuilder.MergeAttribute("onClick", "window.open('" + url.Action(action, controllerName, routeValues) + "','" + action + "','width=500,height=500,scrollbars=no,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=0,top=0'); return false");
            anchorBuilder.MergeAttribute("Title", alt);
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }
         */

        public static MvcHtmlString ActionPopup(this HtmlHelper html, string action, string controllerName, object routeValues,  string LinkName, object htmlAttributes)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            RouteValueDictionary v = new RouteValueDictionary(htmlAttributes);
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.Attributes.Add("class", v["class"].ToString());
            anchorBuilder.Attributes.Add("data-dialog-id", v["data_dialog_id"].ToString());
            anchorBuilder.Attributes.Add("data-dialog-title", v["data_dialog_title"].ToString());

            anchorBuilder.MergeAttribute("href", url.Action(action, controllerName, routeValues));
            anchorBuilder.InnerHtml = LinkName; 
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }

        // Extension method
        public static MvcHtmlString ActionImagePopup(this HtmlHelper html, string action, string controllerName, object routeValues, string imagePath, string alt, object htmlAttributes)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            imgBuilder.MergeAttribute("border", "0");
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);
            // build the <a> tag
            
            RouteValueDictionary v = new RouteValueDictionary(htmlAttributes);
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("Title", alt);
            anchorBuilder.Attributes.Add("class", v["class"].ToString());
            anchorBuilder.Attributes.Add("data-dialog-id", v["data_dialog_id"].ToString());
            anchorBuilder.Attributes.Add("data-dialog-title", v["data_dialog_title"].ToString());

            anchorBuilder.MergeAttribute("href", url.Action(action, controllerName, routeValues));
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }


        public static MvcHtmlString ImageActionLink(this AjaxHelper helper, string imageUrl, string altText, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("alt", altText);
            var link = helper.ActionLink("[replaceme]", actionName, routeValues, ajaxOptions);
            return new MvcHtmlString(link.ToHtmlString().Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing)));
        }

        public static IHtmlString MyImage(this HtmlHelper htmlHelper, string url)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var img = new TagBuilder("img");
            img.Attributes["alt"] = "[IMAGE]";
            img.Attributes["src"] = UrlHelper.GenerateContentUrl(url, htmlHelper.ViewContext.HttpContext);
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }
        
        public static String ToBase64(this HtmlHelper html, string sAscii)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(sAscii);
            return System.Convert.ToBase64String(bytes, 0, bytes.Length);
        }

        public static String FromBase64(this HtmlHelper html, string sbase64)
        {
            byte[] bytes = System.Convert.FromBase64String(sbase64);
            //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(bytes, 0, bytes.Length);
        }

        public static String FromBase64(string sbase64)
        {
            byte[] bytes = System.Convert.FromBase64String(sbase64);
            //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(bytes, 0, bytes.Length);
        }

        #region -------------------------Translate---------------------------------
        public static String CyrToLatin(this HtmlHelper html, string str)
        {
            return CyrToLatin(str);
        }

        public static String LatinToCyr(this HtmlHelper html, string str)
        {
            return LatinToCyr(str);
        }


        public static String CyrToLatin(string str)
        {

            str = str.Replace("б", "b");
            str = str.Replace("Б", "B");

            str = str.Replace("в", "v");
            str = str.Replace("В", "V");

            str = str.Replace("г", "h");
            str = str.Replace("Г", "H");

            str = str.Replace("ґ", "g");
            str = str.Replace("Ґ", "G");

            str = str.Replace("д", "d");
            str = str.Replace("Д", "D");

            str = str.Replace("є", "ye");
            str = str.Replace("Э", "Ye");

            str = str.Replace("ж", "zh");
            str = str.Replace("Ж", "Zh");

            str = str.Replace("з", "z");
            str = str.Replace("З", "Z");

            str = str.Replace("и", "y");
            str = str.Replace("И", "Y");

            str = str.Replace("ї", "yi");
            str = str.Replace("Ї", "YI");

            str = str.Replace("й", "j");
            str = str.Replace("Й", "J");

            str = str.Replace("к", "k");
            str = str.Replace("К", "K");

            str = str.Replace("л", "l");
            str = str.Replace("Л", "L");

            str = str.Replace("м", "m");
            str = str.Replace("М", "M");

            str = str.Replace("н", "n");
            str = str.Replace("Н", "N");

            str = str.Replace("п", "p");
            str = str.Replace("П", "P");

            str = str.Replace("р", "r");
            str = str.Replace("Р", "R");

            str = str.Replace("с", "s");
            str = str.Replace("С", "S");

            str = str.Replace("ч", "ch");
            str = str.Replace("Ч", "CH");

            str = str.Replace("ш", "sh");
            str = str.Replace("Щ", "SHH");

            str = str.Replace("ю", "yu");
            str = str.Replace("Ю", "YU");

            str = str.Replace("Я", "YA");
            str = str.Replace("я", "ya");

            str = str.Replace('ь', '^');
            str = str.Replace("Ь", "^");

            str = str.Replace('т', 't');
            str = str.Replace("Т", "T");

            str = str.Replace('ц', 'c');
            str = str.Replace("Ц", "C");

            str = str.Replace('о', 'o');
            str = str.Replace("О", "O");

            str = str.Replace('е', 'e');
            str = str.Replace("Е", "E");

            str = str.Replace('а', 'a');
            str = str.Replace("А", "A");

            str = str.Replace('ф', 'f');
            str = str.Replace("Ф", "F");

            str = str.Replace('і', 'i');
            str = str.Replace("І", "I");

            str = str.Replace('У', 'U');
            str = str.Replace("у", "u");

            str = str.Replace('х', 'x');
            str = str.Replace("Х", "X");

            str = str.Replace('ы', '*');
            str = str.Replace("Ы", "*");

            return str;
        }

        public static String LatinToCyr(string str)
        {

            str = str.Replace("b", "б");
            str = str.Replace("B", "Б");

            str = str.Replace("в", "v");
            str = str.Replace("V", "В");

            str = str.Replace("h", "г");
            str = str.Replace("H", "Г");

            str = str.Replace("g", "ґ");
            str = str.Replace("G", "Ґ");

            str = str.Replace("d", "д");
            str = str.Replace("D", "Д");

            str = str.Replace("ye", "є");
            str = str.Replace("Ye", "Э");

            str = str.Replace("zh", "ж");
            str = str.Replace("Zh", "Ж");

            str = str.Replace("z", "з");
            str = str.Replace("Z", "З");



            str = str.Replace("yi", "ї");
            str = str.Replace("YI", "Ї");

            str = str.Replace("y", "и");
            str = str.Replace("Y", "И");

            str = str.Replace("j", "й");
            str = str.Replace("J", "Й");

            str = str.Replace("k", "к");
            str = str.Replace("K", "К");

            str = str.Replace("l", "л");
            str = str.Replace("L", "Л");

            str = str.Replace("m", "м");
            str = str.Replace("M", "М");

            str = str.Replace("n", "н");
            str = str.Replace("N", "Н");

            str = str.Replace("p", "п");
            str = str.Replace("P", "П");

            str = str.Replace("r", "р");
            str = str.Replace("R", "Р");

            str = str.Replace("s", "с");
            str = str.Replace("S", "С");

            str = str.Replace("ch", "ч");
            str = str.Replace("CH", "Ч");

            str = str.Replace("sh", "ш");
            str = str.Replace("SHH", "Щ");

            str = str.Replace('a', 'а');
            str = str.Replace("A", "А");

            str = str.Replace("yu", "ю");
            str = str.Replace("YU", "Ю");

            str = str.Replace("YA", "Я");
            str = str.Replace("ya", "я");

            str = str.Replace('^', 'ь');
            str = str.Replace("^", "Ь");

            str = str.Replace('t', 'т');
            str = str.Replace("T", "Т");

            str = str.Replace('c', 'ц');
            str = str.Replace("C", "Ц");

            str = str.Replace('o', 'о');
            str = str.Replace("O", "О");

            str = str.Replace('e', 'е');
            str = str.Replace("E", "Е");

            str = str.Replace('f', 'ф');
            str = str.Replace("F", "Ф");

            str = str.Replace('i', 'і');
            str = str.Replace("I", "І");

            str = str.Replace('U', 'У');
            str = str.Replace("u", "у");

            str = str.Replace('x', 'х');
            str = str.Replace("X", "Х");

            str = str.Replace('*', 'ы');
            str = str.Replace("*", "Ы");

            return str;
        }

        #endregion

    }
}