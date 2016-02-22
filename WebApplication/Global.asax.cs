using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}",                           // URL with parameters
                new { controller = "Portlet", action = "Portal"}  // Parameter defaults
            );


            routes.MapRoute(
                "UnActivePortlets",                                              // Route name
                "Portlet/UnActivePortlets",                           // URL with parameters
                new { controller = "Portlet", action = "UnActivePortlets"}  // Parameter defaults
            );



            routes.MapRoute(
              "portletName",                                              // Route name
              "Portlet/Content/{portlet_ID}/{page}/{portletName}",                           // URL with parameters
              new { controller = "Portlet", action = "Content", portlet_ID = "", page = "", portletName = "" }  // Parameter defaults
            );

            
            routes.MapRoute(
              "PortletsPlacementManager",                                              // Route name
              "Portlet/PortletsPlacementManager/{column_ID}/{portlet_ID}/{row_No}/{is_Drop}",                           // URL with parameters
              new { controller = "Portlet", action = "PortletsPlacementManager", column_ID = "", portlet_ID = "", row_No = "", is_Drop = "" }  // Parameter defaults
            );

            routes.MapRoute(
              "PortletsStatusManager",                                              // Route name
              "Portlet/PortletsStatusManager/{portlet_ID}/{is_Active}",                           // URL with parameters
              new { controller = "Portlet", action = "PortletsStatusManager", portlet_ID = "", is_Active = "" }  // Parameter defaults
            );

         
            routes.MapRoute(
            "TotalCatetogoryPortlets",                                              // Route name
            "Portlet/TotalCatetogoryPortlets/{category_ID}/{is_Active}",                           // URL with parameters
            new { controller = "Portlet", action = "TotalCatetogoryPortlets", category_ID = "", is_Active = "" }  // Parameter defaults
          );

            routes.MapRoute(
            "TotalPortlets",                                              // Route name
            "Portlet/TotalPortlets/{is_Active}",                           // URL with parameters
            new { controller = "Portlet", action = "TotalPortlets", is_Active = "" }  // Parameter defaults
          );

             routes.MapRoute(
              "GetItemDetail",                                              // Route name
              "Portlet/GetItemDetail/{portlet_ID}/{item_No}",                           // URL with parameters
              new { controller = "Portlet", action = "GetItemDetail", portlet_ID = "", item_No = "" }  // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            WebApplication.Models.Data data = new WebApplication.Models.Data();

           
            data.AddCategory("Lajme");
            data.AddPortlet("http://www.albeu.com/rss/rss.php", 1, "Lajme shqip", 1, true);
            data.AddPortlet("http://www.albeu.com/rss/rss.php?kat=news", 1, "Lajme anglisht", 2, true);
            data.AddPortlet("http://www.albeu.com/rss/rss.php?kat=sport", 1, "Sport", 2, false);
           
            data.AddPortlet("http://www.albeu.com/rss/rss.php?kat=bota", 2, "Lajme nga bota", 3, true);
           
           
            data.AddPortlet("http://feeds.abcnews.com/abcnews/internationalheadlines", 3, "ABC News:International Headlines", 2, false);
                     data.AddPortlet("http://www.albeu.com/rss/rss.php?kat=teknologji", 1, "Teknologjia ne bote", 1, true);
                     data.AddPortlet("http://www.albeu.com/rss/rss.php", 1, "Moti ne Kosove", 1, true);


                     data.AddCategory("e-Ekonomia");

                     data.AddPortlet("http://www.albeu.com/rss/rss.php?kat=ekonomi", 1, "Ekonomi", 1, true);
                     data.AddCategory("e-Statistikat");
                     data.AddPortlet("https://ask.rks-gov.net//zyra-e-shtypit?format=feed&amp;type=rss", 1, "Agjencia Statistikore e Kosoves", 5, true);
           

                      data.AddCategory("e-Presidenca");
            data.AddPortlet("http://www.president-ksgov.net/rss/10_3.xml", 1, "Te fundit", 1, true);
            data.AddPortlet("http://www.president-ksgov.net/rss/6_1.xml", 1, "Takime", 2, true);
            data.AddPortlet("http://www.president-ksgov.net/rss/6_2.xml", 1, "Presidentja", 3, true);
            data.AddPortlet("http://www.president-ksgov.net/rss/8_1.xml", 1, "Presidenca Anglisht", 4, true);
            data.AddPortlet("http://www.president-ksgov.net/rss/8_2.xml", 2, "Te fundit anglisht", 1, true);
            data.AddPortlet("http://www.president-ksgov.net/rss/8_3.xml", 2, "Te fundit serbisht", 2, true);
            data.AddPortlet("http://www.president-ksgov.net/rss/10_1.xml", 2, "Media deklarata", 3, true);
            data.AddPortlet("http://www.president-ksgov.net/rss/10_2.xml", 3, "Media Anglisht", 4, true);
           

            data.AddCategory("e-Kryeministri");
            data.AddPortlet("http://www.kryeministri-ks.net/rss/rss.php", 1, "Lajmet nga zyra e kryeministrit", 1, true);
           

            Application["data"] = data.Complete();
        }

        public void Session_OnStart()
        {
            WebApplication.Models.ds _dsSession = new WebApplication.Models.ds();
            WebApplication.Models.ds _dsApplication = (WebApplication.Models.ds) Application["data"];
            _dsSession.EnforceConstraints = false;

            System.Data.DataRow[] rows = _dsApplication.Portlet.Select();
            System.Data.DataRow rowTemp;
            foreach( System.Data.DataRow row in  rows )
            {
                rowTemp = _dsSession.Portlet_User.NewRow();
                rowTemp["Category_ID"] = row["Category_ID"];
                rowTemp["User_ID"] = Session.Count + 1;
                rowTemp["Portlet_ID"] = row["Portlet_ID"];
                rowTemp["Column_No"] = row["Column_No"];
                rowTemp["Row_Sequence"] = row["Row_Sequence"];
                rowTemp["Title"] = row["Title"];
                rowTemp["Is_Image_Allowed"] = row["Is_Image_Allowed"];
                rowTemp["Is_Active"] = true;
                _dsSession.Portlet_User.Rows.Add(rowTemp);
            }

            Session["data"] = _dsSession;
        }
         


    }
}