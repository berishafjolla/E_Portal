using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace WebApplication.Models
{
    public static class Utility
    {
        public static string Get_Path()
        {
            string temp = "";
            if (System.Web.HttpContext.Current.Request.Url.AbsolutePath == "/")
            {
                temp = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
                temp = temp.Remove(temp.Length - 1);
            }
            else
                temp = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path).Replace(System.Web.HttpContext.Current.Request.Url.AbsolutePath, "") +  WebApplication.Models.Utility.GetGSite();

            return temp;
        }

        public static string GetGSite()
        {
            return System.Configuration.ConfigurationManager.AppSettings["GSite"].ToString();
        }
    }
}
