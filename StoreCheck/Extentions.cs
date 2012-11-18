﻿using System;
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
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, object routeValues, string imagePath, string alt)
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
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }

        // Extension method
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controllerName, object routeValues, string imagePath, string alt)
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
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }
        //function OpenDialog() {window.open("some url", "DialogName", "height=200,width=200,modal=yes,alwaysRaised=yes");}
        // Extension method
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controllerName, object routeValues, string imagePath, string alt, bool popup)
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
        /*
        public static MvcHtmlString ActionImageAjax(this HtmlHelper html, string action, string controllerName, object routeValues, string imagePath, string alt, bool popup)
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
        } */


        // Extension method
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controllerName, object routeValues, string imagePath, string alt, object htmlAttributes)
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
    }
}