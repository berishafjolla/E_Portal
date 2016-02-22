using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Threading;
using System.Xml;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.Compilation;



namespace WebApplication.Controllers
{
    public class PortletController : Controller
    {
        //
        // GET: /Portlet/
        //
        public ActionResult Index()
        {
            return View();
        }
        public RedirectResult RedirectToAspx()
        {
            return Redirect("/Temp.aspx");
        }
     
        public RedirectResult Shtet()
        {
            return Redirect("/WebFormShtet.aspx");
        }
        public ActionResult Popullsia()
        {
            return View();
        }

        public RedirectResult Ballina()
        {
            return Redirect("/Home.aspx");
        }
        public RedirectResult Kontakt()
        {
            return Redirect("/Kontakt.aspx");
        }
        public ActionResult ASK()
        {
            return View();
        }
      
        /// <summary>
        /// provides portlet/webpart content using provided context parameters
        /// </summary>
        /// <param name="Portlet_ID">application portlet id</param>
        /// <param name="page">specific portlet page to be viewed</param>
        /// <param name="portletName">portlet name</param>
        /// <returns></returns>
        public ActionResult Content(int? portlet_ID, int page, string portletName)
        {
            Thread.Sleep(100);
            // invalid portlet id
            if( portlet_ID == null )
                return View("ErrorPortalItem");

            #region declaration
            XmlNodeList objNL;
            StringBuilder str = new StringBuilder();
            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
            string title = "";
            string ItemLink = "";
            string ItemTitle = "";
            double total_Items = 0;
            int last_Item_No = 0;
            System.IO.TextWriter tr = new System.IO.StringWriter();
            HtmlTextWriter writer = new  HtmlTextWriter(tr);
            HtmlTextWriter nestedWriter = new HtmlTextWriter(tr);
            #endregion
         
            #region loading RSS feed
            WebApplication.Models.ds.PortletRow portRow = ((WebApplication.Models.ds) this.HttpContext.Application["data"]).Portlet.FindByPortlet_ID( Convert.ToInt32( portlet_ID ) );
            string link = portRow.Link;
            bool is_Image_Allowed = portRow.Is_Image_Allowed;



            XmlDocument objDoc = new XmlDocument();

          
            try
            {
                objDoc.LoadXml(portRow.RSS_Feed);
            }
            catch
            {
                // invalid portlet id
                return View("ErrorPortalItem");
            }
            #endregion


            #region parsing RSS parent node
            objNL = objDoc.SelectNodes("rss/channel");
            if (null != objNL)
            {
                // get title for portlet
                title = objNL[0].ChildNodes[0].InnerText;
            }
            #endregion

            #region parsing items in RSS feed
            if (null != objDoc)
            {
                objNL = objDoc.SelectNodes("rss/channel/item");
                if (null != objNL)
                {
                    int counter = 1;
                    string description = "";
                    total_Items = objNL.Count;

                    str.Append("<ul style=\" vertical-align:top; padding:0em 1em 0em 1em;\">");
                    writer.AddAttribute( HtmlTextWriterAttribute.Style,"vertical-align:top; padding:0em 1em 0em 1em;");
                    writer.RenderBeginTag(HtmlTextWriterTag.Ul);

                    foreach (XmlNode XNode in objNL)
                    {
                        if (counter >= ((page * pageSize) - pageSize + 1) && counter <= (page * pageSize))
                        {
                            str.Append("<li>");
                            
                            ItemTitle = "";
                            description = "";
                            ItemLink = "";

                            foreach (XmlNode XNodeNested in XNode.ChildNodes)
                            {
                                switch (XNodeNested.Name)
                                {
                                    case "description":
                                        description = XNodeNested.InnerText;
                                        break;
                                    case "title":
                                        ItemTitle = XNodeNested.InnerText;
                                        break;
                                    case "link":
                                        ItemLink = XNodeNested.InnerText;
                                        break;
                                }
                            }
                            
                            // conditon if description element of item length is greater then 1000 characters or it has html tags
                            if (description.Length > 1000 || !is_Image_Allowed )
                            {
                                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                                
                                nestedWriter = new HtmlTextWriter(new System.IO.StringWriter());
                                nestedWriter.AddAttribute(HtmlTextWriterAttribute.Href, ItemLink);
                                nestedWriter.AddAttribute(HtmlTextWriterAttribute.Target, "_blank");
                                nestedWriter.RenderBeginTag(HtmlTextWriterTag.A);
                                nestedWriter.InnerWriter.WriteLine(ItemTitle);
                                nestedWriter.RenderEndTag();
                                
                                writer.InnerWriter.WriteLine(nestedWriter.InnerWriter.ToString());
                                
                                writer.RenderEndTag();
                            }
                            else 
                            {
                                if( description.Contains("&lt;img") || description.Contains("<img")   )
                                {
                                    writer.RenderBeginTag(HtmlTextWriterTag.Li);
                                    nestedWriter = new HtmlTextWriter(new System.IO.StringWriter());
                                    nestedWriter.AddAttribute(HtmlTextWriterAttribute.Href, ItemLink);
                                    nestedWriter.AddAttribute(HtmlTextWriterAttribute.Target, "_blank");
                                    nestedWriter.RenderBeginTag(HtmlTextWriterTag.A);
                                    nestedWriter.InnerWriter.WriteLine(ItemTitle);
                                    nestedWriter.RenderEndTag();
                                    writer.InnerWriter.WriteLine(nestedWriter.InnerWriter.ToString());
                                    writer.Write(description);
                                    writer.RenderEndTag();
                                 }
                                else
                                {
                                    writer.RenderBeginTag(HtmlTextWriterTag.Li);

                                    nestedWriter = new HtmlTextWriter(new System.IO.StringWriter());
                                    nestedWriter.AddAttribute(HtmlTextWriterAttribute.Href, ItemLink);
                                    nestedWriter.AddAttribute(HtmlTextWriterAttribute.Target, "_blank");
                                    nestedWriter.AddAttribute(HtmlTextWriterAttribute.Title, description);
                                    nestedWriter.RenderBeginTag(HtmlTextWriterTag.A);
                                    nestedWriter.RenderEndTag();
                                    nestedWriter.InnerWriter.WriteLine(ItemTitle);
                                    writer.InnerWriter.WriteLine(nestedWriter.InnerWriter.ToString());
                                    writer.RenderEndTag();
                                }
                            }
                           
                            last_Item_No = counter;
                        }
                        counter++;
                    }
                    writer.RenderEndTag();
                }
            }
            #endregion

            #region generate content view information
            int start_Range = ((page * pageSize) - pageSize);
            start_Range = start_Range == 0 ? 1 : start_Range;
            ViewData["Header"] = "<b>Page:</b> " + page + "  <b>( </b> " + start_Range.ToString() + "<b> - </b>" + last_Item_No.ToString() + " <b> )</b> " +
                " <b> from " + total_Items.ToString() + "</b>";
            #endregion

            #region setting view's naviation variables
            double temp = total_Items / pageSize;
            int possible_Pages = Convert.ToInt32(Math.Ceiling(temp));

            ViewData["Next_Page"] = page + 1;
            ViewData["Previous_Page"] = page - 1;

            if ( ( page + 1 ) > possible_Pages)
                ViewData["Is_Next_Page_Possible"] = false; 
            else
                ViewData["Is_Next_Page_Possible"] = true;
            if ((page + 1) == possible_Pages)
                ViewData["Is_Next_Page_Possible"] = true;

            if ( ( page  ) == 1)
                ViewData["Is_Previous_Page_Possible"] = false;
            else
                ViewData["Is_Previous_Page_Possible"] = true;
            #endregion

            #region setting view's content variables
            ViewData["content"] = writer.InnerWriter.ToString();// str.ToString();
            ViewData["title"] = title;
            ViewData["portletName"] = portletName;
            #endregion
            return View();
        }


        public ActionResult GetItemDetail(int? portlet_ID, int? item_No)
        {
            // invalid portlet id
            if (portlet_ID == null || item_No == null)
                return View("ErrorPortalItem");
           
            #region declaration
            XmlNodeList objNL;
            StringBuilder str = new StringBuilder();
            
            // portlet page size 
            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());

            string title = "";
            string imagePath = "";
            string ItemName = "Item" + portlet_ID.ToString();
            string ItemLink = "";
            string ItemTitle = "";
            #endregion

            #region loading RSS path
            string link = ((WebApplication.Models.ds)this.HttpContext.Application["data"]).Portlet.FindByPortlet_ID(Convert.ToInt32(portlet_ID)).Link;
            XmlDocument objDoc = new XmlDocument();
            
            try
            {
                objDoc.Load(link);
            }
            catch
            {
                // invalid portlet id
                return View("ErrorPortalItem");
            }
            #endregion
           
            #region parsing RSS header for title
            objNL = objDoc.SelectNodes("rss/channel");
            if (null != objNL)
            {
                // get title for portlet
                title = objNL[0].ChildNodes[0].InnerText;
            }
            #endregion

            #region get image path for portlet from RSS feed
            objNL = objDoc.SelectNodes("rss/channel/image");
            if (null != objNL)
            {
                objNL = objDoc.SelectNodes("rss/channel/image/url");
                if (objNL.Count != 0)
                    imagePath = objNL[0].InnerText;
                else
                    imagePath = "";
            }
            #endregion

            #region content to be generated from RSS feed
            int total_Items = 0;
            if (null != objDoc)
            {
                objNL = objDoc.SelectNodes("rss/channel/item");
                if (null != objNL)
                {
                    int counter = 1;
                    string description = "";

                    total_Items = objNL.Count;
                    foreach (XmlNode XNode in objNL)
                    {
                        if (counter == item_No)
                        {
                            ItemTitle = "";
                            description = "";
                            ItemLink = "";

                            foreach (XmlNode XNodeNested in XNode.ChildNodes)
                            {
                                switch (XNodeNested.Name)
                                {
                                    case "description":
                                        description = XNodeNested.InnerText;
                                        break;
                                    case "title":
                                        ItemTitle = XNodeNested.InnerText;
                                        break;
                                    case "link":
                                        ItemLink = XNodeNested.InnerText;
                                        break;
                                }
                            }
                            break;
                        }
                        counter++;
                    }
                    str.Append(description);
                }
            }
            #endregion

            #region setting view's content variables
            ViewData["detail"] = str.ToString();
            ViewData["imagePath"] = imagePath;
            ViewData["title"] = title;
            #endregion

            return View("ItemDetail");
        }


        public ActionResult Portal()
        {
            ViewData["feedsLinkText"] = "Disable Feeds";
            ViewData["feedsActionName"] = "UnActivePortlets";
            ViewData["refreshActionName"] = "Portal";
            return View("Portal");
        }

        public ActionResult Shendetesia()
        {
            return View();
        }
       
        public ActionResult UnActivePortlets()
        {
            ViewData["feedsLinkText"] = "Active Feeds";
            ViewData["feedsActionName"] = "Portal";
            ViewData["refreshActionName"] = "UnActivePortlets";
            return View("UnActivePortlets");
        }
     
        public ActionResult Dokumente()
        {
           
            return View();
        }

     
      
        public ActionResult Kalendari()
        {

            return View();
        }
      
        /// <summary>
        /// manage's customed portlet adjustment 
        /// </summary>
        /// <param name="column_ID">portlet column id</param>
        /// <param name="portlet_ID">portlet id</param>
        /// <param name="row_No">row no in particular portlet column</param>
        /// <param name="is_Drop">change in portlet category show 1 else 0</param>
        public ActionResult PortletsPlacementManager(string column_ID, string portlet_ID,int? row_No,int? is_Drop)
        {
            // invalid portlet id
            if (column_ID == null || portlet_ID == null || row_No == null || is_Drop == null)
                return View("ErrorPortalItem");

            #region declaration
            int _portlet_ID = Convert.ToInt32(portlet_ID.ToString().Replace("portlet", ""));
            int category_ID = Convert.ToInt32(column_ID.Replace("portletColumn", "").Substring(1));
            int column_No = Convert.ToInt32(column_ID.Replace("portletColumn", "").Substring(0, 1));

            WebApplication.Models.ds _ds = (WebApplication.Models.ds)Session["data"];

            string filter = " portlet_ID = " + _portlet_ID.ToString();
            DataRow[] rows = _ds.Portlet_User.Select(  filter );
            #endregion

            #region portlet placement 
            if (rows.Length == 1)
            {
                rows[0]["Category_ID"] = category_ID;
                rows[0]["Column_No"] = column_No;
                rows[0]["Row_Sequence"] = Convert.ToInt32( row_No );
                
                filter = " portlet_ID = " + _portlet_ID.ToString() + " and category_ID =" + category_ID.ToString() +
                    " and column_No = " + column_No.ToString() + " and Row_Sequence > " + row_No.ToString();
                DataRow[] tempRows = _ds.Portlet_User.Select(filter);

                if (is_Drop == 0)
                {
                    int subsequent_Row_No = Convert.ToInt32(row_No) + 1;
                    foreach (DataRow row in tempRows)
                    {
                        row["Row_No"] = subsequent_Row_No;
                        subsequent_Row_No++;
                    }
                }
                else
                {
                    rows[0]["Row_Sequence"] = tempRows.Length + 1;
                }
            }

            _ds.AcceptChanges();
            Session["data"] = _ds;
            #endregion

            return View("ErrorPortalItem");
        }


        /// <summary>
        /// manage's customed portlet adjustment 
        /// </summary>
        /// <param name="column_ID">portlet column id</param>
        /// <param name="portlet_ID">portlet id</param>
        /// <param name="row_No">row no in particular portlet column</param>
        /// <param name="is_Drop">change in portlet category show 1 else 0</param>
        public ActionResult PortletsStatusManager(string portlet_ID,bool is_Active)
        {
            // invalid portlet id
            if ( portlet_ID == null )
                return View("ErrorPortalItem");

            #region declaration
            int _portlet_ID = Convert.ToInt32(portlet_ID.ToString().Replace("portlet", ""));
         
            WebApplication.Models.ds _ds = (WebApplication.Models.ds)Session["data"];

            string filter = " portlet_ID = " + _portlet_ID.ToString();
            DataRow[] rows = _ds.Portlet_User.Select(filter);
            #endregion

            #region portlet placement
            if (rows.Length == 1)
            {
                rows[0]["Is_Active"] = is_Active;
            }

            _ds.AcceptChanges();
            Session["data"] = _ds;
            #endregion

            return View("ErrorPortalItem");
        }


        /// <summary>
        /// return's total number portlet in particular category
        /// </summary>
        /// <param name="category_ID">portlet category id</param>
        /// <param name="is_Active">portlet is_Active</param>
        public ContentResult TotalCatetogoryPortlets(string category_ID,bool is_Active)
        {
            int _category_ID = Convert.ToInt32(category_ID.Replace("portletColumn", "").Substring(1));
            string filter = " Is_Active = " + is_Active.ToString() + " and Category_ID = " + _category_ID.ToString();
            string category = ((WebApplication.Models.ds)this.HttpContext.Application["data"]).Category.FindByCategory_ID(_category_ID).Category;
            int total_Category_Protlets = ((WebApplication.Models.ds)Session["data"]).Portlet_User.Select(filter).Length;
            return Content( category + " ( " + total_Category_Protlets.ToString() + " )" );
        }

        /// <summary>
        /// return's total number portlet 
        /// </summary>
        public ContentResult TotalPortlets(bool is_Active)
        {
            string filter = " Is_Active = " + is_Active.ToString();
            int total_Category_Protlets = ((WebApplication.Models.ds)Session["data"]).Portlet_User.Select(filter).Length;
            return Content(total_Category_Protlets.ToString());
        }


    }
}
